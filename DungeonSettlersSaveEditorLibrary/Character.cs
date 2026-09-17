using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace DungeonSettlersSaveEditorLibrary
{
    public class Character
    {
        public string guid;
        public string name;
        private JsonNode? SkillTree;
        private JsonNode? LearnedSkills;
        private JsonNode? EntityComponents;
        private JsonNode? AffecterHolders;
        private JsonArray? EntityComponentsArray;


        public Character(string guid)
        {
            this.guid = guid;
            getTrees();
            this.name = getName();
        }

        private void getTrees()
        {
            SkillTree = Save.saveJson["PlayerUnitsSaveData"]!["SkillTrees"]![guid]!["SkillTrees"]!;
            LearnedSkills = Save.saveJson["PlayerUnitsSaveData"]!["SkillTrees"]![guid]!["LearnedSkills"]!;
            EntityComponents = Save.saveJson["EntityComponentSaveData"]!["EntityComponents"]![guid]!;

            // TODO: Make a bit more elegant, this is fragile.
            AffecterHolders = EntityComponents[2]![1]![1]!;
            EntityComponentsArray = Save.saveJson["EntityComponentSaveData"]!["EntityComponents"]![guid].AsArray()!;
        }

        private string getName()
        {
            JsonNode? personalData = EntityComponentsArray.FirstOrDefault(x => x?["Type"]?.GetValue<int>() == 10);

            string unitName = personalData["Data"]!["UnitNameTextKey"].GetValue<string>();
            string unitDefaultName = personalData["Data"]!["DefaultUnitNameTextKey"].GetValue<string>();

            if (unitName == unitDefaultName)
            {
                Dictionary<string, string> TextKeyNames = TableReader.getTextKeyNames();
                return TextKeyNames[unitName];
            }
            else
            {
                return unitName;
            }
        }

        public void addSkill(string type, string key)
        {
            // Add the skill to the tree
            JsonArray? skillTree = SkillTree[type]!.AsArray();
            skillTree.Add(key);

            // Add an empty array for learned skills to prevent a null reference exception.

            LearnedSkills.AsObject().Add(key, new JsonArray());
        }

        public void removeSkill(string type, string skill)
        {
            // Remove the skill from the tree
            JsonArray? skillTree = SkillTree[type]!.AsArray()!;

            // Find the node in the array and yeet it.
            JsonNode? skillToDelete = skillTree.FirstOrDefault(
                node => node?.GetValue<string>() == skill
            );
            skillTree.Remove(skillToDelete);

            // Delete learned skills
            // TODO: Preserve skill points spent in the tree.
            LearnedSkills.AsObject().Remove(skill);
        }

        public void addInscription(Inscription inscription)
        {
            switch (inscription.type)
            {
                case InscriptionType.NormalInscription:
                    addInscriptionDefaultSteps(inscription);
                    break;

                case InscriptionType.SkillInscription:
                    addSkillInscription(inscription);
                    addInscriptionDefaultSteps(inscription);
                    break;
            }
        }

        public void addSkillInscription(Inscription inscription)
        {
            // Determine skill
            string skill = inscription.skillData["skill"];
            string skillType = inscription.skillData["skillType"];

            // add skill1
            addSkill(skillType, skill);

            // add skill points
            addSkillPoints(skillType, 5);
        }


        public void addInscriptionDefaultSteps(Inscription inscription)
        {
            // Create Json object for the new inscription
            JsonObject inscriptionJson = new JsonObject
            {
                ["Key"] = inscription.inscriptionId,
                ["Stack"] = 1,
                ["Duration"] = 0.0,
                ["InitialDuration"] = 0.0
            };

            // Inject it
            AffecterHolders.AsArray().Add(inscriptionJson);
        }

        public void removeInscription(Inscription inscription)
        {
            switch (inscription.type)
            {
                case InscriptionType.NormalInscription:
                    removeInscriptionDefaultSteps(inscription);
                    break;

                case InscriptionType.SkillInscription:
                    removeSkillInscription(inscription);
                    removeInscriptionDefaultSteps(inscription);
                    break;
            }
        }

        public void removeSkillInscription(Inscription inscription)
        {
            // Determine skill
            string skillType = inscription.skillData["skillType"];
            string skill = inscription.skillData["skill"];

            removeSkill(skillType, skill);

            // remove skill points
            addSkillPoints(skillType, -5);
        }


        public void removeInscriptionDefaultSteps(Inscription inscription)
        {
            var inscriptionToBeDeleted = AffecterHolders.AsArray().FirstOrDefault(x => x?["Key"]?.GetValue<string>() == inscription.inscriptionId);
            AffecterHolders.AsArray().Remove(inscriptionToBeDeleted);

        }
        public List<string> getCurrentInscriptions()
        {
            List<string> currentInscriptions = new List<string>();

            var inscriptionJsonNodes = AffecterHolders.AsArray().Where(x => x?["Key"]?.GetValue<string>().Contains("Inscription") == true).ToList();
            foreach (JsonNode node in inscriptionJsonNodes)
            {
                string inscriptionName = node["Key"].GetValue<string>();
                currentInscriptions.Add(inscriptionName);
            }
            return currentInscriptions;
        }

        public void addSkillPoints(string type, int added)
        {
            JsonNode? progressionStats = EntityComponentsArray.FirstOrDefault(x => x?["Type"]?.GetValue<int>() == 0);
            string skillCounterName = type + "SkillPoint";

            var skillPoints = progressionStats["Data"]["ProgressionStats"][skillCounterName].GetValue<float>();
            skillPoints = skillPoints + added;
            progressionStats["Data"]["ProgressionStats"][skillCounterName] = skillPoints;
        }
    }
}

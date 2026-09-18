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

        private JsonNode? progressionStats;

        private JsonNode? permanentStats;

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

            progressionStats = EntityComponentsArray.FirstOrDefault(x => x?["Type"]?.GetValue<int>() == 0)["Data"]["ProgressionStats"];
            permanentStats = EntityComponentsArray.FirstOrDefault(x => x?["Type"]?.GetValue<int>() == 0)["Data"]["PermanentStats"];
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

        public List<string> getCurrentSkillsOfType(string type)
        {
            List<string> skillList = new List<string>();
            JsonArray? skillTree = SkillTree[type]!.AsArray();
            foreach (var skillTreeItem in skillTree)
            {
                string skillName = skillTreeItem.GetValue<string>();
                skillList.Add(skillName);
            }
            return skillList;
        }

        public void addSkill(string type, string skill)
        {

            
            // Add the skill to the tree
            JsonArray? skillTree = SkillTree[type]!.AsArray();

            JsonNode? skillToAdd = skillTree.FirstOrDefault(
                     node => node?.GetValue<string>() == skill
             );

            if (skillToAdd == null)
            {
                skillTree.Add(skill);
            }

            // Add an empty array for learned skills to prevent a null reference exception.
            if (!LearnedSkills.AsObject().ContainsKey(skill))
            {
                LearnedSkills.AsObject().Add(skill, new JsonArray());
            }
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
            // Check if the inscription is already present
            List<string> currentInscriptions = getCurrentInscriptions();
            if (!currentInscriptions.Contains(inscription.inscriptionId))
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
            else
            {
                // Do nothing or tell the user it's already present
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
            string skillCounterName = type + "SkillPoint";

            //var skillPoints = progressionStats["Data"]["ProgressionStats"][skillCounterName].GetValue<float>();
            var skillPoints = progressionStats[skillCounterName].GetValue<float>();
            skillPoints = skillPoints + added;
            progressionStats[skillCounterName] = skillPoints;
        }

        public Dictionary<string, float> getTalentLevels()
        {
            Dictionary<string, float> talentLevels = new Dictionary<string, float>();

            talentLevels.Add("TalentStrength", (float)progressionStats["TalentStrength"]);
            talentLevels.Add("TalentConstitution", (float)progressionStats["TalentConstitution"]);
            talentLevels.Add("TalentWillPower", (float)progressionStats["TalentWillPower"]);
            talentLevels.Add("TalentIntelligence", (float)progressionStats["TalentIntelligence"]);
            talentLevels.Add("TalentAgility", (float)progressionStats["TalentAgility"]);
            talentLevels.Add("TalentPerception", (float)progressionStats["TalentPerception"]);
            return talentLevels;
        }

        public void changeTalentLevel(string statName, float newValue)
        {
            if (newValue >= -1.0f && newValue <= 3.0f)
            {
                changeProgressionStat(statName, newValue);
            }
            else
            { 
                //nonsense value
            }
        }

        public Dictionary<string, float> getPermanentStats()
        {
            Dictionary<string, float> permanentStatsDictionary = new Dictionary<string, float>();

            string[] statNames = { "Strength", "Constitution", "WillPower", "Intelligence", "Agility", "Perception" };
            foreach (string statName in statNames)
            {
                if (permanentStats.AsObject().ContainsKey(statName))
                {
                    permanentStatsDictionary.Add(statName, (float)permanentStats[statName]);
                }
                else
                {
                    permanentStatsDictionary.Add(statName, 0.0f);
                }
            }
            return permanentStatsDictionary;
        }

        public void changePermanentStats(string statName, float newValue)
        {

            permanentStats[statName] = newValue;
        }

        public void changeProgressionStat(string statName, float newValue)
        {

            progressionStats[statName] = newValue;
        }
    }
}

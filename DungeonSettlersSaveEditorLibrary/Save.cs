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
    public class Save
    {
        //private string modifiedSavePath = "C:\\Users\\Bert\\AppData\\LocalLow\\CanOpener\\Dungeon Settlers\\Saves\\LyraGreatswordBugEdited.json";
        private string orignalSavePath;

        private string newName;
        public static JsonNode saveJson;
        public Dictionary<string, Character> characterDictionary;
        //public List<Character> characters;

        //public static Save save;

        public Save(string orignalSavePath, string newName)
        {
            this.orignalSavePath = orignalSavePath;
            this.newName = newName;

            // Read the file
            string jsonText = File.ReadAllText(orignalSavePath);
            saveJson = JsonNode.Parse(jsonText);
            characterDictionary = new Dictionary<string, Character>();

            // Load Characters
            getCharacters();
        }

        /// <summary>
        /// For the GUI
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, string> getCharacterGuids()
        {
            Dictionary<string, string> characterGuids = new Dictionary<string, string>();
            foreach (KeyValuePair<string,Character> character in characterDictionary)
            {
                characterGuids.Add(character.Value.guid, character.Value.name);
            }
            return characterGuids;
        }

        private void renameSave()
        {
            // Rename the modified save in a way that shows up in game.
            JsonNode campaignSaveHeader = saveJson["CampaignSaveHeader"]!;
            campaignSaveHeader["DisplayName"] = newName;
        }

        public void writeSaveFile()
        {
            renameSave();

            // Use the Path of the orignal save but the new name when saving.
            string dir = Path.GetDirectoryName(orignalSavePath);
            string modifiedSavePath = dir + "/" + newName + ".json";

            File.WriteAllText(modifiedSavePath, saveJson.ToJsonString());
        }

        public void getCharacters()
        {
             JsonArray playerGUIDsBase = saveJson["EntityContainerSaveData"]!["UnitContainerSaveData"]!["Base"]!["PlayerGuidList"]!.AsArray();
             JsonArray playerGUIDsDungeon = saveJson["EntityContainerSaveData"]!["UnitContainerSaveData"]!["Dungeon"]!["PlayerGuidList"]!.AsArray();
             JsonNode skillTree = saveJson["PlayerUnitsSaveData"]!;
          
            // Collect all characters.
            foreach (var item in playerGUIDsBase)
            {
                characterDictionary.Add(item.ToString(),new Character(item.ToString()));
            }
            foreach (var item in playerGUIDsDungeon)
            {
                characterDictionary.Add(item.ToString(), new Character(item.ToString()));
            }

            //JsonNode? playerGUIDsDungeon = save["EntityContainerSaveData"]!["UnitContainerSaveData"]!["Dungeon"]!["PlayerGuidList"]!;
        }

        public void addInscriptionToCharacter(string guid, string inscriptionId)
        {
            Character characterToEdit = characterDictionary[guid];
            Inscription inscription = TableReader.getInscriptionList()[inscriptionId];

            characterToEdit.addInscription(inscription);
        }

        public void removeInscriptionToCharacter(string guid, string inscriptionId)
        {
            Character characterToEdit = characterDictionary[guid];
            Inscription inscription = TableReader.getInscriptionList()[inscriptionId];

            characterToEdit.removeInscription(inscription);
        }

        public List<string> getCurrentInscriptionsFromCharacter(string guid)
        {
            Character characterToRead = characterDictionary[guid];
            return characterToRead.getCurrentInscriptions();
        }

        public Dictionary<string, float> getTalentLevels(string guid)
        {
            Character characterToRead = characterDictionary[guid];
            return characterToRead.getTalentLevels();
        }

        public void changeCharacterTalentLevel(string guid, string talentKey, float newValue)
        {
            Character characterToEdit = characterDictionary[guid];
            characterToEdit.changeTalentLevel(talentKey, newValue);
        }

        public Dictionary<string, float> getCharacterPermanentStats(string guid)
        {
            Character characterToRead = characterDictionary[guid];
            return characterToRead.getPermanentStats();
        }

        public void changeCharacterPermanentStats(string guid, string valueKey, float newValue)
        {
            Character characterToEdit = characterDictionary[guid];
            characterToEdit.changePermanentStats(valueKey, newValue);
        }

        public List<string> getCharacterCurrentSkillsOfType(string guid, string type)
        {
            Character characterToRead = characterDictionary[guid];
            return characterToRead.getCurrentSkillsOfType(type);
        }

        public void giveCharacterSkillOfType(string guid, string skillName, string type)
        {
            Character characterToEdit = characterDictionary[guid];
            characterToEdit.addSkill(type, skillName);
        }

        public void removeCharacterSkillOfType(string guid, string skillName, string type)
        {
            Character characterToEdit = characterDictionary[guid];
            characterToEdit.removeSkill(type, skillName);
        }
    }
}

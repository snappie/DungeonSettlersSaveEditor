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
            //characters = new List<Character>();
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
    }
}

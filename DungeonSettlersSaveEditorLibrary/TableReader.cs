using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace DungeonSettlersSaveEditorLibrary
{

    /// <summary>
    /// A class that reads JSOn tables containing game data.
    /// This class is not read anything from saves
    /// </summary>
    public static class TableReader
    {
        private static Dictionary<string, string> inscriptionKeyNamePairList;
        private static List<JsonNode> inscriptionNodeList;

        private static Dictionary<string, Inscription> inscriptionList;

        // Do you want a dicionary with your dictionary?
        private static Dictionary<string, Dictionary<string, string>> skillInscriptionNameList;

        private static Dictionary<string, Skill> skillList;

        private static Dictionary<string, string> TextKeyNames;


        //public static List<string> GetInscriptionKeyList() { 
        //    if (inscriptionKeyList == null)
        //    {
        //        string tablePath = Environment.CurrentDirectory + @"/Data/TraitTable.json";
        //        string tableJson = File.ReadAllText(tablePath);
        //
        //        // Read all the inscriptions from AffecterTable.json
        //        // I only need the names for now but like to keep the data handy.
        //        JsonArray data = JsonNode.Parse(tableJson)!.AsArray();
        //        inscriptionNodeList = data
        //            .Where(x => x?["TypeName"]?.GetValue<string>() == "Inscription")
        //            .ToList();
        //
        //        inscriptionKeyList = new List<string>();
        //        foreach (var inscription in inscriptionNodeList)
        //        {
        //            // Gather data
        //            string inscriptionName = inscription["Key"].GetValue<string>();
        //            
        //            // For the gui and because I'm lazy.
        //            inscriptionKeyList.Add(inscriptionName);
        //        }
        //
        //    }
        //    return inscriptionKeyList;
        //}
        public static Dictionary<string, string> GetInscriptionKeyList()
        {
            if (inscriptionKeyNamePairList == null)
            {
                inscriptionKeyNamePairList = new Dictionary<string, string>();
                getInscriptionList();

                foreach (KeyValuePair<string, Inscription> item in inscriptionList)
                {
                    string key = item.Key;
                    string name = item.Value.name;

                    inscriptionKeyNamePairList.Add(key, name);
                }               
            }
            return inscriptionKeyNamePairList;
        }


        /// <summary>
        /// I can't find a good way to link Skill Inscriptions to their skills so I have do make my own json for it.
        /// 
        /// Getting a list of the skillInscriptions themselves wasn't great either
        /// Especially the ["Key"] == ["DevComment3"] is really shaky but it's the only way I found to detect them reliably.
        /// 
        /// I'm currently running ths every startup because f it.
        /// 
        /// This skill list also completely independent of getSkillList() so some mismatches may occur
        /// </summary>
        public static void createSkillInscriptionPairJson()
        {
            string writeJsonPath = Environment.CurrentDirectory + @"/Data/SkillInscriptionsTable.json";
            string tablePath = Environment.CurrentDirectory + @"/Data/TraitTable.json";
            string tableJson = File.ReadAllText(tablePath);

            JsonArray data = JsonNode.Parse(tableJson)!.AsArray();
            JsonArray inscriptionData = new JsonArray(data
                .Where(x => x?["TypeName"]?.GetValue<string>() == "Inscription" && x?["Key"]?.GetValue<string>() == x?["DevComment3"]?.GetValue<string>())
                .Select(x => 
                {
                    string? skill = x?["Key"]?.GetValue<string>();
                    // Remove "AFFECTER_" and "Inscription"
                    skill = skill.Substring(9, skill.Length-20);

                    // TODO: Find a better way to do this
                    if (skill is "Fire" or "Water" or "Nature")
                        skill += "Magic";

                    // Currently, all "rare" rarity skill inscriptions are sub skills, and "uncommon" ones are main skills.
                    JsonObject result = new JsonObject
                    {
                        ["Key"] = x?["Key"]?.GetValue<string>(),
                        ["Skill"] = skill,
                        ["SkillType"] = x?["Rarity"]?.GetValue<int>() switch
                        {
                            1 => "Main",
                            2 => "Sub",
                            _ => "Unknown"
                        },
                        ["Rarity"] = x?["Rarity"]?.GetValue<int>(),
                        ["TypeName"] = x?["TypeName"]?.GetValue<string>()
                    };
                    return result;

                }).ToArray()
                );

            var options = new JsonSerializerOptions { WriteIndented = true};
            
            File.WriteAllText(
                writeJsonPath,
                System.Text.Json.JsonSerializer.Serialize(inscriptionData, options)
            );
        }

        /// <summary>
        /// I'm generating the skill list by checking what skills are mentioned in backgrounds.
        /// I don't have a json file that contains them in an easily retrieveable list.
        /// If one day a skill is added that isn't part of a background, then it won't show up here.
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, Skill> getSkillList()
        {
            if (skillList == null)
            {
                skillList = new Dictionary<string, Skill>();   

                string tablePath = Environment.CurrentDirectory + @"/Data/TraitTable.json";
                string tableJson = File.ReadAllText(tablePath);
                JsonArray traitTable = JsonNode.Parse(tableJson)!.AsArray();

                List<JsonObject> backgrounds = traitTable
                    .OfType<JsonObject>()
                    .Where(x => x["TypeName"]?.GetValue<string>() == "Background")
                    .ToList();

                foreach (JsonObject background in backgrounds)
                {
                    processSkillTree(background, "AvaliableMainSkillTreeTypes", "Main");
                    processSkillTree(background, "AvaliableSubSkillTreeTypes", "Sub");
                }
            }
            return skillList;
        }

        /// <summary>
        /// because I don't want the classes in the Forms
        /// </summary>
        /// <returns></returns>
        public static List<string> getSkillNameListOfType(string type)
        {
            getSkillList();
            List<string> skillNameList = new List<string>();
            foreach (KeyValuePair<string, Skill> skill in skillList)
            {
                if (skill.Value.type == type)
                skillNameList.Add(skill.Key);
            }
            return skillNameList;
        }
        private static void processSkillTree(JsonObject background, string skillTreeName, string type)
        {
            if (background.ContainsKey(skillTreeName))
            {
                JsonArray? skillListJson = background[skillTreeName]?.AsArray();
                foreach (JsonNode? skill in skillListJson)
                {
                    string skillName = skill!.GetValue<string>();
                    if (skillName == "NULL")
                        continue;
                    if (!skillList.ContainsKey(skillName))
                    {
                        Skill newSkill = new Skill(skillName, type);
                        skillList.Add(skillName, newSkill);
                    }
                }
            }
        }

        public static Dictionary<string, Dictionary<string, string>> getSkillInscriptionNameList()
        {
            TableReader.createSkillInscriptionPairJson();
            if (skillInscriptionNameList == null)
            {
                skillInscriptionNameList = new Dictionary<string, Dictionary<string, string>>();

                string tablePath = Environment.CurrentDirectory + @"/Data/SkillInscriptionsTable.json";
                string tableJson = File.ReadAllText(tablePath);

                JsonArray data = JsonNode.Parse(tableJson)!.AsArray();
                foreach (JsonObject inscription in data)
                {
                    string key = inscription["Key"].GetValue<string>();
                    string skill = inscription["Skill"].GetValue<string>();
                    string skillType = inscription["SkillType"].GetValue<string>();
                    int rarity = inscription["Rarity"].GetValue<int>();
                    
                    Dictionary<string, string> keyPairs = new Dictionary<string, string>();
                    keyPairs.Add("key", key);
                    keyPairs.Add("skill", skill);
                    keyPairs.Add("skillType", skillType);
                    keyPairs.Add("rarity", rarity.ToString());

                    skillInscriptionNameList.Add(key, keyPairs);
                }
            }

            return skillInscriptionNameList;
        }

        public static Dictionary<string, Inscription> getInscriptionList()
        {
            if (inscriptionList == null)
            {
                string tablePath = Environment.CurrentDirectory + @"/Data/TraitTable.json";
                string tableJson = File.ReadAllText(tablePath);

                JsonArray data = JsonNode.Parse(tableJson)!.AsArray();
                inscriptionNodeList = data
                    .Where(x => x?["Key"]?.GetValue<string>().Contains("Inscription") == true)
                    .ToList();

                inscriptionList = new Dictionary<string, Inscription>();
                foreach (var inscription in inscriptionNodeList)
                {
                    // Gather data
                    string inscriptionId = inscription["Key"].GetValue<string>();
                    int rarity = inscription["Rarity"].GetValue<int>();

                    // For easy of use
                    Inscription generatedInscription = new Inscription(inscriptionId, rarity);
                    inscriptionList.Add(inscriptionId, generatedInscription);
                }

            }
            return inscriptionList;
        }

        public static Dictionary<string, string> getTextKeyNames()
        {
            if (TextKeyNames == null)
            {
                string tablePath = Environment.CurrentDirectory + @"/Data/TextKeyTable_en.json";
                string tableJson = File.ReadAllText(tablePath);

                TextKeyNames = JsonConvert.DeserializeObject<Dictionary<string, string>>(tableJson);
                //JsonArray data = JsonNode.Parse(tableJson)!.AsArray();
            }
            return TextKeyNames;
        }
    }
}

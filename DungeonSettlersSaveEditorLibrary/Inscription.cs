using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Nodes;

namespace DungeonSettlersSaveEditorLibrary
{
    public class Inscription
    {
        public string inscriptionId;
        public InscriptionType type;
        public string name;
        public int rarity;

        /// <summary>
        /// This is ONLY used for special cases.
        /// </summary>
        public Dictionary<string, string> skillData;

        public Inscription(string inscriptionId, int rarity)
        {
            this.inscriptionId  = inscriptionId;
            this.rarity = rarity;
            this.name = getName();
            determineType();
        }

        private string getName()
        {
            // The inscriptions have predictable TEXTKEY names
            // string inscriptionId = "AFFECTER_LowGradeGuardChanceInscription"
            // string textKey = $"TEXTKEY_{inscriptionId}_NAME";
            //
            // TEXTKEY_AFFECTER_LowGradeGuardChanceInscription_NAME

            string textKey = $"TEXTKEY_{inscriptionId}_NAME";

            Dictionary<string, string> TextKeyNames = TableReader.getTextKeyNames();
            return TextKeyNames[textKey];
        }
        private void determineType()
        {
            // Null if not a special case:
            if (TableReader.getSkillInscriptionNameList().ContainsKey(inscriptionId))
            {
                // It's a skill inscription!
                this.type = InscriptionType.SkillInscription;
                skillData = TableReader.getSkillInscriptionNameList()[inscriptionId];

            }
            else
            {
                // Aninscryption that doesn't require additional actions.
                this.type = InscriptionType.NormalInscription;
            }
            
        }
    }
}

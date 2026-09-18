using DungeonSettlersSaveEditorLibrary;
using System.Net;

namespace DungeonSettlersSaveEditor
{
    public partial class MainForm : Form
    {


        private Dictionary<string, string> affecters;

        private List<string> mainSkillList;
        private List<string> subSkillList;
        private Dictionary<string, string> characterGuids;
        private Dictionary<string, string> currentInscriptionsForIndex;

        private Dictionary<string, float> currentTalentLevels = new Dictionary<string, float>();

        private Dictionary<string, float> currentPermanentStats = new Dictionary<string, float>();

        private List<string> currentMainSkills = new List<string>();
        private List<string> currentSubSkills = new List<string>();
        private string selectedCharacterGuid;
        private string selectedInscriptionId;


        private Save save;

        public MainForm()
        {
            InitializeComponent();

        }

        private void loadSave(string filePath)
        {
            // Clear previous data
            CharacterGuidList.Items.Clear();
            CurrentInscriptionsList.Items.Clear();
            ListBoxCurrentCharacterMainSkills.Items.Clear();
            ListBoxCurrentCharacterSubSkills.Items.Clear();

            selectedCharacterGuid = null;
            currentTalentLevels = new Dictionary<string, float>();
            currentPermanentStats = new Dictionary<string, float>();
            currentMainSkills = new List<string>();
            currentSubSkills = new List<string>();

            string newSaveName = Path.GetFileName(filePath);
            newSaveName = newSaveName.Substring(0, newSaveName.Length - 5) + "_Edited";
            TextBoxNewSaveName.Text = newSaveName;
            save = new Save(filePath, newSaveName);

            characterGuids = save.getCharacterGuids();
            foreach (KeyValuePair<string, string> characterGuid in characterGuids)
            {
                CharacterGuidList.Items.Add(characterGuid.Value);
            }
        }

        private void loadDataFromTables()
        {
            // Initialive save unrelated data
            TableReader.getSkillInscriptionNameList();
            TableReader.getInscriptionList();

            affecters = TableReader.GetInscriptionKeyList();
            mainSkillList = TableReader.getSkillNameListOfType("Main");
            subSkillList = TableReader.getSkillNameListOfType("Sub");

            foreach (KeyValuePair<string, string> inscription in affecters)
            {
                InscriptionList.Items.Add(inscription.Value);
            }

            foreach (string skill in mainSkillList)
            {
                ListBoxMainSkillNames.Items.Add(skill);
            }
            foreach (string skill in subSkillList)
            {
                ListBoxSubSkillNames.Items.Add(skill);
            }

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            CurrentInscriptionsCharacterName.Text = "";

            loadDataFromTables();
            CharacterGuidList.Items.Clear();

            // TODO: Not implemented yet so made invisbile
            numericUpDownMainSkills.Visible = false;
            numericUpDownSubSkills.Visible = false;
        }


        private void CharacterGuidList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedCharacterIndex = CharacterGuidList.SelectedIndex;
            if (selectedCharacterIndex >= 0)
            {
                selectedCharacterGuid = characterGuids.ElementAt(selectedCharacterIndex).Key;
                getCurrentInscriptions();
                getCurrentTalentLevels();
                getCurrentPermanentStats();
                getCurrentSkills();
            }
            else
            {
                // // Negative selectedCharacterIndex
            }
        }

        #region Skill Controls

        private void getCurrentSkills()
        {
            if (selectedCharacterGuid != null)
            {
                ListBoxCurrentCharacterMainSkills.Items.Clear();
                ListBoxCurrentCharacterSubSkills.Items.Clear();

                currentMainSkills = save.getCharacterCurrentSkillsOfType(selectedCharacterGuid, "Main");
                currentSubSkills = save.getCharacterCurrentSkillsOfType(selectedCharacterGuid, "Sub");

                foreach (string mainSkill in currentMainSkills)
                {
                    ListBoxCurrentCharacterMainSkills.Items.Add(mainSkill);
                }

                foreach (string subSkill in currentSubSkills)
                {
                    ListBoxCurrentCharacterSubSkills.Items.Add(subSkill);
                }
            }
        }

        private void addSkill(string skillName, string type)
        {
            if (selectedCharacterGuid != null)
            {
                save.giveCharacterSkillOfType(selectedCharacterGuid, skillName, type);
            }
            getCurrentSkills();
        }

        private void removeSkill(string skillName, string type)
        {
            if (selectedCharacterGuid != null)
            {
                save.removeCharacterSkillOfType(selectedCharacterGuid, skillName, type);
            }
            getCurrentSkills();
        }

        private void ButtonAddMainSkill_Click(object sender, EventArgs e)
        {
            if (ListBoxMainSkillNames.SelectedIndex != -1)
            {
                string selectedSkill = mainSkillList.ElementAt(ListBoxMainSkillNames.SelectedIndex);
                addSkill(selectedSkill, "Main");
            }
        }

        private void ButtonRemoveMainSkill_Click(object sender, EventArgs e)
        {
            if (ListBoxCurrentCharacterMainSkills.SelectedIndex != -1)
            {
                string selectedSkill = mainSkillList.ElementAt(ListBoxCurrentCharacterMainSkills.SelectedIndex);
                removeSkill(selectedSkill ,"Main");
            }
        }

        private void ButtonAddSubSkill_Click(object sender, EventArgs e)
        {
            if (ListBoxSubSkillNames.SelectedIndex != -1)
            {
                string selectedSkill = subSkillList.ElementAt(ListBoxSubSkillNames.SelectedIndex);
                addSkill(selectedSkill, "Sub");
            }
        }

        private void ButtonRemoveSubSkill_Click(object sender, EventArgs e)
        {
            if (ListBoxCurrentCharacterSubSkills.SelectedIndex != -1)
            {
                string selectedSkill = subSkillList.ElementAt(ListBoxCurrentCharacterSubSkills.SelectedIndex);
                removeSkill(selectedSkill, "Sub");
            }
        }


        #endregion

        #region Inscription Controls

        private void getCurrentInscriptions()
        {
            CurrentInscriptionsList.Items.Clear();

            List<string> currentInscriptions = save.getCurrentInscriptionsFromCharacter(selectedCharacterGuid);
            affecters = TableReader.GetInscriptionKeyList();
            currentInscriptionsForIndex = new Dictionary<string, string>();

            foreach (string inscriptionKey in currentInscriptions)
            {
                string inscriptionName = affecters[inscriptionKey];
                CurrentInscriptionsList.Items.Add(inscriptionName);

                currentInscriptionsForIndex.Add(inscriptionKey, inscriptionName);
            }
        }

        private void ButtonAddInscription_Click(object sender, EventArgs e)
        {

            if (selectedCharacterGuid != null && selectedInscriptionId != null)
            {
                save.addInscriptionToCharacter(selectedCharacterGuid, selectedInscriptionId);
                getCurrentInscriptions();
            }
        }

        private void ButtonRemoveInscription_Click(object sender, EventArgs e)
        {

            int selectedInscriptionIndex = CurrentInscriptionsList.SelectedIndex;
            if (selectedInscriptionIndex >= 0)
            {
                string selectedInscriptionId = currentInscriptionsForIndex.ElementAt(selectedInscriptionIndex).Key;

                save.removeInscriptionToCharacter(selectedCharacterGuid, selectedInscriptionId);
                getCurrentInscriptions();
            }
            else
            {
                // No inscription selected.
            }

        }


        private void InscriptionList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedInscriptionIndex = InscriptionList.SelectedIndex;
            if (selectedInscriptionIndex >= 0)
            {
                selectedInscriptionId = affecters.ElementAt(selectedInscriptionIndex).Key;
            }
        }

        #endregion


        #region save/load

        private void ButtonSaveChanges_Click(object sender, EventArgs e)
        {
            save.writeSaveFile();
        }

        private void ButtonLoadSave_Click(object sender, EventArgs e)
        {
            string filePath = string.Empty;
            string defaultDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\AppData\LocalLow\CanOpener\Dungeon Settlers\Saves";

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = defaultDirectory;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;
                    loadSave(filePath);
                }
            }
        }

        #endregion





        private void getCurrentPermanentStats()
        {
            if (selectedCharacterGuid != null)
            {
                currentPermanentStats = save.getCharacterPermanentStats(selectedCharacterGuid);
                numericUpDownStrengthPermanentStats.Value = (decimal)currentPermanentStats["Strength"];
                numericUpDownConstitutionPermanentStats.Value = (decimal)currentPermanentStats["Constitution"];
                numericUpDownWillPowerPermanentStats.Value = (decimal)currentPermanentStats["WillPower"];
                numericUpDownIntelligencePermanentStats.Value = (decimal)currentPermanentStats["Intelligence"];
                numericUpDownAgilityPermanentStats.Value = (decimal)currentPermanentStats["Agility"];
                numericUpDownPerceptionPermanentStats.Value = (decimal)currentPermanentStats["Perception"];
            }
        }

        private void changePermanentStats(string statKey, float newValue)
        {
            if (selectedCharacterGuid != null)
            {
                save.changeCharacterPermanentStats(selectedCharacterGuid, statKey, newValue);
                getCurrentPermanentStats();
            }
            else
            {
                // no selected character
            }
        }

        #region Talent Controls

        private void changeTalentLevel(string talentKey, float amount)
        {
            if (selectedCharacterGuid != null)
            {
                float talentLevel = currentTalentLevels[talentKey];
                float newValue = talentLevel + amount;

                save.changeCharacterTalentLevel(selectedCharacterGuid, talentKey, newValue);
                getCurrentTalentLevels();
            }
        }

        private void getCurrentTalentLevels()
        {
            currentTalentLevels = save.getTalentLevels(selectedCharacterGuid);

            LabelAbilityCounterStrengthTalent.Text = getTalentLevelString("TalentStrength");
            LabelAbilityCounterConstitutionTalent.Text = getTalentLevelString("TalentConstitution");
            LabelAbilityCounterWillPowerTalent.Text = getTalentLevelString("TalentWillPower");
            LabelAbilityCounterIntelligenceTalent.Text = getTalentLevelString("TalentIntelligence");
            LabelAbilityCounterAgilityTalent.Text = getTalentLevelString("TalentAgility");
            LabelAbilityCounterPerceptionTalent.Text = getTalentLevelString("TalentPerception");
        }

        private string getTalentLevelString(string talentKey)
        {
            string talentLevelName = string.Empty;
            float talentLevelFloat = currentTalentLevels[talentKey];

            switch (talentLevelFloat)
            {
                case -1.0f:
                    talentLevelName = " (Poor)";
                    break;
                case 0.0f:
                    talentLevelName = " (Moderate)";
                    break;
                case 1.0f:
                    talentLevelName = " (Outstanding)";
                    break;
                case 2.0f:
                    talentLevelName = " (Exceptional)";
                    break;
                case 3.0f:
                    talentLevelName = " (Genius)";
                    break;
            }

            return talentLevelFloat.ToString() + talentLevelName;
        }

        // Button gore
        // Yes, I could have used NumericUpDown controls for this but I forgot about those at the time
        // And I haven't felt like changing it afterwards.
        private void ButtonStrengthIncrease_Click(object sender, EventArgs e)
        {
            changeTalentLevel("TalentStrength", 1.0f);
        }

        private void ButtonStrengthDecrease_Click(object sender, EventArgs e)
        {
            changeTalentLevel("TalentStrength", -1.0f);
        }

        private void ButtonConstitutionIncrease_Click(object sender, EventArgs e)
        {
            changeTalentLevel("TalentConstitution", 1.0f);
        }

        private void ButtonConstitutionDecrease_Click(object sender, EventArgs e)
        {
            changeTalentLevel("TalentConstitution", -1.0f);
        }

        private void ButtonWillPowerIncrease_Click(object sender, EventArgs e)
        {
            changeTalentLevel("TalentWillPower", 1.0f);
        }

        private void ButtonWillPowerDecrease_Click(object sender, EventArgs e)
        {
            changeTalentLevel("TalentWillPower", -1.0f);
        }

        private void ButtonIntelligenceIncrease_Click(object sender, EventArgs e)
        {
            changeTalentLevel("TalentIntelligence", 1.0f);
        }

        private void ButtonIntelligenceDecrease_Click(object sender, EventArgs e)
        {
            changeTalentLevel("TalentIntelligence", -1.0f);
        }

        private void ButtonAgilityIncrease_Click(object sender, EventArgs e)
        {
            changeTalentLevel("TalentAgility", 1.0f);
        }

        private void ButtonAgilityDecrease_Click(object sender, EventArgs e)
        {
            changeTalentLevel("TalentAgility", -1.0f);
        }

        private void ButtonPerceptionIncrease_Click(object sender, EventArgs e)
        {
            changeTalentLevel("TalentPerception", 1.0f);
        }

        private void ButtonPerceptionDecrease_Click(object sender, EventArgs e)
        {
            changeTalentLevel("TalentPerception", -1.0f);
        }

        #endregion

        #region Permanent numericUpDowns

        private void numericUpDownStrengthPermanentStats_ValueChanged(object sender, EventArgs e)
        {
            float newValue = (float)numericUpDownStrengthPermanentStats.Value;
            changePermanentStats("Strength", newValue);
        }

        private void numericUpDownConstitutionPermanentStats_ValueChanged(object sender, EventArgs e)
        {
            float newValue = (float)numericUpDownConstitutionPermanentStats.Value;
            changePermanentStats("Constitution", newValue);
        }

        private void numericUpDownWillPowerPermanentStats_ValueChanged(object sender, EventArgs e)
        {
            float newValue = (float)numericUpDownWillPowerPermanentStats.Value;
            changePermanentStats("WillPower", newValue);
        }

        private void numericUpDownIntelligencePermanentStats_ValueChanged(object sender, EventArgs e)
        {
            float newValue = (float)numericUpDownIntelligencePermanentStats.Value;
            changePermanentStats("Intelligence", newValue);
        }

        private void numericUpDownAgilityPermanentStats_ValueChanged(object sender, EventArgs e)
        {
            float newValue = (float)numericUpDownAgilityPermanentStats.Value;
            changePermanentStats("Agility", newValue);
        }

        private void numericUpDownPerceptionPermanentStats_ValueChanged(object sender, EventArgs e)
        {
            float newValue = (float)numericUpDownPerceptionPermanentStats.Value;
            changePermanentStats("Perception", newValue);
        }

        #endregion




    }
}

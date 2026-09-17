using DungeonSettlersSaveEditorLibrary;
using System.Net;

namespace DungeonSettlersSaveEditor
{
    public partial class MainForm : Form
    {


        private Dictionary<string, string> affecters;
        private Dictionary<string, string> characterGuids;
        private Dictionary<string, string> currentInscriptionsForIndex;


        private Save save;

        public MainForm()
        {
            InitializeComponent();

            loadDataFromTables();
            CharacterGuidList.Items.Clear();

        }

        private void loadSave(string filePath)
        {
            CharacterGuidList.Items.Clear();
            CurrentInscriptionsList.Items.Clear();

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
            affecters = TableReader.GetInscriptionKeyList();

            InscriptionList.Items.Clear();
            foreach (KeyValuePair<string, string> inscription in affecters)
            {
                InscriptionList.Items.Add(inscription.Value);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            CurrentInscriptionsCharacterName.Text = "";

            TableReader.getSkillInscriptionNameList();
            TableReader.getInscriptionList();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {

            int selectedCharacterIndex = CharacterGuidList.SelectedIndex;
            if (selectedCharacterIndex >= 0)
            {
                int selectedInscriptionIndex = InscriptionList.SelectedIndex;
                if (selectedInscriptionIndex >= 0)
                {
                    string selectedCharacterGuid = characterGuids.ElementAt(selectedCharacterIndex).Key;
                    string selectedInscriptionId = affecters.ElementAt(selectedInscriptionIndex).Key;
                    save.addInscriptionToCharacter(selectedCharacterGuid, selectedInscriptionId);
                    getCurrentInscriptions();
                }
                else
                {
                    // Some error
                }
            }
            else
            {
                // Some error
            }
            //Save.save
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            int selectedCharacterIndex = CharacterGuidList.SelectedIndex;
            if (selectedCharacterIndex >= 0)
            {
                int selectedInscriptionIndex = CurrentInscriptionsList.SelectedIndex;
                if (selectedInscriptionIndex >= 0)
                {
                    string selectedCharacterGuid = characterGuids.ElementAt(selectedCharacterIndex).Key;
                    string selectedInscriptionId = currentInscriptionsForIndex.ElementAt(selectedInscriptionIndex).Key;

                    save.removeInscriptionToCharacter(selectedCharacterGuid, selectedInscriptionId);
                    getCurrentInscriptions();
                }
                else
                {
                    // No inscription selected.
                }
            }
            else
            {
                // Negative selectedCharacterIndex
            }
        }

        private void CharacterGuidList_SelectedIndexChanged(object sender, EventArgs e)
        {
            getCurrentInscriptions();
        }

        private void getCurrentInscriptions()
        {
            CurrentInscriptionsList.Items.Clear();

            int selectedCharacterIndex = CharacterGuidList.SelectedIndex;
            if (selectedCharacterIndex >= 0)
            {
                string selectedCharacterGuid = characterGuids.ElementAt(selectedCharacterIndex).Key;

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
            else
            {
                // // Negative selectedCharacterIndex
            }
        }

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
    }
}

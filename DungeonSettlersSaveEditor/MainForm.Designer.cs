namespace DungeonSettlersSaveEditor
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            CharacterGuidList = new ListBox();
            InscriptionList = new ListBox();
            RemoveButton = new Button();
            AddButton = new Button();
            CurrentInscriptionsList = new ListBox();
            CurrentInscriptionLabel = new Label();
            CurrentInscriptionsCharacterName = new Label();
            ButtonSaveChanges = new Button();
            ButtonLoadSave = new Button();
            TextBoxNewSaveName = new TextBox();
            LabelNewSaveName = new Label();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // CharacterGuidList
            // 
            CharacterGuidList.FormattingEnabled = true;
            CharacterGuidList.Location = new Point(12, 42);
            CharacterGuidList.Name = "CharacterGuidList";
            CharacterGuidList.Size = new Size(291, 629);
            CharacterGuidList.TabIndex = 0;
            CharacterGuidList.SelectedIndexChanged += CharacterGuidList_SelectedIndexChanged;
            // 
            // InscriptionList
            // 
            InscriptionList.FormattingEnabled = true;
            InscriptionList.Location = new Point(319, 42);
            InscriptionList.Name = "InscriptionList";
            InscriptionList.Size = new Size(379, 629);
            InscriptionList.TabIndex = 1;
            // 
            // RemoveButton
            // 
            RemoveButton.Location = new Point(730, 335);
            RemoveButton.Name = "RemoveButton";
            RemoveButton.Size = new Size(112, 34);
            RemoveButton.TabIndex = 2;
            RemoveButton.Text = "Remove";
            RemoveButton.UseVisualStyleBackColor = true;
            RemoveButton.Click += RemoveButton_Click;
            // 
            // AddButton
            // 
            AddButton.Location = new Point(730, 295);
            AddButton.Name = "AddButton";
            AddButton.Size = new Size(112, 34);
            AddButton.TabIndex = 3;
            AddButton.Text = "Add";
            AddButton.UseVisualStyleBackColor = true;
            AddButton.Click += AddButton_Click;
            // 
            // CurrentInscriptionsList
            // 
            CurrentInscriptionsList.FormattingEnabled = true;
            CurrentInscriptionsList.Location = new Point(723, 442);
            CurrentInscriptionsList.Name = "CurrentInscriptionsList";
            CurrentInscriptionsList.Size = new Size(457, 229);
            CurrentInscriptionsList.TabIndex = 4;
            // 
            // CurrentInscriptionLabel
            // 
            CurrentInscriptionLabel.AutoSize = true;
            CurrentInscriptionLabel.Location = new Point(723, 408);
            CurrentInscriptionLabel.Name = "CurrentInscriptionLabel";
            CurrentInscriptionLabel.Size = new Size(119, 25);
            CurrentInscriptionLabel.TabIndex = 5;
            CurrentInscriptionLabel.Text = "Currently has:";
            // 
            // CurrentInscriptionsCharacterName
            // 
            CurrentInscriptionsCharacterName.AutoSize = true;
            CurrentInscriptionsCharacterName.Location = new Point(723, 383);
            CurrentInscriptionsCharacterName.Name = "CurrentInscriptionsCharacterName";
            CurrentInscriptionsCharacterName.Size = new Size(166, 25);
            CurrentInscriptionsCharacterName.TabIndex = 6;
            CurrentInscriptionsCharacterName.Text = "CHARACTER NAME";
            // 
            // ButtonSaveChanges
            // 
            ButtonSaveChanges.Location = new Point(892, 42);
            ButtonSaveChanges.Name = "ButtonSaveChanges";
            ButtonSaveChanges.Size = new Size(177, 34);
            ButtonSaveChanges.TabIndex = 7;
            ButtonSaveChanges.Text = "Save Changes";
            ButtonSaveChanges.UseVisualStyleBackColor = true;
            ButtonSaveChanges.Click += ButtonSaveChanges_Click;
            // 
            // ButtonLoadSave
            // 
            ButtonLoadSave.Location = new Point(723, 42);
            ButtonLoadSave.Name = "ButtonLoadSave";
            ButtonLoadSave.Size = new Size(112, 34);
            ButtonLoadSave.TabIndex = 8;
            ButtonLoadSave.Text = "Load Save";
            ButtonLoadSave.UseVisualStyleBackColor = true;
            ButtonLoadSave.Click += ButtonLoadSave_Click;
            // 
            // TextBoxNewSaveName
            // 
            TextBoxNewSaveName.Location = new Point(892, 107);
            TextBoxNewSaveName.Name = "TextBoxNewSaveName";
            TextBoxNewSaveName.Size = new Size(288, 31);
            TextBoxNewSaveName.TabIndex = 9;
            // 
            // LabelNewSaveName
            // 
            LabelNewSaveName.AutoSize = true;
            LabelNewSaveName.Location = new Point(892, 79);
            LabelNewSaveName.Name = "LabelNewSaveName";
            LabelNewSaveName.Size = new Size(75, 25);
            LabelNewSaveName.TabIndex = 10;
            LabelNewSaveName.Text = "Save as:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(892, 150);
            label1.Name = "label1";
            label1.Size = new Size(288, 25);
            label1.TabIndex = 11;
            label1.Text = "The old save wil not be overwritten";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(892, 175);
            label2.Name = "label2";
            label2.Size = new Size(224, 25);
            label2.TabIndex = 12;
            label2.Text = "if you use a different name";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1192, 690);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(LabelNewSaveName);
            Controls.Add(TextBoxNewSaveName);
            Controls.Add(ButtonLoadSave);
            Controls.Add(ButtonSaveChanges);
            Controls.Add(CurrentInscriptionsCharacterName);
            Controls.Add(CurrentInscriptionLabel);
            Controls.Add(CurrentInscriptionsList);
            Controls.Add(AddButton);
            Controls.Add(RemoveButton);
            Controls.Add(InscriptionList);
            Controls.Add(CharacterGuidList);
            Name = "MainForm";
            Text = "Dungeon Settlers Save Editor";
            Load += MainForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox CharacterGuidList;
        private ListBox InscriptionList;
        private Button RemoveButton;
        private Button AddButton;
        private ListBox CurrentInscriptionsList;
        private Label CurrentInscriptionLabel;
        private Label CurrentInscriptionsCharacterName;
        private Button ButtonSaveChanges;
        private Button ButtonLoadSave;
        private TextBox TextBoxNewSaveName;
        private Label LabelNewSaveName;
        private Label label1;
        private Label label2;
    }
}

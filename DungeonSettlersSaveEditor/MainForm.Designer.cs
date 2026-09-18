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
            components = new System.ComponentModel.Container();
            CharacterGuidList = new ListBox();
            ButtonSaveChanges = new Button();
            ButtonLoadSave = new Button();
            TextBoxNewSaveName = new TextBox();
            LabelNewSaveName = new Label();
            label1 = new Label();
            label2 = new Label();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            CurrentInscriptionsCharacterName = new Label();
            CurrentInscriptionLabel = new Label();
            CurrentInscriptionsList = new ListBox();
            ButtonAddInscription = new Button();
            ButtonRemoveInscription = new Button();
            InscriptionList = new ListBox();
            tabPage2 = new TabPage();
            ButtonRemoveSubSkill = new Button();
            ButtonRemoveMainSkill = new Button();
            ButtonAddSubSkill = new Button();
            ButtonAddMainSkill = new Button();
            ListBoxSubSkillNames = new ListBox();
            ListBoxCurrentCharacterSubSkills = new ListBox();
            ListBoxCurrentCharacterMainSkills = new ListBox();
            ListBoxMainSkillNames = new ListBox();
            numericUpDownSubSkills = new NumericUpDown();
            numericUpDownMainSkills = new NumericUpDown();
            numericUpDownPerceptionPermanentStats = new NumericUpDown();
            numericUpDownAgilityPermanentStats = new NumericUpDown();
            numericUpDownIntelligencePermanentStats = new NumericUpDown();
            numericUpDownWillPowerPermanentStats = new NumericUpDown();
            numericUpDownConstitutionPermanentStats = new NumericUpDown();
            numericUpDownStrengthPermanentStats = new NumericUpDown();
            LabelPermanentStatsTooltip = new Label();
            label4 = new Label();
            label3 = new Label();
            LabelAbilityNamePerceptionTalent = new Label();
            LabelAbilityNameAgilityTalent = new Label();
            LabelAbilityNameIntelligenceTalent = new Label();
            LabelAbilityNameWillPowerTalent = new Label();
            LabelAbilityNameConstitutionTalent = new Label();
            LabelAbilityCounterStrengthTalent = new Label();
            LabelAbilityCounterPerceptionTalent = new Label();
            LabelAbilityCounterAgilityTalent = new Label();
            LabelAbilityCounterIntelligenceTalent = new Label();
            LabelAbilityCounterWillPowerTalent = new Label();
            LabelAbilityCounterConstitutionTalent = new Label();
            LabelAbilityNameStrengthTalent = new Label();
            ButtonPerceptionIncrease = new Button();
            ButtonPerceptionDecrease = new Button();
            ButtonAgilityIncrease = new Button();
            ButtonAgilityDecrease = new Button();
            ButtonIntelligenceIncrease = new Button();
            ButtonIntelligenceDecrease = new Button();
            ButtonWillPowerIncrease = new Button();
            ButtonWillPowerDecrease = new Button();
            ButtonConstitutionIncrease = new Button();
            ButtonConstitutionDecrease = new Button();
            ButtonStrengthIncrease = new Button();
            ButtonStrengthDecrease = new Button();
            toolTip1 = new ToolTip(components);
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownSubSkills).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownMainSkills).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownPerceptionPermanentStats).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownAgilityPermanentStats).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownIntelligencePermanentStats).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownWillPowerPermanentStats).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownConstitutionPermanentStats).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownStrengthPermanentStats).BeginInit();
            SuspendLayout();
            // 
            // CharacterGuidList
            // 
            CharacterGuidList.FormattingEnabled = true;
            CharacterGuidList.Location = new Point(12, 157);
            CharacterGuidList.Name = "CharacterGuidList";
            CharacterGuidList.Size = new Size(291, 329);
            CharacterGuidList.TabIndex = 0;
            CharacterGuidList.SelectedIndexChanged += CharacterGuidList_SelectedIndexChanged;
            // 
            // ButtonSaveChanges
            // 
            ButtonSaveChanges.Location = new Point(687, 21);
            ButtonSaveChanges.Name = "ButtonSaveChanges";
            ButtonSaveChanges.Size = new Size(177, 34);
            ButtonSaveChanges.TabIndex = 7;
            ButtonSaveChanges.Text = "Save Changes";
            ButtonSaveChanges.UseVisualStyleBackColor = true;
            ButtonSaveChanges.Click += ButtonSaveChanges_Click;
            // 
            // ButtonLoadSave
            // 
            ButtonLoadSave.Location = new Point(569, 21);
            ButtonLoadSave.Name = "ButtonLoadSave";
            ButtonLoadSave.Size = new Size(112, 34);
            ButtonLoadSave.TabIndex = 8;
            ButtonLoadSave.Text = "Load Save";
            ButtonLoadSave.UseVisualStyleBackColor = true;
            ButtonLoadSave.Click += ButtonLoadSave_Click;
            // 
            // TextBoxNewSaveName
            // 
            TextBoxNewSaveName.Location = new Point(687, 86);
            TextBoxNewSaveName.Name = "TextBoxNewSaveName";
            TextBoxNewSaveName.Size = new Size(288, 31);
            TextBoxNewSaveName.TabIndex = 9;
            // 
            // LabelNewSaveName
            // 
            LabelNewSaveName.AutoSize = true;
            LabelNewSaveName.Location = new Point(687, 58);
            LabelNewSaveName.Name = "LabelNewSaveName";
            LabelNewSaveName.Size = new Size(75, 25);
            LabelNewSaveName.TabIndex = 10;
            LabelNewSaveName.Text = "Save as:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(890, 17);
            label1.Name = "label1";
            label1.Size = new Size(288, 25);
            label1.TabIndex = 11;
            label1.Text = "The old save wil not be overwritten";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(890, 42);
            label2.Name = "label2";
            label2.Size = new Size(224, 25);
            label2.TabIndex = 12;
            label2.Text = "if you use a different name";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(309, 123);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(873, 936);
            tabControl1.TabIndex = 13;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(CurrentInscriptionsCharacterName);
            tabPage1.Controls.Add(CurrentInscriptionLabel);
            tabPage1.Controls.Add(CurrentInscriptionsList);
            tabPage1.Controls.Add(ButtonAddInscription);
            tabPage1.Controls.Add(ButtonRemoveInscription);
            tabPage1.Controls.Add(InscriptionList);
            tabPage1.Location = new Point(4, 34);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(865, 898);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Inscriptions and Traits";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // CurrentInscriptionsCharacterName
            // 
            CurrentInscriptionsCharacterName.AutoSize = true;
            CurrentInscriptionsCharacterName.Location = new Point(6, 623);
            CurrentInscriptionsCharacterName.Name = "CurrentInscriptionsCharacterName";
            CurrentInscriptionsCharacterName.Size = new Size(166, 25);
            CurrentInscriptionsCharacterName.TabIndex = 11;
            CurrentInscriptionsCharacterName.Text = "CHARACTER NAME";
            // 
            // CurrentInscriptionLabel
            // 
            CurrentInscriptionLabel.AutoSize = true;
            CurrentInscriptionLabel.Location = new Point(6, 648);
            CurrentInscriptionLabel.Name = "CurrentInscriptionLabel";
            CurrentInscriptionLabel.Size = new Size(119, 25);
            CurrentInscriptionLabel.TabIndex = 10;
            CurrentInscriptionLabel.Text = "Currently has:";
            // 
            // CurrentInscriptionsList
            // 
            CurrentInscriptionsList.FormattingEnabled = true;
            CurrentInscriptionsList.Location = new Point(6, 676);
            CurrentInscriptionsList.Name = "CurrentInscriptionsList";
            CurrentInscriptionsList.Size = new Size(362, 204);
            CurrentInscriptionsList.TabIndex = 9;
            // 
            // ButtonAddInscription
            // 
            ButtonAddInscription.Location = new Point(6, 565);
            ButtonAddInscription.Name = "ButtonAddInscription";
            ButtonAddInscription.Size = new Size(170, 34);
            ButtonAddInscription.TabIndex = 8;
            ButtonAddInscription.Text = "Add Inscription";
            ButtonAddInscription.UseVisualStyleBackColor = true;
            ButtonAddInscription.Click += ButtonAddInscription_Click;
            // 
            // ButtonRemoveInscription
            // 
            ButtonRemoveInscription.Location = new Point(188, 565);
            ButtonRemoveInscription.Name = "ButtonRemoveInscription";
            ButtonRemoveInscription.Size = new Size(175, 34);
            ButtonRemoveInscription.TabIndex = 7;
            ButtonRemoveInscription.Text = "Remove Inscription";
            ButtonRemoveInscription.UseVisualStyleBackColor = true;
            ButtonRemoveInscription.Click += ButtonRemoveInscription_Click;
            // 
            // InscriptionList
            // 
            InscriptionList.FormattingEnabled = true;
            InscriptionList.Location = new Point(3, 18);
            InscriptionList.Name = "InscriptionList";
            InscriptionList.Size = new Size(365, 529);
            InscriptionList.TabIndex = 4;
            InscriptionList.SelectedIndexChanged += InscriptionList_SelectedIndexChanged;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(ButtonRemoveSubSkill);
            tabPage2.Controls.Add(ButtonRemoveMainSkill);
            tabPage2.Controls.Add(ButtonAddSubSkill);
            tabPage2.Controls.Add(ButtonAddMainSkill);
            tabPage2.Controls.Add(ListBoxSubSkillNames);
            tabPage2.Controls.Add(ListBoxCurrentCharacterSubSkills);
            tabPage2.Controls.Add(ListBoxCurrentCharacterMainSkills);
            tabPage2.Controls.Add(ListBoxMainSkillNames);
            tabPage2.Controls.Add(numericUpDownSubSkills);
            tabPage2.Controls.Add(numericUpDownMainSkills);
            tabPage2.Controls.Add(numericUpDownPerceptionPermanentStats);
            tabPage2.Controls.Add(numericUpDownAgilityPermanentStats);
            tabPage2.Controls.Add(numericUpDownIntelligencePermanentStats);
            tabPage2.Controls.Add(numericUpDownWillPowerPermanentStats);
            tabPage2.Controls.Add(numericUpDownConstitutionPermanentStats);
            tabPage2.Controls.Add(numericUpDownStrengthPermanentStats);
            tabPage2.Controls.Add(LabelPermanentStatsTooltip);
            tabPage2.Controls.Add(label4);
            tabPage2.Controls.Add(label3);
            tabPage2.Controls.Add(LabelAbilityNamePerceptionTalent);
            tabPage2.Controls.Add(LabelAbilityNameAgilityTalent);
            tabPage2.Controls.Add(LabelAbilityNameIntelligenceTalent);
            tabPage2.Controls.Add(LabelAbilityNameWillPowerTalent);
            tabPage2.Controls.Add(LabelAbilityNameConstitutionTalent);
            tabPage2.Controls.Add(LabelAbilityCounterStrengthTalent);
            tabPage2.Controls.Add(LabelAbilityCounterPerceptionTalent);
            tabPage2.Controls.Add(LabelAbilityCounterAgilityTalent);
            tabPage2.Controls.Add(LabelAbilityCounterIntelligenceTalent);
            tabPage2.Controls.Add(LabelAbilityCounterWillPowerTalent);
            tabPage2.Controls.Add(LabelAbilityCounterConstitutionTalent);
            tabPage2.Controls.Add(LabelAbilityNameStrengthTalent);
            tabPage2.Controls.Add(ButtonPerceptionIncrease);
            tabPage2.Controls.Add(ButtonPerceptionDecrease);
            tabPage2.Controls.Add(ButtonAgilityIncrease);
            tabPage2.Controls.Add(ButtonAgilityDecrease);
            tabPage2.Controls.Add(ButtonIntelligenceIncrease);
            tabPage2.Controls.Add(ButtonIntelligenceDecrease);
            tabPage2.Controls.Add(ButtonWillPowerIncrease);
            tabPage2.Controls.Add(ButtonWillPowerDecrease);
            tabPage2.Controls.Add(ButtonConstitutionIncrease);
            tabPage2.Controls.Add(ButtonConstitutionDecrease);
            tabPage2.Controls.Add(ButtonStrengthIncrease);
            tabPage2.Controls.Add(ButtonStrengthDecrease);
            tabPage2.Location = new Point(4, 34);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(865, 898);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Stats and Skills";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // ButtonRemoveSubSkill
            // 
            ButtonRemoveSubSkill.Location = new Point(246, 683);
            ButtonRemoveSubSkill.Name = "ButtonRemoveSubSkill";
            ButtonRemoveSubSkill.Size = new Size(221, 34);
            ButtonRemoveSubSkill.TabIndex = 9;
            ButtonRemoveSubSkill.Text = "Remove Sub Skill";
            ButtonRemoveSubSkill.UseVisualStyleBackColor = true;
            ButtonRemoveSubSkill.Click += ButtonRemoveSubSkill_Click;
            // 
            // ButtonRemoveMainSkill
            // 
            ButtonRemoveMainSkill.Location = new Point(13, 683);
            ButtonRemoveMainSkill.Name = "ButtonRemoveMainSkill";
            ButtonRemoveMainSkill.Size = new Size(221, 34);
            ButtonRemoveMainSkill.TabIndex = 9;
            ButtonRemoveMainSkill.Text = "Remove Main Skill";
            ButtonRemoveMainSkill.UseVisualStyleBackColor = true;
            ButtonRemoveMainSkill.Click += ButtonRemoveMainSkill_Click;
            // 
            // ButtonAddSubSkill
            // 
            ButtonAddSubSkill.Location = new Point(246, 643);
            ButtonAddSubSkill.Name = "ButtonAddSubSkill";
            ButtonAddSubSkill.Size = new Size(221, 34);
            ButtonAddSubSkill.TabIndex = 9;
            ButtonAddSubSkill.Text = "Add Sub Skill";
            ButtonAddSubSkill.UseVisualStyleBackColor = true;
            ButtonAddSubSkill.Click += ButtonAddSubSkill_Click;
            // 
            // ButtonAddMainSkill
            // 
            ButtonAddMainSkill.Location = new Point(11, 643);
            ButtonAddMainSkill.Name = "ButtonAddMainSkill";
            ButtonAddMainSkill.Size = new Size(221, 34);
            ButtonAddMainSkill.TabIndex = 9;
            ButtonAddMainSkill.Text = "Add Main Skill";
            ButtonAddMainSkill.UseVisualStyleBackColor = true;
            ButtonAddMainSkill.Click += ButtonAddMainSkill_Click;
            // 
            // ListBoxSubSkillNames
            // 
            ListBoxSubSkillNames.FormattingEnabled = true;
            ListBoxSubSkillNames.Location = new Point(242, 348);
            ListBoxSubSkillNames.Name = "ListBoxSubSkillNames";
            ListBoxSubSkillNames.Size = new Size(225, 279);
            ListBoxSubSkillNames.TabIndex = 8;
            // 
            // ListBoxCurrentCharacterSubSkills
            // 
            ListBoxCurrentCharacterSubSkills.FormattingEnabled = true;
            ListBoxCurrentCharacterSubSkills.Location = new Point(240, 728);
            ListBoxCurrentCharacterSubSkills.Name = "ListBoxCurrentCharacterSubSkills";
            ListBoxCurrentCharacterSubSkills.Size = new Size(225, 154);
            ListBoxCurrentCharacterSubSkills.TabIndex = 8;
            // 
            // ListBoxCurrentCharacterMainSkills
            // 
            ListBoxCurrentCharacterMainSkills.FormattingEnabled = true;
            ListBoxCurrentCharacterMainSkills.Location = new Point(9, 728);
            ListBoxCurrentCharacterMainSkills.Name = "ListBoxCurrentCharacterMainSkills";
            ListBoxCurrentCharacterMainSkills.Size = new Size(225, 154);
            ListBoxCurrentCharacterMainSkills.TabIndex = 8;
            // 
            // ListBoxMainSkillNames
            // 
            ListBoxMainSkillNames.FormattingEnabled = true;
            ListBoxMainSkillNames.Location = new Point(11, 348);
            ListBoxMainSkillNames.Name = "ListBoxMainSkillNames";
            ListBoxMainSkillNames.Size = new Size(223, 279);
            ListBoxMainSkillNames.TabIndex = 7;
            // 
            // numericUpDownSubSkills
            // 
            numericUpDownSubSkills.Location = new Point(680, 422);
            numericUpDownSubSkills.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numericUpDownSubSkills.Name = "numericUpDownSubSkills";
            numericUpDownSubSkills.Size = new Size(94, 31);
            numericUpDownSubSkills.TabIndex = 6;
            numericUpDownSubSkills.ValueChanged += numericUpDownPerceptionPermanentStats_ValueChanged;
            // 
            // numericUpDownMainSkills
            // 
            numericUpDownMainSkills.Location = new Point(680, 385);
            numericUpDownMainSkills.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numericUpDownMainSkills.Name = "numericUpDownMainSkills";
            numericUpDownMainSkills.Size = new Size(94, 31);
            numericUpDownMainSkills.TabIndex = 6;
            numericUpDownMainSkills.ValueChanged += numericUpDownPerceptionPermanentStats_ValueChanged;
            // 
            // numericUpDownPerceptionPermanentStats
            // 
            numericUpDownPerceptionPermanentStats.Location = new Point(386, 273);
            numericUpDownPerceptionPermanentStats.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numericUpDownPerceptionPermanentStats.Name = "numericUpDownPerceptionPermanentStats";
            numericUpDownPerceptionPermanentStats.Size = new Size(94, 31);
            numericUpDownPerceptionPermanentStats.TabIndex = 6;
            numericUpDownPerceptionPermanentStats.ValueChanged += numericUpDownPerceptionPermanentStats_ValueChanged;
            // 
            // numericUpDownAgilityPermanentStats
            // 
            numericUpDownAgilityPermanentStats.Location = new Point(386, 229);
            numericUpDownAgilityPermanentStats.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numericUpDownAgilityPermanentStats.Name = "numericUpDownAgilityPermanentStats";
            numericUpDownAgilityPermanentStats.Size = new Size(94, 31);
            numericUpDownAgilityPermanentStats.TabIndex = 6;
            numericUpDownAgilityPermanentStats.ValueChanged += numericUpDownAgilityPermanentStats_ValueChanged;
            // 
            // numericUpDownIntelligencePermanentStats
            // 
            numericUpDownIntelligencePermanentStats.Location = new Point(386, 183);
            numericUpDownIntelligencePermanentStats.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numericUpDownIntelligencePermanentStats.Name = "numericUpDownIntelligencePermanentStats";
            numericUpDownIntelligencePermanentStats.Size = new Size(94, 31);
            numericUpDownIntelligencePermanentStats.TabIndex = 6;
            numericUpDownIntelligencePermanentStats.ValueChanged += numericUpDownIntelligencePermanentStats_ValueChanged;
            // 
            // numericUpDownWillPowerPermanentStats
            // 
            numericUpDownWillPowerPermanentStats.Location = new Point(386, 137);
            numericUpDownWillPowerPermanentStats.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numericUpDownWillPowerPermanentStats.Name = "numericUpDownWillPowerPermanentStats";
            numericUpDownWillPowerPermanentStats.Size = new Size(94, 31);
            numericUpDownWillPowerPermanentStats.TabIndex = 6;
            numericUpDownWillPowerPermanentStats.ValueChanged += numericUpDownWillPowerPermanentStats_ValueChanged;
            // 
            // numericUpDownConstitutionPermanentStats
            // 
            numericUpDownConstitutionPermanentStats.Location = new Point(386, 91);
            numericUpDownConstitutionPermanentStats.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numericUpDownConstitutionPermanentStats.Name = "numericUpDownConstitutionPermanentStats";
            numericUpDownConstitutionPermanentStats.Size = new Size(94, 31);
            numericUpDownConstitutionPermanentStats.TabIndex = 6;
            numericUpDownConstitutionPermanentStats.ValueChanged += numericUpDownConstitutionPermanentStats_ValueChanged;
            // 
            // numericUpDownStrengthPermanentStats
            // 
            numericUpDownStrengthPermanentStats.Location = new Point(386, 49);
            numericUpDownStrengthPermanentStats.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numericUpDownStrengthPermanentStats.Name = "numericUpDownStrengthPermanentStats";
            numericUpDownStrengthPermanentStats.Size = new Size(94, 31);
            numericUpDownStrengthPermanentStats.TabIndex = 6;
            numericUpDownStrengthPermanentStats.ValueChanged += numericUpDownStrengthPermanentStats_ValueChanged;
            // 
            // LabelPermanentStatsTooltip
            // 
            LabelPermanentStatsTooltip.AutoSize = true;
            LabelPermanentStatsTooltip.Location = new Point(509, 12);
            LabelPermanentStatsTooltip.Name = "LabelPermanentStatsTooltip";
            LabelPermanentStatsTooltip.Size = new Size(28, 25);
            LabelPermanentStatsTooltip.TabIndex = 5;
            LabelPermanentStatsTooltip.Text = "ⓘ";
            toolTip1.SetToolTip(LabelPermanentStatsTooltip, "Whatever you add here will be added to the attributes in game.\r\nPermanent stats are usually gained from Elixers / Mandrakes and stuff.\r\n\r\n");
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(360, 12);
            label4.Name = "label4";
            label4.Size = new Size(151, 25);
            label4.TabIndex = 4;
            label4.Text = "Permanents Stats:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(191, 12);
            label3.Name = "label3";
            label3.Size = new Size(101, 25);
            label3.TabIndex = 2;
            label3.Text = "Talent level:";
            // 
            // LabelAbilityNamePerceptionTalent
            // 
            LabelAbilityNamePerceptionTalent.AutoSize = true;
            LabelAbilityNamePerceptionTalent.Location = new Point(9, 278);
            LabelAbilityNamePerceptionTalent.Name = "LabelAbilityNamePerceptionTalent";
            LabelAbilityNamePerceptionTalent.Size = new Size(99, 25);
            LabelAbilityNamePerceptionTalent.TabIndex = 1;
            LabelAbilityNamePerceptionTalent.Text = "Perception:";
            // 
            // LabelAbilityNameAgilityTalent
            // 
            LabelAbilityNameAgilityTalent.AutoSize = true;
            LabelAbilityNameAgilityTalent.Location = new Point(9, 232);
            LabelAbilityNameAgilityTalent.Name = "LabelAbilityNameAgilityTalent";
            LabelAbilityNameAgilityTalent.Size = new Size(66, 25);
            LabelAbilityNameAgilityTalent.TabIndex = 1;
            LabelAbilityNameAgilityTalent.Text = "Agility:";
            // 
            // LabelAbilityNameIntelligenceTalent
            // 
            LabelAbilityNameIntelligenceTalent.AutoSize = true;
            LabelAbilityNameIntelligenceTalent.Location = new Point(9, 186);
            LabelAbilityNameIntelligenceTalent.Name = "LabelAbilityNameIntelligenceTalent";
            LabelAbilityNameIntelligenceTalent.Size = new Size(105, 25);
            LabelAbilityNameIntelligenceTalent.TabIndex = 1;
            LabelAbilityNameIntelligenceTalent.Text = "Intelligence:";
            // 
            // LabelAbilityNameWillPowerTalent
            // 
            LabelAbilityNameWillPowerTalent.AutoSize = true;
            LabelAbilityNameWillPowerTalent.Location = new Point(9, 140);
            LabelAbilityNameWillPowerTalent.Name = "LabelAbilityNameWillPowerTalent";
            LabelAbilityNameWillPowerTalent.Size = new Size(93, 25);
            LabelAbilityNameWillPowerTalent.TabIndex = 1;
            LabelAbilityNameWillPowerTalent.Text = "WillPower:";
            // 
            // LabelAbilityNameConstitutionTalent
            // 
            LabelAbilityNameConstitutionTalent.AutoSize = true;
            LabelAbilityNameConstitutionTalent.Location = new Point(9, 94);
            LabelAbilityNameConstitutionTalent.Name = "LabelAbilityNameConstitutionTalent";
            LabelAbilityNameConstitutionTalent.Size = new Size(113, 25);
            LabelAbilityNameConstitutionTalent.TabIndex = 1;
            LabelAbilityNameConstitutionTalent.Text = "Constitution:";
            // 
            // LabelAbilityCounterStrengthTalent
            // 
            LabelAbilityCounterStrengthTalent.AutoSize = true;
            LabelAbilityCounterStrengthTalent.Location = new Point(242, 48);
            LabelAbilityCounterStrengthTalent.Name = "LabelAbilityCounterStrengthTalent";
            LabelAbilityCounterStrengthTalent.Size = new Size(73, 25);
            LabelAbilityCounterStrengthTalent.TabIndex = 1;
            LabelAbilityCounterStrengthTalent.Text = "no data";
            // 
            // LabelAbilityCounterPerceptionTalent
            // 
            LabelAbilityCounterPerceptionTalent.AutoSize = true;
            LabelAbilityCounterPerceptionTalent.Location = new Point(242, 277);
            LabelAbilityCounterPerceptionTalent.Name = "LabelAbilityCounterPerceptionTalent";
            LabelAbilityCounterPerceptionTalent.Size = new Size(73, 25);
            LabelAbilityCounterPerceptionTalent.TabIndex = 1;
            LabelAbilityCounterPerceptionTalent.Text = "no data";
            // 
            // LabelAbilityCounterAgilityTalent
            // 
            LabelAbilityCounterAgilityTalent.AutoSize = true;
            LabelAbilityCounterAgilityTalent.Location = new Point(242, 232);
            LabelAbilityCounterAgilityTalent.Name = "LabelAbilityCounterAgilityTalent";
            LabelAbilityCounterAgilityTalent.Size = new Size(73, 25);
            LabelAbilityCounterAgilityTalent.TabIndex = 1;
            LabelAbilityCounterAgilityTalent.Text = "no data";
            // 
            // LabelAbilityCounterIntelligenceTalent
            // 
            LabelAbilityCounterIntelligenceTalent.AutoSize = true;
            LabelAbilityCounterIntelligenceTalent.Location = new Point(242, 186);
            LabelAbilityCounterIntelligenceTalent.Name = "LabelAbilityCounterIntelligenceTalent";
            LabelAbilityCounterIntelligenceTalent.Size = new Size(73, 25);
            LabelAbilityCounterIntelligenceTalent.TabIndex = 1;
            LabelAbilityCounterIntelligenceTalent.Text = "no data";
            // 
            // LabelAbilityCounterWillPowerTalent
            // 
            LabelAbilityCounterWillPowerTalent.AutoSize = true;
            LabelAbilityCounterWillPowerTalent.Location = new Point(242, 140);
            LabelAbilityCounterWillPowerTalent.Name = "LabelAbilityCounterWillPowerTalent";
            LabelAbilityCounterWillPowerTalent.Size = new Size(73, 25);
            LabelAbilityCounterWillPowerTalent.TabIndex = 1;
            LabelAbilityCounterWillPowerTalent.Text = "no data";
            // 
            // LabelAbilityCounterConstitutionTalent
            // 
            LabelAbilityCounterConstitutionTalent.AutoSize = true;
            LabelAbilityCounterConstitutionTalent.Location = new Point(242, 94);
            LabelAbilityCounterConstitutionTalent.Name = "LabelAbilityCounterConstitutionTalent";
            LabelAbilityCounterConstitutionTalent.Size = new Size(73, 25);
            LabelAbilityCounterConstitutionTalent.TabIndex = 1;
            LabelAbilityCounterConstitutionTalent.Text = "no data";
            // 
            // LabelAbilityNameStrengthTalent
            // 
            LabelAbilityNameStrengthTalent.AutoSize = true;
            LabelAbilityNameStrengthTalent.Location = new Point(9, 48);
            LabelAbilityNameStrengthTalent.Name = "LabelAbilityNameStrengthTalent";
            LabelAbilityNameStrengthTalent.Size = new Size(83, 25);
            LabelAbilityNameStrengthTalent.TabIndex = 1;
            LabelAbilityNameStrengthTalent.Text = "Strength:";
            // 
            // ButtonPerceptionIncrease
            // 
            ButtonPerceptionIncrease.Location = new Point(166, 270);
            ButtonPerceptionIncrease.Name = "ButtonPerceptionIncrease";
            ButtonPerceptionIncrease.Size = new Size(30, 40);
            ButtonPerceptionIncrease.TabIndex = 0;
            ButtonPerceptionIncrease.Text = "+";
            ButtonPerceptionIncrease.UseVisualStyleBackColor = true;
            ButtonPerceptionIncrease.Click += ButtonPerceptionIncrease_Click;
            // 
            // ButtonPerceptionDecrease
            // 
            ButtonPerceptionDecrease.Location = new Point(202, 270);
            ButtonPerceptionDecrease.Name = "ButtonPerceptionDecrease";
            ButtonPerceptionDecrease.Size = new Size(30, 40);
            ButtonPerceptionDecrease.TabIndex = 0;
            ButtonPerceptionDecrease.Text = "-";
            ButtonPerceptionDecrease.UseVisualStyleBackColor = true;
            ButtonPerceptionDecrease.Click += ButtonPerceptionDecrease_Click;
            // 
            // ButtonAgilityIncrease
            // 
            ButtonAgilityIncrease.Location = new Point(166, 224);
            ButtonAgilityIncrease.Name = "ButtonAgilityIncrease";
            ButtonAgilityIncrease.Size = new Size(30, 40);
            ButtonAgilityIncrease.TabIndex = 0;
            ButtonAgilityIncrease.Text = "+";
            ButtonAgilityIncrease.UseVisualStyleBackColor = true;
            ButtonAgilityIncrease.Click += ButtonAgilityIncrease_Click;
            // 
            // ButtonAgilityDecrease
            // 
            ButtonAgilityDecrease.Location = new Point(202, 224);
            ButtonAgilityDecrease.Name = "ButtonAgilityDecrease";
            ButtonAgilityDecrease.Size = new Size(30, 40);
            ButtonAgilityDecrease.TabIndex = 0;
            ButtonAgilityDecrease.Text = "-";
            ButtonAgilityDecrease.UseVisualStyleBackColor = true;
            ButtonAgilityDecrease.Click += ButtonAgilityDecrease_Click;
            // 
            // ButtonIntelligenceIncrease
            // 
            ButtonIntelligenceIncrease.Location = new Point(166, 178);
            ButtonIntelligenceIncrease.Name = "ButtonIntelligenceIncrease";
            ButtonIntelligenceIncrease.Size = new Size(30, 40);
            ButtonIntelligenceIncrease.TabIndex = 0;
            ButtonIntelligenceIncrease.Text = "+";
            ButtonIntelligenceIncrease.UseVisualStyleBackColor = true;
            ButtonIntelligenceIncrease.Click += ButtonIntelligenceIncrease_Click;
            // 
            // ButtonIntelligenceDecrease
            // 
            ButtonIntelligenceDecrease.Location = new Point(202, 178);
            ButtonIntelligenceDecrease.Name = "ButtonIntelligenceDecrease";
            ButtonIntelligenceDecrease.Size = new Size(30, 40);
            ButtonIntelligenceDecrease.TabIndex = 0;
            ButtonIntelligenceDecrease.Text = "-";
            ButtonIntelligenceDecrease.UseVisualStyleBackColor = true;
            ButtonIntelligenceDecrease.Click += ButtonIntelligenceDecrease_Click;
            // 
            // ButtonWillPowerIncrease
            // 
            ButtonWillPowerIncrease.Location = new Point(166, 132);
            ButtonWillPowerIncrease.Name = "ButtonWillPowerIncrease";
            ButtonWillPowerIncrease.Size = new Size(30, 40);
            ButtonWillPowerIncrease.TabIndex = 0;
            ButtonWillPowerIncrease.Text = "+";
            ButtonWillPowerIncrease.UseVisualStyleBackColor = true;
            ButtonWillPowerIncrease.Click += ButtonWillPowerIncrease_Click;
            // 
            // ButtonWillPowerDecrease
            // 
            ButtonWillPowerDecrease.Location = new Point(202, 132);
            ButtonWillPowerDecrease.Name = "ButtonWillPowerDecrease";
            ButtonWillPowerDecrease.Size = new Size(30, 40);
            ButtonWillPowerDecrease.TabIndex = 0;
            ButtonWillPowerDecrease.Text = "-";
            ButtonWillPowerDecrease.UseVisualStyleBackColor = true;
            ButtonWillPowerDecrease.Click += ButtonWillPowerDecrease_Click;
            // 
            // ButtonConstitutionIncrease
            // 
            ButtonConstitutionIncrease.Location = new Point(166, 86);
            ButtonConstitutionIncrease.Name = "ButtonConstitutionIncrease";
            ButtonConstitutionIncrease.Size = new Size(30, 40);
            ButtonConstitutionIncrease.TabIndex = 0;
            ButtonConstitutionIncrease.Text = "+";
            ButtonConstitutionIncrease.UseVisualStyleBackColor = true;
            ButtonConstitutionIncrease.Click += ButtonConstitutionIncrease_Click;
            // 
            // ButtonConstitutionDecrease
            // 
            ButtonConstitutionDecrease.Location = new Point(202, 86);
            ButtonConstitutionDecrease.Name = "ButtonConstitutionDecrease";
            ButtonConstitutionDecrease.Size = new Size(30, 40);
            ButtonConstitutionDecrease.TabIndex = 0;
            ButtonConstitutionDecrease.Text = "-";
            ButtonConstitutionDecrease.UseVisualStyleBackColor = true;
            ButtonConstitutionDecrease.Click += ButtonConstitutionDecrease_Click;
            // 
            // ButtonStrengthIncrease
            // 
            ButtonStrengthIncrease.Location = new Point(166, 40);
            ButtonStrengthIncrease.Name = "ButtonStrengthIncrease";
            ButtonStrengthIncrease.Size = new Size(30, 40);
            ButtonStrengthIncrease.TabIndex = 0;
            ButtonStrengthIncrease.Text = "+";
            ButtonStrengthIncrease.UseVisualStyleBackColor = true;
            ButtonStrengthIncrease.Click += ButtonStrengthIncrease_Click;
            // 
            // ButtonStrengthDecrease
            // 
            ButtonStrengthDecrease.Location = new Point(202, 40);
            ButtonStrengthDecrease.Name = "ButtonStrengthDecrease";
            ButtonStrengthDecrease.Size = new Size(30, 40);
            ButtonStrengthDecrease.TabIndex = 0;
            ButtonStrengthDecrease.Text = "-";
            ButtonStrengthDecrease.UseVisualStyleBackColor = true;
            ButtonStrengthDecrease.Click += ButtonStrengthDecrease_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1198, 1071);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(LabelNewSaveName);
            Controls.Add(TextBoxNewSaveName);
            Controls.Add(ButtonLoadSave);
            Controls.Add(ButtonSaveChanges);
            Controls.Add(CharacterGuidList);
            Controls.Add(tabControl1);
            Name = "MainForm";
            Text = "Dungeon Settlers Save Editor";
            Load += MainForm_Load;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownSubSkills).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownMainSkills).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownPerceptionPermanentStats).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownAgilityPermanentStats).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownIntelligencePermanentStats).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownWillPowerPermanentStats).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownConstitutionPermanentStats).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownStrengthPermanentStats).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox CharacterGuidList;
        private Button ButtonSaveChanges;
        private Button ButtonLoadSave;
        private TextBox TextBoxNewSaveName;
        private Label LabelNewSaveName;
        private Label label1;
        private Label label2;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private ListBox InscriptionList;
        private Label CurrentInscriptionsCharacterName;
        private Label CurrentInscriptionLabel;
        private ListBox CurrentInscriptionsList;
        private Button ButtonAddInscription;
        private Button ButtonRemoveInscription;
        private Label LabelAbilityNameStrengthTalent;
        private Button ButtonPerceptionDecrease;
        private Button ButtonAgilityDecrease;
        private Button ButtonIntelligenceDecrease;
        private Button ButtonWillPowerDecrease;
        private Button ButtonConstitutionDecrease;
        private Button ButtonStrengthDecrease;
        private Label LabelAbilityNamePerceptionTalent;
        private Label LabelAbilityNameAgilityTalent;
        private Label LabelAbilityNameIntelligenceTalent;
        private Label LabelAbilityNameWillPowerTalent;
        private Label LabelAbilityNameConstitutionTalent;
        private Label LabelAbilityCounterStrengthTalent;
        private Label LabelAbilityCounterPerceptionTalent;
        private Label LabelAbilityCounterAgilityTalent;
        private Label LabelAbilityCounterIntelligenceTalent;
        private Label LabelAbilityCounterWillPowerTalent;
        private Label LabelAbilityCounterConstitutionTalent;
        private Button ButtonPerceptionIncrease;
        private Button ButtonAgilityIncrease;
        private Button ButtonIntelligenceIncrease;
        private Button ButtonWillPowerIncrease;
        private Button ButtonConstitutionIncrease;
        private Button ButtonStrengthIncrease;
        private Label label3;
        private Label label4;
        private Label LabelPermanentStatsTooltip;
        private ToolTip toolTip1;
        private NumericUpDown numericUpDownStrengthPermanentStats;
        private NumericUpDown numericUpDownPerceptionPermanentStats;
        private NumericUpDown numericUpDownAgilityPermanentStats;
        private NumericUpDown numericUpDownIntelligencePermanentStats;
        private NumericUpDown numericUpDownWillPowerPermanentStats;
        private NumericUpDown numericUpDownConstitutionPermanentStats;
        private ListBox ListBoxMainSkillNames;
        private NumericUpDown numericUpDownSubSkills;
        private NumericUpDown numericUpDownMainSkills;
        private ListBox ListBoxSubSkillNames;
        private ListBox ListBoxCurrentCharacterMainSkills;
        private ListBox ListBoxCurrentCharacterSubSkills;
        private Button ButtonRemoveSubSkill;
        private Button ButtonRemoveMainSkill;
        private Button ButtonAddSubSkill;
        private Button ButtonAddMainSkill;
    }
}

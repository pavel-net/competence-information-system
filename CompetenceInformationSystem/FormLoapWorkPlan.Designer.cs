namespace CompetenceInformationSystem
{
    partial class FormLoapWorkPlan
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLoapWorkPlan));
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonFile = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonDirectory = new System.Windows.Forms.Button();
            this.comboBoxSpecialization = new System.Windows.Forms.ComboBox();
            this.richTextBoxState = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxSpecialty = new System.Windows.Forms.ComboBox();
            this.superTabControl1 = new CompetenceInformationSystem.SuperTabControl();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.buttonSave);
            this.panel1.Controls.Add(this.buttonFile);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.buttonDirectory);
            this.panel1.Controls.Add(this.comboBoxSpecialization);
            this.panel1.Controls.Add(this.richTextBoxState);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.comboBoxSpecialty);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(877, 214);
            this.panel1.TabIndex = 0;
            // 
            // buttonSave
            // 
            this.buttonSave.Enabled = false;
            this.buttonSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.buttonSave.Location = new System.Drawing.Point(17, 158);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(280, 42);
            this.buttonSave.TabIndex = 7;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonFile
            // 
            this.buttonFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.buttonFile.Location = new System.Drawing.Point(664, 12);
            this.buttonFile.Name = "buttonFile";
            this.buttonFile.Size = new System.Drawing.Size(161, 69);
            this.buttonFile.TabIndex = 6;
            this.buttonFile.Text = "Загрузить файл";
            this.buttonFile.UseVisualStyleBackColor = true;
            this.buttonFile.Click += new System.EventHandler(this.buttonFile_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label2.Location = new System.Drawing.Point(13, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Специализация";
            // 
            // buttonDirectory
            // 
            this.buttonDirectory.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.buttonDirectory.Location = new System.Drawing.Point(448, 12);
            this.buttonDirectory.Name = "buttonDirectory";
            this.buttonDirectory.Size = new System.Drawing.Size(193, 69);
            this.buttonDirectory.TabIndex = 0;
            this.buttonDirectory.Text = "Загрузить каталог";
            this.buttonDirectory.UseVisualStyleBackColor = true;
            this.buttonDirectory.Click += new System.EventHandler(this.buttonDirectory_Click);
            // 
            // comboBoxSpecialization
            // 
            this.comboBoxSpecialization.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSpecialization.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.comboBoxSpecialization.FormattingEnabled = true;
            this.comboBoxSpecialization.Location = new System.Drawing.Point(17, 114);
            this.comboBoxSpecialization.Name = "comboBoxSpecialization";
            this.comboBoxSpecialization.Size = new System.Drawing.Size(385, 25);
            this.comboBoxSpecialization.TabIndex = 4;
            this.comboBoxSpecialization.SelectedIndexChanged += new System.EventHandler(this.comboBoxSpecialization_SelectedIndexChanged);
            // 
            // richTextBoxState
            // 
            this.richTextBoxState.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxState.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.richTextBoxState.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.richTextBoxState.Location = new System.Drawing.Point(425, 96);
            this.richTextBoxState.Name = "richTextBoxState";
            this.richTextBoxState.ReadOnly = true;
            this.richTextBoxState.Size = new System.Drawing.Size(447, 113);
            this.richTextBoxState.TabIndex = 3;
            this.richTextBoxState.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label1.Location = new System.Drawing.Point(13, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Специальность";
            // 
            // comboBoxSpecialty
            // 
            this.comboBoxSpecialty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSpecialty.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.comboBoxSpecialty.FormattingEnabled = true;
            this.comboBoxSpecialty.Location = new System.Drawing.Point(17, 44);
            this.comboBoxSpecialty.Name = "comboBoxSpecialty";
            this.comboBoxSpecialty.Size = new System.Drawing.Size(385, 25);
            this.comboBoxSpecialty.TabIndex = 1;
            this.comboBoxSpecialty.SelectedIndexChanged += new System.EventHandler(this.comboBoxSpecialty_SelectedIndexChanged);
            // 
            // superTabControl1
            // 
            this.superTabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.superTabControl1.Location = new System.Drawing.Point(12, 232);
            this.superTabControl1.Name = "superTabControl1";
            this.superTabControl1.SelectedIndex = 0;
            this.superTabControl1.Size = new System.Drawing.Size(877, 433);
            this.superTabControl1.TabIndex = 1;
            // 
            // FormLoapWorkPlan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 677);
            this.Controls.Add(this.superTabControl1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormLoapWorkPlan";
            this.Text = "Загрузить рабочий план дисциплины";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormLoapWorkPlan_FormClosing);
            this.Load += new System.EventHandler(this.FormLoapWorkPlan_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonFile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonDirectory;
        private System.Windows.Forms.ComboBox comboBoxSpecialization;
        private System.Windows.Forms.RichTextBox richTextBoxState;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxSpecialty;
        private SuperTabControl superTabControl1;
        private System.Windows.Forms.Button buttonSave;
    }
}
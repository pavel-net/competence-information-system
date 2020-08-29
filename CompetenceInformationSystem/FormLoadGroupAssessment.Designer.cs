namespace CompetenceInformationSystem
{
    partial class FormLoadGroupAssessment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLoadGroupAssessment));
            this.panelOption = new System.Windows.Forms.Panel();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.comboBoxSem = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.superTabControl1 = new CompetenceInformationSystem.SuperTabControl();
            this.panelOption.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelOption
            // 
            this.panelOption.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelOption.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelOption.Controls.Add(this.buttonLoad);
            this.panelOption.Controls.Add(this.comboBoxSem);
            this.panelOption.Controls.Add(this.label1);
            this.panelOption.Location = new System.Drawing.Point(12, 12);
            this.panelOption.Name = "panelOption";
            this.panelOption.Size = new System.Drawing.Size(900, 70);
            this.panelOption.TabIndex = 0;
            // 
            // buttonLoad
            // 
            this.buttonLoad.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.buttonLoad.Location = new System.Drawing.Point(270, 12);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(210, 54);
            this.buttonLoad.TabIndex = 2;
            this.buttonLoad.Text = "Загрузить файл";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // comboBoxSem
            // 
            this.comboBoxSem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.comboBoxSem.FormattingEnabled = true;
            this.comboBoxSem.Items.AddRange(new object[] {
            "Осенний",
            "Весенний"});
            this.comboBoxSem.Location = new System.Drawing.Point(7, 35);
            this.comboBoxSem.Name = "comboBoxSem";
            this.comboBoxSem.Size = new System.Drawing.Size(229, 25);
            this.comboBoxSem.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label1.Location = new System.Drawing.Point(3, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Выберите семестер";
            // 
            // superTabControl1
            // 
            this.superTabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.superTabControl1.Location = new System.Drawing.Point(12, 101);
            this.superTabControl1.Name = "superTabControl1";
            this.superTabControl1.SelectedIndex = 0;
            this.superTabControl1.Size = new System.Drawing.Size(900, 639);
            this.superTabControl1.TabIndex = 1;
            this.superTabControl1.SelectedIndexChanged += new System.EventHandler(this.superTabControl1_SelectedIndexChanged);
            // 
            // FormLoadGroupAssessment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 752);
            this.Controls.Add(this.superTabControl1);
            this.Controls.Add(this.panelOption);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormLoadGroupAssessment";
            this.Text = "Загрузить оценки слушателей";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormLoadGroupAssessment_FormClosing);
            this.Load += new System.EventHandler(this.FormLoadGroupAssessment_Load);
            this.panelOption.ResumeLayout(false);
            this.panelOption.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelOption;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.ComboBox comboBoxSem;
        private System.Windows.Forms.Label label1;
        private SuperTabControl superTabControl1;
    }
}
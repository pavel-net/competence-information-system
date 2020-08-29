namespace CompetenceInformationSystem
{
    partial class FormAssessmentUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAssessmentUser));
            this.comboBoxSemester = new System.Windows.Forms.ComboBox();
            this.labelStudent = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridViewDiscip = new System.Windows.Forms.DataGridView();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDiscip)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxSemester
            // 
            this.comboBoxSemester.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSemester.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.comboBoxSemester.FormattingEnabled = true;
            this.comboBoxSemester.Location = new System.Drawing.Point(16, 85);
            this.comboBoxSemester.Name = "comboBoxSemester";
            this.comboBoxSemester.Size = new System.Drawing.Size(285, 25);
            this.comboBoxSemester.TabIndex = 0;
            this.comboBoxSemester.SelectionChangeCommitted += new System.EventHandler(this.comboBoxSemester_SelectionChangeCommitted);
            // 
            // labelStudent
            // 
            this.labelStudent.AutoSize = true;
            this.labelStudent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.labelStudent.Location = new System.Drawing.Point(12, 18);
            this.labelStudent.Name = "labelStudent";
            this.labelStudent.Size = new System.Drawing.Size(226, 20);
            this.labelStudent.TabIndex = 1;
            this.labelStudent.Text = "Успеваемость слушателя";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label2.Location = new System.Drawing.Point(12, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Выберите семестер";
            // 
            // dataGridViewDiscip
            // 
            this.dataGridViewDiscip.AllowUserToAddRows = false;
            this.dataGridViewDiscip.AllowUserToDeleteRows = false;
            this.dataGridViewDiscip.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewDiscip.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewDiscip.BackgroundColor = System.Drawing.Color.Silver;
            this.dataGridViewDiscip.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDiscip.Location = new System.Drawing.Point(16, 134);
            this.dataGridViewDiscip.Name = "dataGridViewDiscip";
            this.dataGridViewDiscip.Size = new System.Drawing.Size(659, 348);
            this.dataGridViewDiscip.TabIndex = 3;
            this.dataGridViewDiscip.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewDiscip_CellEndEdit);
            this.dataGridViewDiscip.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridViewDiscip_DataError);
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.buttonOk.Location = new System.Drawing.Point(511, 502);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(164, 60);
            this.buttonOk.TabIndex = 4;
            this.buttonOk.Text = "Отмена";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.buttonSave.Location = new System.Drawing.Point(16, 502);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(146, 60);
            this.buttonSave.TabIndex = 5;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // FormAssessmentUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 591);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.dataGridViewDiscip);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelStudent);
            this.Controls.Add(this.comboBoxSemester);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormAssessmentUser";
            this.Text = "Успеваемость слушателя";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormAssessmentUser_FormClosing);
            this.Load += new System.EventHandler(this.FormAssessmentUser_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDiscip)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxSemester;
        private System.Windows.Forms.Label labelStudent;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridViewDiscip;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonSave;
    }
}
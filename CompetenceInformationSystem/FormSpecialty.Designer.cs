namespace CompetenceInformationSystem
{
    partial class FormSpecialty
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSpecialty));
            this.dataGridViewSpecialization = new System.Windows.Forms.DataGridView();
            this.dataGridViewSpecialty = new System.Windows.Forms.DataGridView();
            this.buttonSaveSpec = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonDelete2 = new System.Windows.Forms.Button();
            this.buttonAdd2 = new System.Windows.Forms.Button();
            this.buttonSave2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSpecialization)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSpecialty)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewSpecialization
            // 
            this.dataGridViewSpecialization.AllowUserToAddRows = false;
            this.dataGridViewSpecialization.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewSpecialization.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewSpecialization.BackgroundColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewSpecialization.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewSpecialization.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewSpecialization.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewSpecialization.Location = new System.Drawing.Point(12, 507);
            this.dataGridViewSpecialization.MultiSelect = false;
            this.dataGridViewSpecialization.Name = "dataGridViewSpecialization";
            this.dataGridViewSpecialization.Size = new System.Drawing.Size(798, 225);
            this.dataGridViewSpecialization.TabIndex = 3;
            this.dataGridViewSpecialization.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewSpecialty_CellEndEdit);
            this.dataGridViewSpecialization.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dataGridViewSpecialization_UserDeletingRow);
            // 
            // dataGridViewSpecialty
            // 
            this.dataGridViewSpecialty.AllowUserToAddRows = false;
            this.dataGridViewSpecialty.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewSpecialty.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewSpecialty.BackgroundColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewSpecialty.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewSpecialty.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewSpecialty.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewSpecialty.Location = new System.Drawing.Point(12, 76);
            this.dataGridViewSpecialty.MultiSelect = false;
            this.dataGridViewSpecialty.Name = "dataGridViewSpecialty";
            this.dataGridViewSpecialty.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewSpecialty.Size = new System.Drawing.Size(798, 277);
            this.dataGridViewSpecialty.TabIndex = 0;
            this.dataGridViewSpecialty.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewSpecialty_CellEndEdit);
            this.dataGridViewSpecialty.CurrentCellChanged += new System.EventHandler(this.dataGridViewSpecialty_CurrentCellChanged);
            this.dataGridViewSpecialty.SelectionChanged += new System.EventHandler(this.dataGridViewSpecialty_SelectionChanged);
            this.dataGridViewSpecialty.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dataGridViewSpecialty_UserDeletingRow);
            // 
            // buttonSaveSpec
            // 
            this.buttonSaveSpec.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.buttonSaveSpec.Location = new System.Drawing.Point(239, 6);
            this.buttonSaveSpec.Name = "buttonSaveSpec";
            this.buttonSaveSpec.Size = new System.Drawing.Size(150, 48);
            this.buttonSaveSpec.TabIndex = 4;
            this.buttonSaveSpec.Text = "Сохранить";
            this.buttonSaveSpec.UseVisualStyleBackColor = true;
            this.buttonSaveSpec.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.25F);
            this.buttonAdd.Location = new System.Drawing.Point(416, 6);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(64, 48);
            this.buttonAdd.TabIndex = 5;
            this.buttonAdd.Text = "+";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAddSpec1_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.25F);
            this.buttonDelete.Location = new System.Drawing.Point(496, 6);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(70, 48);
            this.buttonDelete.TabIndex = 6;
            this.buttonDelete.Text = "-";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonDelete2
            // 
            this.buttonDelete2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.25F);
            this.buttonDelete2.Location = new System.Drawing.Point(496, 39);
            this.buttonDelete2.Name = "buttonDelete2";
            this.buttonDelete2.Size = new System.Drawing.Size(70, 44);
            this.buttonDelete2.TabIndex = 9;
            this.buttonDelete2.Text = "-";
            this.buttonDelete2.UseVisualStyleBackColor = true;
            this.buttonDelete2.Click += new System.EventHandler(this.buttonDelete2_Click);
            // 
            // buttonAdd2
            // 
            this.buttonAdd2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.25F);
            this.buttonAdd2.Location = new System.Drawing.Point(409, 39);
            this.buttonAdd2.Name = "buttonAdd2";
            this.buttonAdd2.Size = new System.Drawing.Size(71, 44);
            this.buttonAdd2.TabIndex = 8;
            this.buttonAdd2.Text = "+";
            this.buttonAdd2.UseVisualStyleBackColor = true;
            this.buttonAdd2.Click += new System.EventHandler(this.buttonAdd2_Click);
            // 
            // buttonSave2
            // 
            this.buttonSave2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.buttonSave2.Location = new System.Drawing.Point(239, 39);
            this.buttonSave2.Name = "buttonSave2";
            this.buttonSave2.Size = new System.Drawing.Size(150, 44);
            this.buttonSave2.TabIndex = 7;
            this.buttonSave2.Text = "Сохранить";
            this.buttonSave2.UseVisualStyleBackColor = true;
            this.buttonSave2.Click += new System.EventHandler(this.buttonSaveSpec2_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label1.Location = new System.Drawing.Point(5, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(212, 20);
            this.label1.TabIndex = 10;
            this.label1.Text = "Список специальностей";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label2.Location = new System.Drawing.Point(3, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(202, 20);
            this.label2.TabIndex = 11;
            this.label2.Text = "Список специализаций";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.buttonSaveSpec);
            this.panel1.Controls.Add(this.buttonAdd);
            this.panel1.Controls.Add(this.buttonDelete);
            this.panel1.Location = new System.Drawing.Point(12, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(798, 64);
            this.panel1.TabIndex = 12;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.buttonDelete2);
            this.panel2.Controls.Add(this.buttonSave2);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.buttonAdd2);
            this.panel2.Location = new System.Drawing.Point(12, 405);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(798, 88);
            this.panel2.TabIndex = 13;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // FormSpecialty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(822, 744);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridViewSpecialization);
            this.Controls.Add(this.dataGridViewSpecialty);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormSpecialty";
            this.Text = "Специальности";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormSpecialty_FormClosing);
            this.Load += new System.EventHandler(this.FormSpecialty_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSpecialization)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSpecialty)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewSpecialization;
        private System.Windows.Forms.DataGridView dataGridViewSpecialty;
        private System.Windows.Forms.Button buttonSaveSpec;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonDelete2;
        private System.Windows.Forms.Button buttonAdd2;
        private System.Windows.Forms.Button buttonSave2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;

    }
}
namespace CompetenceInformationSystem
{
    partial class FormAssessmentCompetence
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAssessmentCompetence));
            this.labelSpec = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewCompetence = new System.Windows.Forms.DataGridView();
            this.Assessment = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewAssessment = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.richTextBoxState = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonStartAssessment = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCompetence)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAssessment)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelSpec
            // 
            this.labelSpec.AutoSize = true;
            this.labelSpec.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.labelSpec.Location = new System.Drawing.Point(12, 9);
            this.labelSpec.Name = "labelSpec";
            this.labelSpec.Size = new System.Drawing.Size(140, 20);
            this.labelSpec.TabIndex = 1;
            this.labelSpec.Text = "Специализация";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label1.Location = new System.Drawing.Point(12, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Список компетенций";
            // 
            // dataGridViewCompetence
            // 
            this.dataGridViewCompetence.AllowUserToAddRows = false;
            this.dataGridViewCompetence.AllowUserToDeleteRows = false;
            this.dataGridViewCompetence.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewCompetence.BackgroundColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewCompetence.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewCompetence.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCompetence.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Assessment});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewCompetence.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewCompetence.Location = new System.Drawing.Point(16, 65);
            this.dataGridViewCompetence.Name = "dataGridViewCompetence";
            this.dataGridViewCompetence.ReadOnly = true;
            this.dataGridViewCompetence.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridViewCompetence.Size = new System.Drawing.Size(865, 167);
            this.dataGridViewCompetence.TabIndex = 3;
            this.dataGridViewCompetence.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewCompetence_CellContentClick);
            // 
            // Assessment
            // 
            this.Assessment.HeaderText = "Оценить";
            this.Assessment.Name = "Assessment";
            this.Assessment.ReadOnly = true;
            this.Assessment.Width = 90;
            // 
            // dataGridViewAssessment
            // 
            this.dataGridViewAssessment.AllowUserToAddRows = false;
            this.dataGridViewAssessment.AllowUserToDeleteRows = false;
            this.dataGridViewAssessment.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewAssessment.BackgroundColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewAssessment.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewAssessment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewAssessment.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewAssessment.Location = new System.Drawing.Point(16, 353);
            this.dataGridViewAssessment.Name = "dataGridViewAssessment";
            this.dataGridViewAssessment.ReadOnly = true;
            this.dataGridViewAssessment.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridViewAssessment.Size = new System.Drawing.Size(885, 289);
            this.dataGridViewAssessment.TabIndex = 4;
            this.dataGridViewAssessment.CurrentCellChanged += new System.EventHandler(this.dataGridViewAssessment_CurrentCellChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label2.Location = new System.Drawing.Point(12, 316);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(350, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Оценка компетенций на данный момент";
            // 
            // richTextBoxState
            // 
            this.richTextBoxState.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxState.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.richTextBoxState.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.richTextBoxState.Location = new System.Drawing.Point(16, 681);
            this.richTextBoxState.Name = "richTextBoxState";
            this.richTextBoxState.ReadOnly = true;
            this.richTextBoxState.Size = new System.Drawing.Size(482, 99);
            this.richTextBoxState.TabIndex = 7;
            this.richTextBoxState.Text = "";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.buttonStartAssessment);
            this.panel1.Location = new System.Drawing.Point(16, 238);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(865, 66);
            this.panel1.TabIndex = 8;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.button2.Location = new System.Drawing.Point(3, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(144, 60);
            this.button2.TabIndex = 4;
            this.button2.Text = "Выделить все компетенции";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.button1.Location = new System.Drawing.Point(181, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(140, 60);
            this.button1.TabIndex = 3;
            this.button1.Text = "Сбросить все компетенции";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonStartAssessment
            // 
            this.buttonStartAssessment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonStartAssessment.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.buttonStartAssessment.Location = new System.Drawing.Point(385, 3);
            this.buttonStartAssessment.Name = "buttonStartAssessment";
            this.buttonStartAssessment.Size = new System.Drawing.Size(366, 60);
            this.buttonStartAssessment.TabIndex = 2;
            this.buttonStartAssessment.Text = "Оценить выбранные компетенции";
            this.buttonStartAssessment.UseVisualStyleBackColor = true;
            this.buttonStartAssessment.Click += new System.EventHandler(this.buttonStartAssessment_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label3.Location = new System.Drawing.Point(15, 658);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(193, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "Текущая информация";
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.button3.Location = new System.Drawing.Point(729, 708);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(172, 72);
            this.button3.TabIndex = 10;
            this.button3.Text = "Выход";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.buttonSave.Location = new System.Drawing.Point(531, 708);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(172, 72);
            this.buttonSave.TabIndex = 11;
            this.buttonSave.Text = "Сохранить в базе";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // FormAssessmentCompetence
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(913, 806);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.richTextBoxState);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridViewAssessment);
            this.Controls.Add(this.dataGridViewCompetence);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelSpec);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormAssessmentCompetence";
            this.Text = "Оценить компетенции";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormAssessmentCompetence_FormClosing);
            this.Load += new System.EventHandler(this.FormAssessmentCompetence_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCompetence)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAssessment)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelSpec;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridViewCompetence;
        private System.Windows.Forms.DataGridView dataGridViewAssessment;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox richTextBoxState;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonStartAssessment;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Assessment;
    }
}
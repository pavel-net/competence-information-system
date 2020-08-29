namespace CompetenceInformationSystem
{
    partial class FormGroupAndStudent
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGroupAndStudent));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dataGridViewGroup = new System.Windows.Forms.DataGridView();
            this.buttonSaveGroup = new System.Windows.Forms.Button();
            this.buttonDeleteGroup = new System.Windows.Forms.Button();
            this.buttonAddGroup = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.перевестиНаСледующийКурсToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выделеннуюГруппуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.всеГруппыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonАssessmentGroup = new System.Windows.Forms.Button();
            this.buttonАssessmentStudent = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonAddStudent = new System.Windows.Forms.Button();
            this.buttonSaveStudent = new System.Windows.Forms.Button();
            this.labelSpec = new System.Windows.Forms.Label();
            this.buttonDeleteStudent = new System.Windows.Forms.Button();
            this.labelGroup = new System.Windows.Forms.Label();
            this.dataGridViewStudent = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGroup)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStudent)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dataGridViewGroup);
            this.splitContainer1.Panel1.Controls.Add(this.buttonSaveGroup);
            this.splitContainer1.Panel1.Controls.Add(this.buttonDeleteGroup);
            this.splitContainer1.Panel1.Controls.Add(this.buttonAddGroup);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.menuStrip1);
            this.splitContainer1.Panel1MinSize = 200;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.buttonАssessmentGroup);
            this.splitContainer1.Panel2.Controls.Add(this.buttonАssessmentStudent);
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Panel2.Controls.Add(this.dataGridViewStudent);
            this.splitContainer1.Panel2MinSize = 300;
            this.splitContainer1.Size = new System.Drawing.Size(883, 653);
            this.splitContainer1.SplitterDistance = 371;
            this.splitContainer1.TabIndex = 0;
            // 
            // dataGridViewGroup
            // 
            this.dataGridViewGroup.AllowUserToAddRows = false;
            this.dataGridViewGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewGroup.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewGroup.BackgroundColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewGroup.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewGroup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewGroup.Location = new System.Drawing.Point(16, 112);
            this.dataGridViewGroup.Name = "dataGridViewGroup";
            this.dataGridViewGroup.ReadOnly = true;
            this.dataGridViewGroup.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewGroup.Size = new System.Drawing.Size(340, 479);
            this.dataGridViewGroup.TabIndex = 8;
            this.dataGridViewGroup.SelectionChanged += new System.EventHandler(this.dataGridViewGroup_SelectionChanged_1);
            this.dataGridViewGroup.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dataGridViewGroup_UserDeletingRow_1);
            // 
            // buttonSaveGroup
            // 
            this.buttonSaveGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSaveGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.buttonSaveGroup.Location = new System.Drawing.Point(19, 62);
            this.buttonSaveGroup.Name = "buttonSaveGroup";
            this.buttonSaveGroup.Size = new System.Drawing.Size(151, 42);
            this.buttonSaveGroup.TabIndex = 7;
            this.buttonSaveGroup.Text = "Сохранить";
            this.buttonSaveGroup.UseVisualStyleBackColor = true;
            this.buttonSaveGroup.Click += new System.EventHandler(this.buttonSaveGroup_Click);
            // 
            // buttonDeleteGroup
            // 
            this.buttonDeleteGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDeleteGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.25F);
            this.buttonDeleteGroup.Location = new System.Drawing.Point(286, 62);
            this.buttonDeleteGroup.Name = "buttonDeleteGroup";
            this.buttonDeleteGroup.Size = new System.Drawing.Size(70, 42);
            this.buttonDeleteGroup.TabIndex = 6;
            this.buttonDeleteGroup.Text = "-";
            this.buttonDeleteGroup.UseVisualStyleBackColor = true;
            this.buttonDeleteGroup.Click += new System.EventHandler(this.buttonDeleteGroup_Click);
            // 
            // buttonAddGroup
            // 
            this.buttonAddGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAddGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.25F);
            this.buttonAddGroup.Location = new System.Drawing.Point(196, 62);
            this.buttonAddGroup.Name = "buttonAddGroup";
            this.buttonAddGroup.Size = new System.Drawing.Size(71, 42);
            this.buttonAddGroup.TabIndex = 5;
            this.buttonAddGroup.Text = "+";
            this.buttonAddGroup.UseVisualStyleBackColor = true;
            this.buttonAddGroup.Click += new System.EventHandler(this.buttonAddGroup_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label1.Location = new System.Drawing.Point(15, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Список групп";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.перевестиНаСледующийКурсToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(371, 27);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // перевестиНаСледующийКурсToolStripMenuItem
            // 
            this.перевестиНаСледующийКурсToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.выделеннуюГруппуToolStripMenuItem,
            this.всеГруппыToolStripMenuItem});
            this.перевестиНаСледующийКурсToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.перевестиНаСледующийКурсToolStripMenuItem.Name = "перевестиНаСледующийКурсToolStripMenuItem";
            this.перевестиНаСледующийКурсToolStripMenuItem.Size = new System.Drawing.Size(216, 23);
            this.перевестиНаСледующийКурсToolStripMenuItem.Text = "Перевести на следующий курс";
            // 
            // выделеннуюГруппуToolStripMenuItem
            // 
            this.выделеннуюГруппуToolStripMenuItem.Name = "выделеннуюГруппуToolStripMenuItem";
            this.выделеннуюГруппуToolStripMenuItem.Size = new System.Drawing.Size(206, 24);
            this.выделеннуюГруппуToolStripMenuItem.Text = "Выделенную группу";
            this.выделеннуюГруппуToolStripMenuItem.Click += new System.EventHandler(this.выделеннуюГруппуToolStripMenuItem_Click);
            // 
            // всеГруппыToolStripMenuItem
            // 
            this.всеГруппыToolStripMenuItem.Name = "всеГруппыToolStripMenuItem";
            this.всеГруппыToolStripMenuItem.Size = new System.Drawing.Size(206, 24);
            this.всеГруппыToolStripMenuItem.Text = "Все группы";
            this.всеГруппыToolStripMenuItem.Click += new System.EventHandler(this.всеГруппыToolStripMenuItem_Click_1);
            // 
            // buttonАssessmentGroup
            // 
            this.buttonАssessmentGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonАssessmentGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.buttonАssessmentGroup.Location = new System.Drawing.Point(182, 528);
            this.buttonАssessmentGroup.Name = "buttonАssessmentGroup";
            this.buttonАssessmentGroup.Size = new System.Drawing.Size(309, 63);
            this.buttonАssessmentGroup.TabIndex = 4;
            this.buttonАssessmentGroup.Text = "Оценка компетенций";
            this.buttonАssessmentGroup.UseVisualStyleBackColor = true;
            this.buttonАssessmentGroup.Click += new System.EventHandler(this.buttonАssessmentGroup_Click);
            // 
            // buttonАssessmentStudent
            // 
            this.buttonАssessmentStudent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonАssessmentStudent.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.buttonАssessmentStudent.Location = new System.Drawing.Point(12, 528);
            this.buttonАssessmentStudent.Name = "buttonАssessmentStudent";
            this.buttonАssessmentStudent.Size = new System.Drawing.Size(146, 63);
            this.buttonАssessmentStudent.TabIndex = 3;
            this.buttonАssessmentStudent.Text = "Успеваемость слушателя";
            this.buttonАssessmentStudent.UseVisualStyleBackColor = true;
            this.buttonАssessmentStudent.Click += new System.EventHandler(this.buttonАssessmentStudent_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.buttonAddStudent);
            this.panel1.Controls.Add(this.buttonSaveStudent);
            this.panel1.Controls.Add(this.labelSpec);
            this.panel1.Controls.Add(this.buttonDeleteStudent);
            this.panel1.Controls.Add(this.labelGroup);
            this.panel1.Location = new System.Drawing.Point(12, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(479, 101);
            this.panel1.TabIndex = 2;
            // 
            // buttonAddStudent
            // 
            this.buttonAddStudent.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.25F);
            this.buttonAddStudent.Location = new System.Drawing.Point(281, 64);
            this.buttonAddStudent.Name = "buttonAddStudent";
            this.buttonAddStudent.Size = new System.Drawing.Size(73, 32);
            this.buttonAddStudent.TabIndex = 7;
            this.buttonAddStudent.Text = "+";
            this.buttonAddStudent.UseVisualStyleBackColor = true;
            this.buttonAddStudent.Click += new System.EventHandler(this.buttonAddStudent_Click_1);
            // 
            // buttonSaveStudent
            // 
            this.buttonSaveStudent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.buttonSaveStudent.Location = new System.Drawing.Point(117, 64);
            this.buttonSaveStudent.Name = "buttonSaveStudent";
            this.buttonSaveStudent.Size = new System.Drawing.Size(143, 32);
            this.buttonSaveStudent.TabIndex = 6;
            this.buttonSaveStudent.Text = "Сохранить";
            this.buttonSaveStudent.UseVisualStyleBackColor = true;
            this.buttonSaveStudent.Click += new System.EventHandler(this.buttonSaveStudent_Click);
            // 
            // labelSpec
            // 
            this.labelSpec.AutoSize = true;
            this.labelSpec.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.labelSpec.Location = new System.Drawing.Point(3, 38);
            this.labelSpec.Name = "labelSpec";
            this.labelSpec.Size = new System.Drawing.Size(145, 20);
            this.labelSpec.TabIndex = 5;
            this.labelSpec.Text = "Специализация:";
            // 
            // buttonDeleteStudent
            // 
            this.buttonDeleteStudent.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.25F);
            this.buttonDeleteStudent.Location = new System.Drawing.Point(376, 64);
            this.buttonDeleteStudent.Name = "buttonDeleteStudent";
            this.buttonDeleteStudent.Size = new System.Drawing.Size(72, 32);
            this.buttonDeleteStudent.TabIndex = 4;
            this.buttonDeleteStudent.Text = "-";
            this.buttonDeleteStudent.UseVisualStyleBackColor = true;
            this.buttonDeleteStudent.Click += new System.EventHandler(this.buttonDeleteStudent_Click);
            // 
            // labelGroup
            // 
            this.labelGroup.AutoSize = true;
            this.labelGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.labelGroup.Location = new System.Drawing.Point(3, 6);
            this.labelGroup.Name = "labelGroup";
            this.labelGroup.Size = new System.Drawing.Size(154, 20);
            this.labelGroup.TabIndex = 2;
            this.labelGroup.Text = "Название группы";
            // 
            // dataGridViewStudent
            // 
            this.dataGridViewStudent.AllowUserToAddRows = false;
            this.dataGridViewStudent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewStudent.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewStudent.BackgroundColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewStudent.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewStudent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewStudent.Location = new System.Drawing.Point(12, 112);
            this.dataGridViewStudent.Name = "dataGridViewStudent";
            this.dataGridViewStudent.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewStudent.Size = new System.Drawing.Size(479, 410);
            this.dataGridViewStudent.TabIndex = 1;
            this.dataGridViewStudent.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewStudent_CellEndEdit);
            this.dataGridViewStudent.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dataGridViewStudent_UserDeletingRow);
            // 
            // FormGroupAndStudent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(883, 653);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormGroupAndStudent";
            this.Text = "Учебные группы";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormGroupAndStudent_FormClosing);
            this.Load += new System.EventHandler(this.FormGroupAndStudent_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGroup)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStudent)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button buttonDeleteGroup;
        private System.Windows.Forms.Button buttonAddGroup;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonАssessmentGroup;
        private System.Windows.Forms.Button buttonАssessmentStudent;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonDeleteStudent;
        private System.Windows.Forms.Label labelGroup;
        private System.Windows.Forms.DataGridView dataGridViewStudent;
        private System.Windows.Forms.Label labelSpec;
        private System.Windows.Forms.Button buttonSaveStudent;
        private System.Windows.Forms.Button buttonSaveGroup;
        private System.Windows.Forms.DataGridView dataGridViewGroup;
        private System.Windows.Forms.Button buttonAddStudent;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem перевестиНаСледующийКурсToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выделеннуюГруппуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem всеГруппыToolStripMenuItem;
    }
}
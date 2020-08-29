namespace CompetenceInformationSystem
{
    partial class FormDisciplineAndCompetence
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDisciplineAndCompetence));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabDiscipline = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonSaveCompChosenDisp = new System.Windows.Forms.Button();
            this.buttonAddCompetenceToDiscip = new System.Windows.Forms.Button();
            this.buttonDelCompetenceFromDiscip = new System.Windows.Forms.Button();
            this.dataGridCompChosenDiscip = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.panelDiscipline = new System.Windows.Forms.Panel();
            this.buttonDeleteDis = new System.Windows.Forms.Button();
            this.buttonSaveDis = new System.Windows.Forms.Button();
            this.buttonAddDis = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewDiscip = new System.Windows.Forms.DataGridView();
            this.tabCompetence = new System.Windows.Forms.TabPage();
            this.buttonSaveDiscipChosenComp = new System.Windows.Forms.Button();
            this.dataGridDisciplineChosenCompetence = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.panelCompetence = new System.Windows.Forms.Panel();
            this.buttonDeleteComp = new System.Windows.Forms.Button();
            this.buttonSaveComp = new System.Windows.Forms.Button();
            this.buttonAddComp = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridViewComp = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabDiscipline.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCompChosenDiscip)).BeginInit();
            this.panelDiscipline.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDiscip)).BeginInit();
            this.tabCompetence.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDisciplineChosenCompetence)).BeginInit();
            this.panelCompetence.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewComp)).BeginInit();
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
            this.splitContainer1.Panel1.Controls.Add(this.treeView1);
            this.splitContainer1.Panel1MinSize = 50;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Panel2MinSize = 50;
            this.splitContainer1.Size = new System.Drawing.Size(974, 740);
            this.splitContainer1.SplitterDistance = 323;
            this.splitContainer1.TabIndex = 0;
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(323, 740);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabDiscipline);
            this.tabControl1.Controls.Add(this.tabCompetence);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(647, 740);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_TabIndexChanged);
            this.tabControl1.TabIndexChanged += new System.EventHandler(this.tabControl1_TabIndexChanged);
            // 
            // tabDiscipline
            // 
            this.tabDiscipline.Controls.Add(this.panel1);
            this.tabDiscipline.Controls.Add(this.dataGridCompChosenDiscip);
            this.tabDiscipline.Controls.Add(this.label3);
            this.tabDiscipline.Controls.Add(this.panelDiscipline);
            this.tabDiscipline.Controls.Add(this.label1);
            this.tabDiscipline.Controls.Add(this.dataGridViewDiscip);
            this.tabDiscipline.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.tabDiscipline.Location = new System.Drawing.Point(4, 29);
            this.tabDiscipline.Name = "tabDiscipline";
            this.tabDiscipline.Padding = new System.Windows.Forms.Padding(3);
            this.tabDiscipline.Size = new System.Drawing.Size(639, 707);
            this.tabDiscipline.TabIndex = 0;
            this.tabDiscipline.Text = "Дисциплины";
            this.tabDiscipline.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.buttonSaveCompChosenDisp);
            this.panel1.Controls.Add(this.buttonAddCompetenceToDiscip);
            this.panel1.Controls.Add(this.buttonDelCompetenceFromDiscip);
            this.panel1.Enabled = false;
            this.panel1.Location = new System.Drawing.Point(28, 642);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(603, 57);
            this.panel1.TabIndex = 15;
            // 
            // buttonSaveCompChosenDisp
            // 
            this.buttonSaveCompChosenDisp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.buttonSaveCompChosenDisp.Location = new System.Drawing.Point(264, 3);
            this.buttonSaveCompChosenDisp.Name = "buttonSaveCompChosenDisp";
            this.buttonSaveCompChosenDisp.Size = new System.Drawing.Size(133, 36);
            this.buttonSaveCompChosenDisp.TabIndex = 16;
            this.buttonSaveCompChosenDisp.Text = "Сохранить";
            this.buttonSaveCompChosenDisp.UseVisualStyleBackColor = true;
            this.buttonSaveCompChosenDisp.Click += new System.EventHandler(this.buttonSaveCompChosenDisp_Click);
            // 
            // buttonAddCompetenceToDiscip
            // 
            this.buttonAddCompetenceToDiscip.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.25F);
            this.buttonAddCompetenceToDiscip.Location = new System.Drawing.Point(425, 3);
            this.buttonAddCompetenceToDiscip.Name = "buttonAddCompetenceToDiscip";
            this.buttonAddCompetenceToDiscip.Size = new System.Drawing.Size(84, 36);
            this.buttonAddCompetenceToDiscip.TabIndex = 13;
            this.buttonAddCompetenceToDiscip.Text = "+";
            this.buttonAddCompetenceToDiscip.UseVisualStyleBackColor = true;
            this.buttonAddCompetenceToDiscip.Click += new System.EventHandler(this.buttonAddCompetenceToDiscip_Click);
            // 
            // buttonDelCompetenceFromDiscip
            // 
            this.buttonDelCompetenceFromDiscip.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.25F);
            this.buttonDelCompetenceFromDiscip.Location = new System.Drawing.Point(520, 3);
            this.buttonDelCompetenceFromDiscip.Name = "buttonDelCompetenceFromDiscip";
            this.buttonDelCompetenceFromDiscip.Size = new System.Drawing.Size(80, 36);
            this.buttonDelCompetenceFromDiscip.TabIndex = 14;
            this.buttonDelCompetenceFromDiscip.Text = "-";
            this.buttonDelCompetenceFromDiscip.UseVisualStyleBackColor = true;
            this.buttonDelCompetenceFromDiscip.Click += new System.EventHandler(this.buttonDelCompetenceFromDiscip_Click);
            // 
            // dataGridCompChosenDiscip
            // 
            this.dataGridCompChosenDiscip.AllowUserToAddRows = false;
            this.dataGridCompChosenDiscip.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridCompChosenDiscip.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridCompChosenDiscip.BackgroundColor = System.Drawing.Color.Silver;
            this.dataGridCompChosenDiscip.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridCompChosenDiscip.Location = new System.Drawing.Point(28, 434);
            this.dataGridCompChosenDiscip.Name = "dataGridCompChosenDiscip";
            this.dataGridCompChosenDiscip.ReadOnly = true;
            this.dataGridCompChosenDiscip.Size = new System.Drawing.Size(603, 202);
            this.dataGridCompChosenDiscip.TabIndex = 12;
            this.dataGridCompChosenDiscip.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dataGridCompChosenDiscip_UserDeletingRow);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label3.Location = new System.Drawing.Point(24, 396);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(230, 20);
            this.label3.TabIndex = 11;
            this.label3.Text = "Компетенции дисциплины";
            // 
            // panelDiscipline
            // 
            this.panelDiscipline.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelDiscipline.BackColor = System.Drawing.SystemColors.Control;
            this.panelDiscipline.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDiscipline.Controls.Add(this.buttonDeleteDis);
            this.panelDiscipline.Controls.Add(this.buttonSaveDis);
            this.panelDiscipline.Controls.Add(this.buttonAddDis);
            this.panelDiscipline.Enabled = false;
            this.panelDiscipline.Location = new System.Drawing.Point(28, 334);
            this.panelDiscipline.Name = "panelDiscipline";
            this.panelDiscipline.Size = new System.Drawing.Size(603, 59);
            this.panelDiscipline.TabIndex = 10;
            // 
            // buttonDeleteDis
            // 
            this.buttonDeleteDis.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.25F);
            this.buttonDeleteDis.Location = new System.Drawing.Point(520, 3);
            this.buttonDeleteDis.Name = "buttonDeleteDis";
            this.buttonDeleteDis.Size = new System.Drawing.Size(80, 36);
            this.buttonDeleteDis.TabIndex = 9;
            this.buttonDeleteDis.Text = "-";
            this.buttonDeleteDis.UseVisualStyleBackColor = true;
            this.buttonDeleteDis.Click += new System.EventHandler(this.buttonDeleteDis_Click);
            // 
            // buttonSaveDis
            // 
            this.buttonSaveDis.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.buttonSaveDis.Location = new System.Drawing.Point(264, 3);
            this.buttonSaveDis.Name = "buttonSaveDis";
            this.buttonSaveDis.Size = new System.Drawing.Size(133, 36);
            this.buttonSaveDis.TabIndex = 7;
            this.buttonSaveDis.Text = "Сохранить";
            this.buttonSaveDis.UseVisualStyleBackColor = true;
            this.buttonSaveDis.Click += new System.EventHandler(this.buttonSaveDis_Click);
            // 
            // buttonAddDis
            // 
            this.buttonAddDis.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.25F);
            this.buttonAddDis.Location = new System.Drawing.Point(425, 3);
            this.buttonAddDis.Name = "buttonAddDis";
            this.buttonAddDis.Size = new System.Drawing.Size(84, 36);
            this.buttonAddDis.TabIndex = 8;
            this.buttonAddDis.Text = "+";
            this.buttonAddDis.UseVisualStyleBackColor = true;
            this.buttonAddDis.Click += new System.EventHandler(this.buttonAddDis_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label1.Location = new System.Drawing.Point(24, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Список дисциплин";
            // 
            // dataGridViewDiscip
            // 
            this.dataGridViewDiscip.AllowUserToAddRows = false;
            this.dataGridViewDiscip.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewDiscip.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewDiscip.BackgroundColor = System.Drawing.Color.Silver;
            this.dataGridViewDiscip.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDiscip.Location = new System.Drawing.Point(28, 51);
            this.dataGridViewDiscip.Name = "dataGridViewDiscip";
            this.dataGridViewDiscip.Size = new System.Drawing.Size(603, 277);
            this.dataGridViewDiscip.TabIndex = 0;
            this.dataGridViewDiscip.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewDiscip_CellEndEdit);
            this.dataGridViewDiscip.CurrentCellChanged += new System.EventHandler(this.dataGridViewDiscip_CurrentCellChanged);
            this.dataGridViewDiscip.SelectionChanged += new System.EventHandler(this.dataGridViewDiscip_SelectionChanged);
            this.dataGridViewDiscip.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dataGridViewDiscip_UserDeletingRow);
            // 
            // tabCompetence
            // 
            this.tabCompetence.Controls.Add(this.buttonSaveDiscipChosenComp);
            this.tabCompetence.Controls.Add(this.dataGridDisciplineChosenCompetence);
            this.tabCompetence.Controls.Add(this.label4);
            this.tabCompetence.Controls.Add(this.panelCompetence);
            this.tabCompetence.Controls.Add(this.label2);
            this.tabCompetence.Controls.Add(this.dataGridViewComp);
            this.tabCompetence.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.tabCompetence.Location = new System.Drawing.Point(4, 29);
            this.tabCompetence.Name = "tabCompetence";
            this.tabCompetence.Padding = new System.Windows.Forms.Padding(3);
            this.tabCompetence.Size = new System.Drawing.Size(639, 707);
            this.tabCompetence.TabIndex = 1;
            this.tabCompetence.Text = "Компетенции";
            this.tabCompetence.UseVisualStyleBackColor = true;
            // 
            // buttonSaveDiscipChosenComp
            // 
            this.buttonSaveDiscipChosenComp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSaveDiscipChosenComp.Enabled = false;
            this.buttonSaveDiscipChosenComp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.buttonSaveDiscipChosenComp.Location = new System.Drawing.Point(30, 636);
            this.buttonSaveDiscipChosenComp.Name = "buttonSaveDiscipChosenComp";
            this.buttonSaveDiscipChosenComp.Size = new System.Drawing.Size(251, 44);
            this.buttonSaveDiscipChosenComp.TabIndex = 15;
            this.buttonSaveDiscipChosenComp.Text = "Сохранить";
            this.buttonSaveDiscipChosenComp.UseVisualStyleBackColor = true;
            this.buttonSaveDiscipChosenComp.Click += new System.EventHandler(this.buttonSaveDiscipChosenComp_Click);
            // 
            // dataGridDisciplineChosenCompetence
            // 
            this.dataGridDisciplineChosenCompetence.AllowUserToAddRows = false;
            this.dataGridDisciplineChosenCompetence.AllowUserToDeleteRows = false;
            this.dataGridDisciplineChosenCompetence.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridDisciplineChosenCompetence.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridDisciplineChosenCompetence.BackgroundColor = System.Drawing.Color.Silver;
            this.dataGridDisciplineChosenCompetence.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridDisciplineChosenCompetence.Location = new System.Drawing.Point(30, 387);
            this.dataGridDisciplineChosenCompetence.Name = "dataGridDisciplineChosenCompetence";
            this.dataGridDisciplineChosenCompetence.Size = new System.Drawing.Size(577, 232);
            this.dataGridDisciplineChosenCompetence.TabIndex = 14;
            this.dataGridDisciplineChosenCompetence.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridDisciplineChosenCompetence_CellEndEdit);
            this.dataGridDisciplineChosenCompetence.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridDisciplineChosenCompetence_DataError);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label4.Location = new System.Drawing.Point(24, 364);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(229, 20);
            this.label4.TabIndex = 12;
            this.label4.Text = "Выберите специализацию";
            // 
            // panelCompetence
            // 
            this.panelCompetence.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelCompetence.BackColor = System.Drawing.SystemColors.Control;
            this.panelCompetence.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCompetence.Controls.Add(this.buttonDeleteComp);
            this.panelCompetence.Controls.Add(this.buttonSaveComp);
            this.panelCompetence.Controls.Add(this.buttonAddComp);
            this.panelCompetence.Enabled = false;
            this.panelCompetence.Location = new System.Drawing.Point(28, 297);
            this.panelCompetence.Name = "panelCompetence";
            this.panelCompetence.Size = new System.Drawing.Size(579, 49);
            this.panelCompetence.TabIndex = 10;
            // 
            // buttonDeleteComp
            // 
            this.buttonDeleteComp.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.25F);
            this.buttonDeleteComp.Location = new System.Drawing.Point(497, 3);
            this.buttonDeleteComp.Name = "buttonDeleteComp";
            this.buttonDeleteComp.Size = new System.Drawing.Size(79, 33);
            this.buttonDeleteComp.TabIndex = 9;
            this.buttonDeleteComp.Text = "-";
            this.buttonDeleteComp.UseVisualStyleBackColor = true;
            this.buttonDeleteComp.Click += new System.EventHandler(this.buttonDeleteComp_Click);
            // 
            // buttonSaveComp
            // 
            this.buttonSaveComp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.buttonSaveComp.Location = new System.Drawing.Point(194, 0);
            this.buttonSaveComp.Name = "buttonSaveComp";
            this.buttonSaveComp.Size = new System.Drawing.Size(176, 36);
            this.buttonSaveComp.TabIndex = 7;
            this.buttonSaveComp.Text = "Сохранить";
            this.buttonSaveComp.UseVisualStyleBackColor = true;
            this.buttonSaveComp.Click += new System.EventHandler(this.buttonSaveComp_Click);
            // 
            // buttonAddComp
            // 
            this.buttonAddComp.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.25F);
            this.buttonAddComp.Location = new System.Drawing.Point(390, 3);
            this.buttonAddComp.Name = "buttonAddComp";
            this.buttonAddComp.Size = new System.Drawing.Size(88, 33);
            this.buttonAddComp.TabIndex = 8;
            this.buttonAddComp.Text = "+";
            this.buttonAddComp.UseVisualStyleBackColor = true;
            this.buttonAddComp.Click += new System.EventHandler(this.buttonAddComp_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label2.Location = new System.Drawing.Point(24, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Компетенции";
            // 
            // dataGridViewComp
            // 
            this.dataGridViewComp.AllowUserToAddRows = false;
            this.dataGridViewComp.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewComp.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewComp.BackgroundColor = System.Drawing.Color.Silver;
            this.dataGridViewComp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewComp.Location = new System.Drawing.Point(28, 52);
            this.dataGridViewComp.Name = "dataGridViewComp";
            this.dataGridViewComp.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewComp.Size = new System.Drawing.Size(579, 239);
            this.dataGridViewComp.TabIndex = 2;
            this.dataGridViewComp.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewComp_CellEndEdit);
            this.dataGridViewComp.CurrentCellChanged += new System.EventHandler(this.dataGridViewComp_CurrentCellChanged);
            this.dataGridViewComp.SelectionChanged += new System.EventHandler(this.dataGridViewComp_SelectionChanged);
            this.dataGridViewComp.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dataGridViewComp_UserDeletingRow);
            // 
            // FormDisciplineAndCompetence
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(974, 740);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormDisciplineAndCompetence";
            this.Text = "Дисциплины и компетенции";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormDisciplineAndCompetence_FormClosing);
            this.Load += new System.EventHandler(this.FormDisciplineAndCompetence_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabDiscipline.ResumeLayout(false);
            this.tabDiscipline.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCompChosenDiscip)).EndInit();
            this.panelDiscipline.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDiscip)).EndInit();
            this.tabCompetence.ResumeLayout(false);
            this.tabCompetence.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDisciplineChosenCompetence)).EndInit();
            this.panelCompetence.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewComp)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabDiscipline;
        private System.Windows.Forms.TabPage tabCompetence;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridViewDiscip;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridViewComp;
        private System.Windows.Forms.Button buttonDeleteDis;
        private System.Windows.Forms.Button buttonAddDis;
        private System.Windows.Forms.Button buttonSaveDis;
        private System.Windows.Forms.Button buttonDeleteComp;
        private System.Windows.Forms.Button buttonAddComp;
        private System.Windows.Forms.Button buttonSaveComp;
        private System.Windows.Forms.Panel panelDiscipline;
        private System.Windows.Forms.Panel panelCompetence;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonAddCompetenceToDiscip;
        private System.Windows.Forms.Button buttonDelCompetenceFromDiscip;
        private System.Windows.Forms.DataGridView dataGridCompChosenDiscip;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonSaveCompChosenDisp;
        private System.Windows.Forms.DataGridView dataGridDisciplineChosenCompetence;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonSaveDiscipChosenComp;
    }
}
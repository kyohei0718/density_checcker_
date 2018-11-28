namespace density_checcker2
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.exe = new System.Windows.Forms.Button();
            this.ReadFile = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ファイルFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.開くOToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clear = new System.Windows.Forms.Button();
            this.WriteFile = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.splitsize = new System.Windows.Forms.TextBox();
            this.pointmax = new System.Windows.Forms.TextBox();
            this.pointaverage = new System.Windows.Forms.TextBox();
            this.memory = new System.Windows.Forms.TextBox();
            this.exetime = new System.Windows.Forms.TextBox();
            this.localconsole = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // exe
            // 
            this.exe.Location = new System.Drawing.Point(58, 192);
            this.exe.Name = "exe";
            this.exe.Size = new System.Drawing.Size(75, 23);
            this.exe.TabIndex = 0;
            this.exe.Text = "exe";
            this.exe.UseVisualStyleBackColor = true;
            this.exe.Click += new System.EventHandler(this.exe_Click);
            // 
            // ReadFile
            // 
            this.ReadFile.Location = new System.Drawing.Point(103, 25);
            this.ReadFile.Name = "ReadFile";
            this.ReadFile.Size = new System.Drawing.Size(306, 19);
            this.ReadFile.TabIndex = 1;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Multiselect = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ファイルFToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(421, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ファイルFToolStripMenuItem
            // 
            this.ファイルFToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.開くOToolStripMenuItem});
            this.ファイルFToolStripMenuItem.Name = "ファイルFToolStripMenuItem";
            this.ファイルFToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.ファイルFToolStripMenuItem.Text = "ファイル(&F)";
            // 
            // 開くOToolStripMenuItem
            // 
            this.開くOToolStripMenuItem.Name = "開くOToolStripMenuItem";
            this.開くOToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.開くOToolStripMenuItem.Text = "開く(&O)";
            this.開くOToolStripMenuItem.Click += new System.EventHandler(this.開くOToolStripMenuItem_Click);
            // 
            // clear
            // 
            this.clear.Location = new System.Drawing.Point(297, 192);
            this.clear.Name = "clear";
            this.clear.Size = new System.Drawing.Size(75, 23);
            this.clear.TabIndex = 3;
            this.clear.Text = "clear";
            this.clear.UseVisualStyleBackColor = true;
            this.clear.Click += new System.EventHandler(this.clear_Click);
            // 
            // WriteFile
            // 
            this.WriteFile.Location = new System.Drawing.Point(103, 49);
            this.WriteFile.Name = "WriteFile";
            this.WriteFile.Size = new System.Drawing.Size(306, 19);
            this.WriteFile.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "読み込みファイル";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "書き込みファイル";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "分割サイズ(mm)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "最大点数";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 9;
            this.label5.Text = "平均点数";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 141);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 10;
            this.label6.Text = "メモリ使用量";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 162);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 11;
            this.label7.Text = "実行時間";
            // 
            // splitsize
            // 
            this.splitsize.Location = new System.Drawing.Point(102, 71);
            this.splitsize.Name = "splitsize";
            this.splitsize.Size = new System.Drawing.Size(54, 19);
            this.splitsize.TabIndex = 12;
            // 
            // pointmax
            // 
            this.pointmax.Location = new System.Drawing.Point(79, 96);
            this.pointmax.Name = "pointmax";
            this.pointmax.ReadOnly = true;
            this.pointmax.Size = new System.Drawing.Size(89, 19);
            this.pointmax.TabIndex = 13;
            // 
            // pointaverage
            // 
            this.pointaverage.Location = new System.Drawing.Point(79, 117);
            this.pointaverage.Name = "pointaverage";
            this.pointaverage.ReadOnly = true;
            this.pointaverage.Size = new System.Drawing.Size(89, 19);
            this.pointaverage.TabIndex = 14;
            // 
            // memory
            // 
            this.memory.Location = new System.Drawing.Point(79, 138);
            this.memory.Name = "memory";
            this.memory.ReadOnly = true;
            this.memory.Size = new System.Drawing.Size(89, 19);
            this.memory.TabIndex = 15;
            // 
            // exetime
            // 
            this.exetime.Location = new System.Drawing.Point(79, 159);
            this.exetime.Name = "exetime";
            this.exetime.ReadOnly = true;
            this.exetime.Size = new System.Drawing.Size(89, 19);
            this.exetime.TabIndex = 16;
            // 
            // localconsole
            // 
            this.localconsole.Location = new System.Drawing.Point(174, 96);
            this.localconsole.Multiline = true;
            this.localconsole.Name = "localconsole";
            this.localconsole.ReadOnly = true;
            this.localconsole.Size = new System.Drawing.Size(235, 82);
            this.localconsole.TabIndex = 17;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 227);
            this.Controls.Add(this.localconsole);
            this.Controls.Add(this.exetime);
            this.Controls.Add(this.memory);
            this.Controls.Add(this.pointaverage);
            this.Controls.Add(this.pointmax);
            this.Controls.Add(this.splitsize);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.WriteFile);
            this.Controls.Add(this.clear);
            this.Controls.Add(this.ReadFile);
            this.Controls.Add(this.exe);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button exe;
        private System.Windows.Forms.TextBox ReadFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ファイルFToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 開くOToolStripMenuItem;
        private System.Windows.Forms.Button clear;
        private System.Windows.Forms.TextBox WriteFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox pointaverage;
        private System.Windows.Forms.TextBox memory;
        private System.Windows.Forms.TextBox exetime;
        private System.Windows.Forms.TextBox localconsole;
        public System.Windows.Forms.TextBox splitsize;
        public System.Windows.Forms.TextBox pointmax;
    }
}


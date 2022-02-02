namespace Lab5
{
    partial class Form3
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.формаПредставленияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.бинарнаяToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.основнаяToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 27);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(802, 373);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(368, 415);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Далее";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.формаПредставленияToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(816, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // формаПредставленияToolStripMenuItem
            // 
            this.формаПредставленияToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.бинарнаяToolStripMenuItem,
            this.основнаяToolStripMenuItem});
            this.формаПредставленияToolStripMenuItem.Name = "формаПредставленияToolStripMenuItem";
            this.формаПредставленияToolStripMenuItem.Size = new System.Drawing.Size(142, 20);
            this.формаПредставленияToolStripMenuItem.Text = "Форма представления";
            // 
            // бинарнаяToolStripMenuItem
            // 
            this.бинарнаяToolStripMenuItem.Name = "бинарнаяToolStripMenuItem";
            this.бинарнаяToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.бинарнаяToolStripMenuItem.Text = "Бинарная";
            this.бинарнаяToolStripMenuItem.Click += new System.EventHandler(this.бинарнаяToolStripMenuItem_Click);
            // 
            // основнаяToolStripMenuItem
            // 
            this.основнаяToolStripMenuItem.Name = "основнаяToolStripMenuItem";
            this.основнаяToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.основнаяToolStripMenuItem.Text = "Основная";
            this.основнаяToolStripMenuItem.Click += new System.EventHandler(this.основнаяToolStripMenuItem_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(816, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form3";
            this.Text = "Входная матрица";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem формаПредставленияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem бинарнаяToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem основнаяToolStripMenuItem;
    }
}
using System;
using System.Drawing;
using System.Windows.Forms;

namespace IHSUniversities
{
    partial class AdminMainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminMainForm));
            this.panelMain = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.labelForNameU = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.удалитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.labelBuffDormitory = new System.Windows.Forms.Label();
            this.labelForFIt = new System.Windows.Forms.Label();
            this.labelForSIt = new System.Windows.Forms.Label();
            this.labelForExIt = new System.Windows.Forms.Label();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBoxSearch = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBoxPersonalArea = new System.Windows.Forms.PictureBox();
            this.pictureBoxBuffDormitory = new System.Windows.Forms.PictureBox();
            this.pictureBoxForSIt = new System.Windows.Forms.PictureBox();
            this.pictureBoxForFIt = new System.Windows.Forms.PictureBox();
            this.pictureBoxForExIt = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPersonalArea)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBuffDormitory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxForSIt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxForFIt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxForExIt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.pictureBox2);
            this.panelMain.Controls.Add(this.label2);
            this.panelMain.Controls.Add(this.pictureBox3);
            this.panelMain.Controls.Add(this.comboBox1);
            this.panelMain.Controls.Add(this.labelForNameU);
            this.panelMain.Controls.Add(this.dataGridView1);
            this.panelMain.Controls.Add(this.pictureBoxSearch);
            this.panelMain.Controls.Add(this.textBox1);
            this.panelMain.Controls.Add(this.pictureBox1);
            this.panelMain.Controls.Add(this.pictureBoxPersonalArea);
            this.panelMain.Location = new System.Drawing.Point(-3, -2);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1661, 1034);
            this.panelMain.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(136)))), ((int)(((byte)(193)))));
            this.label2.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(55, 235);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(378, 38);
            this.label2.TabIndex = 18;
            this.label2.Text = "Сохранить изменения";
            this.label2.Visible = false;
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(167)))), ((int)(((byte)(229)))));
            this.comboBox1.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.comboBox1.ForeColor = System.Drawing.SystemColors.Window;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "ВУЗов",
            "Факультетов",
            "Специальностей"});
            this.comboBox1.Location = new System.Drawing.Point(328, 136);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(349, 46);
            this.comboBox1.TabIndex = 13;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // labelForNameU
            // 
            this.labelForNameU.AutoSize = true;
            this.labelForNameU.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(88)))), ((int)(((byte)(130)))));
            this.labelForNameU.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelForNameU.ForeColor = System.Drawing.Color.White;
            this.labelForNameU.Location = new System.Drawing.Point(29, 136);
            this.labelForNameU.Name = "labelForNameU";
            this.labelForNameU.Size = new System.Drawing.Size(284, 38);
            this.labelForNameU.TabIndex = 12;
            this.labelForNameU.Text = "Таблица данны:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(136)))), ((int)(((byte)(193)))));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Location = new System.Drawing.Point(34, 374);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 102;
            this.dataGridView1.RowTemplate.Height = 40;
            this.dataGridView1.Size = new System.Drawing.Size(1605, 629);
            this.dataGridView1.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.удалитьToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(205, 52);
            // 
            // удалитьToolStripMenuItem
            // 
            this.удалитьToolStripMenuItem.Name = "удалитьToolStripMenuItem";
            this.удалитьToolStripMenuItem.Size = new System.Drawing.Size(204, 48);
            this.удалитьToolStripMenuItem.Text = "Удалить";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(195)))), ((int)(((byte)(245)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("MS Reference Sans Serif", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.ForeColor = System.Drawing.SystemColors.Window;
            this.textBox1.Location = new System.Drawing.Point(62, 44);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(1324, 33);
            this.textBox1.TabIndex = 0;
            // 
            // labelBuffDormitory
            // 
            this.labelBuffDormitory.AutoSize = true;
            this.labelBuffDormitory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(88)))), ((int)(((byte)(130)))));
            this.labelBuffDormitory.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.900001F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelBuffDormitory.ForeColor = System.Drawing.Color.White;
            this.labelBuffDormitory.Location = new System.Drawing.Point(40, 89);
            this.labelBuffDormitory.Name = "labelBuffDormitory";
            this.labelBuffDormitory.Size = new System.Drawing.Size(102, 49);
            this.labelBuffDormitory.TabIndex = 11;
            this.labelBuffDormitory.Text = "ВУЗ";
            // 
            // labelForFIt
            // 
            this.labelForFIt.AutoSize = true;
            this.labelForFIt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(107)))), ((int)(((byte)(158)))));
            this.labelForFIt.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.900001F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelForFIt.ForeColor = System.Drawing.Color.White;
            this.labelForFIt.Location = new System.Drawing.Point(99, 633);
            this.labelForFIt.Name = "labelForFIt";
            this.labelForFIt.Size = new System.Drawing.Size(232, 42);
            this.labelForFIt.TabIndex = 18;
            this.labelForFIt.Text = "Факультет1";
            // 
            // labelForSIt
            // 
            this.labelForSIt.Location = new System.Drawing.Point(0, 0);
            this.labelForSIt.Name = "labelForSIt";
            this.labelForSIt.Size = new System.Drawing.Size(100, 23);
            this.labelForSIt.TabIndex = 0;
            // 
            // labelForExIt
            // 
            this.labelForExIt.Location = new System.Drawing.Point(0, 0);
            this.labelForExIt.Name = "labelForExIt";
            this.labelForExIt.Size = new System.Drawing.Size(100, 23);
            this.labelForExIt.TabIndex = 0;
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(61, 4);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::IHSUniversities.Properties.Resources.sf;
            this.pictureBox3.Location = new System.Drawing.Point(31, 220);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(432, 80);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 17;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Visible = false;
            // 
            // pictureBoxSearch
            // 
            this.pictureBoxSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(195)))), ((int)(((byte)(245)))));
            this.pictureBoxSearch.Image = global::IHSUniversities.Properties.Resources.loupe;
            this.pictureBoxSearch.Location = new System.Drawing.Point(1411, 40);
            this.pictureBoxSearch.Name = "pictureBoxSearch";
            this.pictureBoxSearch.Size = new System.Drawing.Size(40, 40);
            this.pictureBoxSearch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxSearch.TabIndex = 4;
            this.pictureBoxSearch.TabStop = false;
            this.pictureBoxSearch.Click += new System.EventHandler(this.pictureBox4_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(88)))), ((int)(((byte)(130)))));
            this.pictureBox1.Image = global::IHSUniversities.Properties.Resources.searh_field;
            this.pictureBox1.Location = new System.Drawing.Point(34, 25);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1435, 69);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBoxPersonalArea
            // 
            this.pictureBoxPersonalArea.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(88)))), ((int)(((byte)(130)))));
            this.pictureBoxPersonalArea.Image = global::IHSUniversities.Properties.Resources.user;
            this.pictureBoxPersonalArea.Location = new System.Drawing.Point(1485, 25);
            this.pictureBoxPersonalArea.Name = "pictureBoxPersonalArea";
            this.pictureBoxPersonalArea.Size = new System.Drawing.Size(69, 69);
            this.pictureBoxPersonalArea.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxPersonalArea.TabIndex = 1;
            this.pictureBoxPersonalArea.TabStop = false;
            this.pictureBoxPersonalArea.Click += new System.EventHandler(this.pictureBoxPersonalArea_Click);
            // 
            // pictureBoxBuffDormitory
            // 
            this.pictureBoxBuffDormitory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(117)))), ((int)(((byte)(159)))));
            this.pictureBoxBuffDormitory.Image = global::IHSUniversities.Properties.Resources.Buff;
            this.pictureBoxBuffDormitory.Location = new System.Drawing.Point(38, 510);
            this.pictureBoxBuffDormitory.Name = "pictureBoxBuffDormitory";
            this.pictureBoxBuffDormitory.Size = new System.Drawing.Size(850, 75);
            this.pictureBoxBuffDormitory.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxBuffDormitory.TabIndex = 6;
            this.pictureBoxBuffDormitory.TabStop = false;
            this.pictureBoxBuffDormitory.UseWaitCursor = true;
            // 
            // pictureBoxForSIt
            // 
            this.pictureBoxForSIt.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxForSIt.Name = "pictureBoxForSIt";
            this.pictureBoxForSIt.Size = new System.Drawing.Size(100, 50);
            this.pictureBoxForSIt.TabIndex = 0;
            this.pictureBoxForSIt.TabStop = false;
            // 
            // pictureBoxForFIt
            // 
            this.pictureBoxForFIt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(117)))), ((int)(((byte)(159)))));
            this.pictureBoxForFIt.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxForFIt.Image")));
            this.pictureBoxForFIt.Location = new System.Drawing.Point(76, 625);
            this.pictureBoxForFIt.Name = "pictureBoxForFIt";
            this.pictureBoxForFIt.Size = new System.Drawing.Size(822, 67);
            this.pictureBoxForFIt.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxForFIt.TabIndex = 17;
            this.pictureBoxForFIt.TabStop = false;
            this.pictureBoxForFIt.UseWaitCursor = true;
            // 
            // pictureBoxForExIt
            // 
            this.pictureBoxForExIt.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxForExIt.Name = "pictureBoxForExIt";
            this.pictureBoxForExIt.Size = new System.Drawing.Size(100, 50);
            this.pictureBoxForExIt.TabIndex = 0;
            this.pictureBoxForExIt.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(88)))), ((int)(((byte)(130)))));
            this.pictureBox2.Image = global::IHSUniversities.Properties.Resources.question_mark;
            this.pictureBox2.Location = new System.Drawing.Point(1570, 25);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(69, 69);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 19;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // AdminMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(88)))), ((int)(((byte)(130)))));
            this.ClientSize = new System.Drawing.Size(1659, 1029);
            this.Controls.Add(this.panelMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MinimumSize = new System.Drawing.Size(1691, 1041);
            this.Name = "AdminMainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ИСС для поиска специальностей";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPersonalArea)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBuffDormitory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxForSIt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxForFIt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxForExIt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }


        #endregion

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBoxPersonalArea;
        private System.Windows.Forms.PictureBox pictureBoxSearch;
        private System.Windows.Forms.Label labelForFIt;
        private System.Windows.Forms.PictureBox pictureBoxForFIt;
        private System.Windows.Forms.Label labelForSIt;
        private System.Windows.Forms.PictureBox pictureBoxForSIt;
        private System.Windows.Forms.Label labelBuffDormitory;
        private PictureBox pictureBoxBuffDormitory;
        private Label labelForExIt;
        private PictureBox pictureBoxForExIt;
        private DataGridView dataGridView1;
        private Label labelForNameU;
        private ComboBox comboBox1;
        private Label label2;
        private PictureBox pictureBox3;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem удалитьToolStripMenuItem;
        private ContextMenuStrip contextMenuStrip2;
        private PictureBox pictureBox2;
    }
}


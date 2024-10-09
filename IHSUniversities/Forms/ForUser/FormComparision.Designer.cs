using System;
using System.Drawing;
using System.Windows.Forms;

namespace IHSUniversities
{
    partial class FormComparision
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
            this.labelP = new System.Windows.Forms.Label();
            this.labelNS = new System.Windows.Forms.Label();
            this.labelEx1 = new System.Windows.Forms.Label();
            this.labelEx2 = new System.Windows.Forms.Label();
            this.labelEx3 = new System.Windows.Forms.Label();
            this.labelD = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.labelEx = new System.Windows.Forms.Label();
            this.pictureBoxEx = new System.Windows.Forms.PictureBox();
            this.panelMain = new System.Windows.Forms.Panel();
            this.labelUn = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEx)).BeginInit();
            this.panelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelP
            // 
            this.labelP.AutoSize = true;
            this.labelP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(88)))), ((int)(((byte)(130)))));
            this.labelP.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelP.ForeColor = System.Drawing.Color.White;
            this.labelP.Location = new System.Drawing.Point(921, 10);
            this.labelP.Name = "labelP";
            this.labelP.Size = new System.Drawing.Size(227, 76);
            this.labelP.TabIndex = 13;
            this.labelP.Text = "Колличество\r\nбаллов";
            this.labelP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelNS
            // 
            this.labelNS.AutoSize = true;
            this.labelNS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(88)))), ((int)(((byte)(130)))));
            this.labelNS.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelNS.ForeColor = System.Drawing.Color.White;
            this.labelNS.Location = new System.Drawing.Point(442, 27);
            this.labelNS.Name = "labelNS";
            this.labelNS.Size = new System.Drawing.Size(431, 38);
            this.labelNS.TabIndex = 11;
            this.labelNS.Text = "Название специальности";
            this.labelNS.UseWaitCursor = true;
            // 
            // labelEx1
            // 
            this.labelEx1.AutoSize = true;
            this.labelEx1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(88)))), ((int)(((byte)(130)))));
            this.labelEx1.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelEx1.ForeColor = System.Drawing.Color.White;
            this.labelEx1.Location = new System.Drawing.Point(1165, 27);
            this.labelEx1.Name = "labelEx1";
            this.labelEx1.Size = new System.Drawing.Size(182, 38);
            this.labelEx1.TabIndex = 14;
            this.labelEx1.Text = "1 экзамен";
            // 
            // labelEx2
            // 
            this.labelEx2.AutoSize = true;
            this.labelEx2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(88)))), ((int)(((byte)(130)))));
            this.labelEx2.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelEx2.ForeColor = System.Drawing.Color.White;
            this.labelEx2.Location = new System.Drawing.Point(1402, 27);
            this.labelEx2.Name = "labelEx2";
            this.labelEx2.Size = new System.Drawing.Size(182, 38);
            this.labelEx2.TabIndex = 15;
            this.labelEx2.Text = "2 экзамен";
            // 
            // labelEx3
            // 
            this.labelEx3.AutoSize = true;
            this.labelEx3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(88)))), ((int)(((byte)(130)))));
            this.labelEx3.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelEx3.ForeColor = System.Drawing.Color.White;
            this.labelEx3.Location = new System.Drawing.Point(1652, 27);
            this.labelEx3.Name = "labelEx3";
            this.labelEx3.Size = new System.Drawing.Size(182, 38);
            this.labelEx3.TabIndex = 16;
            this.labelEx3.Text = "3 экзамен";
            // 
            // labelD
            // 
            this.labelD.AutoSize = true;
            this.labelD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(88)))), ((int)(((byte)(130)))));
            this.labelD.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelD.ForeColor = System.Drawing.Color.White;
            this.labelD.Location = new System.Drawing.Point(1878, 27);
            this.labelD.Name = "labelD";
            this.labelD.Size = new System.Drawing.Size(208, 38);
            this.labelD.TabIndex = 17;
            this.labelD.Text = "Общежитие";
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Gray;
            this.pictureBox3.Location = new System.Drawing.Point(3, 99);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(2126, 2);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 19;
            this.pictureBox3.TabStop = false;
            // 
            // labelEx
            // 
            this.labelEx.AutoSize = true;
            this.labelEx.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(117)))), ((int)(((byte)(159)))));
            this.labelEx.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.900001F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelEx.ForeColor = System.Drawing.Color.White;
            this.labelEx.Location = new System.Drawing.Point(93, 112);
            this.labelEx.Name = "labelEx";
            this.labelEx.Size = new System.Drawing.Size(864, 42);
            this.labelEx.TabIndex = 0;
            this.labelEx.Text = "Нету ни одной специальности для сравнения";
            // 
            // pictureBoxEx
            // 
            this.pictureBoxEx.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(88)))), ((int)(((byte)(130)))));
            this.pictureBoxEx.Image = global::IHSUniversities.Properties.Resources.Rectangle_18;
            this.pictureBoxEx.Location = new System.Drawing.Point(62, 83);
            this.pictureBoxEx.Name = "pictureBoxEx";
            this.pictureBoxEx.Size = new System.Drawing.Size(1495, 117);
            this.pictureBoxEx.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxEx.TabIndex = 0;
            this.pictureBoxEx.TabStop = false;
            // 
            // panelMain
            // 
            this.panelMain.AutoScroll = true;
            this.panelMain.Controls.Add(this.labelUn);
            this.panelMain.Controls.Add(this.labelEx2);
            this.panelMain.Controls.Add(this.pictureBox3);
            this.panelMain.Controls.Add(this.labelD);
            this.panelMain.Controls.Add(this.labelEx3);
            this.panelMain.Controls.Add(this.labelEx1);
            this.panelMain.Controls.Add(this.labelP);
            this.panelMain.Controls.Add(this.labelNS);
            this.panelMain.Location = new System.Drawing.Point(-3, -2);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(2129, 961);
            this.panelMain.TabIndex = 0;
            // 
            // labelUn
            // 
            this.labelUn.AutoSize = true;
            this.labelUn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(88)))), ((int)(((byte)(130)))));
            this.labelUn.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelUn.ForeColor = System.Drawing.Color.White;
            this.labelUn.Location = new System.Drawing.Point(26, 27);
            this.labelUn.Name = "labelUn";
            this.labelUn.Size = new System.Drawing.Size(77, 38);
            this.labelUn.TabIndex = 20;
            this.labelUn.Text = "ВУЗ";
            // 
            // FormComparision
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(88)))), ((int)(((byte)(130)))));
            this.ClientSize = new System.Drawing.Size(2127, 953);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.labelEx);
            this.Controls.Add(this.pictureBoxEx);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximumSize = new System.Drawing.Size(2159, 1041);
            this.MinimumSize = new System.Drawing.Size(2159, 1041);
            this.Name = "FormComparision";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Список сравнения";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEx)).EndInit();
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private Label labelP;
        private Label labelNS;
        private Label labelEx1;
        private Label labelEx2;
        private Label labelEx3;
        private Label labelD;
        private PictureBox pictureBox3;
        private Panel panelMain;
        private PictureBox pictureBoxEx;
        private Label labelEx;
        private Label labelUn;
    }
}


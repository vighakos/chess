
namespace chess
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.black_min = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.black_sec = new System.Windows.Forms.Label();
            this.nextPlayerLbl = new System.Windows.Forms.Label();
            this.white_sec = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.white_min = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.Timer_tick);
            // 
            // black_min
            // 
            this.black_min.Font = new System.Drawing.Font("Microsoft YaHei", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.black_min.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.black_min.Location = new System.Drawing.Point(596, 25);
            this.black_min.Name = "black_min";
            this.black_min.Size = new System.Drawing.Size(38, 28);
            this.black_min.TabIndex = 0;
            this.black_min.Text = "10";
            this.black_min.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(628, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 28);
            this.label2.TabIndex = 1;
            this.label2.Text = ":";
            // 
            // black_sec
            // 
            this.black_sec.Font = new System.Drawing.Font("Microsoft YaHei", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.black_sec.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.black_sec.Location = new System.Drawing.Point(640, 25);
            this.black_sec.Name = "black_sec";
            this.black_sec.Size = new System.Drawing.Size(38, 28);
            this.black_sec.TabIndex = 2;
            this.black_sec.Text = "00";
            this.black_sec.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // nextPlayerLbl
            // 
            this.nextPlayerLbl.Font = new System.Drawing.Font("Microsoft YaHei", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.nextPlayerLbl.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.nextPlayerLbl.Location = new System.Drawing.Point(596, 283);
            this.nextPlayerLbl.Name = "nextPlayerLbl";
            this.nextPlayerLbl.Size = new System.Drawing.Size(426, 28);
            this.nextPlayerLbl.TabIndex = 3;
            this.nextPlayerLbl.Text = "Fehér játékos következik";
            this.nextPlayerLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // white_sec
            // 
            this.white_sec.Font = new System.Drawing.Font("Microsoft YaHei", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.white_sec.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.white_sec.Location = new System.Drawing.Point(640, 545);
            this.white_sec.Name = "white_sec";
            this.white_sec.Size = new System.Drawing.Size(38, 28);
            this.white_sec.TabIndex = 6;
            this.white_sec.Text = "00";
            this.white_sec.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(628, 543);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 28);
            this.label3.TabIndex = 5;
            this.label3.Text = ":";
            // 
            // white_min
            // 
            this.white_min.Font = new System.Drawing.Font("Microsoft YaHei", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.white_min.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.white_min.Location = new System.Drawing.Point(596, 545);
            this.white_min.Name = "white_min";
            this.white_min.Size = new System.Drawing.Size(38, 28);
            this.white_min.TabIndex = 4;
            this.white_min.Text = "10";
            this.white_min.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1034, 601);
            this.Controls.Add(this.white_sec);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.white_min);
            this.Controls.Add(this.nextPlayerLbl);
            this.Controls.Add(this.black_sec);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.black_min);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sakk :|";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label black_min;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label black_sec;
        private System.Windows.Forms.Label nextPlayerLbl;
        private System.Windows.Forms.Label white_sec;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label white_min;
    }
}


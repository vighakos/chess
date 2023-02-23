
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.minLbl = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.secLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // minLbl
            // 
            this.minLbl.AutoSize = true;
            this.minLbl.Font = new System.Drawing.Font("Microsoft YaHei", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.minLbl.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.minLbl.Location = new System.Drawing.Point(614, 23);
            this.minLbl.Name = "minLbl";
            this.minLbl.Size = new System.Drawing.Size(38, 28);
            this.minLbl.TabIndex = 0;
            this.minLbl.Text = "00";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(646, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 28);
            this.label2.TabIndex = 1;
            this.label2.Text = ":";
            // 
            // secLbl
            // 
            this.secLbl.AutoSize = true;
            this.secLbl.Font = new System.Drawing.Font("Microsoft YaHei", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.secLbl.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.secLbl.Location = new System.Drawing.Point(658, 23);
            this.secLbl.Name = "secLbl";
            this.secLbl.Size = new System.Drawing.Size(38, 28);
            this.secLbl.TabIndex = 2;
            this.secLbl.Text = "00";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.secLbl);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.minLbl);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label minLbl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label secLbl;
    }
}


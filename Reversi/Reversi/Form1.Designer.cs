namespace Reversi
{
    partial class Reversi
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblTurn = new System.Windows.Forms.Label();
            this.lblBTokens = new System.Windows.Forms.Label();
            this.lblBCounter = new System.Windows.Forms.Label();
            this.lblWTokens = new System.Windows.Forms.Label();
            this.lblWCounter = new System.Windows.Forms.Label();
            this.btnRestart = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.ForestGreen;
            this.pictureBox1.Location = new System.Drawing.Point(12, 47);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(327, 327);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            // 
            // lblTurn
            // 
            this.lblTurn.AutoSize = true;
            this.lblTurn.BackColor = System.Drawing.Color.Black;
            this.lblTurn.Font = new System.Drawing.Font("Microsoft YaHei UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTurn.ForeColor = System.Drawing.Color.White;
            this.lblTurn.Location = new System.Drawing.Point(101, 9);
            this.lblTurn.Name = "lblTurn";
            this.lblTurn.Size = new System.Drawing.Size(150, 35);
            this.lblTurn.TabIndex = 1;
            this.lblTurn.Text = "Black Turn";
            // 
            // lblBTokens
            // 
            this.lblBTokens.AutoSize = true;
            this.lblBTokens.Location = new System.Drawing.Point(258, 9);
            this.lblBTokens.Name = "lblBTokens";
            this.lblBTokens.Size = new System.Drawing.Size(37, 13);
            this.lblBTokens.TabIndex = 2;
            this.lblBTokens.Text = "Black:";
            // 
            // lblBCounter
            // 
            this.lblBCounter.AutoSize = true;
            this.lblBCounter.Location = new System.Drawing.Point(301, 9);
            this.lblBCounter.Name = "lblBCounter";
            this.lblBCounter.Size = new System.Drawing.Size(13, 13);
            this.lblBCounter.TabIndex = 3;
            this.lblBCounter.Text = "2";
            // 
            // lblWTokens
            // 
            this.lblWTokens.AutoSize = true;
            this.lblWTokens.Location = new System.Drawing.Point(258, 26);
            this.lblWTokens.Name = "lblWTokens";
            this.lblWTokens.Size = new System.Drawing.Size(38, 13);
            this.lblWTokens.TabIndex = 4;
            this.lblWTokens.Text = "White:";
            // 
            // lblWCounter
            // 
            this.lblWCounter.AutoSize = true;
            this.lblWCounter.Location = new System.Drawing.Point(301, 26);
            this.lblWCounter.Name = "lblWCounter";
            this.lblWCounter.Size = new System.Drawing.Size(13, 13);
            this.lblWCounter.TabIndex = 5;
            this.lblWCounter.Text = "2";
            // 
            // btnRestart
            // 
            this.btnRestart.Location = new System.Drawing.Point(12, 9);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(83, 35);
            this.btnRestart.TabIndex = 6;
            this.btnRestart.Text = "New Game";
            this.btnRestart.UseVisualStyleBackColor = true;
            this.btnRestart.Click += new System.EventHandler(this.btnRestart_Click);
            // 
            // Reversi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(351, 384);
            this.Controls.Add(this.btnRestart);
            this.Controls.Add(this.lblWCounter);
            this.Controls.Add(this.lblWTokens);
            this.Controls.Add(this.lblBCounter);
            this.Controls.Add(this.lblBTokens);
            this.Controls.Add(this.lblTurn);
            this.Controls.Add(this.pictureBox1);
            this.MaximizeBox = false;
            this.Name = "Reversi";
            this.Text = "Reversi";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblTurn;
        private System.Windows.Forms.Label lblBTokens;
        private System.Windows.Forms.Label lblBCounter;
        private System.Windows.Forms.Label lblWTokens;
        private System.Windows.Forms.Label lblWCounter;
        private System.Windows.Forms.Button btnRestart;
    }
}


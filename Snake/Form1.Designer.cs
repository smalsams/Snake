namespace Snake
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Gameboard = new System.Windows.Forms.PictureBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.LevelLabel = new System.Windows.Forms.Label();
            this.level = new System.Windows.Forms.Label();
            this.ModeLabel = new System.Windows.Forms.Label();
            this.mode = new System.Windows.Forms.Label();
            this.GOsign = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            ((System.ComponentModel.ISupportInitialize)(this.Gameboard)).BeginInit();
            this.SuspendLayout();
            // 
            // Gameboard
            // 
            this.Gameboard.BackColor = System.Drawing.Color.Cyan;
            this.Gameboard.Location = new System.Drawing.Point(9, 9);
            this.Gameboard.Name = "Gameboard";
            this.Gameboard.Size = new System.Drawing.Size(600, 600);
            this.Gameboard.TabIndex = 0;
            this.Gameboard.TabStop = false;
            this.Gameboard.Paint += new System.Windows.Forms.PaintEventHandler(this.Draw);
            // 
            // LevelLabel
            // 
            this.LevelLabel.AutoSize = true;
            this.LevelLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LevelLabel.Location = new System.Drawing.Point(650, 40);
            this.LevelLabel.Name = "LevelLabel";
            this.LevelLabel.Size = new System.Drawing.Size(66, 28);
            this.LevelLabel.TabIndex = 1;
            this.LevelLabel.Text = "Level:";
            // 
            // level
            // 
            this.level.AutoSize = true;
            this.level.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.level.Location = new System.Drawing.Point(728, 40);
            this.level.Name = "level";
            this.level.Size = new System.Drawing.Size(24, 28);
            this.level.TabIndex = 2;
            this.level.Text = "1";
            // 
            // ModeLabel
            // 
            this.ModeLabel.AutoSize = true;
            this.ModeLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ModeLabel.Location = new System.Drawing.Point(650, 80);
            this.ModeLabel.Name = "ModeLabel";
            this.ModeLabel.Size = new System.Drawing.Size(71, 28);
            this.ModeLabel.TabIndex = 3;
            this.ModeLabel.Text = "Mode:";
            // 
            // mode
            // 
            this.mode.AutoSize = true;
            this.mode.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.mode.Location = new System.Drawing.Point(728, 80);
            this.mode.Name = "mode";
            this.mode.Size = new System.Drawing.Size(71, 28);
            this.mode.TabIndex = 4;
            this.mode.Text = "Player";
            // 
            // GOsign
            // 
            this.GOsign.AutoSize = true;
            this.GOsign.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.GOsign.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.GOsign.ForeColor = System.Drawing.Color.Black;
            this.GOsign.Location = new System.Drawing.Point(215, 268);
            this.GOsign.Name = "GOsign";
            this.GOsign.Size = new System.Drawing.Size(159, 37);
            this.GOsign.TabIndex = 5;
            this.GOsign.Text = "Game Over";
            this.GOsign.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(638, 150);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(245, 35);
            this.label1.TabIndex = 6;
            this.label1.Text = "Press SPACE to Play";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(627, 185);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(270, 30);
            this.label2.TabIndex = 7;
            this.label2.Text = "Press M to change Mode";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(697, 245);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 30);
            this.label3.TabIndex = 8;
            this.label3.Text = "W -> UP";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(687, 289);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 30);
            this.label4.TabIndex = 9;
            this.label4.Text = "A -> LEFT";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(665, 330);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(134, 30);
            this.label5.TabIndex = 10;
            this.label5.Text = "S -> DOWN";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(666, 377);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(133, 30);
            this.label6.TabIndex = 11;
            this.label6.Text = "D -> RIGHT";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(900, 650);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.GOsign);
            this.Controls.Add(this.mode);
            this.Controls.Add(this.ModeLabel);
            this.Controls.Add(this.level);
            this.Controls.Add(this.LevelLabel);
            this.Controls.Add(this.Gameboard);
            this.Name = "Form1";
            this.Text = "SnakeAI";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyPush);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyRelease);
            ((System.ComponentModel.ISupportInitialize)(this.Gameboard)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox Gameboard;
        private System.Windows.Forms.Timer timer;
        private Label LevelLabel;
        private Label level;
        private Label ModeLabel;
        private Label mode;
        private Label GOsign;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private FontDialog fontDialog1;
    }
}
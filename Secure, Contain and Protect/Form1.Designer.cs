namespace Secure__Contain_and_Protect
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.agent = new System.Windows.Forms.PictureBox();
            this.zombie = new System.Windows.Forms.PictureBox();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.floor = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.agent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zombie)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.floor)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Bahnschrift SemiBold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(47, 557);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Kills: 0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Bahnschrift SemiBold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(271, 557);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Health:";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(364, 557);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(307, 25);
            this.progressBar1.TabIndex = 2;
            // 
            // agent
            // 
            this.agent.BackColor = System.Drawing.Color.Transparent;
            this.agent.Image = global::Secure__Contain_and_Protect.Properties.Resources.agent_idle_right;
            this.agent.Location = new System.Drawing.Point(381, 381);
            this.agent.Name = "agent";
            this.agent.Size = new System.Drawing.Size(128, 128);
            this.agent.TabIndex = 3;
            this.agent.TabStop = false;
            this.agent.Tag = "agent";
            // 
            // zombie
            // 
            this.zombie.BackColor = System.Drawing.Color.Transparent;
            this.zombie.Image = global::Secure__Contain_and_Protect.Properties.Resources.zombie_static_right;
            this.zombie.Location = new System.Drawing.Point(12, 349);
            this.zombie.Name = "zombie";
            this.zombie.Size = new System.Drawing.Size(160, 160);
            this.zombie.TabIndex = 4;
            this.zombie.TabStop = false;
            this.zombie.Tag = "zombie";
            // 
            // gameTimer
            // 
            this.gameTimer.Enabled = true;
            this.gameTimer.Interval = 20;
            this.gameTimer.Tick += new System.EventHandler(this.gameEngine);
            // 
            // floor
            // 
            this.floor.BackColor = System.Drawing.Color.Transparent;
            this.floor.Location = new System.Drawing.Point(0, 511);
            this.floor.Name = "floor";
            this.floor.Size = new System.Drawing.Size(960, 40);
            this.floor.TabIndex = 5;
            this.floor.TabStop = false;
            this.floor.Tag = "floor";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Secure__Contain_and_Protect.Properties.Resources.city_background_5;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(944, 601);
            this.Controls.Add(this.agent);
            this.Controls.Add(this.zombie);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.floor);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Secure, Contain and Protect";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.keyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.keyUp);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.agent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zombie)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.floor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.PictureBox agent;
        private System.Windows.Forms.PictureBox zombie;
        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.PictureBox floor;
    }
}


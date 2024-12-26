namespace Need_for_Speed___Hot_Pursuit_2010_Trainer
{
    partial class MainForm
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
            lblTrainerStatus = new Label();
            btnHPToggle = new Button();
            label1 = new Label();
            btnTakedownToggle = new Button();
            label2 = new Label();
            lblHPStatus = new Label();
            lblTakedownStatus = new Label();
            btnNitroToggle = new Button();
            label3 = new Label();
            lblFullNitro = new Label();
            btnBotsNoNitro = new Button();
            lblBotsNoNitro = new Label();
            label5 = new Label();
            SuspendLayout();
            // 
            // lblTrainerStatus
            // 
            lblTrainerStatus.AutoSize = true;
            lblTrainerStatus.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTrainerStatus.Location = new Point(12, 9);
            lblTrainerStatus.Name = "lblTrainerStatus";
            lblTrainerStatus.Size = new Size(175, 15);
            lblTrainerStatus.TabIndex = 0;
            lblTrainerStatus.Text = "Trainer NOT attached to game";
            // 
            // btnHPToggle
            // 
            btnHPToggle.Location = new Point(172, 27);
            btnHPToggle.Name = "btnHPToggle";
            btnHPToggle.Size = new Size(75, 23);
            btnHPToggle.TabIndex = 1;
            btnHPToggle.Text = "Toggle";
            btnHPToggle.UseVisualStyleBackColor = true;
            btnHPToggle.Click += btnHPToggle_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 31);
            label1.Name = "label1";
            label1.Size = new Size(78, 15);
            label1.TabIndex = 2;
            label1.Text = "Unlimited HP";
            // 
            // btnTakedownToggle
            // 
            btnTakedownToggle.Location = new Point(172, 56);
            btnTakedownToggle.Name = "btnTakedownToggle";
            btnTakedownToggle.Size = new Size(75, 23);
            btnTakedownToggle.TabIndex = 3;
            btnTakedownToggle.Text = "Toggle";
            btnTakedownToggle.UseVisualStyleBackColor = true;
            btnTakedownToggle.Click += btnTakedownToggle_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 60);
            label2.Name = "label2";
            label2.Size = new Size(99, 15);
            label2.TabIndex = 4;
            label2.Text = "Instant Takedown";
            // 
            // lblHPStatus
            // 
            lblHPStatus.AutoSize = true;
            lblHPStatus.Location = new Point(253, 31);
            lblHPStatus.Name = "lblHPStatus";
            lblHPStatus.Size = new Size(28, 15);
            lblHPStatus.TabIndex = 5;
            lblHPStatus.Text = "OFF";
            // 
            // lblTakedownStatus
            // 
            lblTakedownStatus.AutoSize = true;
            lblTakedownStatus.Location = new Point(253, 60);
            lblTakedownStatus.Name = "lblTakedownStatus";
            lblTakedownStatus.Size = new Size(28, 15);
            lblTakedownStatus.TabIndex = 6;
            lblTakedownStatus.Text = "OFF";
            // 
            // btnNitroToggle
            // 
            btnNitroToggle.Location = new Point(172, 85);
            btnNitroToggle.Name = "btnNitroToggle";
            btnNitroToggle.Size = new Size(75, 23);
            btnNitroToggle.TabIndex = 7;
            btnNitroToggle.Text = "Toggle";
            btnNitroToggle.UseVisualStyleBackColor = true;
            btnNitroToggle.Click += btnNitroToggle_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 89);
            label3.Name = "label3";
            label3.Size = new Size(56, 15);
            label3.TabIndex = 8;
            label3.Text = "Full Nitro";
            // 
            // lblFullNitro
            // 
            lblFullNitro.AutoSize = true;
            lblFullNitro.Location = new Point(253, 89);
            lblFullNitro.Name = "lblFullNitro";
            lblFullNitro.Size = new Size(28, 15);
            lblFullNitro.TabIndex = 9;
            lblFullNitro.Text = "OFF";
            // 
            // btnBotsNoNitro
            // 
            btnBotsNoNitro.Location = new Point(172, 114);
            btnBotsNoNitro.Name = "btnBotsNoNitro";
            btnBotsNoNitro.Size = new Size(75, 23);
            btnBotsNoNitro.TabIndex = 10;
            btnBotsNoNitro.Text = "Toggle";
            btnBotsNoNitro.UseVisualStyleBackColor = true;
            btnBotsNoNitro.Click += btnBotsNoNitro_Click;
            // 
            // lblBotsNoNitro
            // 
            lblBotsNoNitro.AutoSize = true;
            lblBotsNoNitro.Location = new Point(253, 118);
            lblBotsNoNitro.Name = "lblBotsNoNitro";
            lblBotsNoNitro.Size = new Size(28, 15);
            lblBotsNoNitro.TabIndex = 11;
            lblBotsNoNitro.Text = "OFF";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 118);
            label5.Name = "label5";
            label5.Size = new Size(107, 15);
            label5.TabIndex = 12;
            label5.Text = "Bots With No Nitro";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(465, 152);
            Controls.Add(label5);
            Controls.Add(lblBotsNoNitro);
            Controls.Add(btnBotsNoNitro);
            Controls.Add(lblFullNitro);
            Controls.Add(label3);
            Controls.Add(btnNitroToggle);
            Controls.Add(lblTakedownStatus);
            Controls.Add(lblHPStatus);
            Controls.Add(label2);
            Controls.Add(btnTakedownToggle);
            Controls.Add(label1);
            Controls.Add(btnHPToggle);
            Controls.Add(lblTrainerStatus);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MainForm";
            Text = "Need for Speed Hot Pursuit 2010 Trainer";
            FormClosing += MainForm_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTrainerStatus;
        private Button btnHPToggle;
        private Label label1;
        private Button btnTakedownToggle;
        private Label label2;
        private Label lblHPStatus;
        private Label lblTakedownStatus;
        private Button btnNitroToggle;
        private Label label3;
        private Label lblFullNitro;
        private Button btnBotsNoNitro;
        private Label lblBotsNoNitro;
        private Label label5;
    }
}

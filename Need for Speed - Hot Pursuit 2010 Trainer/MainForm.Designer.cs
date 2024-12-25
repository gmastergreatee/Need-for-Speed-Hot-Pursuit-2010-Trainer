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
            btnAttach = new Button();
            SuspendLayout();
            // 
            // lblTrainerStatus
            // 
            lblTrainerStatus.AutoSize = true;
            lblTrainerStatus.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTrainerStatus.Location = new Point(12, 16);
            lblTrainerStatus.Name = "lblTrainerStatus";
            lblTrainerStatus.Size = new Size(175, 15);
            lblTrainerStatus.TabIndex = 0;
            lblTrainerStatus.Text = "Trainer NOT attached to game";
            // 
            // btnAttach
            // 
            btnAttach.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAttach.Location = new Point(351, 12);
            btnAttach.Name = "btnAttach";
            btnAttach.Size = new Size(75, 23);
            btnAttach.TabIndex = 1;
            btnAttach.Text = "Load";
            btnAttach.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(438, 319);
            Controls.Add(btnAttach);
            Controls.Add(lblTrainerStatus);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form1";
            Text = "Need for Speed Hot Pursuit 2010 Trainer";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTrainerStatus;
        private Button btnAttach;
    }
}

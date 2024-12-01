namespace betulMayin
{
    partial class Form2
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
            lblUser = new Label();
            lblTime = new Label();
            lblYapan = new Label();
            lblHamle = new Label();
            button1 = new Button();
            SuspendLayout();
            // 
            // lblUser
            // 
            lblUser.AutoSize = true;
            lblUser.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblUser.Location = new Point(1336, 79);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(89, 20);
            lblUser.TabIndex = 0;
            lblUser.Text = "Oyuncu Adı";
            // 
            // lblTime
            // 
            lblTime.AutoSize = true;
            lblTime.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblTime.Location = new Point(1336, 37);
            lblTime.Name = "lblTime";
            lblTime.Size = new Size(47, 25);
            lblTime.TabIndex = 1;
            lblTime.Text = "süre";
            // 
            // lblYapan
            // 
            lblYapan.AutoSize = true;
            lblYapan.Font = new Font("Arial", 7.8F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblYapan.ForeColor = Color.IndianRed;
            lblYapan.Location = new Point(1282, 336);
            lblYapan.Name = "lblYapan";
            lblYapan.Size = new Size(148, 16);
            lblYapan.TabIndex = 2;
            lblYapan.Text = "230229034-Betül EREN ";
            lblYapan.TextAlign = ContentAlignment.BottomCenter;
            // 
            // lblHamle
            // 
            lblHamle.AutoSize = true;
            lblHamle.Location = new Point(1336, 121);
            lblHamle.Name = "lblHamle";
            lblHamle.Size = new Size(94, 20);
            lblHamle.TabIndex = 3;
            lblHamle.Text = "Hamle Sayısı";
            // 
            // button1
            // 
            button1.BackColor = Color.PaleVioletRed;
            button1.BackgroundImageLayout = ImageLayout.None;
            button1.Location = new Point(1328, 166);
            button1.Margin = new Padding(100);
            button1.Name = "button1";
            button1.Size = new Size(102, 39);
            button1.TabIndex = 10;
            button1.Text = "Skorboard";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LavenderBlush;
            ClientSize = new Size(1582, 753);
            Controls.Add(button1);
            Controls.Add(lblHamle);
            Controls.Add(lblYapan);
            Controls.Add(lblTime);
            Controls.Add(lblUser);
            MaximumSize = new Size(1600, 1000);
            Name = "Form2";
            Text = "230229034- Betül EREN";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblUser;
        private Label lblTime;
        private Label lblYapan;
        private Label lblHamle;
        private Button button1;
    }
}
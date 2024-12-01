namespace betulMayin
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
            lblAd = new Label();
            lblMayin = new Label();
            lblGrid = new Label();
            txtAd = new TextBox();
            numMayin = new NumericUpDown();
            numGrid = new NumericUpDown();
            butonOyun = new Button();
            ((System.ComponentModel.ISupportInitialize)numMayin).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numGrid).BeginInit();
            SuspendLayout();
            // 
            // lblAd
            // 
            lblAd.AutoSize = true;
            lblAd.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblAd.Location = new Point(209, 47);
            lblAd.Name = "lblAd";
            lblAd.Size = new Size(89, 20);
            lblAd.TabIndex = 0;
            lblAd.Text = "Oyuncu Adı";
            // 
            // lblMayin
            // 
            lblMayin.AutoSize = true;
            lblMayin.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblMayin.Location = new Point(209, 108);
            lblMayin.Name = "lblMayin";
            lblMayin.Size = new Size(95, 20);
            lblMayin.TabIndex = 1;
            lblMayin.Text = "Mayın Sayısı";
            // 
            // lblGrid
            // 
            lblGrid.AutoSize = true;
            lblGrid.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblGrid.Location = new Point(209, 172);
            lblGrid.Name = "lblGrid";
            lblGrid.Size = new Size(81, 20);
            lblGrid.TabIndex = 2;
            lblGrid.Text = "Grid Sayısı";
            // 
            // txtAd
            // 
            txtAd.Location = new Point(383, 46);
            txtAd.Name = "txtAd";
            txtAd.Size = new Size(150, 27);
            txtAd.TabIndex = 3;
            // 
            // numMayin
            // 
            numMayin.Location = new Point(383, 106);
            numMayin.Name = "numMayin";
            numMayin.Size = new Size(150, 27);
            numMayin.TabIndex = 4;
            // 
            // numGrid
            // 
            numGrid.Location = new Point(383, 172);
            numGrid.Name = "numGrid";
            numGrid.Size = new Size(150, 27);
            numGrid.TabIndex = 5;
            // 
            // butonOyun
            // 
            butonOyun.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            butonOyun.Location = new Point(269, 307);
            butonOyun.Margin = new Padding(30);
            butonOyun.Name = "butonOyun";
            butonOyun.Size = new Size(193, 66);
            butonOyun.TabIndex = 6;
            butonOyun.Text = "Oyuna Başla\r\n";
            butonOyun.UseVisualStyleBackColor = true;
            butonOyun.Click += butonOyun_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LavenderBlush;
            BackgroundImage = Image.FromFile("C:\\Users\\hp\\source\\repos\\betulMayin\\betulMayin\\leopink.jpeg");
            ClientSize = new Size(800, 450);
            Controls.Add(butonOyun);
            Controls.Add(numGrid);
            Controls.Add(numMayin);
            Controls.Add(txtAd);
            Controls.Add(lblGrid);
            Controls.Add(lblMayin);
            Controls.Add(lblAd);
            Name = "Form1";
            Text = "Mayın Tarlası                                       Betül EREN";
            ((System.ComponentModel.ISupportInitialize)numMayin).EndInit();
            ((System.ComponentModel.ISupportInitialize)numGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblAd;
        private Label lblMayin;
        private Label lblGrid;
        private TextBox txtAd;
        private NumericUpDown numMayin;
        private NumericUpDown numGrid;
        private Button butonOyun;
    }
}

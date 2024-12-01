namespace betulMayin
{
    partial class Form3
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
            skorListesi = new ListBox();
            btnYenile = new Button();
            lblSkorlar = new Label();
            SuspendLayout();
            // 
            // skorListesi
            // 
            skorListesi.BackColor = Color.LightPink;
            skorListesi.FormattingEnabled = true;
            skorListesi.Location = new Point(92, 85);
            skorListesi.Name = "skorListesi";
            skorListesi.Size = new Size(487, 344);
            skorListesi.TabIndex = 0;
            // 
            // btnYenile
            // 
            btnYenile.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnYenile.Location = new Point(630, 361);
            btnYenile.Margin = new Padding(80);
            btnYenile.Name = "btnYenile";
            btnYenile.Size = new Size(147, 47);
            btnYenile.TabIndex = 2;
            btnYenile.Text = "Yeniden Başla";
            btnYenile.UseVisualStyleBackColor = true;
            btnYenile.Click += btnYenile_Click;
            // 
            // lblSkorlar
            // 
            lblSkorlar.AutoSize = true;
            lblSkorlar.Location = new Point(117, 154);
            lblSkorlar.Name = "lblSkorlar";
            lblSkorlar.Size = new Size(36, 20);
            lblSkorlar.TabIndex = 5;
            lblSkorlar.Text = "liste";
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LavenderBlush;
            ClientSize = new Size(800, 450);
            Controls.Add(lblSkorlar);
            Controls.Add(btnYenile);
            Controls.Add(skorListesi);
            Name = "Form3";
            Text = "Skor Listesi";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblSkorlar;
    }
}
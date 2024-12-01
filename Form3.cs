using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace betulMayin
{
    public partial class Form3 : Form
    {
        private string enIyiSkorlarMesaji;

        public Form3(string skorBilgisi)
        {
            InitializeComponent();
            this.enIyiSkorlarMesaji = skorBilgisi; // Parametreyi sınıf değişkenine atıyoruz
            lblSkorlar.Text = this.enIyiSkorlarMesaji;

            
            string[] skorSatirlari = enIyiSkorlarMesaji.Split('\n');

        }

        private ListBox skorListesi;
        private Button btnYenile;
        private Skorboard skorboard;

        public void SkorGoruntulemeFormu(Skorboard skorboard)
        {
            this.skorboard = skorboard;

            Text = "En İyi 10 Skor";
            Size = new Size(300, 450);

            // Yenile Button
            btnYenile = new Button
            {
                Text = "Yenile",
                Dock = DockStyle.Left
            };
            btnYenile.Click += (sender, e) => SkorlariYukle();
            Controls.Add(btnYenile);
            {
                this.Close(); // Form3'ü kapat
            };
            Controls.Add(btnYenile);

            SkorlariYukle();
        }

        private void SkorlariYukle()
        {
            
            //skorListesi.Items.Clear();

            var enIyiSkorlar = skorboard.GetirEnIyiSkorlar();
            int sira = 1;

            foreach (var skor in enIyiSkorlar)
            {
                string skorMetni = $"{sira}. {skor}";
                if (!skorListesi.Items.Contains(skorMetni))
                {
                    skorListesi.Items.Add(skorMetni);
                }
                sira++;
            }
            skorListesi.Items.Clear();
        }

        private void btnYenile_Click(object sender, EventArgs e)
        {
            
            this.Close(); // Form3'ü kapat
        }
    }
}
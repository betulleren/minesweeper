namespace betulMayin
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);
        }

        private void butonOyun_Click(object sender, EventArgs e)
        {
            string oyuncuAdi = txtAd.Text;
            int mayinSayisi = (int)numMayin.Value;
            int gridSayisi = (int)numGrid.Value;
            Form2 form2 = new Form2(oyuncuAdi, mayinSayisi, gridSayisi);
            form2.Show();

            if (mayinSayisi < 10)
            {
                MessageBox.Show("En az 10 mayın girmelisiniz.");
                return;
            }

            if (gridSayisi >= 30)
            {
                MessageBox.Show(" Grid sayısı 30'dan fazla olamaz.");
                return;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            string dosyaAdi = "skorlar.txt";
            if (File.Exists(dosyaAdi))
            {
                File.Delete(dosyaAdi); // Skor dosyasını sil
            }
        }


    }
}

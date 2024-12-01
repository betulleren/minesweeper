using System;
using System.Drawing;
using System.Windows.Forms;

namespace betulMayin
{
    public class Oyun
    {
        

        private Image mayinIki;
        private Skorboard skorboard; // Skorboard nesnesi

        private System.Windows.Forms.Label lblTime; // Zaman için Label referansı
        private System.Windows.Forms.Timer gameTimer; // Timer tanımı
        private System.Windows.Forms.Label lblHamle; // Hamle sayısı için Label referansı


        private int may;
        private int grid;
        private int[,] positions;
        private Button[,] buttons;
        private Form form;
        private const int MineValue = 1;

        private DateTime startTime;
        private int gecenSüre;
        private int hamleSayisi; // Hamle sayısı
        private int dogruBayrakSayisi; // Doğru bayrak sayısını tutacak değişken



        public Oyun(int mayinSayisi, int gridSayisi, Label label, Label hamleLabel, Form form)
        {

            may = mayinSayisi;
            grid = gridSayisi;
            lblTime = label;
            lblHamle = hamleLabel; // Hamle sayısı label'ını atıyoruz
            this.form = form;

            buttons = new Button[gridSayisi, gridSayisi];
            positions = new int[gridSayisi, gridSayisi];

            skorboard = new Skorboard(0, 0); // Skorboard örneği oluştur

            GenerateMines();
            hamleSayisi = 0;

            mayinIki = ResizeImage(Image.FromFile("C:\\Users\\hp\\source\\repos\\betulMayin\\betulMayin\\mayinIki.png"), 50, 50);

        }



        public void OyunBitir(string oyuncuAdi)
        {
            int dogruBayrakSayisi = 0;

            // Tüm mayınları aç ve doğru bayrak sayısını hesapla
            RevealAllMines(ref dogruBayrakSayisi);

            // Skoru ekle
            skorboard.SkorEkle(oyuncuAdi, dogruBayrakSayisi, gecenSüre);

            // En iyi 10 skoru al ve mesaj olarak göster
            string enIyiSkorlarMesaji = "En İyi Skorlar:\n";
            foreach (var skor in skorboard.GetirEnIyiSkorlar())
            {
                enIyiSkorlarMesaji += skor + "\n";
            }

            // Form3'ü aç ve skoru gönder
            Form3 form3 = new Form3(enIyiSkorlarMesaji);
            form3.Show();
            form.Hide();
        }




        // Mayınları açarken doğru bayrak sayısını güncellemek için
        private void RevealAllMines(ref int dogruBayrakSayisi)
        {
            for (int i = 0; i < grid; i++)
            {
                for (int j = 0; j < grid; j++)
                {
                    if (positions[i, j] == 1) // Eğer bu hücre bir mayın içeriyorsa
                    {
                        if (buttons[i, j].Text == "🚩") // Mayının üzerine bayrak konmuşsa
                        {
                            dogruBayrakSayisi++; // Doğru bayrak sayısını artır
                        }
                        buttons[i, j].Image = mayinIki;
                        
                    }
                }
            }

        }


        private Bitmap ResizeImage(Image image, int width, int height)
        {
            Bitmap resizedImage = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(resizedImage))
            {
                g.DrawImage(image, 0, 0, width, height);
            }
            return resizedImage;
        }


        public void CreateGameGrid(Form form)
        {
            int buttonSize = 40;
            int totalSize = grid * buttonSize; // Gridin toplam boyutu
            form.ClientSize = new Size(grid * totalSize, grid * totalSize);

            for (int i = 0; i < grid; i++)
            {
                for (int j = 0; j < grid; j++)
                {
                    Button button = new Button();
                    button.Size = new Size(buttonSize, buttonSize);
                    button.Location = new Point(i * buttonSize, j * buttonSize);
                    button.Click += (sender, e) => Button_Click(sender, e, i, j, form);
                    button.MouseDown += Button_MouseDown; // Sağ tıklama olayı 
                    buttons[i, j] = button;
                    form.Controls.Add(button);
                }
            }
        }


        private void GenerateMines()
        {
            Random rand = new Random();
            int minesPlaced = 0;

            while (minesPlaced < may)
            {
                int x = rand.Next(0, grid);
                int y = rand.Next(0, grid);

                if (positions[x, y] != 1)
                {
                    positions[x, y] = 1;
                    minesPlaced++;
                }
            }
        }


        private void Button_Click(object sender, EventArgs e, int x, int y, Form form,bool userClick = true)
        {
            Button clickedButton = sender as Button;
            x = clickedButton.Location.X / 40;
            y = clickedButton.Location.Y / 40;

            if (userClick)
            {
                hamleSayisi++;
                lblHamle.Text = $"Hamle Sayısı: {hamleSayisi}";
            }

            // Sol tık ile hücre açma işlemi
            if (positions[x, y] == 1) // Mayın mı?
            {
                clickedButton.Image = mayinIki;
                
                MessageBox.Show("Mayına bastınız! Oyun bitti.");
                RevealAllMines();
                return;
            }

            int mineCount = CountAdjacentMines(x, y);
            clickedButton.Text = mineCount > 0 ? mineCount.ToString() : "";
            clickedButton.BackColor = Color.LightGray;
            clickedButton.Enabled = false;

            

            // Eğer mayın yoksa, komşu hücreleri de aç
            if (mineCount == 0)
            {
                RevealAdjacentCells(x, y);
            }


            if (gameTimer == null)
            {
                startTime = DateTime.Now;
                gecenSüre = 0;

                gameTimer = new System.Windows.Forms.Timer();
                gameTimer.Interval = 1000; // 1 saniye
                gameTimer.Tick += Timer_Tick;
                gameTimer.Start();
            }
            CheckWinCondition();
        }



        private int CountAdjacentMines(int x, int y)
        {
            int count = 0;

            // Komşu hücrelerin koordinatları
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    // Kendisi dışındaki komşuları kontrol et
                    if (i == 0 && j == 0) continue;

                    int neighborX = x + i;
                    int neighborY = y + j;

                    // Geçersiz indeks kontrolü
                    if (neighborX >= 0 && neighborX < grid && neighborY >= 0 && neighborY < grid)
                    {
                        if (positions[neighborX, neighborY] == 1) // Mayın mı?
                        {
                            count++;
                        }
                    }
                }
            }

            return count;
        }

        private void RevealAdjacentCells(int x, int y)
        {
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    // Kendisi dışındaki komşuları kontrol et
                    if (i == 0 && j == 0) continue;

                    int neighborX = x + i;
                    int neighborY = y + j;

                    // Geçersiz indeks kontrolü
                    if (neighborX >= 0 && neighborX < grid && neighborY >= 0 && neighborY < grid)
                    {
                        Button neighborButton = buttons[neighborX, neighborY];
                        if (neighborButton.Enabled) // Eğer hücre tıklanabilir ise
                        {
                            Button_Click(neighborButton, null, neighborX, neighborY, neighborButton.FindForm(),false); // Komşu hücreyi aç
                        }
                    }
                }
            }
        }

        private void Button_MouseDown(object sender, MouseEventArgs e)
        {
            Button clickedButton = sender as Button;
            int x = clickedButton.Location.X / 40; // Buton boyutuna göre X konumu
            int y = clickedButton.Location.Y / 40; // Buton boyutuna göre Y konumu

            // Sağ tık ile bayrak ekleme işlemi
            if (e.Button == MouseButtons.Right)
            {
                if (clickedButton.Text == "🚩") // Eğer bayrak varsa, kaldır
                {
                    clickedButton.Text = ""; // Bayrağı kaldır
                }
                else // Eğer bayrak yoksa, bayrağı ekle
                {
                    clickedButton.Text = "🚩"; // Bayrağı ekle
                }
            }
        }

        private void RevealAllMines()
        {

            int dogruBayrakSayisi = 0;

            for (int i = 0; i < grid; i++)
            {
                for (int j = 0; j < grid; j++)
                {
                    if (positions[i, j] == 1) // Eğer bu hücre bir mayın içeriyorsa
                    {
                        if (buttons[i, j].Text == "🚩") // Mayının üzerine bayrak konmuşsa
                        {
                            dogruBayrakSayisi++; // Doğru bayrak sayısını artır
                        }
                        buttons[i, j].Image = mayinIki;
                        
                        buttons[i, j].Enabled = false; // Butonu devre dışı bırak
                    }
                }
            }

            if (gameTimer != null)
            {
                gameTimer.Stop();
                gameTimer = null; // Timer nesnesini sıfırla
            }

            UpdateTimeDisplay(); // Süreyi ekranda güncelle
            lblTime.Text = $"Oyun Bitti! Süre: {gecenSüre} saniye";

            // Skor hesapla ve göster
            Skorboard skorBoard = new Skorboard(dogruBayrakSayisi, gecenSüre);

        }
        //TIMER
        private void StartTimer()
        {
            if (gameTimer == null)
            {
                gecenSüre = 0;

                gameTimer = new System.Windows.Forms.Timer();
                gameTimer.Interval = 1000; // 1 saniye
                gameTimer.Tick += Timer_Tick;
                gameTimer.Start();
            }
        }


        private void UpdateTimeDisplay()
        {
            lblTime.Text = $"Geçen Süre: {gecenSüre} saniye";
        }



        private void CheckWinCondition()
        {
            // Kazanma koşulunu kontrol et
            bool kazanildi = true;

            for (int i = 0; i < grid; i++)
            {
                for (int j = 0; j < grid; j++)
                {
                    // Eğer mayın olmayan açılmamış bir hücre varsa, kazanılmadı
                    if (positions[i, j] != 1 && buttons[i, j].Enabled)
                    {
                        kazanildi = false;
                        break;
                    }
                }
            }

            // Eğer kazanıldıysa, zamanlayıcıyı durdur ve mesajı göster
            if (kazanildi)
            {
                gameTimer.Stop();
                UpdateTimeDisplay(); // Süreyi güncelle
                lblTime.Text = $"Tebrikler, kazandınız! Süre: {gecenSüre} saniye";
            }
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            gecenSüre++; 
            lblTime.Text = $"Geçen Süre: {gecenSüre} saniye"; // Zamanı lblTime'a güncelle
        }
    }
}
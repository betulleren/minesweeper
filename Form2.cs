
using System;
using System.Windows.Forms;

namespace betulMayin
{
    public partial class Form2 : Form
    {
        private Oyun oyun;
        private Skorboard skorboard; // Skorboard nesnesi ekliyoruz


        public Form2(string oyuncuAdi, int mayinSayisi, int gridSayisi)
        {
            InitializeComponent();
            lblUser.Text = oyuncuAdi;
            this.AutoScroll = true;

            // Oyun nesnesi oluştur
            oyun = new Oyun(mayinSayisi, gridSayisi, lblTime, lblHamle, this);
            oyun.CreateGameGrid(this);
            skorboard = new Skorboard(0, 0); // Skorboard örneğini oluştur
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string oyuncuAdi = lblUser.Text; // Oyuncu adını label'dan alıyoruz
            oyun.OyunBitir(oyuncuAdi); // Oyun bitir ve skoru göster

            // En iyi 10 skoru al ve mesaj olarak göster
            string enIyiSkorlarMesaji = "En İyi Skorlar:\n";
            foreach (var skor in skorboard.GetirEnIyiSkorlar())
            {
                enIyiSkorlarMesaji += skor + "\n";
            }

            // Form3'e skor bilgisini gönder
            Form3 form3 = new Form3(enIyiSkorlarMesaji);

        }


    }
}








/*private System.Windows.Forms.Timer gameTimer; // Timer tanımını tam ad alanıyla yapıyoruz


private int may;
private int grid;
private int[,] positions;
private Button[,] buttons;

private DateTime startTime;
private int gecenSüre;
public Form2(string oyuncuAdi, int mayinSayisi, int gridSayisi)
{
    InitializeComponent();
    lblUser.Text = oyuncuAdi;

    may = mayinSayisi;
    grid = gridSayisi;

    buttons = new Button[gridSayisi, gridSayisi];
    positions = new int[gridSayisi, gridSayisi];

    // Formun boyutunu ayarlıyoruz
    int buttonSize = 40; // Her butonun boyutu (örneğin, 40x40)
    int totalSize = grid * buttonSize; // Gridin toplam boyutu
    this.ClientSize = new Size(totalSize * 20, totalSize * 20); // Formun boyutunu büyütüyoruz

    CreateGameGrid();
    GenerateMines();
}

private void CreateGameGrid()
{
    int buttonSize = 40;
    // this.ClientSize=new Size(grid*buttonSize,grid*buttonSize);

    int totalSize = grid * buttonSize; // Gridin toplam boyutu
    this.ClientSize = new Size(totalSize + 20, totalSize + 20);
    this.ClientSize = new Size(totalSize, totalSize);

    // Gridin başlangıç konumu (ekranın ortası)
    int startX = (this.ClientSize.Width - totalSize) / 2;
    int startY = (this.ClientSize.Height - totalSize) / 2;

    for (int i = 0; i < grid; i++)
    {
        for (int j = 0; j < grid; j++)
        {
            Button button = new Button();
            button.Size = new Size(buttonSize, buttonSize);
            button.Location = new Point(i * buttonSize, j * buttonSize);
            button.Click += Button_Click; // Sol tıklama olayı ekliyoruz
            button.MouseDown += Button_MouseDown; // Sağ tıklama olayı ekliyoruz
            button.Click += Button_Click;
            buttons[i, j] = button;
            this.Controls.Add(button);
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

        if (positions[x, y] != 10)
        {
            positions[x, y] = 10;
            minesPlaced++;
        }
    }
}


private void Button_Click(object sender, EventArgs e)
{
    Button clickedButton = sender as Button;
    int x = clickedButton.Location.X / 40;
    int y = clickedButton.Location.Y / 40;

    // Sol tık ile hücre açma işlemi
    if (positions[x, y] == 10) // Mayın mı?
    {
        clickedButton.BackColor = Color.Red; // Mayına basıldı
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
                if (positions[neighborX, neighborY] == 10) // Mayın mı?
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
                    Button_Click(neighborButton, null); // Komşu hücreyi aç
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
    for (int i = 0; i < grid; i++)
    {
        for (int j = 0; j < grid; j++)
        {
            if (positions[i, j] == 10)
            {
                buttons[i, j].BackColor = Color.Pink;
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
}
//TIMER


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
            if (positions[i, j] != 10 && buttons[i, j].Enabled)
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
    gecenSüre++; // Süreyi bir artır
    UpdateTimeDisplay(); // Süreyi ekranda güncelle
}
}
}
*/


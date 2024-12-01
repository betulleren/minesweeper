using System;
using System.Collections.Generic;
using System.Linq;

namespace betulMayin
{
    public class Skorboard
    {
        //skor kaydı için oyuncu adı, doğru bayrak sayısı, toplam süre ve hesaplanan skoru tutar
        public class Skor
        {
            public string OyuncuAdi { get; set; }
            public int DogruBayrakSayisi { get; set; }
            public int ToplamSure { get; set; }
            public int SkorPuan { get; set; }

            public Skor(string oyuncuAdi, int dogruBayrakSayisi, int toplamSure)
            {
                OyuncuAdi = oyuncuAdi;
                DogruBayrakSayisi = dogruBayrakSayisi;
                ToplamSure = toplamSure;
                SkorPuan = HesaplaSkor();
            }

            private int HesaplaSkor()
            {
                return ToplamSure > 0 ? (DogruBayrakSayisi * 1000) / ToplamSure : 0;
            }

            public override string ToString()
            {
                return $"{OyuncuAdi} - Doğru Bayrak Sayısı: {DogruBayrakSayisi}, Süre: {ToplamSure} saniye, Skor: {SkorPuan}";
            }

            public static Skor Parse(string skorString)
            {
                var parts = skorString.Split(',');
                return new Skor(parts[0], int.Parse(parts[1]), int.Parse(parts[2]));
            }
        }

        private List<Skor> enIyiSkorlar;
        private const string DosyaAdi = "skorlar.txt";

        public Skorboard(int dogruBayrakSayisi, int toplamSüre)
        {
            enIyiSkorlar = new List<Skor>();
            SkorYukle();

        }

        // Yeni bir skor ekleyip en iyi 10 listeyi günceller
        public void SkorEkle(string oyuncuAdi, int dogruBayrakSayisi, int toplamSure)
        {
            var yeniSkor = new Skor(oyuncuAdi, dogruBayrakSayisi, toplamSure);
            enIyiSkorlar.Add(yeniSkor);

            // Skorları sıralayıp en yüksek 10 skoru saklar
            enIyiSkorlar = enIyiSkorlar.OrderByDescending(s => s.SkorPuan).Take(10).ToList();
            SkorKaydet();
        }

        // En iyi 10 skoru getirir
        public List<Skor> GetirEnIyiSkorlar()
        {
            return enIyiSkorlar;
        }

        private void SkorKaydet()
        {
            var skorlar = enIyiSkorlar.Select(s => $"{s.OyuncuAdi},{s.DogruBayrakSayisi},{s.ToplamSure}");
            File.WriteAllLines(DosyaAdi, skorlar);
        }

        private void SkorYukle()
        {
            if (File.Exists(DosyaAdi))
            {
                var skorlar = File.ReadAllLines(DosyaAdi);
                foreach (var skor in skorlar)
                {
                    enIyiSkorlar.Add(Skor.Parse(skor));
                }

                enIyiSkorlar = enIyiSkorlar.OrderByDescending(s => s.SkorPuan).Take(10).ToList();
            }
        }




    }
}
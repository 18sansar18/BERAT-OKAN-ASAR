using System;
using System.Collections.Generic;
using System.Text;

namespace Ö
{
    public class Oyun
    {
        public string karakter_silah;
        public int mermi_sayısı;
        public int karakter_yaş;
        private int karakter_sağlık;
        private int karakter_para;



        public Oyun(string _karakter_silah, int _mermi_sayısı, int _karakter_yaş, int _karakter_sağlık, int _karakter_para)
        {
            karakter_silah = _karakter_silah;
            mermi_sayısı = _mermi_sayısı;
            karakter_yaş = _karakter_yaş;
            karakter_sağlık = _karakter_sağlık;
            karakter_para = _karakter_para;
        }



        public int Karakter_para
        {
            get
            {
                return karakter_para;
            }

            set
            {

                karakter_para = value;

            }

        }

        public int Karakter_sağlık
        {
            get
            {
                return karakter_sağlık;

            }

            set
            {
                if (value <= 0)
                {
                    Console.WriteLine("Öldünüz..");
                }
                else
                {
                    karakter_sağlık = value;
                }
            }
        }

        public int çatışma_durumu(int şiddet)
        {
            mermi_sayısı -= şiddet * 20;
            karakter_sağlık -= şiddet * 10;

            return mermi_sayısı;
            return karakter_sağlık;

        }

        public void sorcan()
        {
            Console.WriteLine("CAN ALMAK İSTER MİSİN (E/H) (2000 TL = 30HP) ");
        }



        public int can_al()
        {
            karakter_sağlık += 30;

            return karakter_sağlık;

        }

        public void sormermi()
        {
            Console.WriteLine("Mermi ALMAK İSTER MİSİN (E/H) (2500 TL = 70 MERMİ) ");
        }
        public int mermi_al()
        {
            mermi_sayısı += 70;

            return mermi_sayısı;

        }






        public void karakter_durumu()
        {
            Console.WriteLine("Karakterin Silahı --->" + karakter_silah);
            Console.WriteLine("Karakter Mermi Sayısı ---> " + mermi_sayısı);
            Console.WriteLine("Karakter Canı ---> " + karakter_sağlık);
            Console.WriteLine("Karakter Para --->" + karakter_para);
            Console.WriteLine("Karakter yaş --->" + karakter_yaş + "\n");

        }

        public void başlansınmı()
        {

            Console.WriteLine("Yeni Savaşa Başlansın Mı?");

        }
        public void ağır()
        {
            Console.WriteLine(" \n\n ****************************************** AĞIR BİR SAVAŞDI ... **********************************************");
        }
        public void hafif()
        {
            Console.WriteLine(" \n\n ************************************* HAFİF BİR SAVAŞTI ... ŞANSLISIN ******************************************");
        }




    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("------------------------------------------  ÇETE SAVAŞLARINA HOŞGELDİNİZ  -----------------------------------------");

            Console.WriteLine("Savaşa Hazır Mısın Jack ? (E/H) ");
            char eh = Convert.ToChar(Console.ReadLine());
            if (eh == 'E')
            {
                Console.WriteLine("GÜZELLL.. Cesur bir savaşçıya benziyorsun");

            }
            else
            {
                Console.WriteLine("KORKAK HERİF.. DEFOL BURDAN");
                goto a1;
            }

            Console.WriteLine("İşte sana bir silah ve birazda mermi... \nAyrıca ilerleyen bölümlerde zırh , can , mermi ve yeni silahlar albilmen için biraz para");
            Console.WriteLine("Paranı dikkatli harca. Savaştığın çetelerin kuvvetine göre para kazanırsın \n... Burda en önemli şey ŞANS ve PARA evlat.....\n\n");


            Oyun Jack = new Oyun("M4A1-S", 120, 22, 100, 10000);



            Console.WriteLine("Karakterinin durumu şu anki durumu .....");
            Jack.karakter_durumu();


            while (true)
            {
                Jack.başlansınmı();
                Console.WriteLine("(E)");

                char ehh = Convert.ToChar(Console.ReadLine());
                if (ehh == 'E')
                {
                    Console.WriteLine("Çatışmaya Giriyorsunuz....... Rakip Analizi Yapılıyor ........(***RAKİBİNİZİN GÜÇLERİ RASTGELE BELİRLENMİŞTİR***)");
                }
                Random rastgele = new Random();
                int _şiddet = rastgele.Next(1, 7);
                Console.WriteLine("\n\n ***********************************   KARŞIMIZDAKİ ÇETE " + _şiddet + " /7 GÜCÜNDE   ********************************* ");


                Jack.çatışma_durumu(_şiddet);
                if (_şiddet == 6 || _şiddet== 5)
                {
                    Jack.ağır();
                }
                else
                {
                    Jack.hafif();
                }
                Jack.Karakter_para = Jack.Karakter_para + _şiddet * 750;
                Jack.karakter_durumu();
                
                Jack.sorcan();
                char sorcan = Convert.ToChar(Console.ReadLine());

                if (sorcan == 'E')
                {
                    Jack.can_al();
                    Console.WriteLine("CAN ALINDI");

                    Jack.Karakter_para -= 2500;
                }
                else
                {

                }

                Jack.sormermi();
                char sormermi = Convert.ToChar(Console.ReadLine());
                if (sormermi == 'E')
                {
                    Jack.mermi_al();
                    Console.WriteLine("MERMİ ALINDI");
                    Jack.Karakter_para -= 2500;

                }
                else
                {

                }

                Jack.karakter_durumu();


                if (Jack.Karakter_sağlık < 0)
                {

                    Console.WriteLine("*********************************ÖLDÜN***************************");
                    goto a2;
                }

                if (Jack.mermi_sayısı < 0)
                {
                    Console.WriteLine("***************** MERMİSİZ ADAM ÖLÜ ADAMDIR *****************");
                    goto a3;
                }






            }

        a1: Console.WriteLine("*****************************OYUN BİTTİ***************************** ... \nOYUNUN EKSİKLERİ : \n1-) PARA BİTMESİNE RAĞMEN ALIM YAPMAYA DEVAM EDİLİYOR.. \n2-) SİLAH ALIM SEKMESİ YAKINDA GELİCEK \n3-) Can 100 'ün üzerine çıkıyor. Limit konulmalı. \n4-) 0 IN ALTINA MERMİ SAYISI İLE SAVAŞA GİRİNCE OYUN BİTİYOR, SAVAŞTA DA 0 IN ALTINA DÜŞÜNCE BİTMESİ SAĞLANMALI..  ");
        a2: Console.WriteLine("*****************************OYUN BİTTİ***************************** ... \nOYUNUN EKSİKLERİ : \n1-) PARA BİTMESİNE RAĞMEN ALIM YAPMAYA DEVAM EDİLİYOR.. \n2-) SİLAH ALIM SEKMESİ YAKINDA GELİCEK \n3-) Can 100 'ün üzerine çıkıyor. Limit konulmalı. \n4-) 0 IN ALTINA MERMİ SAYISI İLE SAVAŞA GİRİNCE OYUN BİTİYOR, SAVAŞTA DA 0 IN ALTINA DÜŞÜNCE BİTMESİ SAĞLANMALI..");
        a3: Console.WriteLine("*****************************OYUN BİTTİ***************************** ... \nOYUNUN EKSİKLERİ : \n1-) PARA BİTMESİNE RAĞMEN ALIM YAPMAYA DEVAM EDİLİYOR.. \n2-) SİLAH ALIM SEKMESİ YAKINDA GELİCEK \n3-) Can 100 'ün üzerine çıkıyor. Limit konulmalı. \n4-) 0 IN ALTINA MERMİ SAYISI İLE SAVAŞA GİRİNCE OYUN BİTİYOR, SAVAŞTA DA 0 IN ALTINA DÜŞÜNCE BİTMESİ SAĞLANMALI..");

        }


    }
}




using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ders16_DOSYA_KLASÖR_ÖRNEK1_
{
    internal class Program
    {
        static void Main(string[] args)
        {

            
            char secim;
            do
            {
                string ogrno, ogrsinif, sinifklasorYol, ogrKlasorYol;
                string ogr_adSoyad;
                
                ANAMENU:
                Console.Clear();
                Console.WriteLine("\t"+"\n"+"\t"+"~~~~HOŞGELDİNİZ~~~~");
                Console.WriteLine("\n"+"\n");
                Console.WriteLine("1- Yeni Öğrenci Kaydı");
                Console.WriteLine("2- Öğrenci Bilgilerini Güncelleme");
                Console.WriteLine("3- Öğrenci Kaydı Silme");
                Console.WriteLine("4- Öğrenci Sınıf Değişikliği");
                Console.WriteLine("5- Çıkış");
                
                Console.Write("\t" + "\t" + "\n" + "Yapmak İstediğiniz İşlemi Seçiniz.." + "\n");
                secim = Convert.ToChar(Console.ReadLine());

                if (secim=='1')
                {
                KAYIT:
                    Console.Clear();
                    Console.WriteLine("Kaydetmek İstediğiniz Öğrencinin Numarasını Giriniz..");
                    ogrno= Console.ReadLine();
                    Console.WriteLine("Öğrenciyi Kaydetmek İstediğiniz Sınıfı Şubesiyle Birlikte Giriniz..");
                    ogrsinif= Console.ReadLine();
                    sinifklasorYol = @"c:\okul2\" + ogrsinif;//öğrencinin girmiş olduğu şube sınıflarının yolu
                    
                    string ogrnklasor = @"c:\okul2\" + ogrsinif + "\\" + ogrno;//öğrencinin kendi klasör yolu

                    if (System.IO.Directory.Exists(sinifklasorYol)==true && System.IO.Directory.Exists(ogrnklasor)==false)
                    {
                        System.IO.Directory.CreateDirectory(ogrnklasor);// girilen numaralı klasör oluşturuldu

                        string dosyaadi = ogrno + ".txt";//şimdi bilgi metin dosyası oluşturacağız adi= öğrencino+txt
                        
                        string hedefyol = System.IO.Path.Combine(ogrnklasor, dosyaadi);//öğrenciye oluşturduğumuz klasörün patikasını öğrnumarası adıyla oluşturduğumuz dosyayla kombine ettik
                       
                        if (System.IO.File.Exists(hedefyol)==false)
                        {

                            System.IO.File.Create(hedefyol).Close();//eğer o adda dosya yoksa oluşsun..
                            Console.Clear();
                            Console.WriteLine("\n"+"{0} numaralı öğrenci için klasör ve dosya başarıyla oluşturulmuştur..", ogrno);

                            //dosya oluştu şimdi içini dolduracağız..
                            string ad, soyad, cinsiyet, adres, telefon;
                            Console.WriteLine("\t"+"\n" + "\n" + "Kaydedilen öğrenci dosyası için gerekli bilgileri yazınız..");
                            Console.Write("Adı: ");
                            ad = Console.ReadLine();
                            Console.Write("Soyadı: ");
                            soyad = Console.ReadLine();
                            Console.Write("Cinsiyet(KADIN/ERKEK): ");
                            cinsiyet = Console.ReadLine();
                            Console.Write("Telefon: ");
                            telefon = Console.ReadLine();
                            Console.Write("Adres: ");
                            adres = Console.ReadLine();

                            //dosyaya kullanıcıdan alınan bilgilerin yazılması
                            string[] ogrbilgi = { "Öğrenci No: " + ogrno, "Adı: " + ad, "Soyadı: " + soyad,"Cinsiyet: "+cinsiyet, "Telefon: " + telefon, "Adres: " + adres };//dzinin her bir elemanı satır olacak yazılacak
                            string ogrbilgidosya_yol = @"c:\okul2\" + ogrsinif + "\\" + ogrno + "\\" + ogrno + ".txt";
                            System.IO.File.WriteAllLines(ogrbilgidosya_yol, ogrbilgi);
                            Console.Clear();

                            Console.WriteLine("\n" + "~~Öğrenci bilgileri başarıyla kaydedilmiştir..Başka bir işlem yapmak istiyor musunuz?(e/h)");
                            char cevap = Convert.ToChar(Console.ReadLine());

                            if (cevap == 'E' || cevap == 'e')
                            {
                                goto ANAMENU;
                            }
                            else
                            {
                                Console.WriteLine("~~~~~~...İYİ GÜNLER DİLERİZ...~~~~~~");
                                Console.ReadKey();
                                Environment.Exit(0);
                            }
                            
                        }
                        else
                        {
                            Console.WriteLine("Dosya zaten mevcut..");


                        }
                  
                    }
                    if (System.IO.Directory.Exists(ogrnklasor)==false)
                    {
                        Console.WriteLine("O şubede sınıf bulunmamaktadır..Kontrol ediniz.");
                        Console.ReadKey();
                        goto KAYIT;
                    }
                    else
                    {
                        Console.WriteLine("Okulda {0} adlı şubede {1} numaralı öğrencinin kaydı zaten mevcuttur", ogrsinif,ogrno);
                        Console.WriteLine("Başka bir işlem yapmak İstiyor musunuz?(e/h)");
                        char cevap = Convert.ToChar(Console.ReadLine());
                        
                        if (cevap=='E'||cevap=='e')
                        {
                            goto ANAMENU;
                        }
                        else
                        {
                            Console.WriteLine("\t" + "\n" + "~~~~~~...İYİ GÜNLER DİLERİZ...~~~~~~");
                            Console.ReadKey();
                            Environment.Exit(0);
                        }
                    }

                        
                        
                        
                }   
                


                if (secim == '2')//dosya bilgilerinin getittirme ve dosyalarda bilgi arama
                {
                    GORUNTULEME:
                    Console.WriteLine(" Güncellemek istediğiniz öğrenci numarasını giriniz..");
                    string ogrenci_no = Console.ReadLine();

                    DirectoryInfo klasorbilgisi = new DirectoryInfo("c:\\okul2");//istediğimiz klasörün bilgilerinni sakladık
                    FileInfo[] dosyalar = klasorbilgisi.GetFiles(ogrenci_no + ".txt",SearchOption.AllDirectories);

                    int adet = dosyalar.Count();//dosyalar dizisinin eleman sayısı
                    if (adet>0)
                    {
                        string ogrenci_dosyayolu = dosyalar[0].DirectoryName;//dosyalar dizisinin ilk elemanının dosya hedef yolunu atadık
                        string ogrenci_dosyaadi = ogrenci_no + ".txt";
                        string ogrenci_hedefyolu= System.IO.Path.Combine(ogrenci_dosyayolu, ogrenci_dosyaadi);
                        string[] ogrenci_bilgisi = System.IO.File.ReadAllLines(ogrenci_hedefyolu);
                        foreach (string  item in ogrenci_bilgisi)
                        {
                            Console.WriteLine(item);
                        }
                        
                    
                    GUNCELLE:
                    string karar;
                    do
                    {
                        Console.WriteLine("\t"+"\n"+"Güncellemek istediğiniz öğrenci bilgisini seçiniz..");
                    Console.WriteLine("1-) Ad");
                    Console.WriteLine("2-) Soyad");
                    Console.WriteLine("3-) Cinsiyet");
                    Console.WriteLine("4-) Telefon");
                    Console.WriteLine("5-) Adres");
                    karar = Console.ReadLine();
                    if (karar=="1")
                    {

                                Console.WriteLine("Yeni ad bilgisini giriniz..");
                                string yeniisim = Console.ReadLine();
                                ogrenci_bilgisi[1] = "Ad: " + yeniisim;
                                System.IO.File.WriteAllLines(ogrenci_hedefyolu, ogrenci_bilgisi);
                                Console.Clear();
                                Console.WriteLine("\t" + "\n" + "Ad bilgisi başarıyla güncellenmiştir..");
                                Console.WriteLine("\t" + "\n" + "~~~~Güncellenen Bilgiler~~~~");
                                foreach (string item in ogrenci_bilgisi)
                                {
                                    Console.WriteLine(item);
                                }

                                string guncellemedevam;
                                do
                                {
                                    Console.WriteLine("Öğrenciye ait başka bilgi güncellemek ister misiniz(e/h)..?");
                                    guncellemedevam = Console.ReadLine();
                                    if (guncellemedevam == "E" || guncellemedevam == "e")
                                    {
                                        goto GUNCELLE;
                                    }
                                    if (guncellemedevam == "H" || guncellemedevam == "h")
                                    {
                                        Console.WriteLine("\t" + "\n" + "~~~~~~...İYİ GÜNLER DİLERİZ...~~~~~~");
                                        Console.ReadKey();
                                        Environment.Exit(0);
                                    }

                                } while (guncellemedevam != "E" || guncellemedevam != "e" || guncellemedevam != "H" || guncellemedevam != "h");


                            }
                        if (karar == "2")
                        {

                                Console.WriteLine("Yeni soyad bilgisini giriniz..");
                                string yenisoyad = Console.ReadLine();
                                ogrenci_bilgisi[2] = "Soyad: " + yenisoyad;
                                System.IO.File.WriteAllLines(ogrenci_hedefyolu, ogrenci_bilgisi);
                                Console.Clear();
                                Console.WriteLine("\t" + "\n" + "Soyad bilgisi başarıyla güncellenmiştir..");
                                Console.WriteLine("\t" + "\n" + "~~~~Güncellenen Bilgiler~~~~");
                                foreach (string item in ogrenci_bilgisi)
                                {
                                    Console.WriteLine(item);
                                }

                                string guncellemedevam;
                                do
                                {
                                    Console.WriteLine("Öğrenciye ait başka bilgi güncellemek ister misiniz(e/h)..?");
                                    guncellemedevam = Console.ReadLine();
                                    if (guncellemedevam == "E" || guncellemedevam == "e")
                                    {
                                        goto GUNCELLE;
                                    }
                                    if (guncellemedevam == "H" || guncellemedevam == "h")
                                    {
                                        Console.WriteLine("\t" + "\n" + "~~~~~~...İYİ GÜNLER DİLERİZ...~~~~~~");
                                        Console.ReadKey();
                                        Environment.Exit(0);
                                    }

                                } while (guncellemedevam != "E" || guncellemedevam != "e" || guncellemedevam != "H" || guncellemedevam != "h");

                            }
                        if (karar == "3")
                        {
                                Console.WriteLine("Yeni Cinsiyet bilgisini giriniz..");
                                string yenicinsiyet = Console.ReadLine();
                                ogrenci_bilgisi[3] = "Cinsiyet(ERKEK/KADIN): " + yenicinsiyet;
                                System.IO.File.WriteAllLines(ogrenci_hedefyolu, ogrenci_bilgisi);
                                Console.Clear();
                                Console.WriteLine("\t" + "\n" + "Cinsiyet bilgisi başarıyla güncellenmiştir..");
                                Console.WriteLine("\t" + "\n" + "~~~~Güncellenen Bilgiler~~~~");
                                foreach (string item in ogrenci_bilgisi)
                                {
                                    Console.WriteLine(item);
                                }
                                string guncellemedevam;
                                do
                                {
                                    Console.WriteLine("Öğrenciye ait başka bilgi güncellemek ister misiniz(e/h)..?");
                                    guncellemedevam = Console.ReadLine();
                                    if (guncellemedevam == "E" || guncellemedevam == "e")
                                    {
                                        goto GUNCELLE;
                                    }
                                    if (guncellemedevam == "H" || guncellemedevam == "h")
                                    {
                                        Console.WriteLine("\t" + "\n" + "~~~~~~...İYİ GÜNLER DİLERİZ...~~~~~~");
                                        Console.ReadKey();
                                        Environment.Exit(0);
                                    }

                                } while (guncellemedevam != "E" || guncellemedevam != "e" || guncellemedevam != "H" || guncellemedevam != "h");





                            }
                        if (karar == "4")
                        {
                            Console.WriteLine("Yeni telefon numarasını giriniz..");
                            string yenitelefon= Console.ReadLine();
                                ogrenci_bilgisi[4] = "Telefon: " + yenitelefon;
                                System.IO.File.WriteAllLines(ogrenci_hedefyolu, ogrenci_bilgisi);
                                Console.Clear();
                                Console.WriteLine("\t" + "\n" + "Telefon numarası başarıyla güncellenmiştir..");
                                Console.WriteLine("\t" + "\n" + "~~~~Güncellenen Bilgiler~~~~");
                                foreach (string item in ogrenci_bilgisi)
                                {
                                    Console.WriteLine(item);
                                }
                              
                                string guncellemedevam;
                                do
                                { 
                                    Console.WriteLine("Başka bilgi güncellemek ister misiniz(e/h)..?");
                                    guncellemedevam=Console.ReadLine();
                                    if (guncellemedevam=="E"||guncellemedevam=="e")
                                    {
                                      goto  GUNCELLE;
                                    }
                                    if (guncellemedevam == "H" || guncellemedevam == "h")
                                    {
                                        Console.WriteLine("\t" + "\n" + "~~~~~~...İYİ GÜNLER DİLERİZ...~~~~~~");
                                        Console.ReadKey();
                                        Environment.Exit(0);
                                    }

                                } while (guncellemedevam != "E" || guncellemedevam != "e"|| guncellemedevam != "H" || guncellemedevam != "h");
                                 

                            }
                        if (karar == "5")
                        {
                                Console.WriteLine("Yeni adres bilgisini giriniz..");
                                string yeniadres = Console.ReadLine();
                                ogrenci_bilgisi[5] = "Adres: " + yeniadres;
                                System.IO.File.WriteAllLines(ogrenci_hedefyolu, ogrenci_bilgisi);
                                Console.Clear();
                                Console.WriteLine("\t" + "\n" + "Adres bilgisi başarıyla güncellenmiştir..");
                                Console.WriteLine("\t" + "\n" + "~~~~Güncellenen Bilgiler~~~~");
                                foreach (string item in ogrenci_bilgisi)
                                {
                                    Console.WriteLine(item);
                                }

                                string guncellemedevam;
                                do
                                {
                                    Console.WriteLine("Öğrenciye ait başka bilgi güncellemek ister misiniz(e/h)..?");
                                    guncellemedevam = Console.ReadLine();
                                    if (guncellemedevam == "E" || guncellemedevam == "e")
                                    {
                                        goto GUNCELLE;
                                    }
                                    if (guncellemedevam == "H" || guncellemedevam == "h")
                                    {
                                        Console.WriteLine("\t" + "\n" + "~~~~~~...İYİ GÜNLER DİLERİZ...~~~~~~");
                                        Console.ReadKey();
                                        Environment.Exit(0);
                                    }

                                } while (guncellemedevam != "E" || guncellemedevam != "e" || guncellemedevam != "H" || guncellemedevam != "h");


                            }


                    } while (karar!="1"|| karar != "2" || karar != "3" || karar != "4" || karar != "5");
                   }
                    else
                    {
                        Console.WriteLine("\t" + "\n" + "Kayıtlarda {0} numaralı öğrenci bulunmamaktadır, Kontrol ediniz..", ogrenci_no);
                        Console.ReadKey();
                        Console.Clear();
                        goto GORUNTULEME;
                    }

                }



                if (secim == '3')
                {
                    SİL:
                    Console.WriteLine("\t" + "\n" + "Bilgi klasörü silinecek öğrencinin numarasını giriniz..");
                    string silogrno = Console.ReadLine();
                    System.IO.DirectoryInfo silinecekklasorbilgi= new DirectoryInfo("c:\\okul2");//okul2deki tüm klasör bilgilerini olş nesneye aktardık
                    System.IO.FileInfo[] dosyalar = silinecekklasorbilgi.GetFiles(silogrno + ".txt", System.IO.SearchOption.AllDirectories);//txtkeri aradık diziye aktardık
                    int bulunanDosyalar = dosyalar.Count();
                    if (bulunanDosyalar>0)
                    {
                        string silinecekKlasor_yolu = dosyalar[0].DirectoryName;//directoryname bulunan dosyanın yolunu verir
                        Console.WriteLine(silinecekKlasor_yolu);
                        string[] klasordizisi = silinecekKlasor_yolu.Split('\\');
                        SİLSEC:
                        Console.WriteLine("{0} sınıfındaki {1} numaralı öğrencinin bilgi dosya ve klasörü silmek istiyor musunuz?(e/h)..", klasordizisi[2],silogrno);
                        char silsecim;
                        silsecim =Convert.ToChar( Console.ReadLine());
                        if (silsecim=='e'|| silsecim=='E')
                        {
                            if (System.IO.Directory.Exists(silinecekKlasor_yolu)==true)
                            {
                                System.IO.Directory.Delete(silinecekKlasor_yolu,true);
                                Console.Clear();
                                Console.WriteLine("{0} sınıfındaki {1} numaralı öğrencinin bilgi dosya ve klasörü başarıyla silindi..", klasordizisi[2], silogrno);
                                Console.WriteLine("\t" + "\n" + "Başka bir işlem yapmak İstiyor musunuz?(e/h)");
                                char cevap = Convert.ToChar(Console.ReadLine());

                                if (cevap == 'E' || cevap == 'e')
                                {
                                    goto ANAMENU;
                                }
                                else
                                {
                                    Console.WriteLine("\t" + "\n" + "~~~~~~...İYİ GÜNLER DİLERİZ...~~~~~~");
                                    Console.ReadKey();
                                    Environment.Exit(0);
                                }

                            }
                        }
                        else if (silsecim == 'h' || silsecim == 'H')
                        {
                            Console.WriteLine("\t" + "\n" + "Silme işlemi iptal edildi! Programdan çıkış yapılıyor..İyi günler dileriz");
                            Console.ReadLine();
                            Environment.Exit(0);
                        }
                        else
                        {
                            Console.WriteLine("\t" + "\n" + "Hatalı tuşa bastınız!");
                            goto SİLSEC;
                        }


                    
                    }
                    else
                    {
                        Console.WriteLine("\t" + "\n" + "Silinmek istenen öğrencinin bilgi dosyası mevcut değildir! Kontrol ediniz..");
                        Console.ReadKey();
                        Console.Clear();
                        goto SİL;

                    }
                    Console.ReadKey();




                    //KULLANICIDAN SINIFINI DA ALARAK YAPILAN SİLME İŞLEMİ
                    /* SIL:
                     Console.WriteLine("Bilgi klasörü silinecek öğrencinin numarasını giriniz..");
                     string silogrno = Console.ReadLine();
                     Console.WriteLine("Öğrencinin ait olduğu sınıfı şubesiyle giriniz..(örn:10-A)");
                     string silogrsinif=Console.ReadLine();
                     string silklasor_yolu = @"c:\okul2\"+silogrsinif +"\\"+ silogrno;
                     if (System.IO.Directory.Exists(silklasor_yolu)==true)
                     {
                         System.IO.Directory.Delete(silklasor_yolu,true);
                         Console.Clear();
                         Console.WriteLine("{0} numaralı öğrencinin bilgi kalsörü başarıyla silinmiştir..",silogrno);

                         string guncellemedevam;
                         do
                         {
                             Console.WriteLine("\t" + "\n" + "Silmek istediğiniz başka öğrenci var mı(e/h)..?");
                             guncellemedevam = Console.ReadLine();
                             if (guncellemedevam == "E" || guncellemedevam == "e")
                             {
                                 goto SIL;
                             }
                             if (guncellemedevam == "H" || guncellemedevam == "h")
                             {
                                 Console.WriteLine("\t" + "\n" + "~~~~~~...İYİ GÜNLER DİLERİZ...~~~~~~");
                                 Console.ReadKey();
                                 Environment.Exit(0);
                             }

                         } while (guncellemedevam != "E" || guncellemedevam != "e" || guncellemedevam != "H" || guncellemedevam != "h");

                     }
                     else
                     {
                         Console.WriteLine("\t" + "\n" + "Silinmek istenen öğrencinin bilgi dosyası mevcut değildir!");
                         goto SIL;
                     }*/
                }



                if (secim == '4')
                {
                    DEGISIKLIK:
                    Console.WriteLine("\t" + "\n" + " Sınıf değişikliği yapmak istediğiniz öğrenci numarasını giriniz..");
                    string ogrencino = Console.ReadLine();
                    System.IO.DirectoryInfo tasınacaksinifbilgi = new System.IO.DirectoryInfo("c:\\okul2");
                    System.IO.FileInfo[] bulunandosyalar = tasınacaksinifbilgi.GetFiles(ogrencino + ".txt", System.IO.SearchOption.AllDirectories);
                    int bulunandosyasayi = bulunandosyalar.Count();
                    if (bulunandosyasayi>0)
                    {
                        string tasinacakKlasoryolu = bulunandosyalar[0].DirectoryName;
                        string[] klasorler = tasinacakKlasoryolu.Split('\\');
                       /* foreach (string  item in klasorler)
                        {
                            Console.WriteLine(item);

                        }*/
                       TASIMA:
                        Console.WriteLine("\t" + "\n" + "{0} şubesindeki {1} numaralı öğrenciyi hangi sınıfa taşımak istersiniz?", klasorler[2],ogrencino);
                        string tasınacaksinif = Console.ReadLine();
                        //klasör taşıma
                        if (System.IO.Directory.Exists("c:\\okul2"+"\\"+ tasınacaksinif)==true)
                        {
                            string hedefklasor = @"c:\okul2" + "\\" + tasınacaksinif + "\\" + ogrencino;
                            System.IO.Directory.Move(tasinacakKlasoryolu, hedefklasor);
                            Console.Clear();
                            Console.WriteLine("\t" + "\n" + "{0} sınıfındaki {1} numaralı öğrenci, {2} sınıfına taşınmıştır..", klasorler[2],ogrencino, tasınacaksinif);
                            Console.WriteLine("\t" + "\n" + "Anamenüye dönmek için Enter tuşuna basınız..");
                            Console.ReadKey();
                            goto ANAMENU;
                        }
                        else
                        {
                            Console.WriteLine( "\n"+"\t"  + "Değişiklik yapmak istediğiniz şube okulda bulunmuyor..Kontrol ediniz");
                            Console.ReadKey();
                            Console.Clear();
                            goto TASIMA;
                        }
                    }
                    else
                    {
                        Console.WriteLine("\t" + "\n" + "Kayıtlarda {0} numaralı öğrenci bulunmamaktadır, Kontrol ediniz..",ogrencino);
                        Console.ReadKey();
                        Console.Clear();
                        goto DEGISIKLIK;
                    }
                }



                if (secim == '5')
                {

                    Console.WriteLine("~~~~~~...ÇIKIŞ YAPILIYOR...İYİ GÜNLER DİLERİZ...~~~~~~");
                    Console.ReadKey();
                    Environment.Exit(0);
                }





            } while (secim!='1'|| secim != '2' || secim != '3' || secim != '4' || secim != '5');

        }
    }
}

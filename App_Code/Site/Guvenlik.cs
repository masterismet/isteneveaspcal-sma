using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;


    public class Guvenlik
    {
        public Guvenlik()
        {
        }

        /// <summary>
        /// Değişken sınırlaması yapmak için max bir karakter girin
        /// </summary>
        public static string Kisitla(string kelime, int max)
        {
            if (kelime.Length > max)
            {
                kelime.Substring(0, max);
            }

            return kelime;
        }

        /// <summary>
        /// Girilen değerin sayı olup olmadığını kontrol eder. Sayı değilse geriye 0 döner.
        /// </summary>
        public static int SadeceSayi(object sayi)
        {
            int guvenliSayi;
            try
            {
                guvenliSayi = Convert.ToInt32(sayi);
                if (guvenliSayi.ToString().Length > 10)
                {
                    int kalan = 0;
                    kalan = guvenliSayi.ToString().Length - 10;
                    guvenliSayi = Convert.ToInt32(guvenliSayi.ToString().Substring(0, guvenliSayi.ToString().Length - kalan));
                }
            }
            catch
            {
                guvenliSayi = 0;
            }
            return guvenliSayi;
        }

        /// <summary>
        /// Değişkene Basit Bir Güvenlik Getirebiliriz
        /// </summary>
        public static string BasitGuvenlik(string kelime)
        {
            kelime = kelime.Trim();
            kelime = kelime.Replace("'", "");
            kelime = kelime.Replace("<", "");
            kelime = kelime.Replace(">", "");
            kelime = kelime.Replace("&", "");
            kelime = kelime.Replace("#", "");
            kelime = kelime.Replace("$", "");
            return kelime;
        }

        /// <summary>
        /// Değişken Yanına Sayı Belirterek Limit Koyabiliriz
        /// </summary>
        public static string BasitGuvenlik(string kelime, int maxSayi)
        {
            kelime = kelime.Trim();

            if (kelime.Length > maxSayi)
            {
                kelime = "";
            }
            else
            {
                kelime = kelime.Replace("'", "");
                kelime = kelime.Replace("<", "");
                kelime = kelime.Replace(">", "");
                kelime = kelime.Replace("&", "");
                kelime = kelime.Replace("#", "");
                kelime = kelime.Replace("$", "");
            }
            return kelime;
        }

        /// <summary>
        /// Değişken linkleri girilebilecek tüm geçersiz karakterlerden temizler.
        /// </summary>
        public static string YaziDuzenle(string kelime)
        {
            if (kelime.Length > 100)
            {
                int kalan = 0;
                kalan = kelime.Length - 100;
                kelime = kelime.Substring(0, kelime.Length - kalan);
            }

            kelime = kelime.Replace(@"\", "-");
            kelime = kelime.Replace("/", "-");
            kelime = kelime.Replace("*", "-");
            kelime = kelime.Replace("<", "-");
            kelime = kelime.Replace(">", "-");
            kelime = kelime.Replace("=", "-");
            kelime = kelime.Replace(";", "-");
            kelime = kelime.Replace("+", "-");
            kelime = kelime.Replace("&", "-");
            kelime = kelime.Replace("%", "-");
            kelime = kelime.Replace("#", "-");
            kelime = kelime.Replace("[", "-");
            kelime = kelime.Replace("]", "-");
            kelime = kelime.Replace("{", "-");
            kelime = kelime.Replace("}", "-");
            kelime = kelime.Replace("_", "-");
            kelime = kelime.Replace("?", "-");
            kelime = kelime.Replace("^", "-");
            kelime = kelime.Replace("'", "-");
            kelime = kelime.Replace(":", "-");
            kelime = kelime.Replace(".", "-");
            kelime = kelime.Replace(",", "-");
            kelime = kelime.Replace("@", "-");
            kelime = kelime.Replace("%", "-");
            kelime = kelime.Replace("(", "-");
            kelime = kelime.Replace(")", "-");
            kelime = kelime.Replace("ş", "s");
            kelime = kelime.Replace("Ş", "S");
            kelime = kelime.Replace("Ü", "U");
            kelime = kelime.Replace("ü", "u");
            kelime = kelime.Replace("ö", "o");
            kelime = kelime.Replace("Ö", "O");
            kelime = kelime.Replace("ğ", "g");
            kelime = kelime.Replace("Ğ", "G");
            kelime = kelime.Replace("İ", "I");
            kelime = kelime.Replace("ı", "i");
            kelime = kelime.Replace("ç", "c");
            kelime = kelime.Replace("Ç", "C");
            kelime = kelime.Replace(" ", "-");
            return kelime;
        }

        static public string Degistir(string kelime)
        {
            kelime = kelime.Replace(@"\", "");
            kelime = kelime.Replace("*", "");
            kelime = kelime.Replace("--", "");
            kelime = kelime.Replace("<", "");
            kelime = kelime.Replace(">", "");
            kelime = kelime.Replace("=", "");
            kelime = kelime.Replace(";", "");

            return kelime;
        }

        static public string ForId(string kelime)
        {
            if (kelime.Length > 10)
                kelime = "";
            else
            {
                kelime = kelime.Replace(@"\", "");
                kelime = kelime.Replace("/", "");
                kelime = kelime.Replace("*", "");
                kelime = kelime.Replace("--", "");
                kelime = kelime.Replace("<", "");
                kelime = kelime.Replace(">", "");
                kelime = kelime.Replace("=", "");
                kelime = kelime.Replace(";", "");
                kelime = kelime.Replace("+", "");
                kelime = kelime.Replace("&", "");
                kelime = kelime.Replace("%", "");
                kelime = kelime.Replace("#", "");
                kelime = kelime.Replace("[", "");
                kelime = kelime.Replace("]", "");
                kelime = kelime.Replace("{", "");
                kelime = kelime.Replace("}", "");
                kelime = kelime.Replace("_", "");
                kelime = kelime.Replace("?", "");
                kelime = kelime.Replace("^", "");
                kelime = kelime.Replace("'", "");
                kelime = kelime.Replace("!", "");
            }

            return kelime;
        }

        #region Kelime Kontrol

        public static bool RegexKullanici(string kelime)
        {
            return RegexKontrol(kelime, SiteTanim.RegexKullaniciAdi);
        }
        public static bool RegexSifre(string kelime)
        {
            return RegexKontrol(kelime, SiteTanim.RegexSifre);
        }

        private static bool RegexKontrol(string kelime, string regex)
        {
            Regex rx = new Regex(regex);
            if (rx.Match(kelime).Success)
                return true;
            return false;
        }

        #endregion
    }

using System;
using System.Text;
using System.Security.Cryptography;

namespace IronSky.Helpers
{
    public static class AESHash
    {
        public static string ConvertStringToHex(this String input)
        {
            Byte[] stringBytes = System.Text.Encoding.Unicode.GetBytes(input);
            StringBuilder sbBytes = new StringBuilder(stringBytes.Length * 2);
            foreach (byte b in stringBytes)
            {
                sbBytes.AppendFormat("{0:X2}", b);
            }
            return sbBytes.ToString();
        }

        public static string ConvertHexToString(this String hexInput)
        {
            int numberChars = hexInput.Length;
            byte[] bytes = new byte[numberChars / 2];
            for (int i = 0; i < numberChars; i += 2)
            {
                bytes[i / 2] = Convert.ToByte(hexInput.Substring(i, 2), 16);
            }
            return System.Text.Encoding.Unicode.GetString(bytes);
        }

        public static string AES_Encrypt(this string text)
        {
            string AesIV = @"ZCEHNTNMQVRXMMPP";
            string AesKey = @"IJMXDFFXDWBJNDRH";
            // AesCryptoServiceProvider
            AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
            aes.BlockSize = 128;//blok blok şifreleme yapıldığı için 
                                //nekadarlık bloklar halinde şifreleneceği tanımlanıyor.
            aes.KeySize = 128;//anahtar ile şifreleme yapılıyo. 
                              //anahtar boyutları, 128-192 ve 256 olabilir.
            aes.IV = Encoding.UTF8.GetBytes(AesIV);//bunu anlamadım :=)
            aes.Key = Encoding.UTF8.GetBytes(AesKey);//anahtar bytea çevriliyor. 
                                                     //Böylece evrensel olarak bütün dosya, resim, metin vs 
                                                     //bytelara çevrilerek şifreleme yapılabilir.
            aes.Mode = CipherMode.CBC;//Şifreleme modu seçiliyo genelde cbc olur 
            aes.Padding = PaddingMode.PKCS7;

            // Convert string to byte array
            byte[] src = Encoding.Unicode.GetBytes(text);//aynı şekilde 
                                                         //metin de bytelara çevrilir

            //şifreleme burda gerçekleşiyor
            using (ICryptoTransform encrypt = aes.CreateEncryptor())
            {
                //bloklar alınır şifrelenir
                byte[] dest = encrypt.TransformFinalBlock(src, 0, src.Length);
                // //daha sonra şifreli byte blokları stringe çevrilir.
                return Convert.ToBase64String(dest).ConvertStringToHex();
            }
        }

        public static string AES_Decrypt(this string text)
        {
            text = text.ConvertHexToString();
            string AesIV = @"ZCEHNTNMQVRXMMPP";
            string AesKey = @"IJMXDFFXDWBJNDRH";
            // AesCryptoServiceProvider
            AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
            aes.BlockSize = 128;
            aes.KeySize = 128;
            aes.IV = Encoding.UTF8.GetBytes(AesIV);
            aes.Key = Encoding.UTF8.GetBytes(AesKey);
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;

            // Convert Base64 strings to byte array
            byte[] src = System.Convert.FromBase64String(text);

            // decryption
            using (ICryptoTransform decrypt = aes.CreateDecryptor())
            {
                byte[] dest = decrypt.TransformFinalBlock(src, 0, src.Length);
                return Encoding.Unicode.GetString(dest);
            }
        }
    }
}

using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Common.Cryptography.Interface;
using Newtonsoft.Json;

namespace Common.Cryptography.Service
{
    public class CryptographyService : ICryptographyService
    {
        public CryptographyService()
        {

        }
        private byte[] ToByteArray(string str, Encoding encoding)
        {
            return encoding.GetBytes(str);
        }
        private char CharAt(string s, int n)
        {
            return s[n];
        }
        private String ToBinary(Byte[] data, string separator = "")
        {
            return string.Join(separator.ToString(), data.Select(byt => Convert.ToString(byt, 2).PadLeft(8, '0')));
        }
        public String GetKey(string n, Encoding e)
        {
            var x = new char[36];
            var bytes = ToByteArray(n, e);
            var y = ToBinary(bytes);
            for (var i = 0; i < x.Length; i++)
            {
                x[i] = (char)(((i < 10) ? 48 : 87) + i);
            }

            for (byte z = 0; z < y.Length; z++)
            {
                if (CharAt(y, z) == '1')
                {
                    byte i = 0;
                    while (i < x.Length)
                    {
                        var m = (byte)(i + z + 1);

                        if (m > (x.Length - 1))
                            m = (byte)(m - x.Length);

                        var t = x[i];
                        if (m % 3 == 0)
                        {
                            x[i] = x[m];
                        }
                        else
                        {
                            if (m % 2 == 0)
                            {
                                x[i] = Char.ToUpper(x[m]);
                            }
                            else
                            {
                                x[i] = Char.ToLower(x[m]);
                            }
                        }
                        x[m] = t;

                        i += (byte)(z + 2);
                    }
                }
            }

            return new string(x).Substring(0, 16);
        }
        private RijndaelManaged GetCryptoTransform(string key)
        {
            var keyString64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(key));

            var aes = new RijndaelManaged();
            aes.BlockSize = 128;
            aes.KeySize = 256;

            // It is equal in java 
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;

            var keyArr = Convert.FromBase64String(keyString64);
            var keyArrBytes32Value = new byte[keyArr.Length];

            Array.Copy(keyArr, keyArrBytes32Value, keyArr.Length);

            // Initialization vector.   
            // It could be any value or generated using a random number generator.
            byte[] ivArr = { 1, 2, 3, 4, 5, 6, 6, 5, 4, 3, 2, 1, 7, 7, 7, 7 };
            var ivBytes16Value = new byte[16];

            Array.Copy(ivArr, ivBytes16Value, 16);

            aes.Key = keyArrBytes32Value;
            aes.IV = ivBytes16Value;

            return aes;
        }
        public string Encrypt(string plainText, string key)
        {
            var aes = GetCryptoTransform(key);
            var encrypto = aes.CreateEncryptor();

            var plainTextByte = Encoding.UTF8.GetBytes(plainText);
            var cipherText = encrypto.TransformFinalBlock(plainTextByte, 0, plainTextByte.Length);

            return Convert.ToBase64String(cipherText);
        }

        public string Decrypt(string cipherText, string key)
        {
            var aes = GetCryptoTransform(key);
            var decrypto = aes.CreateDecryptor();

            var encryptedBytes = Convert.FromBase64CharArray(cipherText.ToCharArray(), 0, cipherText.Length);
            var decryptedData = decrypto.TransformFinalBlock(encryptedBytes, 0, encryptedBytes.Length);

            return Encoding.UTF8.GetString(decryptedData);
        }

        public string GetKey(string n, string enoding)
        {
            if (string.Compare(enoding, "ascii", StringComparison.OrdinalIgnoreCase) == 0)
            {
                return GetKey(n, Encoding.ASCII);
            }
            if (string.Compare(enoding, "utf8", StringComparison.OrdinalIgnoreCase) == 0)
            {
                return GetKey(n, Encoding.UTF8);
            }
            if (string.Compare(enoding, "utf7", StringComparison.OrdinalIgnoreCase) == 0)
            {
                return GetKey(n, Encoding.UTF7);
            }
            if (string.Compare(enoding, "unicode", StringComparison.OrdinalIgnoreCase) == 0)
            {
                return GetKey(n, Encoding.Unicode);
            }
            throw new Exception("Unsupported encoding");
        }

        public T Decrypt<T>(string cipherText, string key)
        {
            var cypherText = Decrypt(cipherText, key);

            return JsonConvert.DeserializeObject<T>(cypherText);
        }

        public string Encrypt<T>(T data, string key)
        {
            var plainText = JsonConvert.SerializeObject(data);

            return Decrypt(plainText, key);
        }
    }
}
﻿using System.Text;
using System.Threading.Tasks;

namespace Common.Cryptography.Interface
{
    public interface ICryptographyService
    {
        string Decrypt(string data, string key);
        string Encrypt(string data, string key);
        string GetKey(string n, string e);
        string GetKey(string n, Encoding e);

        Task<T> Decrypt<T>(string cipherText, string key);
    }
}
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Netcore.Infrastructure.Crosscutting
{
    public class Util
    {

        public class ReCaptcha
        {
            public bool Success { get; set; }
            public List<string> ErrorCodes { get; set; }

            public static async Task<bool> Validate(string encodedResponse, string secretKey, string urlGoogle)
            {
                if (string.IsNullOrEmpty(encodedResponse)) return false;

                var client = new System.Net.WebClient();
                var secret = secretKey;

                if (string.IsNullOrEmpty(secret)) return false;

                var googleReply = await client.DownloadStringTaskAsync(string.Format(urlGoogle, secret, encodedResponse));


                var reCaptcha = JsonConvert.DeserializeObject<ReCaptcha>(googleReply);

                return reCaptcha.Success;
            }
        }
        public class EncryptionAlgorithm
        {
            public string Password { get; set; }

            public string EncryptStr(string texto)
            {
                string key = Password;
                if (string.IsNullOrEmpty(key))
                    throw new ArgumentException("Key must have valid value.", nameof(key));
                if (string.IsNullOrEmpty(texto))
                    throw new ArgumentException("The text must have valid value.", nameof(texto));

                var buffer = Encoding.UTF8.GetBytes(texto);
                var hash = new SHA512CryptoServiceProvider();
                var aesKey = new byte[24];
                Buffer.BlockCopy(hash.ComputeHash(Encoding.UTF8.GetBytes(key)), 0, aesKey, 0, 24);

                using (var aes = Aes.Create())
                {
                    if (aes == null)
                        throw new ArgumentException("Parameter must not be null.", nameof(aes));

                    aes.Key = aesKey;

                    using (var encryptor = aes.CreateEncryptor(aes.Key, aes.IV))
                    using (var resultStream = new MemoryStream())
                    {
                        using (var aesStream = new CryptoStream(resultStream, encryptor, CryptoStreamMode.Write))
                        using (var plainStream = new MemoryStream(buffer))
                        {
                            plainStream.CopyTo(aesStream);
                        }

                        var result = resultStream.ToArray();
                        var combined = new byte[aes.IV.Length + result.Length];
                        Array.ConstrainedCopy(aes.IV, 0, combined, 0, aes.IV.Length);
                        Array.ConstrainedCopy(result, 0, combined, aes.IV.Length, result.Length);

                        return Convert.ToBase64String(combined);
                    }
                }
            }

            public string Decrypt(string texto)
            {
                string key = Password;
                if (string.IsNullOrEmpty(key))
                    throw new ArgumentException("Key must have valid value.", nameof(key));
                if (string.IsNullOrEmpty(texto))
                    throw new ArgumentException("The encrypted text must have valid value.", nameof(texto));

                var combined = Convert.FromBase64String(texto);
                var buffer = new byte[combined.Length];
                var hash = new SHA512CryptoServiceProvider();
                var aesKey = new byte[24];
                Buffer.BlockCopy(hash.ComputeHash(Encoding.UTF8.GetBytes(key)), 0, aesKey, 0, 24);

                using (var aes = Aes.Create())
                {
                    if (aes == null)
                        throw new ArgumentException("Parameter must not be null.", nameof(aes));

                    aes.Key = aesKey;

                    var iv = new byte[aes.IV.Length];
                    var ciphertext = new byte[buffer.Length - iv.Length];

                    Array.ConstrainedCopy(combined, 0, iv, 0, iv.Length);
                    Array.ConstrainedCopy(combined, iv.Length, ciphertext, 0, ciphertext.Length);

                    aes.IV = iv;

                    using (var decryptor = aes.CreateDecryptor(aes.Key, aes.IV))
                    using (var resultStream = new MemoryStream())
                    {
                        using (var aesStream = new CryptoStream(resultStream, decryptor, CryptoStreamMode.Write))
                        using (var plainStream = new MemoryStream(ciphertext))
                        {
                            plainStream.CopyTo(aesStream);
                        }

                        return Encoding.UTF8.GetString(resultStream.ToArray());
                    }
                }
            }
        }



       


      
    }
}

using System.Security.Cryptography;

namespace SecreteGen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string secretKey = GenerateSecretKey(32);

            Console.WriteLine("Generated Secret Key: " + secretKey);
        }


        public static string GenerateSecretKey(int lengthInBytes)
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                byte[] keyBytes = new byte[lengthInBytes];
                rng.GetBytes(keyBytes);
                return Convert.ToBase64String(keyBytes);
            }
        }
    }
}
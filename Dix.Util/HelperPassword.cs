using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Dix.Util
{
    public static class HelperPassword
    {
        public static string EncryptString(string plainText, byte[] Key, byte[] IV)
        {
            // Check arguments.
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullEx
using (Rijndael myRijndael = Rijndael.Create())
            {
                string encrypted = HelperPassword.EncryptString(entity.Password, myRijndael.Key, myRijndael.IV);

                entity.Password = encrypted;
            }

            return await _userRepository.AddAsync(entity);
        }
    }
}

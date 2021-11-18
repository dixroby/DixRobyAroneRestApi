using System;
using System.IO;
using System.Security.Cryptography;

namespace Dix.Util
{
    public class Utiles
    {
        public static byte[] StringBase64ToBytes(string valor)
        {
            // recive un valor de tipo string, conviente a base 64 y retorna un byte[]
            return (string.IsNullOrEmpty(valor) == false ? System.Convert.FromBase64String(valor) : null);
        }
    }
}

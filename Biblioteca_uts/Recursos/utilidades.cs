
using System.Security.Cryptography;
using System.Text;

namespace Biblioteca_uts.Recurso
{
    public class utilidades
    {
        public static string EncriptarClave(string clave)
        {
            StringBuilder sb = new StringBuilder();
            using (SHA256 hash = SHA256Managed.Create())
            {
                //codificacion UTF8
                Encoding enc = Encoding.UTF8;
                byte[] result = hash.ComputeHash(enc.GetBytes(clave));
                foreach (byte b in result)
                {
                    sb.Append(b.ToString("x2"));//el x2 es el formato para la cadena

                }
            }
            return sb.ToString();
        }

    }
}

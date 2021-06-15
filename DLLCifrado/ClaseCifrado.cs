using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Data.SqlClient;

namespace DLLCifrado
{
    public class ClaseCifrado
    {
        public string Cifrado (string texto)
        {
            try
            {
                using (SHA256 cifrar = SHA256.Create())
                {
                    byte[] arreglo = cifrar.ComputeHash
                        (Encoding.UTF8.GetBytes(texto));
                    StringBuilder textocifrado = new StringBuilder();
                    for (int i=0; i< arreglo.Length; i++)
                    {
                        textocifrado.Append(arreglo[i].ToString("X2"));
                    }
                    return textocifrado.ToString();
                }
                return "error";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public bool Guardar(string Usuario , string Contraseña)
        {
            var conexion = new SqlConnection
                ("Data Source=LAPTOP-IH9BQBUP;" +
               "Initial Catalog=Usuarios;" +
               "User = sa; Password = 0909");
            try
            {
                var Insertar = new SqlCommand
                  ("INSERT INTO Datos1 (Usuario,Contraseña) VALUES ('" + Usuario +  "','" + Contraseña + "')", conexion);
                  conexion.Open();
                Insertar.ExecuteNonQuery();
                conexion.Close();
                return true;
            }
            catch (Exception ex)
            {
                conexion.Close();
                return false;

            }

        }
    }

}

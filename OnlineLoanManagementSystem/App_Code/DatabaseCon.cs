using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace OnlineLoanManagementSystem.App_Code
{
    public class DatabaseCon
    {

        public static System.Data.DataTable GetData(string dataString)
        {

            var con = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString);

            var dt = new System.Data.DataTable();
            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }

                var query = dataString;

                var sda = new SqlDataAdapter(query, con);
                var ds = new DataSet();
                try
                {
                    sda.SelectCommand.CommandTimeout = 0;
                }
                catch { }
                sda.Fill(ds);
                dt = ds.Tables[0];
            }
            catch
            {

            }
            finally { con.Close(); }

            return dt;
        }


        public static int RunCmd(string Query)
        {
            int d = 0;
            var con = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString);
            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                SqlCommand com = new SqlCommand(Query, con);
                com.CommandTimeout = 0;
                d = Convert.ToInt32((object)com.ExecuteNonQuery());
            }

            catch (Exception)
            {
                return d;
            }
            finally
            {
                con.Close();
            }
            return d;

        }


        public static string Encrypt(string clearText)
        {
            string EncryptionKey = "KAY2JOSH4PBNI99212";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }
        public static string Decrypt(string cipherText)
        {
            try
            {
                string EncryptionKey = "KAY2JOSH4PBNI99212";
                cipherText = cipherText.Replace(" ", "+");
                byte[] cipherBytes = Convert.FromBase64String(cipherText);
                using (Aes encryptor = Aes.Create())
                {
                    Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                    encryptor.Key = pdb.GetBytes(32);
                    encryptor.IV = pdb.GetBytes(16);
                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(cipherBytes, 0, cipherBytes.Length);
                            cs.Close();
                        }
                        cipherText = Encoding.Unicode.GetString(ms.ToArray());
                    }
                }
                return cipherText;
            }
            catch
            {
                return "0";
            }
        }


    }
}
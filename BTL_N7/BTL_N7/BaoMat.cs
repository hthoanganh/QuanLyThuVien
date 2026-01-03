using System;
using System.Security.Cryptography; 
using System.Text;

namespace BTL_N7
{
    public static class BaoMat
    {
        // Hàm băm MD5 (Mã hóa 1 chiều)
        public static string MaHoaMD5(string text)
        {
            if (string.IsNullOrEmpty(text)) return "";

            using (MD5 md5 = MD5.Create())
            {
                // Chuyển chuỗi thành mảng byte
                byte[] inputBytes = Encoding.ASCII.GetBytes(text);

                // Băm (Hash)
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Chuyển ngược lại thành chuỗi Hex (VD: A3F1...)
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2")); // X2 để in hoa
                }
                return sb.ToString();
            }
        }
    }
}
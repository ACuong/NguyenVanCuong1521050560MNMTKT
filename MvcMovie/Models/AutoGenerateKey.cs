using System;
using System.Text.RegularExpressions;

namespace MvcMovie
{
    public class AutoGenerateKey
    {
        public string GenerateKey(string id) // truyen vao ID vd: "PS001"
        {
            string strkey = ""; // ID moi
            string numPart = "", strPart = "", strPhanso = "";

            numPart = Regex.Match(id, @"\d+").Value; // lay ra phan so cua key "1"
            strPart = Regex.Match(id, @"\D+").Value; // lay ra phan chu cua key = "PS"

            int Phanso = Convert.ToInt32(numPart) + 1; // cong them phan so 1 don vi "2"

            for(int i = 0; i < numPart.Length - Phanso.ToString().Length; i++) //(2 -1)
            {
                strPhanso += "0";
            }
            // strPhanso = "0"
            strPhanso += Phanso; // "0" + "2" = "02"
            strkey = strPart + strPhanso;  // "PS" + "02" = "PS02"

            return strkey;
        }

        internal void GenerateKey(object personID)
        {
            throw new NotImplementedException();
        }
    }
}
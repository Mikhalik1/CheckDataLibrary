using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CheckDataLibrary
{
    public class VinCheck
    {
        public bool CheckVin(string vin, int year)
        {
            int ves = 0;
            double kratno = 0;
            char[] ar = vin.ToUpper().ToCharArray();
            char[] iskl = "IOQ".ToCharArray();
            if (string.IsNullOrEmpty(vin))
            {
                return false;
            }
            if (vin.Length != 17)
            {
                return false;
            }
            for (int i = 0; i < ar.Length; i++)
            {
                for (int j = 0; j < iskl.Length; j++)
                {
                    if (iskl[j] == ar[i])
                    {
                        return false;
                    }
                }
            }
            for (int i = 13; i < vin.Length;i++)
            {
                if (!char.IsDigit(vin[i])) 
                {
                    return false;
                }
            }
            char[] alpha = "ABCDEFGHJKLMNPRSTUVWXYZ".ToCharArray();
            char[] number = "12345678123457923456789".ToCharArray();
            int[] weth = { 8, 7, 6, 5, 4, 3, 2, 10, 0, 9, 8, 7, 6, 5, 4, 3, 2 };
            for (int i = 0; i < ar.Length;i++)
            {
                for (int j = 0; j < alpha.Length;j++)
                {
                    if (ar[i] == alpha[j])
                    {
                        ar[i] =  number[j];
                    }
                }
            }
            for(int a = 0;a <ar.Length; a++)
            {
                ves = ves + Convert.ToInt32(char.GetNumericValue(ar[a])) * weth[a]; 
            }
            kratno = ves / 11;
            kratno= Math.Ceiling(kratno) * 11;
            int CHK = Convert.ToInt32(ves - kratno);

            if (CHK == 10)
            {
                ar[8] = 'X';
            }
            if (CHK == char.GetNumericValue(ar[8]) || ar[8] == 'X')
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //public string GetVINCountry(string vin)
        //{

        //}
        //public bool CorrectYear(string vin,int year)
        //{

        //}
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanksProvince
{
    class Program
    {
        #region Fields
        /// <summary>
        /// Address of First File For Reading 
        /// </summary>
        private static string firstDirectory = @"C:\Users\faranam\Desktop\AYN_BRNCH_971025.txt";

        /// <summary>
        /// Address of Second File for Write Output
        /// </summary>
        private static string secondDirectory = @"C:\Users\faranam\Desktop\Context1.txt";

        /// <summary>
        /// Context Of the First File
        /// </summary>
        public static string Context = File.ReadAllText(firstDirectory);
        #endregion

        #region Order Function
        /// <summary>
        /// Change Order of Text
        /// </summary>
        static private void Order()
        {
            string[] context = new string[File.ReadAllLines(firstDirectory).Length];
            context = File.ReadAllLines(firstDirectory);
            Banks bank = new Banks();
            List<Banks> banks = new List<Banks>();
            string[] temp = new string[9];
            for (int i = 0; i < context.Length; i++)
            {
                temp = null;
                bank = new Banks();
                temp = context[i].Split(',');
                if (temp.Length >= 1)
                    bank.BankCode = temp[0] + ", ";
                if (temp.Length >= 2)
                    bank.ProvinceCode = temp[1] + ", ";
                if (temp.Length >= 3)
                    bank.ProvinceName = temp[2] + ", ";
                if (temp.Length >= 4)
                    bank.CityCode = temp[3] + ", ";
                if (temp.Length >= 5)
                    bank.CityName = temp[4] + ", ";
                if (temp.Length >= 6)
                    bank.Branch = temp[5] + ", ";
                if (temp.Length >= 7)
                    bank.BranchName = temp[6] + ", ";
                if (temp.Length >= 8)
                    bank.Address = temp[7] + ", ";
                if (temp.Length >= 9)
                    bank.PostalCode = temp[8] + ", ";
                banks.Add(bank);
            }
            IEnumerable<Banks> orderedList = 
                banks.OrderBy(ProvinceName => ProvinceName.ProvinceName);

            Banks[] bankArray =
                new Banks[File.ReadAllLines(firstDirectory).Length];

            bankArray = orderedList.ToArray();
            int Province = 1;
            string x = "";
            string lastProvince;
            string nowProvince;
            foreach (var item in bankArray)
            {
                lastProvince = temp[0];

                temp[4] = item.Branch;
                temp[1] = item.BranchName;
                temp[2] = item.BankCode;
                temp[3] = item.ProvinceCode;
                temp[0] = item.ProvinceName;
                temp[5] = item.CityCode;
                temp[6] = item.CityName;
                temp[7] = item.PostalCode;
                temp[8] = item.Address;

                nowProvince = item.ProvinceName;
                if (nowProvince.Contains(lastProvince))
                {
                    Province++;

                }
                else
                {
                    x = x.Insert(0, Environment.NewLine + 
                        lastProvince + Province + Environment.NewLine);

                    File.AppendAllText(secondDirectory, x);
                    x = null;
                    Province = 1;
                }
                x += temp[0] +  temp[1] + temp[2] + temp[3] + 
                    temp[4] + temp[5] + temp[6] + temp[7] + temp[8] + Environment.NewLine;
            }
        }
        #endregion

        #region Main Funtion
        /// <summary>
        /// Main Funtion
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Order();

            Console.WriteLine("Jobs Done!");
            Console.ReadKey();
        }
        #endregion
    }
}

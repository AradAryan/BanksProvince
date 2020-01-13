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
        private static string firstDirectory =
            @"C:\Users\faranam\Desktop\AYN_BRNCH_971025.txt";

        /// <summary>
        /// Address of Second File for Write Output
        /// </summary>
        private static string secondDirectory =
            @"C:\Users\faranam\Desktop\Context1.txt";

        /// <summary>
        /// Context Of the First File
        /// </summary>
        public static string Context = File.ReadAllText(firstDirectory);

        public static List<Banks> Banks = new List<Banks>();
        #endregion

        #region Order Function
        /// <summary>
        /// Change Order of Text
        /// </summary>
        static private void FillBanks()
        {
            string[] context = new string[File.ReadAllLines(firstDirectory).Length];
            context = File.ReadAllLines(firstDirectory);
            Banks bank = new Banks();
            List<Banks> banks = new List<Banks>();
            string[] temp = new string[9];
            int arrayCount = 0;
            for (int i = 0; i < context.Length; i++)
            {
                bank = new Banks();
                arrayCount = context[i].Split(',').Length;
                for (int j = 0; j < arrayCount; j++)
                {
                    temp[j] = context[i].Split(',')[j];
                }
                bank.BankCode = temp[0] + ",";
                bank.ProvinceCode = temp[1] + ",";
                bank.ProvinceName = temp[2] + ",";
                bank.CityCode = temp[3] + ",";
                bank.CityName = temp[4] + ",";
                bank.Branch = temp[5] + ",";
                bank.BranchName = temp[6] + ",";
                bank.Address = temp[7] + ",";
                bank.PostalCode = temp[8];
                banks.Add(bank);
            }
            Banks = banks;
        }
        #endregion
        static private void Group()
        {
            var result = Banks.GroupBy(bank => bank.ProvinceName);
            Context = null;
            foreach (var item in result)
            {
                
                Context += item.Key + item.Count() + Environment.NewLine;
                foreach (var bank in item)
                {
                    Context +=  bank.BankCode + bank.ProvinceCode + bank.ProvinceName + bank.CityCode +
                        bank.CityName + bank.Branch + bank.BranchName + bank.Address +bank.PostalCode + Environment.NewLine;
                       
                }
            }
        }

        static private void WriteToFile(string path)
        {
            Stream file = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter writer = new StreamWriter(file,encoding: UTF8Encoding.UTF8);
            writer.Write(Context);
        }
        #region Main Funtion
        /// <summary>
        /// Main Funtion
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            FillBanks();
            Group();
            WriteToFile(secondDirectory);

            Console.WriteLine("Jobs Done!");
            Console.ReadKey();
        }
        #endregion
    }
}

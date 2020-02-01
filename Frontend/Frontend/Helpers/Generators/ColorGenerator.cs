using Frontend.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Frontend.Helpers.Generators
{
    public class ColorGenerator
    {

        static MD5 Md5Hash = MD5.Create();
        static Random Rnd = new Random();

        /// <summary>
        /// generiert fuer das moduleDummy eine Farbe mit der in der App.config festgelegten Methode
        /// </summary>
        /// <param name="moduleDummy"></param>
        public static string generateColor(string name, TimetableModule.ModuleType type)
        {
            string mode = ConfigurationManager.AppSettings.Get("colorgenerator.mode");

            switch(mode){
                case "hash": return GenerateHashColor(name, type);
                case "chaos": return GenerateRandomColor();
                default: return GenerateFixColorByType(type);
            }

        }

        static string GenerateHashColor(string name, TimetableModule.ModuleType type)
        {

            string assigment = ConfigurationManager.AppSettings.Get("colorgenerator.hash.assigment");
            switch (assigment)
            {
                case "byGroup": return GenerateHashColorByGroup(name);
                default: return GenerateHashColorByType(type);
            }
        }

        static string GenerateHashColorByGroup(string name)
        {
            return HashStringToColorString(name);
        }

        static string GenerateHashColorByType(TimetableModule.ModuleType type)
        {
            return HashStringToColorString(type.ToString());
        }

        static string HashStringToColorString(string hashingSource)
        {
            var hash = Md5Hash.ComputeHash(Encoding.UTF8.GetBytes(hashingSource));
            Color color = Color.FromRgb(hash[0], hash[1], hash[2]);

            return color.ToString();
        }


        static String GenerateFixColorByType(TimetableModule.ModuleType type)
        {
            switch (type)
            {
                case TimetableModule.ModuleType.PRACTICE: return ConfigurationManager.AppSettings.Get("colorgenerator.fix.practicaltraining");
                case TimetableModule.ModuleType.TUTORIAL: return ConfigurationManager.AppSettings.Get("colorgenerator.fix.tutorial");
                case TimetableModule.ModuleType.TEST: return ConfigurationManager.AppSettings.Get("colorgenerator.fix.exercise");
                default: return ConfigurationManager.AppSettings.Get("colorgenerator.fix.lecture");

            }

        }

        static String GenerateRandomColor()
        {
            byte [] numbers = new byte[3];

            Rnd.NextBytes(numbers);

            return Color.FromRgb(numbers[0], numbers[1], numbers[2]).ToString();
        }
    }
}

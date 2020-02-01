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
        public static void generateColor(TimetableModule timetableModule)
        {
            string mode = ConfigurationManager.AppSettings.Get("colorgenerator.mode");

            switch(mode){
                case "hash": timetableModule.Color = GenerateHashColor(timetableModule); break;
                case "chaos": timetableModule.Color = generateRandomColor();break;
                default: timetableModule.Color = generateFixColorByType(timetableModule); break;
            }

        }

        static string GenerateHashColor(TimetableModule module)
        {

            string assigment = ConfigurationManager.AppSettings.Get("colorgenerator.hash.assigment");
            switch (assigment)
            {
                case "byGroup": return GenerateHashColorByGroup(module);
                default: return GenerateHashColorByType(module);
            }
        }

        static string GenerateHashColorByGroup(TimetableModule module)
        {
            return HashStringToColorString(module.CourseName);
        }

        static string GenerateHashColorByType(TimetableModule module)
        {
            return HashStringToColorString(module.Type.ToString());
        }

        static string HashStringToColorString(string hashingSource)
        {
            var hash = Md5Hash.ComputeHash(Encoding.UTF8.GetBytes(hashingSource));
            Color color = Color.FromRgb(hash[0], hash[1], hash[2]);

            return color.ToString();
        }


        static String generateFixColorByType(TimetableModule module)
        {
            switch (module.Type)
            {
                case TimetableModule.ModuleType.Praktikum: return ConfigurationManager.AppSettings.Get("colorgenerator.fix.practicaltraining");
                case TimetableModule.ModuleType.Tutorium: return ConfigurationManager.AppSettings.Get("colorgenerator.fix.tutorial");
                case TimetableModule.ModuleType.Übung: return ConfigurationManager.AppSettings.Get("colorgenerator.fix.exercise");
                default: return ConfigurationManager.AppSettings.Get("colorgenerator.fix.lecture");

            }

        }

        static String generateRandomColor()
        {
            byte [] numbers = new byte[3];

            Rnd.NextBytes(numbers);

            return Color.FromRgb(numbers[0], numbers[1], numbers[2]).ToString();
        }
    }
}

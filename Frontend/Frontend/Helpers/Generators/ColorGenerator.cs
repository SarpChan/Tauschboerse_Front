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

        /// <summary>
        /// generiert fuer das moduleDummy eine Farbe mit der in der App.config festgelegten Methode
        /// </summary>
        /// <param name="moduleDummy"></param>
        public static void generateColor(ModuleDummy moduleDummy)
        {
            string mode = ConfigurationManager.AppSettings.Get("colorgenerator.mode");

            switch(mode){
                case "hash": moduleDummy.Color = GenerateHashColor(moduleDummy); break;
                default: moduleDummy.Color = generateFixColorByType(moduleDummy); break;
            }

        }

        static string GenerateHashColor(ModuleDummy module)
        {

            string assigment = ConfigurationManager.AppSettings.Get("colorgenerator.hash.assigment");
            switch (assigment)
            {
                case "byGroup": return GenerateHashColorByGroup(module);
                default: return GenerateHashColorByType(module);
            }
        }

        static string GenerateHashColorByGroup(ModuleDummy module)
        {
            return HashStringToColorString(module.CourseName);
        }

        static string GenerateHashColorByType(ModuleDummy module)
        {
            return HashStringToColorString(module.Type.ToString());
        }

        static string HashStringToColorString(string hashingSource)
        {
            var hash = Md5Hash.ComputeHash(Encoding.UTF8.GetBytes(hashingSource));
            Color color = Color.FromRgb(hash[0], hash[1], hash[2]);

            return color.ToString();
        }


        static String generateFixColorByType(ModuleDummy module)
        {
            switch (module.Type)
            {
                case ModuleDummy.ModuleType.Praktikum: return ConfigurationManager.AppSettings.Get("colorgenerator.fix.practicaltraining");
                case ModuleDummy.ModuleType.Tutorium: return ConfigurationManager.AppSettings.Get("colorgenerator.fix.tutorial");
                case ModuleDummy.ModuleType.Übung: return ConfigurationManager.AppSettings.Get("colorgenerator.fix.exercise");
                default: return ConfigurationManager.AppSettings.Get("colorgenerator.fix.lecture");

            }

        }
    }
}

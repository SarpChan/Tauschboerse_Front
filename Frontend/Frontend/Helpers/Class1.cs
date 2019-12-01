using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frontend.Models;
namespace Frontend.Helpers
{
    class Class1
    {
            static public void Main(String[] args)
            {
            var converter = new Converter();
            string file = "C:\\Users\\djager002\\Documents\\SWPFrontend\\Frontend\\Frontend\\Helpers\\hsrm_medieninformatik.json";
            University uni = converter.ParseJson(file);
            Console.WriteLine(uni.Name);
            var fos = uni.FieldOfStudies;
            foreach (var f in fos)
            {
                Console.WriteLine(f.Title);
            }
            }
        }
    }
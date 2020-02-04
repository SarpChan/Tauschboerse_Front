using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using System.Windows;
using System.IO;
using RestSharp;


/*
 * localhost:8080/rest/university/create
 * crud branch
 * Zeile 88
 */

namespace Frontend.Helpers
{
    class JsonFileDialog
    {

        public void GetJsonFromFile()
        {
            String jsonText = string.Empty;
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.InitialDirectory = @"c:";

                if (openFileDialog.ShowDialog() == true)
                {

                    using (StreamReader stream = new StreamReader(openFileDialog.FileName))
                    {
                        jsonText = stream.ReadToEnd();
                    }

                    SendJsonFile(jsonText);

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            

        }

        public void SendJsonFile(String jsonText)
        {
            var restserverurl = "http://localhost:8080";
            var client = new RestClient(restserverurl);


            var requestTimeTableJson = new RestRequest("/rest/university/create", Method.POST);
            //requestTimeTableJson.AddParameter(jsonText, ParameterType.RequestBody);
            requestTimeTableJson.AddJsonBody(jsonText);
            requestTimeTableJson.RequestFormat = RestSharp.DataFormat.Json;

            var respstadtpostjson = client.Execute(requestTimeTableJson);

        }


    }
}

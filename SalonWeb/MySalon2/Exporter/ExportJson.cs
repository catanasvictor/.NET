using Newtonsoft.Json;
using SalonWeb.DomainModel;
using System;
using System.Collections.Generic;
using System.IO;


namespace SalonWeb.Exporter
{
    public class ExportJson : IExporter
    {
       public ExportJson()
        {

        }
        public void exportFile(List<Appointment> _data)
        {

            string jsonString = JsonConvert.SerializeObject(_data.ToArray());
            string filename = "appointments_form1.json";
            File.WriteAllText(filename, jsonString);
        }

    }
}

using SalonWeb.DomainModel;
using ServiceStack.Text;
using System;
using System.Collections.Generic;
using System.IO;

namespace SalonWeb.Exporter
{
    public class CsvExporter : IExporter
    {
        public CsvExporter()
        {

        }
       public void exportFile(List<Appointment> _data)
        {
            var csv = CsvSerializer.SerializeToCsv(_data);
            string filename = "appointments_form2.csv";
            File.WriteAllText(filename, csv);
        }

       
    }
}

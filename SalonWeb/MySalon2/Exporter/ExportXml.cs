using SalonWeb.DomainModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace SalonWeb.Exporter
{
    public class ExportXml : IExporter
    {
        public ExportXml() { }

        public void exportFile(List<Appointment> _data)
        {
            
            string filename = "appointments_form3.xml";

            FileStream fs = new FileStream(filename, FileMode.Create);

            XmlWriter w = XmlWriter.Create(fs);

            w.WriteStartDocument();
            w.WriteStartElement("appointments");

            foreach (Appointment a in _data)
            {
                w.WriteElementString("ClientName", a.ClientName);
                w.WriteElementString("PhoneNumber", a.PhoneNumber);
                w.WriteElementString("Cost", (a.Cost).ToString());

                if (a.Tasks != null)
                {
                    foreach (Task t in a.Tasks)
                    {
                        w.WriteElementString("Task", t.TaskName);
                    }
                }
            }

            w.WriteEndElement();
            w.WriteEndDocument();
            w.Flush();
            fs.Close();
        }
    }
}

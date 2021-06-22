using SalonWeb.DomainModel;
using System.Collections.Generic;


namespace SalonWeb.Exporter
{
   public interface IExporter
    {
        void exportFile(List<Appointment>_data);
    }
}

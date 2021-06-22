using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SalonWeb.DomainModel
{
    public class Task
    {
        public String TaskName { get; set; }
       
        public float Price { get; set; }

        [Key]
        public int Id { get; set; }

        public int AppointmentId { get; set; }
       
        public virtual Appointment Appointment { get; set; }

    }
}

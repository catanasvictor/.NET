using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace SalonWeb.DomainModel
{

    public class Appointment
    {
        [Display(Name = "Appointment Date")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Data { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public String ClientName { get; set; }

        [RegularExpression(@"^[0-9]*$")]
        [StringLength(12)]
        [Required]
        public String PhoneNumber { get; set; }

      
        public float Cost { get; set; }

        [Key]
        public int Id { get; set; }

        public virtual ICollection<Task> Tasks { get; set; }

        
      
    }
}

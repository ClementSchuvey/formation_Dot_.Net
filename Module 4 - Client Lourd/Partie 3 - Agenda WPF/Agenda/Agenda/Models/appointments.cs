namespace Agenda.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class appointments
    {
        public int id { get; set; }

        public DateTime dateHour { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string subject { get; set; }

        public int id_brokers { get; set; }

        public int id_customers { get; set; }

        public virtual brokers brokers { get; set; }

        public virtual customers customers { get; set; }

        public string timeSlotHour
        {
            get
            {
                return string.Format(dateHour.Hour.ToString());
            }
        }

        public string timeSlotMinute
        {
            get
            {
                return string.Format(dateHour.Minute.ToString());
            }
        }

    }
}

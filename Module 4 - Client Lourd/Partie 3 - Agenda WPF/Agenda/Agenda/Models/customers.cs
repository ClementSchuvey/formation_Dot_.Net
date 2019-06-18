namespace Agenda.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class customers
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public customers()
        {
            appointments = new HashSet<appointments>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string lastName { get; set; }

        [Required]
        [StringLength(50)]
        public string firstName { get; set; }

        [Required]
        [StringLength(100)]
        public string mail { get; set; }

        [Required]
        [StringLength(10)]
        public string phoneNumber { get; set; }

        public int budget { get; set; }

        public string fullName
        {
            get
            {
                return string.Format("{0} {1}", lastName, firstName);
            }
        }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<appointments> appointments { get; set; }
    }
}

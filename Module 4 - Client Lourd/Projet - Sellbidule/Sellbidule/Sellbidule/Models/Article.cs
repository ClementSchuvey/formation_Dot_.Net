namespace Sellbidule.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Article")]
    public partial class Article
    {
        public int id { get; set; }

        [Required]
        [StringLength(10)]
        public string reference { get; set; }

        [Required]
        [StringLength(100)]
        public string name { get; set; }

        public float price { get; set; }

        public int quantity { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string description { get; set; }

        [Required]
        [StringLength(255)]
        public string picture { get; set; }

        public string fullPicture
        {
            get
            {
                return string.Format("../Pictures/" + picture);
            }
        }

        public int id_Category { get; set; }

        public virtual Category Category { get; set; }
    }
}

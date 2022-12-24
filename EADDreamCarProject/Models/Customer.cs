namespace EADDreamCarProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web;

    [Table("Customer")]
    public partial class Customer
    {
        public int CustomerID { get; set; }

        [Required]
        [StringLength(50)]
        public string CustomerName { get; set; }

        [Required]
        [StringLength(50)]
        public string CustomerCity { get; set; }

        [Required]
        [StringLength(50)]
        public string CustomerAddress { get; set; }

        [Required]
        [StringLength(50)]
        public string CustomerContact { get; set; }

        [Required]
        [StringLength(50)]
        public string CustomerEmail { get; set; }

        public int CompanyFID { get; set; }

        public int CarModelFID { get; set; }

        [StringLength(300)]
        public string CustomerPicture { get; set; }

        [NotMapped]
        public HttpPostedFileBase CustomerPic { get; set; }

        //is mai HttpPostedFileBase k liye ek library auto generate ho gi System.Web k name se

        public virtual CarModel CarModel { get; set; }

        public virtual Company Company { get; set; }
    }
}

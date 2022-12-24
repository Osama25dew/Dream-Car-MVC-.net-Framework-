namespace EADDreamCarProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web;

    [Table("CarModel")]
    public partial class CarModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CarModel()
        {
            Customers = new HashSet<Customer>();
        }

        public int CarModelID { get; set; }

        [Required]
        [StringLength(50)]
        public string CarModelName { get; set; }

        [Column(TypeName = "numeric")]
        public decimal CarModelPrice { get; set; }

        [Required]
        [StringLength(50)]
        public string CarModelDescription { get; set; }

        [Required]
        [StringLength(50)]
        public string CarModelEngineCapacity { get; set; }

        [Required]
        [StringLength(50)]
        public string CarModelFuelType { get; set; }

        [StringLength(300)]
        public string CarModelPicture { get; set; }

        [NotMapped]
        public HttpPostedFileBase CarModelPic { get; set; }

        //is mai HttpPostedFileBase k liye ek library auto generate ho gi System.Web k name se

        public int CompanyFID { get; set; }

        public virtual Company Company { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Customer> Customers { get; set; }
    }
}

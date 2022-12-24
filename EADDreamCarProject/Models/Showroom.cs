namespace EADDreamCarProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Showroom")]
    public partial class Showroom
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Showroom()
        {
            CompanyShowrooms = new HashSet<CompanyShowroom>();
        }

        public int ShowroomID { get; set; }

        [Required]
        [StringLength(50)]
        public string ShowroomName { get; set; }

        [Required]
        [StringLength(50)]
        public string ShowroomCity { get; set; }

        [Required]
        [StringLength(50)]
        public string ShowroomAddress { get; set; }

        [Required]
        [StringLength(50)]
        public string ShowroomContact { get; set; }

        [Required]
        [StringLength(50)]
        public string ShowroomEmail { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CompanyShowroom> CompanyShowrooms { get; set; }
    }
}

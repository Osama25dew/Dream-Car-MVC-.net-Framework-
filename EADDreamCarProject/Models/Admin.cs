 namespace EADDreamCarProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web;

    [Table("Admin")]
    public partial class Admin
    {
        public int AdminID { get; set; }

        [Required]
        [StringLength(50)]
        public string AdminName { get; set; }

        [Required]
        [StringLength(50)]
        public string AdminEmail { get; set; }

        [Required]
        [StringLength(50)]
        public string AdminPassword { get; set; }

        [Required]
        [StringLength(50)]
        public string AdminContact { get; set; }

        [Required]
        [StringLength(50)]
        public string AdminAddress { get; set; }

        [StringLength(300)]
        public string AdminPicture { get; set; }

        [NotMapped]
        public HttpPostedFileBase AdminPic { get; set; }

        //is mai HttpPostedFileBase k liye ek library auto generate ho gi System.Web k name se

    }
}

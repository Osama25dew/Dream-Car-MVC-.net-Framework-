namespace EADDreamCarProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CompanyShowroom")]
    public partial class CompanyShowroom
    {
        public int CompanyShowroomID { get; set; }

        public int? CompanyFID { get; set; }

        public int? ShowroomFID { get; set; }

        public virtual Company Company { get; set; }

        public virtual Showroom Showroom { get; set; }
    }
}

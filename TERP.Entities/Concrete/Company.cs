using TERP.Entities.Abstract;

namespace TERP.Entities.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Company : IEntity
    {
        public int Id { get; set; }

        [Required]
        [StringLength(250)]
        public string Name { get; set; }

        [StringLength(50)]
        public string MersisNo { get; set; }

        [StringLength(50)]
        public string EnrolmentNo { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }

        [StringLength(250)]
        public string Email { get; set; }

        [StringLength(500)]
        public string Adress { get; set; }

        [StringLength(60)]
        public string OfficerFullName { get; set; }
    }
}

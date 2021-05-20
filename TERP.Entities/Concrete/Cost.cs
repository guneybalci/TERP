using TERP.Entities.Abstract;

namespace TERP.Entities.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Cost : IEntity
    {
        public int Id { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [Column(TypeName = "date")]
        public DateTime CreatedDate { get; set; }

        [StringLength(250)]
        public string FileUrl { get; set; }

        [StringLength(20)]
        public string Price { get; set; }

        public int? CarID { get; set; }

        public int? PersonalID { get; set; }

        public int? CostTypeID { get; set; }

        public virtual Car Car { get; set; }

        public virtual CostType CostType { get; set; }

        public virtual Personal Personal { get; set; }
    }
}

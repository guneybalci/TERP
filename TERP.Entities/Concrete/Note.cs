using TERP.Entities.Abstract;

namespace TERP.Entities.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Note : IEntity
    {
        public int Id { get; set; }

        [Required]
        [StringLength(500)]
        public string Description { get; set; }

        [Column(TypeName = "date")]
        public DateTime CreatedDate { get; set; }

        public int UserID { get; set; }

        public virtual User User { get; set; }
    }
}

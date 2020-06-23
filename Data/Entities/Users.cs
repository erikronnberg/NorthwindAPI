namespace NorthwindAPI.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Users
    {
        [Key]
        public int UserID { get; set; }

        [StringLength(100)]
        public string UserPassword { get; set; }

        [StringLength(100)]
        public string UserEmail { get; set; }
    }
}

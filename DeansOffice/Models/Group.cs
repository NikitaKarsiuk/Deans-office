﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeansOffice.Models
{
    [Table("Group")]
    public partial class Group
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public int FacultyId { get; set; }
        public virtual Faculty Faculty { get; set; }
    }
}

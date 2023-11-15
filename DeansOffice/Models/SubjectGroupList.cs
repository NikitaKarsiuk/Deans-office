using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeansOffice.Models
{
    [Table("SubjectGroupList")]
    public partial class SubjectGroupList
    {
        public int Id { get; set; }
        public int SubjectId { get; set; } 
        public int GroupId { get; set; }
        public virtual Group Group { get; set; }
        public virtual Subject Subject { get; set; }
    }
}

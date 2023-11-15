using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DeansOffice.Models
{
    [Table("Faculty")]
    public partial class Faculty
    {
        public Faculty()
        {
            Group = new HashSet<Group>();
        }

        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public virtual ICollection<Group> Group { get; set; }
    }
}

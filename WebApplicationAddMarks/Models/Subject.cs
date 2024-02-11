using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationAddMarks.Models
{
    [Table("Subjects")]
    public partial class Subject
    {
        [Key]

        public int SubjectId { get; set; }
        public string SubjectName { get; set; } = null!;

        public virtual ICollection<Marks>? Marks { get; set; }
    }
}

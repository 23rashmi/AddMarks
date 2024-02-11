using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationAddMarks.Models
{
    [Table("Marks")]
    public partial class Marks
    {
        [Key]
        public int MarkId { get; set; }
        public int? StudentId { get; set; }
        public int? SubjectId { get; set; }
        public int Mark { get; set; }

        public virtual Student? Student { get; set; }
        public virtual Subject? Subject { get; set; }
    }
}

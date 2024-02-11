using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationAddMarks.Models
{
    [Table("Students")]
    public partial class Student
    {
        [Key]

        public int StudentId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;

        public virtual ICollection<Marks>? Marks { get; set; }
    }
}

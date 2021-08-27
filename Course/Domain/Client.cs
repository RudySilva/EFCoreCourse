using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseEFCore.Domain
{
    [Table("Clients")]
    public class Client
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Column("Phone")]
        public string Phone { get; set; }
        public string PostCode { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
    }
}
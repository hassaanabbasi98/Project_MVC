using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Bulky.Models
{
    public class Category
    {
        [Key]
        public int  Id { get; set; } // Primary key in our table
        [Required]
        [DisplayName("Category Name")]
        [MaxLength(50)]
        public string Name { get; set; }
        [DisplayName("Display Oder")]
        [Range(1,100)]
        public int DisplayOrder { get; set; }
    }
}

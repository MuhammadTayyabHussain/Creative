using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CreativeWeb.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Category Name")]
        [MaxLength(30)]
        public string Name { get; set; }
        [DisplayName("Display Order")]
        [Range(1,100, ErrorMessage ="Sorry you must enter between 1 to 100 only")]
          public int DisplyOrder { get; set; }
    }
}

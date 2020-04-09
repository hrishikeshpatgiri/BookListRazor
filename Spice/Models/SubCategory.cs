using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Spice.Models
{
    public class SubCategory
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Sub Category Name")]
        public string Name { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public virtual Category category { get; set; }
    }
}

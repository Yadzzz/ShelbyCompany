using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelbyCompany.Models
{
    public class Product
    {
        public Product()
        {

        }

        [Key]
        public int Id { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [Required]
        [MaxLength(11)]
        public int Price { get; set; }

        [Required]
        [MaxLength(11)]
        public int Quantity { get; set; }
    }
}

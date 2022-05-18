using EcommerceBreno.ProductApi.Models;
using System.ComponentModel.DataAnnotations;

namespace EcommerceBreno.ProductApi.DTOs;

public class CategoryDTO
{
    public int CategoryId { get; set; }
    [Required(ErrorMessage = "The name is required")]
    [MaxLength(100)]
    [MinLength(3)]
    public string? Name { get; set; }
    public ICollection<Product>? Products { get; set; }
}

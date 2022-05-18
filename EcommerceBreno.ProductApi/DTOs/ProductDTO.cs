using EcommerceBreno.ProductApi.Models;
using System.ComponentModel.DataAnnotations;

namespace EcommerceBreno.ProductApi.DTOs;

public class ProductDTO
{
    public int Id { get; set; }
    [Required(ErrorMessage = "The Name is required")]
    [MaxLength(100)]
    [MinLength(3)]
    public string? Name { get; set; }
    [Required(ErrorMessage = "The Price is required")]
    public decimal Price { get; set; }
    [Required(ErrorMessage = "The Name is required")]
    [MaxLength(200)]
    [MinLength(5)]
    public string? Description { get; set; }
    [Required(ErrorMessage = "The Stock is required")]
    [Range(1, 9999)]
    public long Stock { get; set; }
    public string? ImageUrl { get; set; }
    public Category? Category { get; set; }
    public int CategoryId { get; set; }
}

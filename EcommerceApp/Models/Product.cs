using System.ComponentModel.DataAnnotations;

namespace EcommerceApp.Models;

public class Product
{
    [Key]
    public int ProductId { get; set; }
    [Required][MaxLength(128)]
    public string Name { get; set; } = String.Empty;
    [Required][MaxLength(256)]
    public string Description { get; set; } = String.Empty;
    [Required][Range(0,5000)]
    public double Price { get; set; } = 0;
    
}
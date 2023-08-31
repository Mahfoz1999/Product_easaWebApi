using System.ComponentModel.DataAnnotations;

namespace Product_Easa_Models.Core;

public class Product
{
    [Required]
    [Key]
    public required int Id { get; set; }
    [Required]
    public required string Name { get; set; }
    public string Description { get; set; } = string.Empty;
}

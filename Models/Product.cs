using System.ComponentModel.DataAnnotations;
using static ServiceStack.LicenseUtils;

namespace AspnetCoreMvcFull.Models
{
  public class Product
  {

    public int ProductId { get; set; }
    [Required(ErrorMessage = "Title is required.")]
    [StringLength(100, ErrorMessage = "Title cannot exceed 100 characters.")]
    public string Title { get; set; }

    [Required(ErrorMessage = "Description is required.")]
    [StringLength(300, ErrorMessage = "Description cannot exceed 300 characters.")]
    public string Description { get; set; }

    [Required(ErrorMessage = "Amount is required.")]
    [Range(0.01, 999999.99, ErrorMessage = "Amount must be greater than 0.")]
    public decimal Amount { get; set; } 
  }
}

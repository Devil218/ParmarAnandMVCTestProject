using System.ComponentModel.DataAnnotations;
using static ServiceStack.LicenseUtils;

namespace AspnetCoreMvcFull.Models
{
  public class OrderDetails
  {
    public int OrderDetailsId { get; set; }
    public int OrderId { get; set; }
    [Required(ErrorMessage = "Product is required.")]
    public int ProductId { get; set; }

    [Required(ErrorMessage = "Quantity is required.")]
    [Range(1, int.MaxValue, ErrorMessage = "Quantity must be a positive number.")]
    public int Quantity { get; set; }

    [Required(ErrorMessage = "Amount is required.")]
    [Range(0.01, 99999999.99, ErrorMessage = "Amount must be greater than 0.")]
    public decimal Amount { get; set; }

    [Required(ErrorMessage = "Tax amount is required.")]
    [Range(0, 99999999.99, ErrorMessage = "Tax must be a valid amount.")]
    public decimal TaxAmount { get; set; }

    [Required(ErrorMessage = "Discount amount is required.")]
    [Range(0, 99999999.99, ErrorMessage = "Discount must be a valid amount.")]
    public decimal DiscountAmount { get; set; }

    [Required(ErrorMessage = "Total amount is required.")]
    [Range(0.01, 99999999.99, ErrorMessage = "Total amount must be greater than 0.")]
    public decimal TotalAmount { get; set; }

    public int CustomerId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }

    public Product Product { get; set; }
  }


  public class OrderDetailsViewModel
  {
    public int OrderId { get; set; }
    public List<OrderDetails> Details { get; set; }
  }

}

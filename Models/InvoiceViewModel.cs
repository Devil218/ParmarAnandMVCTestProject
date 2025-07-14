namespace AspnetCoreMvcFull.Models
{
  public class InvoiceViewModel
  {
    public Orders Order { get; set; }
    public List<OrderDetails> OrderDetails { get; set; }
    public List<Product> Products { get; set; }
    public Customers Customer { get; set; }
    public string InvoiceNumber { get; set; }
  }
}

using Microsoft.AspNetCore.Mvc.Rendering;

namespace AspnetCoreMvcFull.Models
{
  public class Orders
  {

    public int OrderId { get; set; }
    public int CustomerId { get; set; }
    public decimal Amount { get; set; }
    public List<SelectListItem> CustomerList { get; set; }


  }
}

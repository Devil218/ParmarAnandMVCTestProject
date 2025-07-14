using AspnetCoreMvcFull.Models;
using AspnetCoreMvcFull.Services;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;


using System.Threading.Tasks;

namespace AspnetCoreMvcFull.Controllers
{
  public class OrdersController : Controller
  {
    private readonly IOrdersServices _ordersServices;
    private readonly ICustomersServices _customersServices;
    private readonly IProductServices _productServices;
    



    public OrdersController(IOrdersServices ordersServices,ICustomersServices customersServices,IProductServices productServices)
    {
      _ordersServices = ordersServices;
      _customersServices = customersServices;
      _productServices = productServices;
      

    } 
    public async Task<IActionResult> Index()
    {
      var orders = await _ordersServices.GetAllOrdersAsync();
      return View(orders);
    }


    public async Task<IActionResult> CreateOrders()
    {
      

      ViewBag.CustomerList = await GetCustomerDropdownAsync();


      return View();
    }

    [HttpGet]
    public async Task<IActionResult> CreateOrderDetails(int orderId,int customerId)
    {
      var products = await _productServices.GetProductDetils();

      ViewBag.ProductList = products.Select(p => new SelectListItem
      {
        Value = p.ProductId.ToString(),
        Text = p.Title,
      }).ToList();

      ViewBag.customerId = customerId;

      var orderDetails = products.Select(p => new OrderDetails
      {
        OrderId = orderId,
        ProductId = p.ProductId,
        Quantity = 1,              
        Amount = p.Amount,        
        TaxAmount = 0,
        DiscountAmount = 0
      }).ToList();

      return View(orderDetails);
    }


    [HttpPost]
    public async Task<IActionResult> CreateOrders(Orders orders)
    {
      var res = await _ordersServices.CreateOrders(orders);
      return RedirectToAction("CreateOrderDetails", new { orderId = res.OrderId,customerId = res.CustomerId });
    }

    public async Task<IActionResult> Edit(int id)
    {
      var order = await _ordersServices.OrderDetailsByOrderId(id); 

      if (order == null)
        return NotFound();
      int productId = order.FirstOrDefault().ProductId;

      var product = await _productServices.GetProductDetils(); 

      
      var productList = product.Select(p =>
    new SelectListItem
    {
      Value = p.ProductId.ToString(),
      Text = p.Title 
    }).ToList();


      ViewBag.ProductList = productList;

      return View(order);
    }

    [HttpPost]
    public async Task<IActionResult>Edit(int customerId,List<OrderDetails> details)
    {
      foreach (var item in details)
      {
        

        await _ordersServices.SaveOrderDetail(customerId, item); 
      }

      return RedirectToAction("Index");
    }

    //public async Task<IActionResult> CreateOrderDetails(int customerId)
    //{
    //  var products = await _productServices.GetProductDetils();

    //  ViewBag.ProductList = products.Select(p => new SelectListItem
    //  {
    //    Value = p.ProductId.ToString(),
    //    Text = p.Title,
    //  }).ToList();

    //  ViewBag.CustomerId = customerId;

    //  var orderDetails = products.Select(p => new OrderDetails
    //  {
    //    ProductId = p.ProductId,
    //    Quantity = 1,               // default quantity
    //    Amount = p.Amount,           // assuming your Product has Price
    //    TaxAmount = 0,
    //    DiscountAmount = 0
    //  }).ToList();

    //  return View(orderDetails);
    //}


    [HttpPost]
    public async Task<IActionResult> CreateOrderDetails(int customerId, List<OrderDetails> details)
    {
      

      foreach (var item in details)
      {
       

        await _ordersServices.SaveOrderDetail(customerId,item); 
      }

      return RedirectToAction("Index");
    }


    public async Task<IActionResult>Delete(int id)
    {
      var res = await _ordersServices.DeleteOrderByOrderId(id);
      return RedirectToAction("Index");
    }


    private async Task<List<SelectListItem>> GetCustomerDropdownAsync(int? selectedOrderId = null)
    {
      var customers = await _customersServices.GetCustomersDetils();

      var list = customers.Select(c => new SelectListItem
      {
        Value = c.CustomerId.ToString(),
        Text = c.FirstName + " " + c.LastName,
        Selected = (selectedOrderId != null && c.CustomerId == selectedOrderId)
      }).ToList();

      return list;
    }

    public async Task<IActionResult> GenerateInvoice(int orderId)
    {
      InvoiceViewModel model = new InvoiceViewModel();
      
    
      model.InvoiceNumber =  await _ordersServices.GetInvoiceNumber(orderId);
      model.Order = await _ordersServices.GetOrderById(orderId);
      model.OrderDetails = await _ordersServices.OrderDetailsByOrderId(orderId);
      model.Customer = await _customersServices.GetCustomersDetilsByCustomerId(model.Order.CustomerId);
      var allProducts = await _productServices.GetProductDetils();

      model.Products = allProducts
    .Where(p => model.OrderDetails.Select(od => od.ProductId).Contains(p.ProductId))
    .ToList();

      // Map Title and Description to each OrderDetail
      foreach (var detail in model.OrderDetails)
      {
        var product = allProducts.FirstOrDefault(p => p.ProductId == detail.ProductId);
        if (product != null)
        {
          detail.Title = product.Title;        // Assuming product.Title is the name
          detail.Description = product.Description;
        }
      }
        return View(model);
    }



  }
}

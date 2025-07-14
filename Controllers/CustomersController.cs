using AspnetCoreMvcFull.Models;
using AspnetCoreMvcFull.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Reflection;

namespace AspnetCoreMvcFull.Controllers;

public class CustomersController : Controller
{
  private readonly ICustomersServices _productServices;
  public CustomersController(ICustomersServices productServices)
  {
        _productServices = productServices; 
  }

  public async Task<IActionResult> Index()
  {

    var res = await _productServices.GetCustomersDetils();
    return View(res);
  }

  public IActionResult Customers()
  {
    return View();
  }


  [HttpPost]
  public async Task<IActionResult> Customers(Customers customers)
  {
    if (!ModelState.IsValid)
    {
      return View(customers);
    }
    var res =  await _productServices.CreateProduct(customers);


    return RedirectToAction("Index");

  }

  [HttpGet]
  public async Task<IActionResult>Edit(int id)
  {

    var res = await _productServices.GetCustomersDetilsByCustomerId(id);

    return View(res);
  }

  [HttpPost]
  public async Task<IActionResult>Edit(Customers customers)
  {
    if (!ModelState.IsValid)
    {
      return View(customers);
    }
    var res = await _productServices.CreateProduct(customers);

    return RedirectToAction("Index");
  }

  [HttpGet]

  public async Task<IActionResult> Delete(int id)
  {

    var res = await _productServices.DeletedCustomersByCustomerId(id);

    return RedirectToAction("Index");
  }


}

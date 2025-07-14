using AspnetCoreMvcFull.Models;
using AspnetCoreMvcFull.Services;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace AspnetCoreMvcFull.Controllers
{
  public class ProductController : Controller
  {
    private readonly IProductServices _productServices;
    public ProductController(IProductServices productServices)
    {
      _productServices = productServices;

    }  
    public async Task<IActionResult> Index()
    {
      var res = await _productServices.GetProductDetils();
      return View(res);
    }

    public IActionResult CreateProduct()
    {
      return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct(Product product)
    {
      if (!ModelState.IsValid)
      {
        return View(product);
      }
      var res = await _productServices.CreateProduct(product);

      return RedirectToAction("Index");
    }


   
    public async Task<IActionResult> Edit(int id)
    {
      var res =   await _productServices.GetProductDetilsByProductId(id);


      return View(res);
    }

    [HttpPost]
    public async Task<IActionResult>Edit(Product product)
    {
      if (!ModelState.IsValid)
      {
        return View(product);
      }
      var res = await _productServices.CreateProduct(product);

      return RedirectToAction("Index");
    }

    
    public async Task<IActionResult>Delete(int id)
    {
      var res = _productServices.DeletedProductByProductId(id);

      return RedirectToAction("Index"); 
    }


  }
}

using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;
using ProductManagement.Models;
using ProductManagement.ViewModels;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace ProductManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly IWebHostEnvironment hostingEnvironment;


        //HomeController has  a dependency on this services IProductsRepository.this HC is not creating an instance of this dependency using the new keyword
        //we are injecting this IProductsRpository into the HC class using its constructor.This is called Constructor injector
        public HomeController(IProductRepository productRepository, IWebHostEnvironment hostingEnvironment)
        {
            _productRepository = productRepository;
        }
         
        public ViewResult Index()
        {
            var model = _productRepository.GetAllProduct();
            return View(model);
        }
        
        public ViewResult Details(int? id)
        {
   
            Product product = _productRepository.GetProduct(id.Value);

            if(product == null)
            {
                Response.StatusCode = 404;
                return View("ProductNotFound", id.Value);
            }
            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
            {
                Product = _productRepository.GetProduct(id ??1),
                PageTitle = "Product Details"
            };
            //Products model = _productRepository.GetProducts(1);
            return View(homeDetailsViewModel);
        }
        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(ProductCreateViewModel model)
        {
            if(ModelState.IsValid)
            {
                string uniqueFileName = ProcessUploadFile(model);
                
                Product newProduct = new Product
                {
                    Name = model.Name,
                    Description = model.Description,
                    Category = model.Category,
                    PhotoPath = uniqueFileName
                };
                _productRepository.Add(newProduct);
            return RedirectToAction("details", new { id = newProduct.Id });
                }
            return View();
        }

        [HttpGet]
        public ViewResult Edit(int id)
        {
            Product product = _productRepository.GetProduct(id);
            ProductEditViewModel productEditViewModel = new ProductEditViewModel
            {
                //retrieving the product details
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Category = product.Category,
                ExistingPhotoPath = product.PhotoPath
            };
            return View(productEditViewModel);
        }
        [HttpPost]
        public IActionResult Edit(ProductEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                //retrieve the existing product details
                Product product = _productRepository.GetProduct(model.Id);
                //update the properties with the data on the incoming model
                product.Name = model.Name;
                product.Description = model.Description;
                product.Category = model.Category;
               
                
                if (model.Photo != null)
                {
                    if (model.ExistingPhotoPath != null)
                    {
                        string filePath = Path.Combine(hostingEnvironment.WebRootPath, "images", model.ExistingPhotoPath);
                        System.IO.File.Delete(filePath);
                    }
                    product.PhotoPath = ProcessUploadFile(model);
                }
               Product updatedProduct = _productRepository.Update(product);
                return RedirectToAction("index");
            }
            return View(model);
        }

        private string ProcessUploadFile(ProductCreateViewModel model)
        {
            string uniqueFileName = null;
            if (model.Photo != null)
            {

                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.Photo.CopyTo(fileStream);
                }

            }

            return uniqueFileName;
        }
    }
}
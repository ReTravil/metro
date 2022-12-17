using Metropolis.Data;
using Metropolis.Models;
using Metropolis.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Metropolis.Controllers
{
    public class ProductController : Controller
    {
        public readonly DataDbContext _db;

        public ProductController(DataDbContext db)
        {
            _db = db;
        }


        public IActionResult Index()
        {
            IEnumerable<Product> objList = _db.Products;

            foreach (var obj in objList)
            {
                obj.Product_types = _db.Product_types.FirstOrDefault(u => u.Id == obj.Product_type_id);
                obj.Brand = _db.Brands.FirstOrDefault(u => u.Id == obj.Product_type_id);
                obj.Country = _db.Countries.FirstOrDefault(u => u.Id == obj.Product_type_id);

            }

            return View(objList);
        }

        // GET-Create
        [Authorize(Roles = "admin")]
        public IActionResult Create()
        {

            ProductVM productVM = new ProductVM()
            {
                Product = new Product(),
                DDBrand = _db.Brands.Select(i => new SelectListItem
                {
                    Text = i.BrandName,
                    Value = i.Id.ToString()
                }),
                DDCountry = _db.Countries.Select(i => new SelectListItem
                {
                    Text = i.CountryName,
                    Value = i.Id.ToString()
                }),
                DDProduct_Type = _db.Product_types.Select(i => new SelectListItem
                {
                    Text = i.Type_name,
                    Value = i.Id.ToString()
                })
            };

            return View(productVM);
        }

        // POST-Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public IActionResult Create(ProductVM obj)
        {
            if (ModelState.IsValid)
            {
                _db.Products.Add(obj.Product);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);

        }

        // GET Delete
        [Authorize(Roles = "admin")]
        public IActionResult Delete(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Products.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);

        }

        // POST Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.Products.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.Products.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }

        // GET Update
        [Authorize(Roles = "admin, moderator")]
        public IActionResult Update(int? id)
        {
            ProductVM productVM = new ProductVM()
            {
                Product = new Product(),
                DDBrand = _db.Brands.Select(i => new SelectListItem
                {
                    Text = i.BrandName,
                    Value = i.Id.ToString()
                }),
                DDCountry = _db.Countries.Select(i => new SelectListItem
                {
                    Text = i.CountryName,
                    Value = i.Id.ToString()
                }),
                DDProduct_Type = _db.Product_types.Select(i => new SelectListItem
                {
                    Text = i.Type_name,
                    Value = i.Id.ToString()
                })
            };

            if (id == null || id == 0)
            {
                return NotFound();
            }
            productVM.Product = _db.Products.Find(id);
            if (productVM.Product == null)
            {
                return NotFound();
            }
            return View(productVM);

        }

        // POST UPDATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin, moderator")]
        public IActionResult Update(ProductVM obj)
        {
            if (ModelState.IsValid)
            {
                _db.Products.Update(obj.Product);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);

        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _db.Products.Include(b => b.Brand).Include(c => c.Country).Include(t => t.Product_types)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);

        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Electronic_Products_Market_Database_Management_System.Data;
using Electronic_Products_Market_Database_Management_System.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Electronic_Products_Market_Database_Management_System.Controllers
{
      public class ProductController : Controller
      {

            private readonly ApplicationDbContext _context;

            public ProductController(ApplicationDbContext context)
            {
                  _context = context;
            }

            // GET: Product
            public async Task<IActionResult> Index()
            {
                  return View(await _context.Products.ToListAsync());
            }

            // GET: Product/Create
            public IActionResult AddOrEdit(int id = 0)
            {
                  if (id == 0)
                        return View(new ProductModel { });
                  else
                        return View(_context.Products.Find(id));
            }

            // POST: Product/Create
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> AddOrEdit([Bind("pId,pName,pImage,price,inStock,number")] ProductModel product)
            {
                  if (ModelState.IsValid)
                  {
                        if (product.pId == 0)
                              _context.Add(product);
                        else
                              _context.Update(product);

                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                  }
                  return View(product);
            }


            // GET: Product/Delete/5
            public async Task<IActionResult> Delete(int? id)
            {
                  var product = _context.Products.Find(id);
                  _context.Products.Remove(product);
                  await _context.SaveChangesAsync();

                  return RedirectToAction(nameof(Index));
            }

            public async Task<IActionResult> Decrease(int? id)
            {
                  var product = _context.Products.Find(id);
                  product.number--;
                  await _context.SaveChangesAsync();

                  return RedirectToAction(nameof(Index));
            }

            // TODO: set,update the count in adding new products

            // public async Task<IActionResult> GetCount(int? id)
            // {
            //       var product = _context.Products.Find(id);
            //       product.Count += product.number;
            //       await _context.SaveChangesAsync();

            //       return RedirectToAction(nameof(Index));
            // }


      }
}
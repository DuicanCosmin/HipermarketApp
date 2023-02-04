using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HipermarketApp.Data;
using HipermarketApp.Models;
using Microsoft.AspNetCore.Authorization;

namespace HipermarketApp.Controllers
{
    [Authorize("Admin,Product officer,Supplier officer")]
    public class ProductsToSuppliersController : Controller
    {
        private readonly HipermarketAppContext _context;

        public ProductsToSuppliersController(HipermarketAppContext context)
        {
            _context = context;
        }

        // GET: ProductsToSuppliers
        public async Task<IActionResult> Index()
        {       
              var hmAp = _context.ProductsSupplierDetails.Include(x => x.Product).Include(x => x.Supplier);
              return View(await hmAp.ToListAsync());
        }

        // GET: ProductsToSuppliers/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null || _context.ProductsSupplierDetails == null)
        //    {
        //        return NotFound();
        //    }

        //    var productsSupplierDetails = await _context.ProductsSupplierDetails
        //        .FirstOrDefaultAsync(m => m.ProductID == id);
        //    if (productsSupplierDetails == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(productsSupplierDetails);
        //}

        // GET: ProductsToSuppliers/Create
        public IActionResult Create()
        {

            ViewData["ProductID"] = new SelectList(_context.Products, "ID", "ProductName");
            ViewData["SupplierID"] = new SelectList(_context.Suppliers, "ID", "SupplierName");
            return View();
        }

        // POST: ProductsToSuppliers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductID,SupplierID,PurchasePrice,LeadTime")] ProductsSupplierDetails productsSupplierDetails)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productsSupplierDetails);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productsSupplierDetails);
        }

        // GET: ProductsToSuppliers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ProductsSupplierDetails == null)
            {
                return NotFound();
            }

            var productsSupplierDetails = await _context.ProductsSupplierDetails.FindAsync(id);
            if (productsSupplierDetails == null)
            {
                return NotFound();
            }
            return View(productsSupplierDetails);
        }

        // POST: ProductsToSuppliers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductID,SupplierID,PurchasePrice,LeadTime")] ProductsSupplierDetails productsSupplierDetails)
        {
            if (id != productsSupplierDetails.ProductID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productsSupplierDetails);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductsSupplierDetailsExists(productsSupplierDetails.ProductID,productsSupplierDetails.SupplierID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(productsSupplierDetails);
        }

        // GET: ProductsToSuppliers/Delete/5
        public async Task<IActionResult> Delete(int? id1,int? id2)
        {
            if (id1 == null || id2==null || _context.ProductsSupplierDetails == null)
            {
                return NotFound();
            }

            var productsSupplierDetails = await _context.ProductsSupplierDetails
                .FirstOrDefaultAsync(m => m.ProductID == id1 && m.SupplierID==id2);
            if (productsSupplierDetails == null)
            {
                return NotFound();
            }

            return View(productsSupplierDetails);
        }

        // POST: ProductsToSuppliers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id1, int? id2)
        {
            if (_context.ProductsSupplierDetails == null)
            {
                return Problem("Entity set 'HipermarketAppContext.ProductsSupplierDetails'  is null.");
            }
            var productsSupplierDetails = await _context.ProductsSupplierDetails.Where(x=>x.ProductID==id1 && x.SupplierID==id2).FirstOrDefaultAsync();
            if (productsSupplierDetails != null)
            {
                _context.ProductsSupplierDetails.Remove(productsSupplierDetails);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductsSupplierDetailsExists(int? id1, int? id2)
        {
          return _context.ProductsSupplierDetails.Any(e => e.ProductID == id1);
        }
    }
}

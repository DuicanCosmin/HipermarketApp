using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HipermarketApp.Data;
using HipermarketApp.ViewModels;
using HipermarketApp.Models;
using Microsoft.AspNetCore.Authorization;

namespace HipermarketApp.Controllers
{
    [Authorize(Roles = "Admin,Supplier officer")]
    public class ZonesController : Controller
    {
        private readonly HipermarketAppContext _context;

        public ZonesController(HipermarketAppContext context)
        {
            _context = context;
        }

        // GET: Zones
        public async Task<IActionResult> Index()
        {   
            var ZoneList = await _context.Zones.Include(z => z.Category).ToListAsync();

            return View(ZoneList);
        }

        // GET: Zones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Zones == null)
            {
                return NotFound();
            }

            var zoneVM = await _context.Zones
                .Include(z => z.Category)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (zoneVM == null)
            {
                return NotFound();
            }

            return View(zoneVM);
        }

        // GET: Zones/Create
        public IActionResult Create()
        {   

            ViewData["CategoryID"] = new SelectList(_context.Categories, "ID", "CategoryName");
            return View();
        }

        // POST: Zones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CategoryID,ID,Name")] ZoneVM zoneVM)
        {
            ModelState.Remove("PossibleCategories");

            if (ModelState.IsValid)
            {
                Zone NewZone = new();

                NewZone.CategoryID = zoneVM.CategoryID;

                NewZone.Name = zoneVM.Name;

                _context.Add(NewZone);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                List<string> erorrList = new();

                foreach (var value in ModelState.Values)
                {
                    foreach (var error in value.Errors)
                    {
                        erorrList.Add(error.ErrorMessage);
                        //Console.WriteLine(error.ErrorMessage);
                    }
                }
            }
            ViewData["CategoryID"] = new SelectList(_context.Categories, "ID", "CategoryName", zoneVM.CategoryID);
            return View(zoneVM);
        }

        // GET: Zones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Zones == null)
            {
                return NotFound();
            }

            var zone = await _context.Zones.FindAsync(id);

            if (zone == null)
            {
                return NotFound();
            }

            //var zoneVM = new ZoneVM();


            ViewData["CategoryID"] = new SelectList(_context.Categories, "ID", "CategoryName", zone.CategoryID);
            return View(zone);
        }

        // POST: Zones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CategoryID,ID,Name")] ZoneVM zoneVM)
        {
            if (id != zoneVM.ID)
            {
                return NotFound();
            }


            ModelState.Remove("PossibleCategories");
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(zoneVM);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZoneVMExists(zoneVM.ID))
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
            ViewData["CategoryID"] = new SelectList(_context.Categories, "ID", "CategoryName", zoneVM.CategoryID);
            return View(zoneVM);
        }

        // GET: Zones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Zones == null)
            {
                return NotFound();
            }

            var zone = await _context.Zones
                .Include(z => z.Category)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (zone == null)
            {
                return NotFound();
            }

            return View(zone);
        }

        // POST: Zones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Zones == null)
            {
                return Problem("Entity set 'HipermarketAppContext.ZoneVM'  is null.");
            }
            var zoneVM = await _context.Zones.FindAsync(id);
            if (zoneVM != null)
            {
                _context.Zones.Remove(zoneVM);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ZoneVMExists(int id)
        {
          return _context.Zones.Any(e => e.ID == id);
        }
    }
}

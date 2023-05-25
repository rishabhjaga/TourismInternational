using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TourismInternational.Models.EF;

namespace TourismInternational.Controllers
{
    public class TouristLocationsController : Controller
    {
        private readonly LocationDbContext _context= new LocationDbContext();

        //public TouristLocationsController(LocationDbContext context)
        //{
        //    _context = context;
        //}

        // GET: TouristLocations
        public async Task<IActionResult> Index()
        {
              return _context.TouristLocations != null ? 
                          View(await _context.TouristLocations.ToListAsync()) :
                          Problem("Entity set 'LocationDbContext.TouristLocations'  is null.");
        }

        // GET: TouristLocations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TouristLocations == null)
            {
                return NotFound();
            }

            var touristLocation = await _context.TouristLocations
                .FirstOrDefaultAsync(m => m.PlaceId == id);
            if (touristLocation == null)
            {
                return NotFound();
            }

            return View(touristLocation);
        }

        // GET: TouristLocations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TouristLocations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PlaceId,LocationName,City,Country,LocationImage")] TouristLocation touristLocation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(touristLocation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(touristLocation);
        }

        // GET: TouristLocations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TouristLocations == null)
            {
                return NotFound();
            }

            var touristLocation = await _context.TouristLocations.FindAsync(id);
            if (touristLocation == null)
            {
                return NotFound();
            }
            return View(touristLocation);
        }

        // POST: TouristLocations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PlaceId,LocationName,City,Country,LocationImage")] TouristLocation touristLocation)
        {
            if (id != touristLocation.PlaceId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(touristLocation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TouristLocationExists(touristLocation.PlaceId))
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
            return View(touristLocation);
        }

        // GET: TouristLocations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TouristLocations == null)
            {
                return NotFound();
            }

            var touristLocation = await _context.TouristLocations
                .FirstOrDefaultAsync(m => m.PlaceId == id);
            if (touristLocation == null)
            {
                return NotFound();
            }

            return View(touristLocation);
        }

        // POST: TouristLocations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TouristLocations == null)
            {
                return Problem("Entity set 'LocationDbContext.TouristLocations'  is null.");
            }
            var touristLocation = await _context.TouristLocations.FindAsync(id);
            if (touristLocation != null)
            {
                _context.TouristLocations.Remove(touristLocation);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TouristLocationExists(int id)
        {
          return (_context.TouristLocations?.Any(e => e.PlaceId == id)).GetValueOrDefault();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AandPManagement.Data;
using AandPManagement.Models;

namespace AandPManagement.Controllers
{
    public class AssetsController : Controller
    {
        private readonly ProjectContext _context;

        public AssetsController(ProjectContext context)
        {
            _context = context;    
        }

        // GET: Assets
        public async Task<IActionResult> Index(string searchString)
        {
            var assets = from asset in  _context.Assets select asset;
            if(!String.IsNullOrEmpty(searchString))
            {
                assets = assets.Where(a => a.AssetSerialNumber.Contains(searchString)
                                        || a.AssetLocation.Contains(searchString)
                                        || a.AssetDescription.Contains(searchString));
            }

            return View(await assets.AsNoTracking().ToListAsync());
        }

        // GET: Assets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asset = await _context.Assets.SingleOrDefaultAsync(m => m.AssetID == id);
            if (asset == null)
            {
                return NotFound();
            }

            return View(asset);
        }

        // GET: Assets/Create
        public IActionResult Create()
        {
            ViewData["ProjectID"] = new SelectList(_context.Projects, "ProjectID", "ProjectClient");
            return View();
        }

        // POST: Assets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AssetID,AssetAllocated,AssetAnualTestDate,AssetCOCDate,AssetConnections,AssetDescription,AssetDimensions,AssetLiftDate,AssetLocation,AssetMajorTestDate,AssetPressureRating,AssetSerialNumber,AssetWeight,COC,ProjectID")] Asset asset)
        {
            if (ModelState.IsValid)
            {
                _context.Add(asset);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["ProjectID"] = new SelectList(_context.Projects, "ProjectID", "ProjectClient", asset.ProjectID);
            return View(asset);
        }

        // GET: Assets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asset = await _context.Assets.SingleOrDefaultAsync(m => m.AssetID == id);
            if (asset == null)
            {
                return NotFound();
            }
            ViewData["ProjectID"] = new SelectList(_context.Projects, "ProjectID", "ProjectClient", asset.ProjectID);
            return View(asset);
        }

        // POST: Assets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AssetID,AssetAllocated,AssetAnualTestDate,AssetCOCDate,AssetConnections,AssetDescription,AssetDimensions,AssetLiftDate,AssetLocation,AssetMajorTestDate,AssetPressureRating,AssetSerialNumber,AssetWeight,COC,ProjectID")] Asset asset)
        {
            if (id != asset.AssetID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(asset);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AssetExists(asset.AssetID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            ViewData["ProjectID"] = new SelectList(_context.Projects, "ProjectID", "ProjectClient", asset.ProjectID);
            return View(asset);
        }

        // GET: Assets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asset = await _context.Assets.SingleOrDefaultAsync(m => m.AssetID == id);
            if (asset == null)
            {
                return NotFound();
            }

            return View(asset);
        }

        // POST: Assets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var asset = await _context.Assets.SingleOrDefaultAsync(m => m.AssetID == id);
            _context.Assets.Remove(asset);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool AssetExists(int id)
        {
            return _context.Assets.Any(e => e.AssetID == id);
        }
    }
}

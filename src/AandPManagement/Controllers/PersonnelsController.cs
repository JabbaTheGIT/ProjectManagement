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
    public class PersonnelsController : Controller
    {
        private readonly ProjectContext _context;

        public PersonnelsController(ProjectContext context)
        {
            _context = context;    
        }

        // GET: Personnels
        public async Task<IActionResult> Index()
        {
            var projectContext = _context.Personnels.Include(p => p.Project);
            return View(await projectContext.ToListAsync());
        }

        // GET: Personnels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personnel = await _context.Personnels.SingleOrDefaultAsync(m => m.PersonnelID == id);
            if (personnel == null)
            {
                return NotFound();
            }

            return View(personnel);
        }

        // GET: Personnels/Create
        public IActionResult Create()
        {
            ViewData["ProjectID"] = new SelectList(_context.Projects, "ProjectID", "ProjectTitle");
            return View();
        }

        // POST: Personnels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PersonnelID,Email,Name,PhoneNumber,Position,ProjectID")] Personnel personnel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(personnel);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["ProjectID"] = new SelectList(_context.Projects, "ProjectID", "ProjectTitle", personnel.ProjectID);
            return View(personnel);
        }

        // GET: Personnels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personnel = await _context.Personnels.SingleOrDefaultAsync(m => m.PersonnelID == id);
            if (personnel == null)
            {
                return NotFound();
            }
            ViewData["ProjectID"] = new SelectList(_context.Projects, "ProjectID", "ProjectClient", personnel.ProjectID);
            return View(personnel);
        }

        // POST: Personnels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PersonnelID,Email,Name,PhoneNumber,Position,ProjectID")] Personnel personnel)
        {
            if (id != personnel.PersonnelID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(personnel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonnelExists(personnel.PersonnelID))
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
            ViewData["ProjectID"] = new SelectList(_context.Projects, "ProjectID", "ProjectClient", personnel.ProjectID);
            return View(personnel);
        }

        // GET: Personnels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personnel = await _context.Personnels.SingleOrDefaultAsync(m => m.PersonnelID == id);
            if (personnel == null)
            {
                return NotFound();
            }

            return View(personnel);
        }

        // POST: Personnels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var personnel = await _context.Personnels.SingleOrDefaultAsync(m => m.PersonnelID == id);
            _context.Personnels.Remove(personnel);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public bool PersonnelExists(int id)
        {
            return _context.Personnels.Any(e => e.PersonnelID == id);
        }
    }
}

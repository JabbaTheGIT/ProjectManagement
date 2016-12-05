using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AandPManagement.Data;
using AandPManagement.Models;
using Microsoft.AspNetCore.Authorization;

namespace AandPManagement.Controllers
{
    [RequireHttps]
    public class ClientCompaniesController : Controller
    {
        private readonly ProjectContext _context;

        public ClientCompaniesController(ProjectContext context)
        {
            _context = context;    
        }

        // GET: ClientCompanies
        public async Task<IActionResult> Index()
        {
            return View(await _context.ClientCompanys.ToListAsync());
        }

        // GET: ClientCompanies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientCompany = await _context.ClientCompanys.SingleOrDefaultAsync(m => m.ClientCompanyID == id);
            if (clientCompany == null)
            {
                return NotFound();
            }

            return View(clientCompany);
        }

        // GET: ClientCompanies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ClientCompanies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClientCompanyID,Address,Name")] ClientCompany clientCompany)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clientCompany);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(clientCompany);
        }

        // GET: ClientCompanies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientCompany = await _context.ClientCompanys.SingleOrDefaultAsync(m => m.ClientCompanyID == id);
            if (clientCompany == null)
            {
                return NotFound();
            }
            return View(clientCompany);
        }

        // POST: ClientCompanies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClientCompanyID,Address,Name")] ClientCompany clientCompany)
        {
            if (id != clientCompany.ClientCompanyID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clientCompany);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientCompanyExists(clientCompany.ClientCompanyID))
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
            return View(clientCompany);
        }

        // GET: ClientCompanies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientCompany = await _context.ClientCompanys.SingleOrDefaultAsync(m => m.ClientCompanyID == id);
            if (clientCompany == null)
            {
                return NotFound();
            }

            return View(clientCompany);
        }

        // POST: ClientCompanies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clientCompany = await _context.ClientCompanys.SingleOrDefaultAsync(m => m.ClientCompanyID == id);
            _context.ClientCompanys.Remove(clientCompany);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ClientCompanyExists(int id)
        {
            return _context.ClientCompanys.Any(e => e.ClientCompanyID == id);
        }
    }
}

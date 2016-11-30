using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AandPManagement.Data;
using AandPManagement.Models;
using AandPManagement.Models.ProjectViewModels;
using Microsoft.AspNetCore.Http;

namespace AandPManagement.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly ProjectContext _context;

        public ProjectsController(ProjectContext context)
        {
            _context = context;    
        }

        // GET: Projects
        public async Task<IActionResult> Index()
        {
            var projectContext = _context.Projects.Include(p => p.ClientCompany);
            return View(await projectContext.ToListAsync());
        }

        // GET: Projects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var viewModel = new SelectedProjectViewModel();
            viewModel.SelectedProject = await _context.Projects
                .Where(i => i.ProjectID == id).ToListAsync();
            viewModel.SelectedProjectAssets = await _context.Assets
                .Where(i => i.ProjectID == id).ToListAsync();
            viewModel.SelectedProjectPersonnel = await _context.Personnels
                .Where(i => i.ProjectID == id).ToListAsync();
            viewModel.SelectedProjectTasks = await _context.ProjectTasks
                .Where(i => i.ProjectID == id).ToListAsync();
            ViewData["ProjectID"] = id.Value;

            HttpContext.Session.SetInt32("ProjectID", id.Value);

            if (id == null)
            {
                return NotFound();
            }

            if (viewModel == null)
            {
                return NotFound();
            }

            return View(viewModel);
        }

        // GET: Projects/Create
        public IActionResult Create()
        {
            ViewData["ClientCompanyID"] = new SelectList(_context.ClientCompanys, "ClientCompanyID", "Name");
            return View();
        }

        // POST: Projects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProjectID,ClientCompanyID,ProjectClient,ProjectLocation,ProjectNumber,ProjectStartDate,ProjectTitle")] Project project)
        {
            if (ModelState.IsValid)
            {
                _context.Add(project);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["ClientCompanyID"] = new SelectList(_context.ClientCompanys, "ClientCompanyID", "Name", project.ClientCompanyID);
            return View(project);
        }

        // GET: Projects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Projects.SingleOrDefaultAsync(m => m.ProjectID == id);
            if (project == null)
            {
                return NotFound();
            }
            ViewData["ClientCompanyID"] = new SelectList(_context.ClientCompanys, "ClientCompanyID", "Name", project.ClientCompanyID);
            return View(project);
        }

        // POST: Projects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProjectID,ClientCompanyID,ProjectClient,ProjectLocation,ProjectNumber,ProjectStartDate,ProjectTitle")] Project project)
        {
            if (id != project.ProjectID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(project);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectExists(project.ProjectID))
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
            ViewData["ClientCompanyID"] = new SelectList(_context.ClientCompanys, "ClientCompanyID", "Name", project.ClientCompanyID);
            return View(project);
        }

        // GET: Projects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Projects.SingleOrDefaultAsync(m => m.ProjectID == id);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // POST: Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await ClearProject(id);

            var project = await _context.Projects.AsNoTracking().SingleOrDefaultAsync(m => m.ProjectID == id);
            project.ClientCompanyID = null;
            project.ProjectCompleted = true;
            project.ProjectCompletedDate = DateTime.Today;

            _context.Update(project);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        //Clear all linking data
        public async Task ClearProject(int id)
        {
            var persons = await _context.Personnels.Where(i => i.ProjectID == id).ToListAsync();
            var assets = await _context.Assets.Where(i => i.ProjectID == id).ToListAsync();

            foreach (var item in persons)
            {
                item.ProjectID = null;
                item.Project = null;
            }

            foreach (var item in assets)
            {
                item.ProjectID = null;
                item.Project = null;
            }

            await _context.SaveChangesAsync();
        }

        // GET: Projects/ConfirmDelete/5
        public async Task<IActionResult> ConfirmDelete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Projects.SingleOrDefaultAsync(m => m.ProjectID == id);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // POST: Projects/ConfirmDelete/5
        [HttpPost, ActionName("ConfirmDelete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            var project = await _context.Projects.SingleOrDefaultAsync(m => m.ProjectID == id);
            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ProjectExists(int id)
        {
            return _context.Projects.Any(e => e.ProjectID == id);
        }

        //GET: Projects/AddTask
        public IActionResult AddTask(int? id)
        {
            return View();
        }

        // POST: Projects/AddTask
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddTask(int id, [Bind("ID,TaskComplete,TaskCompletedDate,TaskDescription,TaskSetCompletionDate,TaskSetDate,TaskTitle")] ProjectTask projectTask)
        {
            ViewData["ProjectID"] = id;
            if (ModelState.IsValid)
            {
                projectTask.ProjectID = id;
                _context.Add(projectTask);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details/" + id, "Projects");
            }
            return View(projectTask);
        }
        
        //GET: Projects/AddPerson
        public async Task<IActionResult> AddPerson()
        {
           return View(await _context.Personnels.ToListAsync());
        }

        // GET: Projects/ConfirmPerson
        public async Task<IActionResult> ConfirmPerson(int? id)
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

        // POST: Projects/ConfirmPerson
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmPerson(int id, [Bind("PersonnelID, Email,Name,PhoneNumber,Position,ProjectID")] Personnel personnel)
        {
            if (id != personnel.PersonnelID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                personnel.ProjectID = (int)HttpContext.Session.GetInt32("ProjectID");
                _context.Update(personnel);
                await _context.SaveChangesAsync();

                return RedirectToAction("Details/" + (int)HttpContext.Session.GetInt32("ProjectID"), "Projects");
            }
            return View(personnel);
        }

        //GET: Projects/AddAsset
        public async Task<IActionResult> AddAsset(string searchString)
        {
            var assets = from asset in _context.Assets select asset;
            if (!String.IsNullOrEmpty(searchString))
            {
                assets = assets.Where(a => a.AssetSerialNumber.Contains(searchString)
                                        || a.AssetLocation.Contains(searchString)
                                        || a.AssetDescription.Contains(searchString));
            }

            return View(await assets.AsNoTracking().ToListAsync());
        }

        // GET: Projects/ConfirmAsset
        public async Task<IActionResult> ConfirmAsset(int? id)
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

        // POST: Projects/ConfirmAsset
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmAsset(int id, [Bind("AssetID,AssetAllocated,AssetAnualTestDate,AssetCOCDate,AssetConnections,AssetDescription,AssetDimensions,AssetLiftDate,AssetLocation,AssetMajorTestDate,AssetPressureRating,AssetSerialNumber,AssetWeight,COC,ProjectID")] Asset asset)
        {
            if (id != asset.AssetID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                asset.ProjectID = (int)HttpContext.Session.GetInt32("ProjectID");
                asset.AssetAllocated = true;
                _context.Update(asset);
                await _context.SaveChangesAsync();

                return RedirectToAction("Details/" + (int)HttpContext.Session.GetInt32("ProjectID"), "Projects");
            }
            return View(asset);
        }

        // GET: Projects/RemovePerson
        public async Task<IActionResult> RemovePerson(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await _context.Personnels.SingleOrDefaultAsync(m => m.PersonnelID == id);

            if (person == null)
            {
                return NotFound();
            }
            return View(person);
        }

        //POST: Projects/RemovePerson
        [HttpPost, ActionName("RemovePerson")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemovePerson(int id)
        {
            var person = await _context.Personnels.SingleOrDefaultAsync(m => m.PersonnelID == id);
            person.ProjectID = null;
            await _context.SaveChangesAsync();

            return RedirectToAction("Details/" + (int)HttpContext.Session.GetInt32("ProjectID"), "Projects");
        }

        // GET: Projects/RemoveAsset
        public async Task<IActionResult> RemoveAsset(int? id)
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

        //POST: Projects/RemoveAsset
        [HttpPost, ActionName("RemoveAsset")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveAsset(int id)
        {
            var asset = await _context.Assets.SingleOrDefaultAsync(m => m.AssetID == id);
            asset.ProjectID = null;
            asset.AssetAllocated = false;
            await _context.SaveChangesAsync();

            return RedirectToAction("Details/" + (int)HttpContext.Session.GetInt32("ProjectID"), "Projects");
        }

        // GET: Projects/EditTask
        public async Task<IActionResult> EditTask(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectTask = await _context.ProjectTasks.SingleOrDefaultAsync(m => m.ProjectTaskID == id);

            if (projectTask == null)
            {
                return NotFound();
            }
            return View(projectTask);
        }

        // POST: Projects/EditTask
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditTask(int id, [Bind("TaskComplete,TaskCompletedDate,TaskDescription,TaskSetCompletionDate,TaskSetDate,TaskTitle")] ProjectTask projectTask)
        {
            if (ModelState.IsValid)
            {
                projectTask.ProjectTaskID = id;
                projectTask.ProjectID = (int)HttpContext.Session.GetInt32("ProjectID");
                _context.Update(projectTask);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details/" + (int)HttpContext.Session.GetInt32("ProjectID"), "Projects");
            }
            return View(projectTask);
        }

    }
}

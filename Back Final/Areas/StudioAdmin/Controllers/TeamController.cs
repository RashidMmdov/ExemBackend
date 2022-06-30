using Back_Final.DAL;
using Back_Final.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Final.Areas.StudioAdmin.Controllers
{
    [Area("StudioAdmin")]
    public class TeamController : Controller
    {
        private readonly AppDbContext context;

        public TeamController(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<IActionResult> Index()
        {
            List<Teams> teams = await context.Teams.ToListAsync();
            return View(teams);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(Teams teams)
        {
            if (!ModelState.IsValid) return View();
            await context.AddAsync(teams);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Deteil(int id)
        {
            Teams teams = await context.Teams.FirstOrDefaultAsync(t => t.Id == id);
            if (teams == null) return NotFound();
            return View(teams);
        }

        public async Task<IActionResult> Edit(int id)
        {
            Teams teams = await context.Teams.FirstOrDefaultAsync(t => t.Id == id);
            if (teams == null) return NotFound();
            return View(teams);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Edit(int id,Teams teams)
        {
            
            Teams teamsEdit = await context.Teams.FirstOrDefaultAsync(t => t.Id == id);
            teamsEdit.Name = teams.Name;
            teamsEdit.Position = teams.Position;
            teams.Image = teamsEdit.Image;
            if (teamsEdit == null) return View();
            context.Update(teams);
            await context.SaveChangesAsync();
           
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            Teams teams = await context.Teams.FirstOrDefaultAsync(t => t.Id == id);
            if (teams == null) return NotFound();
            return View(teams);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteTeam(int id)
        {
            Teams teams = await context.Teams.FirstOrDefaultAsync(t => t.Id == id);
            if (teams == null) return NotFound();
             context.Remove(teams);
            await context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


    }
}

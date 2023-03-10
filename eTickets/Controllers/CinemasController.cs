using eTickets.Data;
using eTickets.Data.Services;
using eTickets.Data.Static;
using eTickets.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class CinemasController : Controller
    {
        private readonly ICinemasService _service;
        public CinemasController(ICinemasService appDbContext)
        {
            _service = appDbContext;

        }

        [AllowAnonymous]

        public IActionResult Index()
        {
            var CinemasList = _service.GetAll();
            return View(CinemasList);
        }
        //Get: Cinemas/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind("Logo,Name,Description")] Cinema cinema)
        {
            //if (!ModelState.IsValid) return View(cinema);
              _service.Add(cinema);
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Details(int id)
        {
            var cinemas = await _service.GetById(id);
            if (cinemas == null) return View("Empty");
            return View(cinemas);
        }
        //Get Actors/Edit
        public async Task<IActionResult> Edit(int id)
        {
            var cinemaDetail = await _service.GetById(id);
            if (cinemaDetail == null) return View("NotFound");
            return View(cinemaDetail);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Logo,Name,Descritpion")] Cinema cinema)
        {
            /*if (!ModelState.IsValid)
            {
                return View(actor);
            }*/
            await _service.Update(id, cinema);
            return RedirectToAction(nameof(Index));
        }
        //Get/Delete/3
        public async Task<IActionResult> Delete(int id)
        {
            var cinemaReasult = await _service.GetById(id);
            return View(cinemaReasult);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            /*if (!ModelState.IsValid)
            {
                return View(actor);
            }*/
            await _service.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

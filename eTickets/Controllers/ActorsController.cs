using eTickets.Data;
using eTickets.Data.Services;
using eTickets.Data.Static;
using eTickets.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eTickets.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class ActorsController : Controller
    {
        private readonly IActorsService _service;

        public ActorsController(IActorsService service)
        {
            _service= service;
        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            var data = _service.GetAll();
            return View(data);
        }
        public IActionResult Create()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Create([Bind("FullName,ProfilePictureURL,Bio")]Actor actor)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View(actor);
            //}
            _service.Add(actor);
            return RedirectToAction(nameof(Index));
        }
        [AllowAnonymous]
        //Get Actors/Daiela
        public async Task<IActionResult> Details(int id)
        {
            var actorDetail = await _service.GetById(id);
            if (actorDetail == null) return View("Empty");
            return View(actorDetail);
        }
        [AllowAnonymous]
        //Get Actors/Edit
        public async Task<IActionResult> Edit(int id)
        {
            var actorDetail = await _service.GetById(id);
            if (actorDetail == null) return View("NotFound");
            return View(actorDetail);
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Edit(int id,[Bind("Id,FullName,ProfilePictureURL,Bio")] Actor actor)
        {
            /*if (!ModelState.IsValid)
            {
                return View(actor);
            }*/
           await _service.Update(id,actor);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int id)
        {
            var actorDetail = await _service.GetById(id);
            if (actorDetail == null) return View("NotFound");
            return View(actorDetail);
        }
        [AllowAnonymous]
        [HttpPost,ActionName("Delete")]
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

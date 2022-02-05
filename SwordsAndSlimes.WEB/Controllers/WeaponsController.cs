using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SwordsAndSlimes.BLL.Abstraction;
using SwordsAndSlimes.BLL.Models;
using SwordsAndSlimes.WEB.Models;

namespace SwordsAndSlimes.WEB.Controllers
{
    [Authorize]
    public class WeaponsController : Controller
    {
        private IService<WeaponDTO> _weaponsService;
        private IMapper _mapper = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<CharacterDTO, CharacterIndexViewModel>();
            cfg.CreateMap<DungeonDTO, DungeonIndexViewModel>();
            cfg.CreateMap<WeaponDTO, WeaponIndexViewModel>();
            cfg.CreateMap<WeaponDTO, WeaponAboutViewModel>();
            cfg.CreateMap<WeaponIndexViewModel, WeaponDTO>();
            cfg.CreateMap<WeaponAboutViewModel, WeaponDTO>();
        }).CreateMapper() ;

        public WeaponsController(IService<WeaponDTO> weaponsService)
        {
            _weaponsService = weaponsService;
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            return View(_mapper.Map<IEnumerable<WeaponDTO>,List<WeaponIndexViewModel>>(_weaponsService.GetAll()));
        }

        [AllowAnonymous]
        public ActionResult About(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var weapon = _weaponsService.Get(id);

            if (weapon == null)
            {
                return NotFound();
            }
            
            return View(_mapper.Map<WeaponAboutViewModel>(weapon));
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult Create([Bind("Name,Level,Attack,Class")] WeaponIndexViewModel weapon)
        {
            if (ModelState.IsValid)
            {
                _weaponsService.Create(_mapper.Map<WeaponDTO>(weapon));
                return RedirectToAction(nameof(Index));
            }

            return View(weapon);
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var weapon = _weaponsService.Get(id);
            
            if (weapon == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<WeaponIndexViewModel>(weapon));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit(string id, [Bind("Name,Level,Attack,Class")] WeaponIndexViewModel weapon)
        {
            if (id != weapon.Name)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _weaponsService.Update(_mapper.Map<WeaponDTO>(weapon));
                return RedirectToAction(nameof(Index));
            }

            return View(weapon);
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var weapon = _weaponsService.Get(id);
            
            if (weapon == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<WeaponIndexViewModel>(weapon));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult DeleteConfirmed(string id)
        {
            _weaponsService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

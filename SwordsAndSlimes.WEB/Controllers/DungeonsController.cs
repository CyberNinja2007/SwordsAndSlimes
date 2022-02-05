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
    public class DungeonsController : Controller
    {
        private IService<DungeonDTO> _dungeonService;
        private IMapper _mapper = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<CharacterDTO, CharacterIndexViewModel>();
            cfg.CreateMap<DungeonDTO, DungeonIndexViewModel>();
            cfg.CreateMap<DungeonDTO, DungeonAboutViewModel>();
            cfg.CreateMap<DungeonIndexViewModel, DungeonDTO>();
            cfg.CreateMap<DungeonAboutViewModel, DungeonDTO>();
        }).CreateMapper() ;

        public DungeonsController(IService<DungeonDTO> dungeonService)
        {
            _dungeonService = dungeonService;
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            return View(_mapper.Map<IEnumerable<DungeonDTO>,List<DungeonIndexViewModel>>(_dungeonService.GetAll()));
        }

        [AllowAnonymous]
        public ActionResult About(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dungeon = _dungeonService.Get(id);
            
            if (dungeon == null)
            {
                return NotFound();
            }
            
            return View(_mapper.Map<DungeonAboutViewModel>(dungeon));
        }
        
        [Authorize(Roles = "Administrator")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult Create([Bind("Name,Image")] DungeonIndexViewModel dungeon)
        {
            if (ModelState.IsValid)
            {
                _dungeonService.Create(_mapper.Map<DungeonDTO>(dungeon));
                return RedirectToAction(nameof(Index));
            }
            return View(dungeon);
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dungeon = _dungeonService.Get(id);
            if (dungeon == null)
            {
                return NotFound();
            }
            return View(_mapper.Map<DungeonIndexViewModel>(dungeon));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit(string id, [Bind("Name,Image")] DungeonIndexViewModel dungeon)
        {
            if (id != dungeon.Name)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _dungeonService.Update(_mapper.Map<DungeonDTO>(dungeon));
                
                return RedirectToAction(nameof(Index));
            }
            return View(dungeon);
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dungeon = _dungeonService.Get(id);
            
            if (dungeon == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<DungeonIndexViewModel>(dungeon));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult DeleteConfirmed(string id)
        {
            _dungeonService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

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
    public class MonstersController : Controller
    {
        private IService<MonsterDTO> _monsterService;
        private IMapper _mapper = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<DungeonDTO, DungeonIndexViewModel>();
            cfg.CreateMap<MonsterDTO, MonsterIndexViewModel>();
            cfg.CreateMap<MonsterDTO, MonsterAboutViewModel>();
            cfg.CreateMap<MonsterIndexViewModel, MonsterDTO>();
            cfg.CreateMap<MonsterAboutViewModel, MonsterDTO>();
        }).CreateMapper() ;

        public MonstersController(IService<MonsterDTO> monsterService)
        {
            _monsterService = monsterService;
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            return View(_mapper.Map<IEnumerable<MonsterDTO>,List<MonsterIndexViewModel>>(_monsterService.GetAll()));
        }

        [AllowAnonymous]
        public ActionResult About(string id)
        {
            //List<Dungeon> dungeons = new List<Dungeon>();
            
            if (id == null)
            {
                return NotFound();
            }

            var monster = _monsterService.Get(id);
            
            if (monster == null)
            {
                return NotFound();
            }
            
            /*foreach (var dungeon in monster.Dungeons)
            {
                dungeons.Add(dungeon);
            }

            foreach (var dungeonMonster in _context.DungeonMonsters)
            {
                if (dungeonMonster.MonsterName == monster.Name)
                {
                    dungeons.Add(_context.Dungeons.Find(dungeonMonster.DungeonName));
                }
            }

            ViewBag.Dungeons = dungeons;*/
            
            return View(_mapper.Map<MonsterAboutViewModel>(monster));
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult Create([Bind("Name,Level,Health,Attack,Class")] MonsterIndexViewModel monster)
        {
            if (ModelState.IsValid)
            {
               _monsterService.Create(_mapper.Map<MonsterDTO>(monster));
                return RedirectToAction(nameof(Index));
            }
            return View(monster);
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monster = _monsterService.Get(id);
            
            if (monster == null)
            {
                return NotFound();
            }
            
            return View(_mapper.Map<MonsterIndexViewModel>(monster));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit(string id, [Bind("Name,Level,Health,Attack,Class")] MonsterIndexViewModel monster)
        {
            if (id != monster.Name)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _monsterService.Update(_mapper.Map<MonsterDTO>(monster));
                return RedirectToAction(nameof(Index));
            }
            
            return View(monster);
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monster = _monsterService.Get(id);
            
            if (monster == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<MonsterIndexViewModel>(monster));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult DeleteConfirmed(string id)
        {
            _monsterService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

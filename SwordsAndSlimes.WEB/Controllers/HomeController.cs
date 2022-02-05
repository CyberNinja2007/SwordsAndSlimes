using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SwordsAndSlimes.BLL.Abstraction;
using SwordsAndSlimes.BLL.Models;
using SwordsAndSlimes.WEB.Models;

namespace SwordsAndSlimes.WEB.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private IService<CharacterDTO> _characters;
        private IService<DungeonDTO> _dungeons;
        private IService<WeaponDTO> _weapons;
        private IMapper _mapper = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<CharacterDTO, CharacterIndexViewModel>();
            cfg.CreateMap<DungeonDTO, DungeonIndexViewModel>();
            cfg.CreateMap<WeaponDTO, WeaponIndexViewModel>();
        }).CreateMapper() ;

        public HomeController(IService<CharacterDTO> characters,IService<DungeonDTO> dungeons, IService<WeaponDTO> weapons)
        {
            _characters = characters;
            _dungeons = dungeons;
            _weapons = weapons;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            var characters = _characters.GetAll().OrderByDescending(x => x.Level).Take(4);
            var dungeons = _dungeons.GetAll().Take(4);
            var weapons = _weapons.GetAll().OrderByDescending(x => x.Level).Take(4);
            
            ViewBag.TopCharacters = _mapper.Map<IEnumerable<CharacterDTO>,List<CharacterIndexViewModel>>(characters);
            ViewBag.RandomDungeons = _mapper.Map<IEnumerable<DungeonDTO>,List<DungeonIndexViewModel>>(dungeons);
            ViewBag.TopWeapons = _mapper.Map<IEnumerable<WeaponDTO>,List<WeaponIndexViewModel>>(weapons);
            
            return View();
        }

        [AllowAnonymous]
        public IActionResult Privacy()
        {
            return View();
        }

        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
using System.Collections.Generic;
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
    public class CharactersController : Controller
    {
        private IService<CharacterDTO> _characterService;
        private IMapper _mapper = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<WeaponDTO, WeaponIndexViewModel>();
            cfg.CreateMap<MonsterDTO, MonsterIndexViewModel>();
            cfg.CreateMap<CharacterDTO, CharacterIndexViewModel>();
            cfg.CreateMap<CharacterDTO, CharacterAboutViewModel>();
            cfg.CreateMap<CharacterIndexViewModel, CharacterDTO>();
            cfg.CreateMap<CharacterAboutViewModel, CharacterDTO>();
        }).CreateMapper() ;

        public CharactersController(IService<CharacterDTO> characterService)
        {
            _characterService = characterService;
        }
        
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View(_mapper.Map<IEnumerable<CharacterDTO>, List<CharacterIndexViewModel>>(_characterService.GetAll()));
        }
        
        [AllowAnonymous]
        public ActionResult About(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var character = _characterService.Get(id);
            
            if (character == null)
            {
                return NotFound();
            }
            
            return View(_mapper.Map<CharacterAboutViewModel>(character));
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Name,Health,Attack,Level,Class")] CharacterIndexViewModel character)
        {
            if (ModelState.IsValid)
            {
                _characterService.Create(_mapper.Map<CharacterDTO>(character));
                return RedirectToAction(nameof(Index));
            }
            
            return View(character);
        }
        
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var character = _characterService.Get(id);
            
            if (character == null)
            {
                return NotFound();
            }
            
            return View(_mapper.Map<CharacterIndexViewModel>(character));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit(string id, [Bind("Name,Health,Attack,Level,Class")] CharacterIndexViewModel character)
        {
            if (id != character.Name)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _characterService.Update(_mapper.Map<CharacterDTO>(character));
                
                return RedirectToAction(nameof(Index));
            }
            
            return View(character);
        }
        
        [Authorize(Roles = "Administrator")]
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var character = _characterService.Get(id);
            
            if (character == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<CharacterIndexViewModel>(character));
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            _characterService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
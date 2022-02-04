using System;
using System.Collections.Generic;
using System.Linq;
using SwordsAndSlimes.BLL.Abstraction;
using SwordsAndSlimes.BLL.Mappers;
using SwordsAndSlimes.BLL.Models;
using SwordsAndSlimes.DAL.Abstraction;

namespace SwordsAndSlimes.BLL.Services
{
    public class WeaponService : IService<WeaponDTO>
    {
        private IUnitOfWork _unitOfWork;

        public WeaponService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<WeaponDTO> GetAll()
        {
            return _unitOfWork.Weapons.GetAll().Select(x => x.ToDTO());
        }

        public WeaponDTO Get(string name)
        {
            if (name == null)
                throw new Exception("Не установлено имя оружия");
            var weapon = _unitOfWork.Weapons.Get(name);

            if (weapon == null)
                throw new Exception("Оружие не найдено");

            return weapon.ToDTO();
        }

        public void Create(WeaponDTO item)
        {
            if (item == null)
                throw new Exception("Не установлено оружие");
            
            var weapon = item.ToEntity();
            
            _unitOfWork.Weapons.Create(weapon);

            _unitOfWork.Save();
        }

        public void Update(WeaponDTO item)
        {
            if (item == null)
                throw new Exception("Не установлено оружие");
            
            var weapon = item.ToEntity();
            
            _unitOfWork.Weapons.Update(weapon);

            _unitOfWork.Save();
        }

        public void Delete(string name)
        {
            if (name == null)
                throw new Exception("Не установлено имя оружия");
            
            var weapon = _unitOfWork.Weapons.Get(name);

            if (weapon == null)
                throw new Exception("Оружие не найдено");

            _unitOfWork.Weapons.Delete(name);

            _unitOfWork.Save();
        }
    }
}
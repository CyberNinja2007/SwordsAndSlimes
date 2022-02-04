using System;
using System.Collections.Generic;
using System.Linq;
using SwordsAndSlimes.BLL.Abstraction;
using SwordsAndSlimes.BLL.Mappers;
using SwordsAndSlimes.BLL.Models;
using SwordsAndSlimes.DAL.Abstraction;

namespace SwordsAndSlimes.BLL.Services
{
    public class MonsterService : IService<MonsterDTO>
    {
        private IUnitOfWork _unitOfWork;

        public MonsterService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<MonsterDTO> GetAll()
        {
            return _unitOfWork.Monsters.GetAll().Select(x => x.ToDTO());
        }

        public MonsterDTO Get(string name)
        {
            if (name == null)
                throw new Exception("Не установлено имя монстра");
            var monster = _unitOfWork.Monsters.Get(name);

            if (monster == null)
                throw new Exception("Монстр не найден");

            return monster.ToDTO();
        }

        public void Create(MonsterDTO item)
        {
            if (item == null)
                throw new Exception("Не установлен монстр");
            
            var monster = item.ToEntity();
            
            _unitOfWork.Monsters.Create(monster);

            _unitOfWork.Save();
        }

        public void Update(MonsterDTO item)
        {
            if (item == null)
                throw new Exception("Не установлен монстр");
            
            var monster = item.ToEntity();
            
            _unitOfWork.Monsters.Update(monster);

            _unitOfWork.Save();
        }

        public void Delete(string name)
        {
            if (name == null)
                throw new Exception("Не установлено имя монстра");
            
            var monster = _unitOfWork.Monsters.Get(name);

            if (monster == null)
                throw new Exception("Монстр не найден");

            _unitOfWork.Monsters.Delete(name);

            _unitOfWork.Save();
        }
    }
}
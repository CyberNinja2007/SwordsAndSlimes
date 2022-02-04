using System;
using System.Collections.Generic;
using System.Linq;
using SwordsAndSlimes.BLL.Abstraction;
using SwordsAndSlimes.BLL.Mappers;
using SwordsAndSlimes.BLL.Models;
using SwordsAndSlimes.DAL.Abstraction;

namespace SwordsAndSlimes.BLL.Services
{
    public class DungeonService : IService<DungeonDTO>
    {
        private IUnitOfWork _unitOfWork;

        public DungeonService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<DungeonDTO> GetAll()
        {
            return _unitOfWork.Dungeons.GetAll().Select(x => x.ToDTO());
        }

        public DungeonDTO Get(string name)
        {
            if (name == null)
                throw new Exception("Не установлено имя подземелья");
            var dungeon = _unitOfWork.Dungeons.Get(name);

            if (dungeon == null)
                throw new Exception("Подземелье не найдено");

            return dungeon.ToDTO();
        }

        public void Create(DungeonDTO item)
        {
            if (item == null)
                throw new Exception("Не установлено подземелье");
            
            var dungeon = item.ToEntity();
            
            _unitOfWork.Dungeons.Create(dungeon);

            _unitOfWork.Save();
        }

        public void Update(DungeonDTO item)
        {
            if (item == null)
                throw new Exception("Не установлено подземелье");
            
            var dungeon = item.ToEntity();
            
            _unitOfWork.Dungeons.Update(dungeon);

            _unitOfWork.Save();
        }

        public void Delete(string name)
        {
            if (name == null)
                throw new Exception("Не установлено имя подземелья");
            
            var dungeon = _unitOfWork.Dungeons.Get(name);

            if (dungeon == null)
                throw new Exception("Подземелье не найдено");

            _unitOfWork.Characters.Delete(name);

            _unitOfWork.Save();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using SwordsAndSlimes.BLL.Abstraction;
using SwordsAndSlimes.BLL.Mappers;
using SwordsAndSlimes.BLL.Models;
using SwordsAndSlimes.DAL.Abstraction;

namespace SwordsAndSlimes.BLL.Services
{
    public class CharacterService : IService<CharacterDTO>
    {
        private IUnitOfWork _unitOfWork;

        public CharacterService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<CharacterDTO> GetAll()
        {
            return _unitOfWork.Characters.GetAll().Select(x => x.ToDTO());
        }

        public CharacterDTO Get(string name)
        {
            if (name == null)
                throw new Exception("Не установлено имя персонажа");
            var character = _unitOfWork.Characters.Get(name);

            if (character == null)
                throw new Exception("Персонаж не найден");

            return character.ToDTO();
        }

        public void Create(CharacterDTO item)
        {
            if (item == null)
                throw new Exception("Не установлен персонаж");
            
            var character = item.ToEntity();
            
            _unitOfWork.Characters.Create(character);

            _unitOfWork.Save();
        }

        public void Update(CharacterDTO item)
        {
            if (item == null)
                throw new Exception("Не установлен персонаж");
            
            var character = item.ToEntity();
            
            _unitOfWork.Characters.Update(character);

            _unitOfWork.Save();
        }

        public void Delete(string name)
        {
            if (name == null)
                throw new Exception("Не установлено имя персонажа");
            
            var character = _unitOfWork.Characters.Get(name);

            if (character == null)
                throw new Exception("Персонаж не найден");

            _unitOfWork.Characters.Delete(name);

            _unitOfWork.Save();
        }
    }
}
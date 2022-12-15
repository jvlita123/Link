using Data.Entities;
using Data.Repositories;
using Microsoft.AspNetCore.Http;
using Service.Models;
using System.Web;

namespace Service.Services
{
    public class PhotoService
    {
        private readonly PhotoRepository _photoRepository;

        public PhotoService(PhotoRepository photoRepository)
        {
            _photoRepository = photoRepository;
        }

        public List<Photo> GetAll()
        {
            List<Photo> photos = _photoRepository.GetAll().ToList();

            return photos;
        }
        public Photo Add(Photo photo)
        {
            Photo? newPhoto = _photoRepository.AddAndSaveChanges(photo);

            return newPhoto;
        }
        
        public bool CheckForUser(int Id)
        {
            var photos =_photoRepository.GetAll().ToList();
            Photo? photo = _photoRepository.GetAll()
                .Where(p => p.UserId == Id)
                .FirstOrDefault();
            if (photo == null) return true;
            return false;
        }
    }
}
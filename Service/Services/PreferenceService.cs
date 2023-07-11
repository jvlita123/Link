using Data.Entities;
using Data.Repositories;
using Microsoft.AspNetCore.Mvc.Rendering;
using Service.Models.Relation;

namespace Service.Services
{
    public class PreferenceService
    {
        private readonly PreferenceRepository _preferenceRepository;
        private readonly RelationUserRepository _relationUserRepository;

        public PreferenceService(PreferenceRepository preferenceRepository, RelationUserRepository relationUserRepository)
        {
            _preferenceRepository = preferenceRepository;
            _relationUserRepository = relationUserRepository;
        }

        public List<Preference> GetAllByType(string type)
        {
            List<Preference> preferences = _preferenceRepository.GetAllByType(type).ToList();

            return preferences;
        }

        public GetRelationViewModel GetPreferences(int userId, int relId)
        {
            List<SelectListItem>? gendersPreference = this.GetAllByType("Gender")
                .Select(p => new SelectListItem(p.Value, p.Id.ToString()))
                .ToList();

            List<SelectListItem>? minHeightsPreference = this.GetAllByType("MinHeight")
                .Select(p => new SelectListItem(p.Value, p.Id.ToString()))
                .ToList();

            List<SelectListItem>? maxHeightsPreference = this.GetAllByType("MaxHeight")
                .Select(p => new SelectListItem(p.Value, p.Id.ToString()))
                .ToList();

            List<SelectListItem>? localizationsPreference = this.GetAllByType("Localization")
                .Select(p => new SelectListItem(p.Value, p.Id.ToString()))
                .ToList();

            GetRelationViewModel relationViewModel = new GetRelationViewModel
            {
                GendersPreference = gendersPreference,
                MinHeightsPreference = minHeightsPreference,
                MaxHeightsPreference = maxHeightsPreference,
                LocalizationsPreference = localizationsPreference
            };

            relationViewModel.IsEdit = _relationUserRepository.GetAll()
                .Where(ur => ur.UserId == userId)
                .Where(ur => ur.RelationId == relId)
                .Any();

            

            return relationViewModel;
        }

        public List<int> GetPreferenceIds(GetRelationViewModel relationViewModel)
        {
            List<int> preferenceIds = new List<int>
            {
                relationViewModel.GenderId,
                relationViewModel.MinHeightId,
                relationViewModel.MaxHeightId,
                relationViewModel.LocalizationId
            };

            return preferenceIds;
        }
    }
}
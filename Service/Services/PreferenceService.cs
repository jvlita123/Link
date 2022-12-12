using Data.Repositories;
using Microsoft.AspNetCore.Mvc.Rendering;
using Service.Models.Relation;

namespace Service.Services
{
    public class PreferenceService
    {
        private readonly Data.Repositories.PreferenceRepository _preferenceRepository;
        private readonly RelationUserRepository _relationUserRepository;

        public PreferenceService(Data.Repositories.PreferenceRepository preferenceRepository, RelationUserRepository relationUserRepository)
        {
            _preferenceRepository = preferenceRepository;
            _relationUserRepository = relationUserRepository;
        }

        public GetRelationViewModel GetPreferences(int userId, int relId)
        {
            List<SelectListItem>? gendersPreference = _preferenceRepository.GetAllByType("Gender")
                .Select(p => new SelectListItem(p.Value, p.Id.ToString()))
                .ToList();

            List<SelectListItem>? minHeightsPreference = _preferenceRepository.GetAllByType("MinHeight")
                .Select(p => new SelectListItem(p.Value, p.Id.ToString()))
                .ToList();

            List<SelectListItem>? maxHeightsPreference = _preferenceRepository.GetAllByType("MaxHeight")
                .Select(p => new SelectListItem(p.Value, p.Id.ToString()))
                .ToList();

            List<SelectListItem>? localizationsPreference = _preferenceRepository.GetAllByType("Localization")
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

            if (relationViewModel.IsEdit)
            {
                string genderPreferenceId = _relationUserRepository.GetAllByRelationType(userId, "Gender")
                    .Select(ru => ru.PreferenceId)
                    .FirstOrDefault()
                    .ToString();
                string minHeightPreferenceId = _relationUserRepository.GetAllByRelationType(userId, "MinHeight")
                    .Select(ru => ru.PreferenceId)
                    .FirstOrDefault()
                    .ToString();
                string maxHeightPreferenceId = _relationUserRepository.GetAllByRelationType(userId, "MaxHeight")
                    .Select(ru => ru.PreferenceId)
                    .FirstOrDefault()
                    .ToString();
                string localizationPreferenceId = _relationUserRepository.GetAllByRelationType(userId, "Localization")
                    .Select(ru => ru.PreferenceId)
                    .FirstOrDefault()
                    .ToString();

                relationViewModel.GendersPreference.Find(gp => gp.Value == genderPreferenceId).Selected = true;
                relationViewModel.MinHeightsPreference.Find(gp => gp.Value == minHeightPreferenceId).Selected = true;
                relationViewModel.MaxHeightsPreference.Find(gp => gp.Value == maxHeightPreferenceId).Selected = true;
                relationViewModel.LocalizationsPreference.Find(gp => gp.Value == localizationPreferenceId).Selected = true;
            }

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
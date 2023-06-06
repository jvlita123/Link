using Data.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Service.Models.Relation
{
    public class GetRelationViewModel
    {
        public bool IsEdit { get; set; }

        public List<SelectListItem>? GendersPreference { get; set; }
        public List<SelectListItem>? MinHeightsPreference { get; set; }
        public List<SelectListItem>? MaxHeightsPreference { get; set; }
        public List<SelectListItem>? LocalizationsPreference { get; set; }
        public List <User> users = new List<User>();

        public int GenderId { get; set; }
        public int MinHeightId { get; set; }
        public int MaxHeightId { get; set; }
        public int LocalizationId { get; set; }
        public int RelId { get; set; }
        public bool IsRelation { get; set; }
    }
}
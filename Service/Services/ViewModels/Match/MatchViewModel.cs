using Data.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Service.Models.Match
{
    public class MatchViewModel
    {
        public bool? Swipe { get; set; }
        public User User2 { get; set; }

       public MatchViewModel(bool? swipe, User user2)
        {
            Swipe = swipe;
            User2 = user2;
        }
    }
}
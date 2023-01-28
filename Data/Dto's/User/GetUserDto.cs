using Data.Entities;

namespace Data.Dto_s.User
{
    public class GetUserDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool Gender { get; set; }

        public string PhoneNumber { get; set; }

        public string? ProfilePhoto { get; set; }

        public List<string> Photos { get; set; }
    }
}
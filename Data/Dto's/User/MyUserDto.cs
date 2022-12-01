namespace Data.Dto_s.User
{
    public class MyUserDto
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public bool Gender { get; set; }

        public string? PhoneNumber { get; set; }

        public bool IsPremium { get; set; }

        public string? ProfilePhoto { get; set; }

        public List<string>? Photos { get; set; }
    }
}
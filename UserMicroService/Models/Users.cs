namespace UserMicroService.Models
{
    public partial class Users
    {
        public long Identification { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public long? Phone { get; set; }
        public string Rol { get; set; }
        public string Password { get; set; }
    }
}

namespace ContactsAPI.Models
{
    public class Contacts
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? CompanyName { get; set; }
        public string? MobileNumber { get; set; }
        public string? Email { get; set; }
    }
}

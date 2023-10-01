using E_Commerce.Domain.Core.SeedWork;

namespace E_Commerce.Domain.Model
{
    public class User:BaseEntity
    {

        public string Email { get; private set; }
        public string Password { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string City { get; private set; }
        public bool IsActive { get; private set; }

        public User()
        {
            
        }
        public User(string email, string password, string firstName, string lastName, string city)
        {
            Email = email;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            City = city;
            IsActive = true;
        }
    }
}

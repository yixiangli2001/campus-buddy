using campus_buddy.Data;
using campus_buddy.Models;
using System.Text.RegularExpressions;

namespace campus_buddy.Services
{
    public class AuthenticationService
    {
        private readonly Repository<User> _users;
        public User? CurrentUser { get; private set; }

        public AuthenticationService()
        {
            _users = new Repository<User>();
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Data\users.csv");
            _users.AddRange(FileManager.Load<User>(path));
        }


        //  login
        public AuthResult Login(string email, string password)
        {
            List<User> users = _users.GetAll();
            foreach(User u in users)
            {
                Console.WriteLine(u.Name);
            }
            Console.WriteLine();
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
                return AuthResult.Fail("Email and password are required.");
            var user = _users.FindOne(u =>
                u.Email.Equals(email.Trim()) &&
                u.Password == password.Trim());

            if (user == null)
                return AuthResult.Fail($"Invalid email or password.");
            CurrentUser = user;
            return AuthResult.Success(user);
        }

        public void Logout() => CurrentUser = null;
    }

    public class AuthResult
    {
        public bool IsSuccess { get; set; }
        public User? User { get; set; }
        public List<string> Errors { get; set; } = new();

        public static AuthResult Success(User u)
        {
            return new() { IsSuccess = true, User = u };
        }

        public static AuthResult Fail(params string[] messages)
        {
            var res = new AuthResult { IsSuccess = false };
            res.Errors.AddRange(messages);
            return res;
        }

        public string ErrorText() => string.Join("\n", Errors);
    }
}

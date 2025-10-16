
﻿using System;
using System.Linq;
using campus_buddy.Models;

namespace campus_buddy.Services
{
    /// <summary>
    /// Authentication service
    /// Demonstrates: authentication logic and DataService integration
    /// </summary>
    public class AuthenticationService
    {
        private readonly DataService _dataService;

        public static User CurrentUser { get; private set; }

        public AuthenticationService()
        {
            _dataService = DataService.Instance;
        }

        public AuthResult Login(string email, string password)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrEmpty(password))
                return AuthResult.Fail("Email and password are required.");

            email = email.Trim();


            var user = _dataService.Users.FindOne(u =>
                u.Email != null &&
                u.Email.Equals(email, StringComparison.OrdinalIgnoreCase) &&
                u.Password == password);

            return user != null
                ? AuthResult.Ok(user)
                : AuthResult.Fail("Invalid email or password.");
        }

        public AuthResult Register(string name, string email, string password, string phone)
        {
            if (string.IsNullOrWhiteSpace(name) ||
                string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrEmpty(password))
                return AuthResult.Fail("Name, email and password are required.");

            email = email.Trim();
            var exists = _dataService.Users.FindOne(u =>
                u.Email != null &&
                u.Email.Equals(email, StringComparison.OrdinalIgnoreCase));

            if (exists != null)
                return AuthResult.Fail("This email is already registered.");

            var user = new User(name, email, password, phone);
            _dataService.AddUser(user);
            return AuthResult.Ok(user);
        }

        public void Logout()
        {
            CurrentUser = null;
        }

        public User GetCurrentUser()
        {
            return CurrentUser;
        }
    }
    public sealed class AuthResult
    {
        public bool IsSuccess { get; }
        public User? User { get; }
        public string? Error { get; }

        private AuthResult(bool ok, User? user, string? error)
        {
            IsSuccess = ok;
            User = user;
            Error = error;
        }

        public static AuthResult Ok(User user) => new(true, user, null);
        public static AuthResult Fail(string message) => new(false, null, message);

        public string ErrorText() => string.IsNullOrWhiteSpace(Error) ? "Unknown error." : Error!;
    }
}

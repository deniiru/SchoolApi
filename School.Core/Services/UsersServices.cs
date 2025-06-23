using School.Database.Entities;
using System;
using School.Core.Services;
using School.Database.Repositories;
using School.Core.Dtos.Requests.Auth;
using School.Core.Dtos.Responses.Auth;

namespace School.Core.Services
{
    public class UsersServices
    {
        public AuthService authService { get; set; }
        public UsersRepository usersRepository { get; set; }
        public StudentsRepository studentsRepository { get; set; }
        public TeachersRepository teachersRepository { get; set; }

        public UsersServices(
            AuthService authService,
            UsersRepository usersRepository,
            StudentsRepository studentsRepository,
            TeachersRepository teachersRepository)
        {
            this.authService = authService;
            this.usersRepository = usersRepository;
            this.studentsRepository = studentsRepository;
            this.teachersRepository = teachersRepository;
        }

        public async Task RegisterAsync(RegisterRequest registerData)
        {
            if (registerData == null)
            {
                return;
            }

            var salt = authService.GenerateSalt();

            var hashedPassword = authService.HashPassword(registerData.Password, salt);

            var student = studentsRepository.GetByIdAsync(registerData.StudentId).Result;

            var user = new User();
            user.StudentId = registerData.StudentId;
            user.Student = student;
            user.Email = registerData.Email;
            user.Password = hashedPassword;
            user.PasswordSalt = Convert.ToBase64String(salt);
            user.CreatedAt = DateTime.UtcNow;

            await usersRepository.AddAsync(user);
        }

        public async Task<LoginResponse> LoginAsync(LoginRequest payload)
        {
            var user = await usersRepository.GetByEmailAsync(payload.Email);

            if (authService.HashPassword(payload.Password, Convert.FromBase64String(user.PasswordSalt)) == user.Password)
            {
                var role = GetRole(user);

                var id = user.Id;

                LoginResponse loginResponse = new LoginResponse();
                loginResponse.Id = id;
                loginResponse.Token = authService.GetToken(user, role);

                return loginResponse;
            }
            else
            {
                throw new UnauthorizedAccessException("Invalid email or password.");
            }
        }

        private string GetRole(User user)
        {
            if (user.TeacherId != null)
            {
                return "Admin";
            }
            else
            {
                return "User";
            }
        }
    }
}

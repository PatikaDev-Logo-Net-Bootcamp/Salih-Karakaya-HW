namespace Homework_2.Domain.Login
{
    public class LoginDto
    {
        public string userName { get; }
        public string password { get; }

        public LoginDto(string userName, string password)
        {
            this.userName = userName;
            this.password = password;
        }
    }
}

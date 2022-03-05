namespace SampleLogin.Models
{
    public class LoginResponse
    {
        public bool Success { get; set; }
        public string Data { get; set; }
        public bool Error { get => !Success; }

    }
}

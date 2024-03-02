namespace SistemaBico.API.Dtos
{
    public class UserDto
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public bool ValidateLogin()
        {
            return (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password)) ? true : false;
        }
    }
}

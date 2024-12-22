using Microsoft.VisualBasic;

namespace BackendApi.Contracts.User
{
    public class UpdateUserRequest
    {
        public int Id { get; set; }
        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;

    }
}

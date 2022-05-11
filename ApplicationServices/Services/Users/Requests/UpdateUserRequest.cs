namespace ApplicationServices.Services.Users.Requests
{
    public class UpdateUserRequest
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public long RoleId { get; set; }
    }
}

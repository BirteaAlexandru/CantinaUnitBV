namespace ApplicationServices.Services.Users.Responses
{
    public  class UserResponse
    {
        public long Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public long RoleId { get; set; }
        public string RoleName { get; set; }
    }
}

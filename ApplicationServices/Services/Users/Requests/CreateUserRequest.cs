namespace ApplicationServices.Services.Users.Requests;

public  class CreateUserRequest
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string FirstName { get; set; }
    public string SecondName { get; set; }
    public long RoleId { get; set; }

}
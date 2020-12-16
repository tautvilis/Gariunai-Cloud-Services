namespace WebApi.Models.DataTransferObjects
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public string ProfilePicture { get; set; }
    }
}
namespace Gariunai_Cloud_Services.Backend.Entities
{
    internal class Password
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public byte[] Hash { get; set; }
        public byte[] Salt { get; set; }
        public User User { get; set; }
    }
}
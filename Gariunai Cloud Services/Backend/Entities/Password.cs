namespace Gariunai_Cloud_Services.Entities
{
    class Password
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public byte[] Hash { get; set; }
        public byte[] Salt { get; set; }
        public User User{ get; set;}
    }
}

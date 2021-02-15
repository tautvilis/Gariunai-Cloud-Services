using System;

namespace Gariunai_Cloud_Services.Entities
{
    public class Follow
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ShopId {get; set; }
        public DateTime CreatedTime { get; set; }
    }
}
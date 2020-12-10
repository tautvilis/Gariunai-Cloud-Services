using System.Collections.Generic;

namespace WebApi.Models.DataTransferObjects
{
    public class ShopDTO
    {
        public int Id { get; set; }
        public int OwnerId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string LongDescription { get; set; }
        public string Contacts { get; set; }
        public string Location { get; set; }
    }
}
using System;
using System.Collections.Generic;

namespace WebApi.Models
{
    public class Shop
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string LongDescription { get; set; }
        public string Contacts { get; set; }
        public string Location { get; set; }
        public User Owner { get; set; }
        public int OwnerId { get; set; }
        public List<Produce> Produce { get; set; }
        public List<Follow> Followers { get; set; }
        public List<Notification> Notifications { get; set; }

        public string Image1 { get; set; }
        public string Image2 { get; set; }
        public string Image3 { get; set; }
        public string Image4 { get; set; }
    }
}
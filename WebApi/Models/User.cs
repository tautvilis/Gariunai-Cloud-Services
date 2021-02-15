using System;
using System.Collections.Generic;

namespace WebApi.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }

        public string ProfilePicture { get; set; }

        public List<Shop> Businesses { get; set; }
        public List<Follow> Follow { get; set; }
    }
}
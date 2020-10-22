﻿using System.Collections.Generic;

namespace Gariunai_Cloud_Services.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name {get; set;}
        public string Email { get; set; }
        public string Description { get; set;}
        public byte[] Image { get; set; }
        public List<Shop> Businesses { get; set;}
    }
}

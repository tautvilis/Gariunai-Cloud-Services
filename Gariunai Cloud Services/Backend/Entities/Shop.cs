﻿using System.Collections.Generic;

namespace Gariunai_Cloud_Services.Backend.Entities
{
    public class Shop
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public User Owner { get; set; }
        public List<Produce> Produce { get; set; }
    }
}
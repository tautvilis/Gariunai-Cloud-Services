using System.Collections.Generic;

namespace Gariunai_Cloud_Services.Entities
{
    class Business
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> Produce { get; set; }
        public User Owner { get; set; }
    }
}

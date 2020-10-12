using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Gariunai_Cloud_Services.Entities
{
    class User
    {
        [Key] 
        public string Name {get; set;}
        public string Email { get; set; }
        public string Description { get; set;}
        public List<Shop> Businesses { get; set;}
    }
}

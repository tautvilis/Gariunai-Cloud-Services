using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Gariunai_Cloud_Services.Entities
{
    class Password
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public String Hash { get; set; }
        public String Salt { get; set; }
    }
}

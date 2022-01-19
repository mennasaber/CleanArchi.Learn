using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchi.Learn.Domain.Entities
{
    public class User : IdentityUser
    {
        public ICollection<Order> Orders { get; set; }
    }
}

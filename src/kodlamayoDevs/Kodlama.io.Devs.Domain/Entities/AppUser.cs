﻿using Core.Security.Entities;

namespace Kodlama.io.Devs.Domain.Entities
{
    public class AppUser : User
    {
        public Developer Developer { get; set; }
    }
}

﻿using CareerPathCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerPathCore.Contracts
{
    public interface IUserRepository
    {
        Task<User?> GetUserByEmail(string? email);
        Task AddUser(User user);
    }
}

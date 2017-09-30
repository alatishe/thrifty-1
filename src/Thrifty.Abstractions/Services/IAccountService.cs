﻿using System.Threading.Tasks;
using Thrifty.Models;

namespace Thrifty.Abstractions.Services
{
    public interface IAccountService
    {
        Task<int> Create(string name, string key);
    }
}

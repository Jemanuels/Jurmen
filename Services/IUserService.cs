﻿using Jurmen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jurmen.Services
{
    public interface IUserService
    {

        Task<string> RegisterAsync(RegisterModel model);
    }
}
﻿using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eShopViewModels.System.Users;
using Microsoft.AspNetCore.Mvc.RazorPages;
using eShopViewModels.Common;

namespace eShopApplication.System.Users
{
    public interface IUserService
    {
        Task<string> Authencate(LoginRequest request);
        Task<bool> Register(RegisterRequest request);
        Task<PagedResult<UserViewModel>> GetUserPaging(GetUserPagingRequest request);
    }
}

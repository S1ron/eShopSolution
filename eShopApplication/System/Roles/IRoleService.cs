﻿using eShopViewModels.System.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShopApplication.System.Roles
{
    public interface IRoleService
    {
        Task<List<RoleViewModel>> GetAll();
    }
}

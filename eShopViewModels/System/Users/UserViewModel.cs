using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShopViewModels.System.Users
{
    public class UserViewModel
    {
        public Guid Id { get; set; }
        public string FirstName { set; get; }
        public string LastName { set; get; }    
        public string PhoneNumber { set; get; }
        public string UserName { set; get; }
        public string Email { set; get; }
    }
}

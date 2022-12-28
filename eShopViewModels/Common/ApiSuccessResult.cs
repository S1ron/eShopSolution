using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShopViewModels.Common
{
    public class ApiSuccessResult<T> : ApiResult<T> 
    {
        public ApiSuccessResult(T resultObject)
        {
            IsSuccessed = true;
            ResultObj = resultObject;
        }
        public ApiSuccessResult()
        {
            IsSuccessed = true;
        }
    }
}

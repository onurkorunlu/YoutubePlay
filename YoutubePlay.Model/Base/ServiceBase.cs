using System;
using YoutubePlay.Common;
using YoutubePlay.Common.Models;

namespace YoutubePlay.Models.Base
{
    public abstract class ServiceBase
    {
        protected BaseServiceResult<T> SuccessResult<T>(T data)
        {
            return new BaseServiceResult<T>
            {
                IsSucess = true,
                ReturnCode = ReturnCodes.SUCCESSFUL,
                ReturnMessage = AppServiceProvider.Instance.Get<IReturnMessages>().Get(ReturnCodes.SUCCESSFUL),
                Data = data
            };
        }

        protected BaseServiceResult<T> SuccessResult<T>(string returnCode, T data)
        {
            return new BaseServiceResult<T>
            {
                IsSucess = true,
                ReturnCode = returnCode,
                ReturnMessage = AppServiceProvider.Instance.Get<IReturnMessages>().Get(returnCode),
                Data = data
            };
        }

        protected BaseServiceResult<T> ErrorResult<T>(Exception e, object model = null)
        {
            return this.ErrorResult<T>(new YoutubePlayException(ReturnCodes.GENERIC_ERROR, model));
        }

        protected BaseServiceResult<T> ErrorResult<T>(YoutubePlayException e)
        {
            return new BaseServiceResult<T>
            {
                IsSucess = false,
                ReturnCode = e.ErrorCode,
                ReturnMessage = e.Message,
                Data = default(T)
            };
        }

    }
}

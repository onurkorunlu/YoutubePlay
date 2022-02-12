using System.Collections.Generic;
using YoutubePlay.Common.Models;

namespace YoutubePlay.Common
{
    public interface IReturnMessages
    {
        public string Get(string errorCode);

    }

    public class ReturnMessages : IReturnMessages
    {
        Dictionary<string, string> Errors;

        public ReturnMessages()
        {
            Errors = new Dictionary<string, string>
            {
                { ReturnCodes.SUCCESSFUL, "İşlem başarılı." },
                { ReturnCodes.GENERIC_ERROR, "Beklenmeyen bir hata oluştu" }
            };
        }

        public string Get(string errorCode)
        {
            if(Errors.TryGetValue(errorCode, out string errorMessage))
            {
                return errorMessage;
            }

            return "Unknown Error : " + errorCode;
        }
    }


   
}

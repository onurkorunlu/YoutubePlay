using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Linq;
using YoutubePlay.Common;

namespace YoutubePlay.Models.Base
{
    public class YoutubePlayException : Exception
    {
        public string ErrorCode { get; set; }

        public YoutubePlayException(string errorCode, object model = null, Exception innerException = null) : base(AppServiceProvider.Instance.Get<IReturnMessages>().Get(errorCode), innerException)
        {
            ErrorCode = errorCode;
            Data.Add("model", model);
            LogException(this, model);
        }

        public void LogException(YoutubePlayException ex, object model)
        {
            string methodName = "Unknown";
            var s = ex.StackTrace;
            var frames = new StackTrace(ex).GetFrames();
            if (frames != null && frames.Any())
            {
                methodName = frames.Select(f => f.GetMethod()).Last().ToString();
            }

            // Check configs for logging
            AppServiceProvider.Instance.Get<ILogger>().LogError($"Error @{methodName}");
            AppServiceProvider.Instance.Get<ILogger>().LogError("Request : {0}", model ?? JsonConvert.SerializeObject(model));
            AppServiceProvider.Instance.Get<ILogger>().LogError(ex, ex.Message);
        }
    }
}

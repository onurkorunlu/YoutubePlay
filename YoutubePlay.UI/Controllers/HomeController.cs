using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using YoutubePlay.Business.Interfaces;
using YoutubePlay.Common;
using YoutubePlay.Models.Base;
using YoutubePlay.Models.Youtube;

namespace YoutubePlay.UI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public async Task<BaseServiceResult<List<YoutubeVideo>>> SearchAsync([FromQuery] SearchVideoRequest request)
        {
            return await AppServiceProvider.Instance.Get<IYoutubeService>().SearchVideoAsync(request);
        }

        [HttpGet]
        public async Task<BaseServiceResult<YoutubeMp3>> GetMp3UrlAsync(string videoId)
        {
            return await AppServiceProvider.Instance.Get<IYoutubeService>().GetMp3UrlAsync(videoId);
        }
    }
}

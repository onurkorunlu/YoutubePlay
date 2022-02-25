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
    }
}

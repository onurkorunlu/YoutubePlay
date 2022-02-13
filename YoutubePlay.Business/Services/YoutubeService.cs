using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using YoutubePlay.Business.Interfaces;
using YoutubePlay.Models.Base;
using YoutubePlay.Models.Youtube;
using YoutubePlay.YoutubeHelper;

namespace YoutubePlay.Business.Services
{
    public class YoutubeService : ServiceBase, IYoutubeService
    {
        public async Task<BaseServiceResult<List<YoutubeVideo>>> SearchVideoAsync(SearchVideoRequest request)
        {
            try
            {
                List<YoutubeVideo> response = await YoutubeSearch.SearchVideoAsync(request);
                return base.SuccessResult<List<YoutubeVideo>>(response);
            }
            catch (YoutubePlayException e)
            {
                return base.ErrorResult<List<YoutubeVideo>>(e, request);
            }
            catch (Exception e)
            {
                return base.ErrorResult<List<YoutubeVideo>>(e, request);
            }
        }
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using YoutubePlay.Models.Base;
using YoutubePlay.Models.Youtube;

namespace YoutubePlay.Business.Interfaces
{
    public interface IYoutubeService
    {
        public Task<BaseServiceResult<List<YoutubeVideo>>> SearchVideoAsync(SearchVideoRequest request);

        public Task<BaseServiceResult<List<YoutubePlaylist>>> SearchPlaylistAsync(SearchPlaylistRequest request);

    }
}

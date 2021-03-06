using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using YoutubeExplode;
using YoutubeExplode.Videos.Streams;
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

        public async Task<BaseServiceResult<List<YoutubePlaylist>>> SearchPlaylistAsync(SearchPlaylistRequest request)
        {
            try
            {
                List<YoutubePlaylist> response = await YoutubeSearch.SearchPlaylistAsync(request);
                return base.SuccessResult<List<YoutubePlaylist>>(response);
            }
            catch (YoutubePlayException e)
            {
                return base.ErrorResult<List<YoutubePlaylist>>(e, request);
            }
            catch (Exception e)
            {
                return base.ErrorResult<List<YoutubePlaylist>>(e, request);
            }
        }

        public async Task<BaseServiceResult<YoutubeMp3>> GetMp3UrlAsync(string videoId)
        {
            try
            {
                var youtube = new YoutubeClient();
                var streamManifest = await youtube.Videos.Streams.GetManifestAsync(videoId);
                var streamInfo = streamManifest.GetAudioOnlyStreams().GetWithHighestBitrate();
                return base.SuccessResult<YoutubeMp3>(new YoutubeMp3 { Url = FixUrl(streamInfo.Url), Size = streamInfo.Size.MegaBytes, Bitrate = streamInfo.Bitrate.BitsPerSecond });
            }
            catch (YoutubePlayException e)
            {
                return base.ErrorResult<YoutubeMp3>(e, new { VideoId = videoId });
            }
            catch (Exception e)
            {
                return base.ErrorResult<YoutubeMp3>(e, new { VideoId = videoId });
            }

        }

        private string FixUrl(string url)
        {
            return url.Replace("&c=ANDORID", "");
        }
    }
}

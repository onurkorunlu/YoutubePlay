using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using YoutubeExplode;
using YoutubeExplode.Videos.Streams;
using YoutubePlay.Common;
using YoutubePlay.Common.Models;
using YoutubePlay.Models.Base;
using YoutubePlay.YoutubeHelper.Models;

namespace YoutubePlay.YoutubeHelper
{
    public class YoutubeAudioConverter
    {
        public async Task<GetAudioResult> GetAudioUrlByVideoIdAsync(GetAudioRequest request)
        {
            try
            {
                var youtube = new YoutubeClient();
                var streamManifest = await youtube.Videos.Streams.GetManifestAsync(request.VideoId);
                var audioStreamInfo = streamManifest.GetAudioStreams().GetWithHighestBitrate();
                return new GetAudioResult
                {
                    Url = audioStreamInfo.Url,
                    Size = audioStreamInfo.Size,
                    Bitrate = audioStreamInfo.Bitrate,
                    Container = audioStreamInfo.Container
                };
            }
            catch (Exception e)
            {
                AppServiceProvider.Instance.Get<ILogger>().LogError(e, "ERROR @GetAudioByVideoIdAsync");
                throw new YoutubePlayException(ReturnCodes.YT_GET_AUDIO_ERROR);
            }
           
        }
    }
}

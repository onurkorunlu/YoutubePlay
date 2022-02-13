using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using YoutubePlay.Common;
using YoutubePlay.Common.Models;
using YoutubePlay.Models.Base;
using YoutubePlay.Models.Youtube;
using YoutubePlay.YoutubeHelper.Models;

namespace YoutubePlay.YoutubeHelper
{
    public class YoutubeSearch
    {
        public static async Task<List<YoutubeVideo>> SearchVideoAsync(SearchVideoRequest request)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var jsonRequest = @"{'context':{'client':{'clientName':'WEB','clientVersion':'2.20210224.06.00','newVisitorCookie':true},'user':{'lockedSafetyMode':false}},'query':'@query','client':{'hl':'tr','gl':'TR'}}";

                    jsonRequest = jsonRequest.Replace("@query", request.Query);

                    var data = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
                    var postResponse = await client.PostAsync("https://www.youtube.com/youtubei/v1/search?key=AIzaSyAO_FJ2SlqU8Q4STEHLGCilw_Y9_11qcW8", data);
                    var responseString = postResponse.Content.ReadAsStringAsync().Result;
                    YoutubeSearchResponse youtubeSearchResponse = JsonConvert.DeserializeObject<YoutubeSearchResponse>(responseString);
                    List<YoutubeVideo> result = new List<YoutubeVideo>();
                    var contents = youtubeSearchResponse?.contents?.TwoColumnSearchResultsRenderer?.primaryContents?.sectionListRenderer?.contents;
                    if (contents != null && contents.Any())
                    {
                        foreach (var sectionListRenderer in contents)
                        {
                            var itemContents = sectionListRenderer?.itemSectionRenderer?.contents;
                            if (itemContents != null && itemContents.Any())
                            {
                                foreach (var item in itemContents)
                                {
                                    if (item.videoRenderer != null)
                                    {
                                        var videoRenderer = item.videoRenderer;

                                        result.Add(new YoutubeVideo
                                        {
                                            Id = videoRenderer.videoId,
                                            Title = videoRenderer.title?.runs?.First()?.text,
                                            Duration = videoRenderer.lengthText?.simpleText,
                                            Channel = new ChannelInfo
                                            {
                                                Name = videoRenderer.ownerText?.runs?.First()?.text,
                                                Thumbnails = new Thumbnails
                                                {
                                                    Url = videoRenderer?.channelThumbnailSupportedRenderers?.channelThumbnailWithLinkRenderer?.thumbnail?.thumbnails?.First().url,
                                                    Width = videoRenderer?.channelThumbnailSupportedRenderers?.channelThumbnailWithLinkRenderer?.thumbnail?.thumbnails?.First().width,
                                                    Height = videoRenderer?.channelThumbnailSupportedRenderers?.channelThumbnailWithLinkRenderer?.thumbnail?.thumbnails?.First().height
                                                }
                                            },
                                            Thumbnails = new Thumbnails
                                            {
                                                Url = videoRenderer?.thumbnail?.thumbnails?.First()?.url,
                                                Height = videoRenderer?.thumbnail?.thumbnails?.First()?.height,
                                                Width = videoRenderer?.thumbnail?.thumbnails?.First()?.width
                                            },
                                            TimeAgo = videoRenderer.publishedTimeText?.simpleText,
                                            ViewCount = videoRenderer.viewCountText?.simpleText,
                                            ShortViewCount = videoRenderer.shortViewCountText?.simpleText
                                        }); ;
                                    }
                                }
                            }
                        }
                    }

                    return result;
                }
            }
            catch (Exception e)
            {
                AppServiceProvider.Instance.Get<ILogger>().LogError(e, "ERROR @SearchVideoAsync");
                throw new YoutubePlayException(ReturnCodes.YT_HTTP_SEARCH_ERROR, request);
            }
        }

        public static async Task<List<YoutubeVideo>> SearchPlaylistAsync(SearchPlaylistRequest request)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    return new List<YoutubeVideo>();
                }
            }
            catch (Exception e)
            {
                AppServiceProvider.Instance.Get<ILogger>().LogError(e, "ERROR @SearchPlaylistAsync");
                throw new YoutubePlayException(ReturnCodes.YT_HTTP_SEARCH_ERROR, request);
            }
        }

        public static async Task<List<YoutubeVideo>> SearchChannelAsync(SearchChannelRequest request)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    return new List<YoutubeVideo>();
                }
            }
            catch (Exception e)
            {
                AppServiceProvider.Instance.Get<ILogger>().LogError(e, "ERROR @SearchChannelAsync");
                throw new YoutubePlayException(ReturnCodes.YT_HTTP_SEARCH_ERROR, request);
            }
        }
    }
}

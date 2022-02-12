using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using YoutubePlay.Common.Models;
using YoutubePlay.Models.Base;
using YoutubePlay.Models.Youtube;
using YoutubePlay.YoutubeHelper.Models;

namespace YoutubePlay.YoutubeHelper
{
    public class YoutubeSearch
    {
        public static async Task<List<YoutubeVideo>> SearchAsync(SearchVideoRequest request)
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

                    return new List<YoutubeVideo>();
                }
            }
            catch (Exception e)
            {

                throw new YoutubePlayException(ReturnCodes.YT_HTTP_SEARCH_ERROR, request);
            }


        }
    }
}

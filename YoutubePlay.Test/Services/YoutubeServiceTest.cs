using Microsoft.Extensions.Logging;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using YoutubePlay.Business.Interfaces;
using YoutubePlay.Business.Services;
using YoutubePlay.Common;
using YoutubePlay.Models.Youtube;

namespace YoutubePlay.Test.Services
{
    public class YoutubeServiceTest
    {
        [SetUp]
        public void Setup()
        {
            AppServiceProvider.Instance.Register(typeof(IYoutubeService), new YoutubeService());
            AppServiceProvider.Instance.Register(typeof(IReturnMessages), new ReturnMessages());
            AppServiceProvider.Instance.Register(typeof(ILogger), new LoggerFactory().CreateLogger("YoutubeServiceTest"));
        }

        [Test]
        public async Task SearchVideoAsync()
        {
            SearchVideoRequest request = new SearchVideoRequest
            {
                Query = "Tarkan"
            };

            var response = await AppServiceProvider.Instance.Get<IYoutubeService>().SearchVideoAsync(request);
            Assert.IsTrue(response.IsSuccess);
        }

        [Test]
        public async Task SearchPlaylistAsync()
        {
            SearchPlaylistRequest request = new SearchPlaylistRequest
            {
                Query = "Tarkan"
            };

            var response = await AppServiceProvider.Instance.Get<IYoutubeService>().SearchPlaylistAsync(request);
            Assert.IsTrue(response.IsSuccess);
        }
    }
}

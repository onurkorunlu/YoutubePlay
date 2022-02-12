using Microsoft.VisualStudio.TestTools.UnitTesting;
using YoutubePlay.YoutubeHelper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace YoutubePlay.YoutubeHelper.Tests
{
    public class YoutubeSearchTests
    {
        [TestMethod()]
        public async Task SearchAsyncTestAsync()
        {
            await YoutubeSearch.SearchAsync(new Models.Youtube.SearchVideoRequest() { Query = "sansar" });
            Assert.Fail();
        }
    }
}
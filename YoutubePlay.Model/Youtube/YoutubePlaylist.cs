using System;
using System.Collections.Generic;
using System.Text;

namespace YoutubePlay.Models.Youtube
{
    public class YoutubePlaylist
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public short VideoCount { get; set; }
        public string Owner { get; set; }
        public Thumbnails Thumbnails { get; set; }
    }
}

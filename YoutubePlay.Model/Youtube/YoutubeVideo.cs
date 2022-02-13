namespace YoutubePlay.Models.Youtube
{
    public class YoutubeVideo
    {
        public string Title { get; set; }

        public Thumbnails Thumbnails { get; set; }

        public string Duration { get; set; }

        public string TimeAgo { get; set; }

        public ChannelInfo Channel { get; set; }
        public string ViewCount { get; set; }
        public string ShortViewCount { get; set; }
        public string Id { get; set; }
    }
}

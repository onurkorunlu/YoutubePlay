namespace YoutubePlay.Models.Youtube
{
    public class YoutubeVideo
    {
        public string Title { get; set; }

        public string Description { get; set; }
        public string Image { get; set; }

        public string Duration { get; set; }

        public string TimeAgo { get; set; }

        public ChannelInfo Channel { get; set; }
    }
}

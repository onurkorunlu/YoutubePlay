using YoutubeExplode.Videos.Streams;

namespace YoutubePlay.YoutubeHelper.Models
{
    public class GetAudioResult
    {
        public string Url { get; set; }
        public FileSize Size { get; set; }
        public Bitrate Bitrate { get; set; }
        public Container Container { get; set; }
    }
}

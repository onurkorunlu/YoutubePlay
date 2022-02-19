using System.Collections.Generic;

namespace YoutubePlay.YoutubeHelper.Models.Video
{
    public class YoutubeSearchVideoResponse
    {
        internal class Root
        {
            public string estimatedResults { get; set; }
            public string trackingParams { get; set; }
            public Contents contents { get; set; }
        }

        internal class Thumbnail2
        {
            public string url { get; set; }
            public int width { get; set; }
            public int height { get; set; }
        }

        internal class Thumbnail
        {
            public List<Thumbnail2> thumbnails { get; set; }
        }

        internal class Run
        {
            public string text { get; set; }
        }

        internal class Title
        {
            public List<Run> runs { get; set; }
        }

        internal class LongBylineText
        {
            public List<Run> runs { get; set; }
        }

        internal class PublishedTimeText
        {
            public string simpleText { get; set; }
        }

        internal class LengthText
        {
            public string simpleText { get; set; }
        }

        internal class ViewCountText
        {
            public string simpleText { get; set; }
        }

        internal class OwnerText
        {
            public List<Run> runs { get; set; }
        }

        internal class ShortBylineText
        {
            public List<Run> runs { get; set; }
        }

        internal class ShortViewCountText
        {
            public string simpleText { get; set; }
        }

        internal class ChannelThumbnailWithLinkRenderer
        {
            public Thumbnail thumbnail { get; set; }
        }

        internal class ChannelThumbnailSupportedRenderers
        {
            public ChannelThumbnailWithLinkRenderer channelThumbnailWithLinkRenderer { get; set; }
        }

        internal class VideoRenderer
        {
            public string videoId { get; set; }
            public Thumbnail thumbnail { get; set; }
            public Title title { get; set; }
            public LongBylineText longBylineText { get; set; }
            public PublishedTimeText publishedTimeText { get; set; }
            public LengthText lengthText { get; set; }
            public ViewCountText viewCountText { get; set; }
            public OwnerText ownerText { get; set; }
            public ShortBylineText shortBylineText { get; set; }
            public bool showActionMenu { get; set; }
            public ShortViewCountText shortViewCountText { get; set; }
            public ChannelThumbnailSupportedRenderers channelThumbnailSupportedRenderers { get; set; }
        }

        internal class Content2
        {
            public VideoRenderer videoRenderer { get; set; }
            public ItemSectionRenderer itemSectionRenderer { get; set; }
            public TwoColumnSearchResultsRenderer twoColumnSearchResultsRenderer { get; set; }
        }

        internal class ItemSectionRenderer
        {
            public List<Content_ItemSectionRenderer> contents { get; set; }
        }

        internal class Content_ItemSectionRenderer
        {
            public VideoRenderer videoRenderer { get; set; }
        }

        internal class SectionListRenderer
        {
            public List<Content_SectionListRenderer> contents { get; set; }
        }

        internal class Content_SectionListRenderer
        {
            public ItemSectionRenderer itemSectionRenderer { get; set; }
        }

        internal class PrimaryContents
        {
            public SectionListRenderer sectionListRenderer { get; set; }
        }

        internal class TwoColumnSearchResultsRenderer
        {
            public PrimaryContents primaryContents { get; set; }
        }

        internal class Contents
        {
            public TwoColumnSearchResultsRenderer twoColumnSearchResultsRenderer { get; set; }
        }
    }
}


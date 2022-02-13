using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace YoutubePlay.YoutubeHelper.Models
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Thumbnail2
    {
        public string url { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

    public class Thumbnail
    {
        public List<Thumbnail2> thumbnails { get; set; }
    }

    public class Run
    {
        public string text { get; set; }
    }

    public class Title
    {
        public List<Run> runs { get; set; }
    }

    public class LongBylineText
    {
        public List<Run> runs { get; set; }
    }

    public class PublishedTimeText
    {
        public string simpleText { get; set; }
    }

    public class LengthText
    {
        public string simpleText { get; set; }
    }

    public class ViewCountText
    {
        public string simpleText { get; set; }
    }

    public class OwnerText
    {
        public List<Run> runs { get; set; }
    }

    public class ShortBylineText
    {
        public List<Run> runs { get; set; }
    }

    public class ShortViewCountText
    {
        public string simpleText { get; set; }
    }

    public class ChannelThumbnailWithLinkRenderer
    {
        public Thumbnail thumbnail { get; set; }
    }

    public class ChannelThumbnailSupportedRenderers
    {
        public ChannelThumbnailWithLinkRenderer channelThumbnailWithLinkRenderer { get; set; }
    }

    public class VideoRenderer
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

    public class Content2
    {
        public VideoRenderer videoRenderer { get; set; }
        public ItemSectionRenderer itemSectionRenderer { get; set; }
        public TwoColumnSearchResultsRenderer twoColumnSearchResultsRenderer { get; set; }
    }

    public class ItemSectionRenderer
    {
        public List<Content_ItemSectionRenderer> contents { get; set; }
    }

    public class Content_ItemSectionRenderer
    {
        public VideoRenderer videoRenderer { get; set; }
    }

    public class SectionListRenderer
    {
        public List<Content_SectionListRenderer> contents { get; set; }
    }

    public class Content_SectionListRenderer
    {
        public ItemSectionRenderer itemSectionRenderer { get; set; }
    }

    public class PrimaryContents
    {
        public SectionListRenderer sectionListRenderer { get; set; }
    }

    public class TwoColumnSearchResultsRenderer
    {
        public PrimaryContents primaryContents { get; set; }
    }

    public class YoutubeSearchResponse
    {
        public string estimatedResults { get; set; }
        public string trackingParams { get; set; }
        public Contents contents { get; set; }
    }

    public class Contents
    {
        public TwoColumnSearchResultsRenderer TwoColumnSearchResultsRenderer { get; set; }
    }
}


using System;
using System.Collections.Generic;
using System.Text;

namespace YoutubePlay.YoutubeHelper.Models.Playlist
{
    public class YoutubeSearchPlaylistResponse
    {

        internal class Title
        {
            public string simpleText { get; set; }
        }

        internal class Run
        {
            public string text { get; set; }
        }

        internal class ShortBylineText
        {
            public List<Run> runs { get; set; }
        }

        internal class AccessibilityData
        {
            public string label { get; set; }
        }

        internal class Accessibility
        {
            public AccessibilityData accessibilityData { get; set; }
        }

        internal class LengthText
        {
            public Accessibility accessibility { get; set; }
            public string simpleText { get; set; }
        }

        internal class ChildVideoRenderer
        {
            public Title title { get; set; }
            public LengthText lengthText { get; set; }
            public string videoId { get; set; }
        }

        internal class Video
        {
            public ChildVideoRenderer childVideoRenderer { get; set; }
        }

        internal class PlaylistRenderer
        {
            public string playlistId { get; set; }
            public Title title { get; set; }
            public List<Thumbnail> thumbnails { get; set; }
            public string videoCount { get; set; }
            public ShortBylineText shortBylineText { get; set; }
        }

        internal class Thumbnail
        {
            public List<Thumbnail_Detail> thumbnails { get; set; }
        }

        internal class Thumbnail_Detail
        {
            public string url { get; set; }
            public int width { get; set; }
            public int height { get; set; }
        }

        internal class Content2
        {
            public PlaylistRenderer playlistRenderer { get; set; }
            public ItemSectionRenderer itemSectionRenderer { get; set; }
            public TwoColumnSearchResultsRenderer twoColumnSearchResultsRenderer { get; set; }
        }

        internal class ItemSectionRenderer
        {
            public List<Content_ItemSectionRenderer> contents { get; set; }
        }

        internal class Content_ItemSectionRenderer
        {
            public PlaylistRenderer playlistRenderer { get; set; }
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

        internal class Root
        {
            public string estimatedResults { get; set; }
            public string trackingParams { get; set; }
            public Contents contents { get; set; }
        }

        internal class Contents
        {
            public TwoColumnSearchResultsRenderer twoColumnSearchResultsRenderer { get; set; }
        }

    }


}

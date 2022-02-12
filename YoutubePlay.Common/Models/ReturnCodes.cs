using System;
using System.Collections.Generic;
using System.Text;

namespace YoutubePlay.Common.Models
{
    public static class ReturnCodes
    {
        public static string SUCCESSFUL = "0";
        public static string GENERIC_ERROR = "-1";

        // Youtube HTTP ERRORS 1XX
        public static string YT_HTTP_SEARCH_ERROR = "100";
    }
}

import { BaseModel } from "./baseModel";
import { ChannelInfo } from "./channelInfo";
import { Thumbnails } from "./thumbnails";

export class YoutubeVideo extends BaseModel {

    title: string;
    thumbnails: Thumbnails;
    duration: string;
    timeAgo: string;
    channel: ChannelInfo;
    viewCount: string;
    shortViewCount: string;
    id: string;
}

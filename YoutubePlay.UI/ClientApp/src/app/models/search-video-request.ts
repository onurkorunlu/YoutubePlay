import { BaseModel } from "./baseModel";
import { ChannelInfo } from "./channelInfo";
import { Thumbnails } from "./thumbnails";

export class SearchVideoRequest {

    query: string;
    maxResult: number;
}

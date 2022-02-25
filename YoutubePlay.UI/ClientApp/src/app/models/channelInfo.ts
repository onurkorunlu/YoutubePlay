import { BaseModel } from "./baseModel";
import { Thumbnails } from "./thumbnails";

export class ChannelInfo extends BaseModel {
    thumbnails: Thumbnails;
    name: string;
}

import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { BaseResult } from '../models/base-result';
import { SearchVideoRequest } from '../models/search-video-request';
import { YoutubeVideo } from '../models/youtube-video';
import { HttpService } from './http.service';

@Injectable({
    providedIn: 'root'
})
export class YoutubeService {

    constructor(public httpService: HttpService) { }

    searchVideos(request: SearchVideoRequest): Observable<BaseResult<YoutubeVideo[]>> {
        return this.httpService.getWithModel<BaseResult<YoutubeVideo[]>>("home/search?", request);
    }
}

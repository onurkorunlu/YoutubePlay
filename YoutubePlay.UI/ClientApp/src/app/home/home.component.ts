import { Component } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import * as Plyr from 'plyr';
import { Options } from 'plyr';
import { SearchVideoRequest } from '../models/search-video-request';
import { YoutubeVideo } from '../models/youtube-video';
import { YoutubeService } from '../services/youtube.service';

@Component({
    selector: 'app-home',
    templateUrl: './home.component.html',
})
export class HomeComponent {

    private player: Plyr;

    public videoList: YoutubeVideo[] = [];
    public playlist: YoutubeVideo[] = [];
    public selectedItem: YoutubeVideo = null;
    public isLoading = false;
    public searchVideoRequest: SearchVideoRequest = <SearchVideoRequest>{ maxResult: 20 };


    public items =["Item1","Item2","Item3","Item4" ]

    constructor(private youtubeService: YoutubeService, private sanitizer: DomSanitizer) {
        this.player = new Plyr('#player', {
            /* options */
        });
    };

    public searchVideos = function () {
        console.log(this.searchVideoRequest);
        this.isLoading = true;
        this.youtubeService.searchVideos(this.searchVideoRequest).subscribe(
            (res) => {
                if (res.isSuccess) {
                    this.isLoading = false;
                    this.videoList = res.data;
                }
            },
            (errorMessage: string) => {
                console.log(errorMessage);
                this.isLoading = false;
            }
        );
    }

    public play = function (item) {
        this.selectedItem = item;
        var index = this.videoList.indexOf(item);
        this.playlist = this.videoList.slice(index)
        console.log(this.videoList);
        this.youtubeService.getMp3(item.id).subscribe(
            (res) => {
                if (res.isSuccess) {
                    console.log(res.data);
                    this.selectedItem.url = res.data.url;
                    var htmlPlayer = document.getElementById('player');
                    htmlPlayer.setAttribute("src", res.data.url);
                    this.player = new Plyr('#player', <Options>{
                        title: this.selectedItem.title,
                        autoplay: true,
                        source: {
                            type: 'audio',
                            title: this.selectedItem.title,
                            sources: [
                                {
                                    src: res.data.url,
                                    type: 'audio/mp3'
                                }
                            ]
                        }
                    });

                    setTimeout(this.checkState, 3000)
                }
                else {
                    console.log(res);
                }
            },
            (errorMessage: string) => {
                console.log(errorMessage);
                this.isLoading = false;
            }
        )
    }

    public checkState = function () {

        if (this.player.ended) {
            this.autoNext();
        }
        else {
            setTimeout(this.checkState, 5000)
        }
    }

    public autoNext = function () {
        if (this.playlist != null) {

            var currentTrackIndex = this.playlist.indexOf(this.selectedItem);
            if (this.playlist.length != currentTrackIndex + 1) {
                currentTrackIndex++;
                var nextTrack = this.playlist[currentTrackIndex];
                this.play(nextTrack);
            }
        }
    }
};

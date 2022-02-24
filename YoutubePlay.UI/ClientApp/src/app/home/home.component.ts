import { Component } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import * as Plyr from 'plyr';
import { Options } from 'plyr';
import { YoutubeService } from '../services/youtube.service';

@Component({
    selector: 'app-home',
    templateUrl: './home.component.html',
})
export class HomeComponent {

    public videoList = [];
    public key = '';
    public selectedItem = null;
    public isLoading = false;
    public playlist = [];
    private player: Plyr;

    constructor(private youtubeService: YoutubeService, private sanitizer: DomSanitizer) {

        this.player = new Plyr('#player', {
            /* options */
        });

    };

    public searchVideos = function () {

        this.recaptchaV3Service.execute('importantAction')
            .subscribe((token: string) => {
                console.debug(`Token [${token}] generated`);
                this.isLoading = true;
                this.youtubeService.searchVideos(this.key, 10, token, function (res) {
                    if (res.isSuccess) {
                        console.log(res.data.result);
                        this.isLoading = false;
                        this.videoList = res.data.result;
                    }
                }, function (err) {
                    this.isLoading = false;
                })
            }
        );
    }

    public play = function (item) {

        this.selectedItem = item;
        var index = this.videoList.indexOf(item);
        this.playlist = this.videoList.slice(index)
        console.log(this.videoList);
        this.youtubeService.getMp3(item.id,
            function (res) {
                if (res.isSuccess) {
                    console.log(res.data);
                    this.selectedItem.url = res.data.url;
                    var htmlPlayer = document.getElementById('player');
                    htmlPlayer.setAttribute("src", this.sanitizer.bypassSecurityTrustHtml(res.data.url));
                    this.player = new Plyr('#player', <Options>{
                        title: this.selectedItem.title,
                        autoplay: true,
                        source: {
                            type: 'audio',
                            title: this.selectedItem.title,
                            sources: [
                                {
                                    src: this.sanitizer.bypassSecurityTrustHtml(res.data.url),
                                    type: 'audio/mp3'
                                }
                            ]
                        }
                    });

                    setTimeout(this.checkState, 3000)
                }
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

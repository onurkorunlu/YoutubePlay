import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class HttpService {

    private baseUrl: string;

    constructor(private httpClient: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        this.baseUrl = baseUrl;
    }

    getWithModel<T>(path: string, model: any) {
        return this.httpClient.get<T>(this.baseUrl + path + new URLSearchParams(model).toString());
    }

    get<T>(path: string) {
        return this.httpClient.get<T>(this.baseUrl + path);
    }

    post<T>(path: string, model: any) {
        return this.httpClient.post<T>(this.baseUrl + path, model);
    }
}

import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { baseApi } from '../../../config/baseApi';

type DeviceResponse = string[];

@Injectable({
  providedIn: 'root'
})
export class DeviceService {
  constructor(private readonly httpClient: HttpClient) { }

  getDevices(): Observable<DeviceResponse> {
    const devices = this.httpClient.get<string[]>(`${baseApi.url}/device`);
    return devices;
  }
}

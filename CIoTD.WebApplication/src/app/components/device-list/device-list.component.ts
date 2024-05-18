import { Component, OnInit } from '@angular/core';
import { DeviceService } from '../../services/devices/device.service';
import { Device } from '../../../@types/devices/device';

@Component({
  selector: 'app-device-list',
  templateUrl: './device-list.component.html',
  styleUrls: ['./device-list.component.css']
})
export class DeviceListComponent implements OnInit {
  displayedColumns: string[] = ['Identifier'];
  devices: { Identifier: string }[] = [];

  constructor(private deviceService: DeviceService) { }

  ngOnInit(): void {
    this.deviceService.getDevices().subscribe(devices => this.devices = devices.map(device => ({ Identifier: device })));
  }
}

import { Component, OnInit } from '@angular/core';
import { DeviceService } from '../../services/devices/device.service';
import { SelectionModel } from '@angular/cdk/collections';
import { Router } from '@angular/router';

@Component({
  selector: 'app-device-list',
  templateUrl: './device-list.component.html',
  styleUrls: ['./device-list.component.css']
})
export class DeviceListComponent implements OnInit {
  devices: { Identifier: string }[] = [];
  displayedColumns: string[] = ['select', 'Identifier'];
  selection = new SelectionModel<any>(true, []);

  constructor(private deviceService: DeviceService, private router: Router) { }

  ngOnInit(): void {
    this.deviceService.getDevices().subscribe(devices => {
      this.devices = devices.map(device => ({ Identifier: device }));

      // Carregar dispositivos selecionados do localStorage
      const selected = localStorage.getItem('selectedDevices');
      if (selected) {
        const selectedDevices = JSON.parse(selected) as { Identifier: string }[];
        this.devices.forEach(device => {
          if (selectedDevices.some(selectedDevice => selectedDevice.Identifier === device.Identifier)) {
            this.selection.select(device);
          }
        });
      }
    });
  }

  isAllSelected() {
    const numSelected = this.selection.selected.length;
    const numRows = this.devices.length;
    return numSelected === numRows;
  }

  isSomeSelected() {
    const numSelected = this.selection.selected.length;
    const numRows = this.devices.length;
    return numSelected > 0 && numSelected < numRows;
  }

  masterToggle() {
    this.isAllSelected() ? this.selection.clear() : this.devices.forEach(row => this.selection.select(row));
  }

  toggleSelection(device: any) {
    this.selection.toggle(device);
  }

  saveSelection() {
    const selectedDevices = this.selection.selected;
    localStorage.setItem('selectedDevices', JSON.stringify(selectedDevices));
    this.router.navigate(['/configure-commands'], { state: { selectedDevices } });
  }
}

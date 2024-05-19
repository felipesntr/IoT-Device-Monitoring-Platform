import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-configure-commands',
  templateUrl: './configure-commands.component.html',
  styleUrls: ['./configure-commands.component.css']
})
export class ConfigureCommandsComponent implements OnInit {
  selectedDevices: any[] = [];
  availableCommands: string[] = ['Command1', 'Command2', 'Command3'];

  constructor(private router: Router) {
    const navigation = this.router.getCurrentNavigation();
    if (navigation?.extras?.state) {
      this.selectedDevices = navigation.extras.state['selectedDevices'];
    }
  }

  ngOnInit(): void { }

  saveCommands() {
    // Save the command configurations for the selected devices
    console.log('Devices with Commands:', this.selectedDevices);
    // Navigate to the dashboard or next step
    this.router.navigate(['/dashboard']);
  }
}

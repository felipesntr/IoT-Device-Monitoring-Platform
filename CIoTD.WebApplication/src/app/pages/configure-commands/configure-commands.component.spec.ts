import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ConfigureCommandsComponent } from './configure-commands.component';

describe('ConfigureCommandsComponent', () => {
  let component: ConfigureCommandsComponent;
  let fixture: ComponentFixture<ConfigureCommandsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ConfigureCommandsComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ConfigureCommandsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

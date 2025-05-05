import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ConfigureSpaceComponent } from './configure-space.component';

describe('ConfigureSpaceComponent', () => {
  let component: ConfigureSpaceComponent;
  let fixture: ComponentFixture<ConfigureSpaceComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ConfigureSpaceComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ConfigureSpaceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

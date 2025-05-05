import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ConfigureAgentComponent } from './configure-agent.component';

describe('ConfigureAgentComponent', () => {
  let component: ConfigureAgentComponent;
  let fixture: ComponentFixture<ConfigureAgentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ConfigureAgentComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ConfigureAgentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

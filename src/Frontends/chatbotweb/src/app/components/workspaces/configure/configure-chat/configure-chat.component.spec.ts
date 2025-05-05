import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ConfigureChatComponent } from './configure-chat.component';

describe('ConfigureChatComponent', () => {
  let component: ConfigureChatComponent;
  let fixture: ComponentFixture<ConfigureChatComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ConfigureChatComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ConfigureChatComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

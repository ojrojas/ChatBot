import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WorkspacesItemComponent } from './workspaces-item.component';

describe('WorkspacesItemComponent', () => {
  let component: WorkspacesItemComponent;
  let fixture: ComponentFixture<WorkspacesItemComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [WorkspacesItemComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(WorkspacesItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

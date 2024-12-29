import { ComponentFixture, TestBed } from '@angular/core/testing';
import { MainTopbarComponent } from './main-topbar.component';


describe('MainTopbarComponent', () => {
    let component: MainTopbarComponent;
    let fixture: ComponentFixture<MainTopbarComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
        imports: [MainTopbarComponent]
    })
    .compileComponents();
    
      fixture = TestBed.createComponent(MainTopbarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

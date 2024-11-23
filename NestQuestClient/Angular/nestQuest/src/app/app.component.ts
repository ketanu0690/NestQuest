import { Component, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { HeaderComponent } from './header/header.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [HeaderComponent ,RouterOutlet],
  templateUrl: './app.component.html',

// template:'Hello World',
styleUrl: './app.component.scss',
})
export class AppComponent implements OnInit {
  title = 'nestQuest';

  showHeader = true;

  toggleSvg() {
    this.showHeader = !this.showHeader;
  }

  handleToggleEvent() {
    this.toggleSvg();
  }
  async ngOnInit() {}
}

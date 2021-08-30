import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public forecasts: TeamStats[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<TeamStats[]>(baseUrl + 'Teams').subscribe(result => {
      this.forecasts = result;
    }, error => console.error(error));
  }
}

interface TeamStats {
  Team: string;
  MP: number;
  W: number;
  L: number;
  D: number;
  GF: number;
  GA: number;
  GD: number;
  P: number;
}



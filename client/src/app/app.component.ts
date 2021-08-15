import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { IBank } from 'src/models/bank';
import { IPagination } from './pagination';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent {
  title = 'Solvent';
  banks: IBank[];
  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.http.get('https://localhost:5001/api/banks?pagesize=60').subscribe(
      (response: IPagination) => {
        this.banks = response.data;
      },
      (error) => {
        console.log(error);
      }
    );
  }
}

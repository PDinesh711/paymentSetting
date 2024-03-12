import { Component } from '@angular/core';
import { ServicesService } from '../service/services.service';
import { Active } from '../models/active';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { catchError, throwError } from 'rxjs';

export interface Key {
  id: string | null;
  value: string | null;
}


@Component({
  selector: 'app-mainpage',
  templateUrl: './mainpage.component.html',
  styleUrls: ['./mainpage.component.css']
})
export class MainpageComponent {

  //  id :string="";
  //  value:string="";

  constructor(private http: HttpClient , public service : ServicesService) {
   

  }

  toggleSwitch(event: any) {
    var status = event.target.checked;
    this.sendToBackend(status);
  }

  sendToBackend(status: string) {
    const apiUrl = "https://localhost:7103/api/Active/save";
    this.http.post<any>(apiUrl,{status}) 
      .subscribe(response => {
       console.log(response);
   });
  }

  idd: string | null = null;
  value: string | null = null;
  key: Key = { id: " ", value: " " };

  sendDataToBackend(data: Key) {
    const headers = new HttpHeaders({
      'Content-Type': 'application/json'
    });

    return this.http.post<any>('https://localhost:7103/api/Key/save', data, { headers: headers })
      .pipe(
        catchError((error: HttpErrorResponse) => {
          return throwError('Error sending data to backend: ' + error.message);
        })
      );
  }


  inputs() {
    this.idd = prompt("Key ID : ");
    this.value = prompt("Key Value : ");
    // Assign values to key inside inputs() function
    this.key = { id: this.idd, value: this.value };

    // Send data to backend
    this.sendDataToBackend(this.key).subscribe(response => {
      console.log("Response from backend:", response);
      // Handle response as needed
    }, error => {
      console.error("Error sending data to backend:", error);
      // Handle error as needed
    });
  }

 



  // inputs() {
  //   this.idd = prompt("Key ID : ");
  //   this.value = prompt("Key Value : ");
  //   this.key = { id: this.idd, value: this.value };
  //   console.log(this.idd);
  // }
  
  // saveKey(){
  //   this.service.addkeys(this.key).subscribe(data=>{
  //     console.log(data); 
  //   } 
  // //  error => { console.error("Error sending data to backend:", error);}
  //  )
  // }

 
  // inputs(){
  // this.id = prompt("Key ID : ")
  // this.value = prompt("Key Value : ")
  // }



 

}

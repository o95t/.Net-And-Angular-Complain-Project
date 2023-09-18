import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-complain',
  templateUrl: './complain.component.html',
  styleUrls: ['./complain.component.css']
})
export class ComplainComponent implements OnInit {

  url = "";

  constructor(public http: HttpClient, @Inject('BASE_URL') baseUrl: string,
    private router: Router) {
    this.url = baseUrl;
  }
  IsAdmin: boolean = true;
  selectedCar: string;
  status: string;
  complaint: any;

  ngOnInit() {
    this.populateList();
  }
populateList(){
  var reqHeader = new HttpHeaders({ 'Content-Type': 'application/json', 'No-Auth': 'True' });
    this.http.get(this.url + "api/complaint/Get", { headers: reqHeader }).subscribe((data: any) => {
      console.log(data);
      this.complaint = data;
      this.complaint.forEach(element => {

        switch (element.status) {
          case "1":
            element.statusName = "Pending"
            break;
          case "2":
            element.statusName = "Closed"
            break;
          case "3":
            element.statusName = "Rejected"
            break;
          default:
            break;
        }

      });
    },
      (err: HttpErrorResponse) => {
      });

}
  submit(statusId, complainId) {

    console.log(statusId + " * " + complainId);
    var data ="complainId=" + complainId + "&statusId=" + statusId
    var reqHeader = new HttpHeaders({ 'Content-Type': 'application/json','No-Auth':'True' });
    this.http.post(this.url + "api/complaint/update?" + data , { headers: reqHeader }).subscribe((data : any)=>{
    this.populateList();
    },
    (err : HttpErrorResponse)=>{
    });

  }
}

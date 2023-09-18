import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';


@Component({
  selector: 'app-complaint-entry',
  templateUrl: './complaint-entry.component.html',
})
export class ComplainEntryComponent implements OnInit {
  public currentCount = 0;
  url ="";

  complaint: FormGroup;
  
  //complaintobj : complaintobj;

  complaintobj: any= {}

  ngOnInit() {
    this.initForm()
  }
 constructor(public http: HttpClient, @Inject('BASE_URL') baseUrl: string,
      private router: Router){
  this.url = baseUrl;
 }

  initForm() {
    this.complaint = new FormGroup({
      subject: new FormControl(null, Validators.required),
      rate: new FormControl(null),
      mainProblem: new FormControl(null),
      describe: new FormControl(null,Validators.required)
    })
  }

  submit(){
    if (this.complaint.invalid) {
      alert("please fill mandatory fields")
      return;
    }

     
     this.complaintobj.subject = this.complaint.value.subject;
     this.complaintobj.rate = this.complaint.value.rate;
     this.complaintobj.mainProblem = this.complaint.value.mainProblem;
     this.complaintobj.description = this.complaint.value.describe;
    if (this.complaintobj.mainProblem != null)
     this.complaintobj.mainProblem = this.complaintobj.mainProblem.map(x=>x).join(",")

    var reqHeader = new HttpHeaders({ 'Content-Type': 'application/json','No-Auth':'True' });
    this.http.post(this.url + "api/complaint/add" , this.complaintobj, { headers: reqHeader }).subscribe((data : any)=>{
    this.router.navigate(['/complain']);
    },
    (err : HttpErrorResponse)=>{
    });

  
  }
}

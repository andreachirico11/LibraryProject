import { Component, OnInit } from "@angular/core";
import { AdminService } from "../admin.service";
import { Loan } from 'src/app/shared/models/loanModel';

@Component({
  selector: "app-admin-loans",
  templateUrl: "./adminLoans.component.html",
})
export class AdminLoansComponent implements OnInit {
  allLoans: Loan[] = [];
  constructor(private adminService: AdminService) {}

  ngOnInit() {
    this.adminService.allLoans.subscribe(
      loans => this.allLoans = [...loans]
    );
    this.adminService.getAllLoans().subscribe();
  }

}

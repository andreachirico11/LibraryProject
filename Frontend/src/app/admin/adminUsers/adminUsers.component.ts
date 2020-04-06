import { Component, OnInit, Output, EventEmitter } from "@angular/core";
import { AdminService } from "../admin.service";
import { User } from "src/app/shared/models/userModel";

@Component({
  selector: "app-adminUsers",
  templateUrl: "./adminUsers.component.html",
})
export class AdminUsersComponent implements OnInit {
  allUsers: User[] = [];
  @Output() userToEmit : User
  public detailActivated = false;
  constructor(private adminService: AdminService) {}

  ngOnInit() {
    this.adminService.allUsers.subscribe(
      (users) => (this.allUsers = [...users])
    );
    this.adminService.getAllUsers().subscribe();
  }

  openDetails(userId: number) {
    this.detailActivated === false ? this.detailActivated = true : null;

    const foundIndex = this.allUsers.findIndex(
      (user) => user.idUser === userId
    );
      this.userToEmit = this.allUsers[foundIndex];
  }
}

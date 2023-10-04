import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Item } from 'src/app/models/items.model';
import { ItemsService } from 'src/app/services/items.service';

@Component({
  selector: 'app-add-item',
  templateUrl: './add-item.component.html',
  styleUrls: ['./add-item.component.css']
})
export class AddItemComponent implements OnInit {

  addItemsResquest:Item={
    id:'',
    name:'',
    amount:'',
    quantity: 0,
    category:'',
    addedOn:''
  }
  constructor(private itemservice:ItemsService,private router:Router) { }

  ngOnInit(): void {
    this.itemservice.getAllItems(localStorage.getItem("token")?.toString())
    .subscribe((res:any) => {
      console.log("success");
    });
  }
  addItems(){
    this.itemservice.addItems(this.addItemsResquest,localStorage.getItem("token")?.toString())
    .subscribe({
      next:(item)=>{
        this.router.navigate(['items']);
      }
    })
  }
}

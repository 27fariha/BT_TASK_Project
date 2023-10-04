import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Item } from 'src/app/models/items.model';
import { ItemsService } from 'src/app/services/items.service';

@Component({
  selector: 'app-items-list',
  templateUrl: './items-list.component.html',
  styleUrls: ['./items-list.component.css']
})
export class ItemsListComponent implements OnInit {

  public items:Item[]=[];
  constructor(private route:ActivatedRoute,private itemservice:ItemsService,private router:Router) { }

  ngOnInit(): void {
this.itemservice.getAllItems(localStorage.getItem("token")?.toString())
.subscribe({
  next:(items)=>{
    this.items=items;
    console.log(items);
  },
  error:(response)=>{
    console.log(response);
  }
})
  }
deleteItem(id:string){
  this.itemservice.deleteItem(id,localStorage.getItem("token")?.toString())
  .subscribe({
    next:(response)=>{
      this.router.navigate(['items']);
      window.location.reload();
    }
  })
}
ngOnDestroy(){
  this.itemservice
}
}

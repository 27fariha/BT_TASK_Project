import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Route, Router } from '@angular/router';
import { Item } from 'src/app/models/items.model';
import { ItemsService } from 'src/app/services/items.service';

@Component({
  selector: 'app-update-item',
  templateUrl: './update-item.component.html',
  styleUrls: ['./update-item.component.css']
})
export class UpdateItemComponent implements OnInit {

  ItemDetails:Item={
    id:'',
    name:'',
    amount:'',
    quantity:0,
    category:'',
    addedOn:''
};

  constructor(private route:ActivatedRoute,private itemservice:ItemsService,private router:Router) { }

  ngOnInit(): void {
    this.route.paramMap.subscribe({
      next:(param)=>{
        const id=param.get('id');
        if(id){
          //call api
          this.itemservice.getitemview(id,localStorage.getItem("token")?.toString())
          .subscribe({
            next:(response)=>{
              console.log(response);
              this.ItemDetails=response;
              console.log("Details: ",this.ItemDetails);
            }
          })
        }
      }
    })
  }
  updateItems(){
    let id=this.ItemDetails.id;
    console.log(id)
      this.itemservice.updateItem(id,this.ItemDetails,localStorage.getItem("token")?.toString())
    .subscribe({
      next:(response)=>{
        this.router.navigate(['items']);
      }
    })
  }
}

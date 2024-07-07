import { Component, OnInit } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { BaseComponent, SpinnerType } from 'src/app/base/base.component';
import { Product } from 'src/app/contracts/product';
import { HttpClientService } from 'src/app/services/common/http-client.service';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.scss']
})
export class ProductsComponent extends BaseComponent implements OnInit {

constructor(spinner: NgxSpinnerService, private httpClientService: HttpClientService) {
  super(spinner);
  
}

  ngOnInit(): void {
    this.showSpinner(SpinnerType.Timer)
    
    this.httpClientService.get<Product[]>({
      controller : "products"
    }).subscribe(data => console.log(data));
    
    // this.httpClientService.post({
    //   controller  : "products"
    // }, {
    //   name : "Kitab",
    //   stock : 100,
    //   price : 13
    // }).subscribe();

  //  this.httpClientService.put({
  //     controller : "products"
  //  },{
  //       id: " e4cc67d0-06f1-4d7a-9fd0-d79595dae93c",
  //       Name : "Rengliasdqelem",
  //       Stock : 5,
  //       Price : 4000

  //  }).subscribe()

  // this.httpClientService.delete({
  //   controller : "products"
  // }, "e4cc67d0-06f1-4d7a-9fd0-d79595dae93c").subscribe();

  // this.httpClientService.get({
  //   baseUrl : "https://jsonplaceholder.typicode.com",
  //   controller : "posts"
  // }).subscribe(data => console.log(data));
  
  }

}

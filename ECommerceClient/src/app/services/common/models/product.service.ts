import { Injectable } from '@angular/core';
import { HttpClientService } from '../http-client.service';
import { Create_Product } from 'src/app/contracts/create-product';
import { HttpErrorResponse } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  constructor(private httpClientService : HttpClientService) {}

create(product : Create_Product, successCallBack? : any, errorCallBack? : any){
  this.httpClientService.post({
    controller: "products"
  }, product).subscribe(result=>{
    successCallBack();  
  }, (errorResponse : HttpErrorResponse) => {
  const _error : Array<{key: string, value: Array<string>}> = errorResponse.error;
  let message = "";
  _error.forEach((val, idx)=>{
    val.value.forEach((_val, _idx)=>{
      message += `${_val} <br>`
    })
  })
errorCallBack(message);
  });  
}
}

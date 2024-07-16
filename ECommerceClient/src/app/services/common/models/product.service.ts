import { Injectable } from '@angular/core';
import { HttpClientService } from '../http-client.service';
import { Create_Product } from 'src/app/contracts/create-product';
import { HttpErrorResponse } from '@angular/common/http';
import { ListProduct } from 'src/app/contracts/listProduct';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  constructor(private httpClientService : HttpClientService) {}

create(product : Create_Product, successCallBack? : () => void, errorCallBack? : (errorMessage : string) => void){
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

async read(successCallBack? : () => void, errorCallBack? : (errorMesage : string) => void) : Promise<ListProduct[]>{
  let promiseData : Promise<ListProduct[]> =  this.httpClientService.get<ListProduct[]>({
    controller: "products" 
  }).toPromise();

  promiseData.then(x => successCallBack())
  .catch((errorResponse: HttpErrorResponse) => errorCallBack(errorResponse.message));

  return await promiseData;
}
}

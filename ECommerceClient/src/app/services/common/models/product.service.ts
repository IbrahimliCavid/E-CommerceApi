import { Injectable } from '@angular/core';
import { HttpClientService } from '../http-client.service';
import { Create_Product } from 'src/app/contracts/create-product';
import { HttpErrorResponse } from '@angular/common/http';
import { ListProduct } from 'src/app/contracts/listProduct';
import { firstValueFrom, Observable } from 'rxjs';

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

async read(page: number = 0, size: number = 5, successCallBack? : () => void, errorCallBack? : (errorMesage : string) => void) : Promise<{totalCount : number, products : ListProduct[]}>{
  let promiseData : Promise<{totalCount : number, products : ListProduct[]}> =  this.httpClientService.get<{totalCount : number, products : ListProduct[]}>({
    controller: "products",
    queryString : `page=${page}&size=${size}`
  }).toPromise();

  promiseData.then(x => successCallBack())
  .catch((errorResponse: HttpErrorResponse) => errorCallBack(errorResponse.message));

  return await promiseData;
}

async delete(id:string){
  const deleteObservable : Observable<any> = this.httpClientService.delete<any>({
    controller : "Products"
  }, id);

  await firstValueFrom(deleteObservable);
}
}

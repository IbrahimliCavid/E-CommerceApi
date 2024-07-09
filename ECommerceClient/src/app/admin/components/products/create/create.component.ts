import { Component, OnInit } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { BaseComponent, SpinnerType } from 'src/app/base/base.component';
import { Create_Product } from 'src/app/contracts/create-product';
import { AlertifyService, MessageType, Position } from 'src/app/services/admin/alertify.service';
import { ProductService } from 'src/app/services/common/models/product.service';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.scss']
})
export class CreateComponent  extends BaseComponent implements OnInit{

  constructor(spinner: NgxSpinnerService, private  productService : ProductService, private alertify : AlertifyService) {
    super(spinner)
  }
  ngOnInit(): void {}
  create(name : HTMLInputElement, stock : HTMLInputElement, price : HTMLInputElement){
    this.showSpinner(SpinnerType.BallPlus)
      const product : Create_Product = new Create_Product();
      product.name = name.value,
      product.stock = parseInt(price.value),
      product.price = parseFloat(price.value)
      this.productService.create(product, () => {
        this.hideSpinner(SpinnerType.BallPlus);
        this.alertify.message(`${name.value} uğurla əlavə olundu.`, {
          messageType : MessageType.Success,
          dismissOthers : true,
          position : Position.TopLeft
        });
      }
        
       )
  }
}

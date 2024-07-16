import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { BaseComponent, SpinnerType } from 'src/app/base/base.component';
import { Create_Product } from 'src/app/contracts/create-product';
import {
  AlertifyService,
  MessageType,
  Position,
} from 'src/app/services/admin/alertify.service';
import { ProductService } from 'src/app/services/common/models/product.service';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.scss'],
})
export class CreateComponent extends BaseComponent implements OnInit {
  constructor(
    spinner: NgxSpinnerService,
    private productService: ProductService,
    private alertify: AlertifyService
  ) {
    super(spinner);
  }
  ngOnInit(): void {}

  @Output() createdProduct: EventEmitter<Create_Product> = new EventEmitter(); 

  create(
    name: HTMLInputElement,
    stock: HTMLInputElement,
    price: HTMLInputElement
  ) {
    this.showSpinner(SpinnerType.BallPlus);
    const product: Create_Product = new Create_Product();
    (product.name = name.value),
      (product.stock = parseInt(stock.value)),
      (product.price = parseFloat(price.value));

    if (!name.value) {
      this.alertify.message(`Ad boş ola bilməz.`, {
        messageType: MessageType.Error,
        dismissOthers: true,
        position: Position.TopLeft,
      });
      return;
    }

    if (parseInt(stock.value) < 0) {
      this.alertify.message('Daxil edilən say mənfi ola bilməz', {
        messageType: MessageType.Error,
        dismissOthers: true,
        position: Position.TopLeft,
      });
      return;
    }
    if (parseFloat(price.value) < 0) {
      this.alertify.message('Qiymət mənfi ola bilməz', {
        messageType: MessageType.Error,
        dismissOthers: true,
        position: Position.TopLeft,
      });
      return;
    }

    this.productService.create(
      product,
      () => {
        this.hideSpinner(SpinnerType.BallPlus);
        this.alertify.message(`${name.value} uğurla əlavə olundu.`, {
          messageType: MessageType.Success,
          dismissOthers: true,
          position: Position.TopLeft,
        });
        this.createdProduct.emit(Create_Product);
      },
      (errorMessage) => {
        this.alertify.message(errorMessage, {
          dismissOthers: true,
          messageType: MessageType.Error,
          position: Position.TopCenter,
        });
      }
    );
  }
}

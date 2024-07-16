import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { NgxSpinnerService } from 'ngx-spinner';
import { BaseComponent, SpinnerType } from 'src/app/base/base.component';
import { ListProduct } from 'src/app/contracts/listProduct';
import { AlertifyService, MessageType, Position } from 'src/app/services/admin/alertify.service';
import { ProductService } from 'src/app/services/common/models/product.service';


@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})
export class ListComponent extends BaseComponent implements OnInit{
constructor(spinner : NgxSpinnerService,private productService: ProductService, private alertifyService : AlertifyService){
  super(spinner);
}

displayedColumns: string[] = ['Id', 'Name', 'Price', 'Stock', 'CreatedDate', 'UpdatedDate'];
dataSource : MatTableDataSource<ListProduct> = null;


ngOnInit(): void {
  this.showSpinner(SpinnerType.LineSpinFade)
 this.productService.read(()=> this.hideSpinner(SpinnerType.LineSpinFade), errorMessage =>
  this.alertifyService.message(errorMessage, {
    messageType : MessageType.Error,
    position: Position.TopLeft
  }))
}

}

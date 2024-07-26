import { HttpErrorResponse } from '@angular/common/http';
import { Directive, ElementRef, EventEmitter, HostListener, Input, Output, Renderer2 } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { NgxSpinnerService } from 'ngx-spinner';
import { SpinnerType } from 'src/app/base/base.component';
import { DeleteDialogComponent, DeleteState } from 'src/app/dialogs/delete-dialog/delete-dialog.component';
import { AlertifyService, MessageType, Position } from 'src/app/services/admin/alertify.service';
import { HttpClientService } from 'src/app/services/common/http-client.service';
declare var $ : any;
@Directive({
  selector: '[appDelete]'
})
export class DeleteDirective {

  constructor(private element: ElementRef,
    private _renderer: Renderer2,
   private httpClientService: HttpClientService,
    private spinner : NgxSpinnerService,
    public dialog : MatDialog,
    private alertifyService: AlertifyService
  ) {
      const img = _renderer.createElement("img");
      img.setAttribute("src", "assets/Images/DeletIcon.png");
      img.setAttribute("style", "cursor: pointer");
      img.setAttribute("alt", "Delete image");
      img.width = 22;

      _renderer.appendChild(element.nativeElement, img)
    }
 
    @Input() id : string;
    @Input() controller : string;
    @Output() callBack : EventEmitter<any> = new EventEmitter();

    @HostListener("click")
   async onClick(){
    this.openDialog(async() => {
      this.spinner.show(SpinnerType.LineSpinFade);
      const td :HTMLTableCellElement = this.element.nativeElement;
      await this.httpClientService.delete({
        controller: this.controller
      }, this.id).subscribe(data => {
        $(td.parentElement).fadeOut(700, ()=>{
          this.callBack.emit();
          this.alertifyService.message("Uğurla silindi",{
            dismissOthers : true,
            messageType: MessageType.Success,
            position : Position.TopRight
          })
        })
      }, (errorResponse : HttpErrorResponse)=>{
        this.alertifyService.message("Silinmə uğursuz oldu!",{
          dismissOthers : true,
          messageType: MessageType.Error,
          position : Position.TopLeft
        })
        this.spinner.hide(SpinnerType.LineSpinFade)
      })
    });
 
     
    }

    openDialog(afterClosed : any): void {
      const dialogRef = this.dialog.open(DeleteDialogComponent, {
        data: DeleteState.Yes,
      });
  
      dialogRef.afterClosed().subscribe(result => {
        if(result == DeleteState.Yes){
           afterClosed();
        }
      });
    }

}

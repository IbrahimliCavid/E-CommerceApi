import { Directive, ElementRef, Renderer2 } from '@angular/core';
import { HttpClientService } from 'src/app/services/common/http-client.service';

@Directive({
  selector: '[appDelete]'
})
export class DeleteDirective {

  constructor(private element: ElementRef,
    private _renderer: Renderer2,
    private httpClientService : HttpClientService
  ) {
      const img = _renderer.createElement("img");
      img.setAttribute({
        "src" : "../../../../../assets/Images/DeletIcon.png",
        "style" : "cursor : pointer",
        "alt" : "Delete image",
        "width" : "22px"
      })

      _renderer.appendChild(element.nativeElement, img)
    }

}

import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'sliceString'
})
export class SliceStringPipe implements PipeTransform {

  transform(value:string, ...args:any[]): unknown {
  
    let numeroPalabras = (args[0]) ? parseInt(args[0]) : 50;
    let iconoFinal = (args[1]) ? String(args[1]) : '...';
    let arr = value.split(" ");
    arr = arr.slice(0, numeroPalabras);
    let result = arr.join(" ") + iconoFinal;
    return result;
 
  }

}

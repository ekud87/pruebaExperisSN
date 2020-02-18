import {Pipe,PipeTransform} from '@angular/core'

@Pipe({name:'filter',pure:false})
export class CalculateModulePipe implements PipeTransform{
    transform(items:Array<any>, type:string){
        if (!items || !type)
            return items

        return items.filter(item=>{
            return type=='par'? item.id%2==0?true:false:item.id%2!=0?true:false;
        })
    }
}
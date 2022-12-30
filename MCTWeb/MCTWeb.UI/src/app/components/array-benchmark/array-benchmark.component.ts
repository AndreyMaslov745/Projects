import { Component, EventEmitter, Input, Output } from '@angular/core';
import { SortModel } from 'src/app/models/SortModel';
import { ArrayBenchmarkService } from 'src/app/services/array-benchmark.service';


@Component({
  selector: 'app-array-benchmark',
  templateUrl: './array-benchmark.component.html',
  styleUrls: ['./array-benchmark.component.css'],
  providers: []
})
export class ArrayBenchmarkComponent{
  @Output() benchMarkUpdated = new EventEmitter<SortModel>();

  public arrayLength !: number
  public benchmark : SortModel = new SortModel('','');
  private benchmarkService : ArrayBenchmarkService;

  constructor(private  arrayBenchmarkService : ArrayBenchmarkService){
    this.benchmarkService = arrayBenchmarkService;
  }
  
  getBenchmark(length : number){
    this.benchmarkService.getBenchmark(length)
    .subscribe((newbenchmark : SortModel) => {this.benchmark.sortName = newbenchmark.sortName
    this.benchmark.sortingTime = newbenchmark.sortingTime;});
  }
  updateBenchmark(newBechmark : SortModel){
    this.benchmark = newBechmark;
  }

}
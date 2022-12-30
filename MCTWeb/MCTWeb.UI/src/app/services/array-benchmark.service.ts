import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs/internal/Observable";
import { SortModel } from "../models/SortModel" ;

@Injectable({
    providedIn : 'root'
})

export class ArrayBenchmarkService{
    url : string = "https://localhost:7005/generate-array?lenght=";
    client : HttpClient;
    constructor(private http : HttpClient)
    {
        this.client = http
    }

    public getBenchmark(length : number) : Observable<SortModel>{
        
        return this.client.get<SortModel>(this.url + length);
    }
}
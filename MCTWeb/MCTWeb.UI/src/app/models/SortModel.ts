
export class SortModel{

    public sortName : string;
    public sortingTime: string;
    constructor(public name : string, public time: string)
    {
        this.sortName = name;
        this.sortingTime = time;
    }
}
import { IBank } from "src/models/bank";

export interface IPagination {
    pageIndex: number;
    pageSize: number;
    count: number;
    data: IBank[];
}
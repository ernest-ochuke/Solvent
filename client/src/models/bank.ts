import { ICardProduct } from "./cardproduct";

export interface IBank {
    id: number;
    name: string;
    uniqueIdentityNumber: string;
    imageUrl: string;
    cardProducts: ICardProduct[];
  
}
import { Category } from "./category.interface";

export interface Post {
  id:number;
  title:string;
  text:string;
  author:string;
  img:string;
  date:string;
  category:Category;
}
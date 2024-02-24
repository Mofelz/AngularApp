export interface Fio{
  id: number;
  surname: string;
  name: string;
  patronomic?: string;
  number: number;
}
export interface Company{
  id?: number;
  nameCompany: string;
  addresCompany: string;
}
export interface User{
  id?: number;
  active?: boolean;
  name: string;
  password: string;
  role: string;
}

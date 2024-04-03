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
  login: string;
  password: string;
  name: string;
  surname: string;
  patronomic?: string;
  birthday: Date;
  mail: string;
  phoneNumber: string;
}


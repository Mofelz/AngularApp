export interface UserRegistrationDto{
  login: string;
  password: string;
  name: string;
  surname: string;
  patronymic?: string;
  birthday: Date;
  mail: string;
  phoneNumber: string;
  agreementAccept: boolean;
}
export interface UserLoginDto{
  mail: string;
  password: string;
}

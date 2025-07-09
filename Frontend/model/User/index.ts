export interface UserLogin {
    Email: string;
    Password: string;
}

export interface userToken{
    token:string;
}

export interface userCreate{
    UserFullName:string;
    UserPreferName:string;
    UserEmail:string;
    PasswordHash:string;
    UserPhone:string;
}

export interface userData{
    Userid:number;
    UserFullName:string;
    UserPreferName:string;
    UserEmail:string;
    UserPhone:string;
}

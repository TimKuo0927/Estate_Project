export interface UserLogin {
    Email: string;
    Password: string;
}

export interface userData{
    token:string;
}

export interface userCreate{
    UserFullName:string;
    UserPreferName:string;
    UserEmail:string;
    PasswordHash:string;
    UserPhone:string;
}
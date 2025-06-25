import axios from 'axios';
import { UserLogin, userData } from '../../../model/User/index';

export class UserApi {
  private baseUrl: string;

  constructor(baseUrl: string) {
    this.baseUrl = baseUrl + '/User';
  }

  async login(userData: UserLogin): Promise<userData> {
    const res = await axios.post(`${this.baseUrl}/login`, userData);
    return res.data;
  }

  async GetUserData(): Promise<string> {
    var config = {
      headers: {
        Authorization: 'Bearer ' + localStorage.getItem('token'),
      },
    };
    console.log('Authorization Header:', 'Bearer ' + localStorage.getItem('token'));
    const res = await axios.get(`${this.baseUrl}/userData`, config);
    return res.data;
  }
}

import axios from 'axios';
import { UserLogin } from '../../../model/User/index';

export class UserApi {
  private baseUrl: string;

  constructor(baseUrl: string) {
    this.baseUrl = baseUrl + '/User';
  }

  async login(userData: UserLogin): Promise<string> {
    const res = await axios.post(`${this.baseUrl}/login`, userData);
    return res.data;
  }
}

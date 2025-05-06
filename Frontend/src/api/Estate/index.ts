import axios from 'axios';

export class EstateApi {
  private baseUrl: string;

  constructor(baseUrl: string) {
    this.baseUrl = baseUrl + '/Estate';
  }

  async getHomepageImgs(): Promise<string[]> {
    const res = await axios.get(`${this.baseUrl}/getHomepageImgs`);
    return res.data;
  }

  // Add more estate-related methods here
}

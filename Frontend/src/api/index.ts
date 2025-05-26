import { EstateApi } from './Estate';
import { UserApi } from './User';

const baseUrl = import.meta.env.VITE_API_BASE_URL;

class BackendConnector {
  estate: EstateApi;
  user: UserApi;
  constructor(baseUrl: string) {
    this.estate = new EstateApi(baseUrl);
    this.user = new UserApi(baseUrl);
  }
}

const backendConnector = new BackendConnector(baseUrl);
export default backendConnector;

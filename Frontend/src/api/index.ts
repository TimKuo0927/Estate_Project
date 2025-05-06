import { EstateApi } from './Estate';

const baseUrl = import.meta.env.VITE_API_BASE_URL;

class BackendConnector {
  estate: EstateApi;

  constructor(baseUrl: string) {
    this.estate = new EstateApi(baseUrl);
  }
}

const backendConnector = new BackendConnector(baseUrl);
export default backendConnector;

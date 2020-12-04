import axios from 'axios'

const api = axios.create({
  baseURL: 'http://localhost:5000',
});

export async function postData(data) {
  return await api.post('v1/titulos', data);
}

export async function getData() {
 return await api.get('v1/titulos');
}

export async function getDataById(id) {
  return await api.get(`v1/titulos/${id}`);
}

export default api;

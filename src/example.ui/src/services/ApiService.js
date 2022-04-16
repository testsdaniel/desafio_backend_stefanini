
import axios from 'axios'

const axiosInstance = axios.create({
    baseURL: 'http://localhost:50441/api',
    timeout: 1000,
    headers: {}
});

class ApiService {
    getById(endpoint, id){
        axiosInstance.get(`${endpoint}/${id}`).then((response) => {
            console.log(response)
        })
    }
    getAll(endpoint){
        axiosInstance.get(endpoint).then((response) => {
            console.log(response)
        })
    }
    create(endpoint, request){
        axiosInstance.post(endpoint, request).then((response) => {
            console.log(response)
        })
    }
    update(endpoint, request){
        axiosInstance.put(endpoint, request).then((response) => {
            console.log(response)
        })
    }
    delete(endpoint, request){
        axiosInstance.delete(endpoint, request).then((response) => {
            console.log(response)
        })
    }
}

export default new ApiService();
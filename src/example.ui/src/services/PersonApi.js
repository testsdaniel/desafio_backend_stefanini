
import axios from 'axios'

const axiosInstance = axios.create({
    baseURL: 'http://localhost:50441/api',
    timeout: 1000,
    headers: {
        'Content-Type': 'application/json',
        'Accept': 'application/json'
    }
});

export default {
    getById(id, cbSuccess) {
        return axiosInstance.get(`/Person/${id}`)
            .catch(err => console.log(err))
            .then(response => { if (response) cbSuccess(response.data) })
    },
    getAll(cbSuccess) {
        return axiosInstance.get('/Person')
            .catch(err => console.log(err))
            .then(response => { if (response) cbSuccess(response.data.list) })
    },
    create(request, cbSuccess, cbError) {
        request.cpf = request.cpf.replace(/\D/g, "")
        return axiosInstance.post('/Person', request)
            .then(response => { if (response) cbSuccess(response.data.id) })
            .catch(err => { 
                if(err.response && err.response.status === 400) {
                    cbError(err.response.data.errors) 
                } else
                    console.log(err)
            })
    },
    update(request, cbSuccess, cbError) {
        return axiosInstance.put('/Person', request)
            .then(response => { if (response) cbSuccess() })
            .catch(err => { 
                if(err.response && err.response.status === 400) {
                    cbError(err.response.data.errors) 
                } else
                    console.log(err)
            })
    },
    delete(id, cbSuccess) {
        return axiosInstance.delete('/Person', { data: { id } })
            .catch(err => console.log(err))
            .then(response => { if (response) cbSuccess() })
    }
};
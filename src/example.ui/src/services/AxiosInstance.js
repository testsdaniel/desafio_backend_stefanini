import axios from 'axios'

export default axios.create({
    baseURL: 'http://localhost:62411/api',
    timeout: 1000,
    headers: {
        'Content-Type': 'application/json',
        'Accept': 'application/json'
    }
});
import axios from 'axios';

export const login = axios.create({
    baseURL: "http://localhost:8881/api/",
    headers: {'Content-Type': 'application/json'}
})
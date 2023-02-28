import axios from "axios";

export default class FetchHelper{
    baseUrl = "http://localhost:8881/api/";
    
    http;
    constructor(param){
        this.http= axios.create({
            baseURL: this.baseUrl,
            headers: {'Authorization':"Bearer" + param}
        })
    };

    async getAllUsers(){
        const response = await this.http.get("users");
        return response;
    };
}
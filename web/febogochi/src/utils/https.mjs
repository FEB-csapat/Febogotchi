import axios from "axios";

export class FetchHelper{
    static baseUrl = "http://localhost:8881/api/";
    
    static http;

    static initialize(param){
        FetchHelper.http = axios.create({
            baseURL: this.baseUrl,
            headers: {'Authorization':"Bearer" + param}
        })
    }

    static async getAllUsers(){
        const response = await FetchHelper.http.get("users");
        return response.data;
    };
}
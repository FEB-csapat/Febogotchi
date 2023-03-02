import axios from "axios";

export class FetchHelper{
    static baseUrl = "http://localhost:8881/api/";
    
    static http;

    static initialize(param){
        FetchHelper.http = axios.create({
            baseURL: this.baseUrl,
            headers: {'Authorization':"Bearer " + param}
        })
    }

    static getAllUsers(){
        const response = FetchHelper.http.get("users");
        return response;
    };

    static getMyPets(){
        const response = FetchHelper.http.get("/me/pets");
        return response;
    };
    
    static MyPetDoAction(petid, act){
        const jstring = '{"action": \"'+act+'\"}';
        const jsobject =  JSON.parse(jstring);
        const response = FetchHelper.http.put("/me/pets/"+petid+"/action",jsobject);
        return response;
    };
}
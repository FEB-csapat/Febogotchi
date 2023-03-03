import axios from "axios";
import router from "../router";

export class FetchHelper{
    static baseUrl = "http://localhost:8881/api/";
    
    static http;

    static initialize(param){
        FetchHelper.http = axios.create({
            baseURL: this.baseUrl,
            headers: {
                'Authorization':"Bearer " + param,
                'Content-Type': 'application/json'
            }
        })
    }

    static getAllUsers(){
        const response = FetchHelper.http.get("users");
        return response;
    };

    static getAllPetTypes(){
        const respone = FetchHelper.http.get("pet_types");
        return respone;
    }

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

    static createPet(jsondata){
        const response = FetchHelper.http.post('me/pets',jsondata)
        .then(response=> sessionStorage.setItem('mypet',JSON.stringify(response.data)))
        .then(alert("Sikeres létrehozás!"))
        .catch(error=>alert(error));
    }
}
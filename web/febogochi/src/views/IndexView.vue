<template>
<div class="container bg-secondary rounded-2 bg-opacity-50">
        <div class="row mb-5 mt-2 pt-2">
            <div class="col-3">
                <button class="btn btn-primary w-100"><router-link class="nav-link active" aria-current="page" to="/feed">Etet</router-link></button>
            </div>

            <div class="col-3">
                <button class="btn btn-primary w-100"><router-link class="nav-link active" aria-current="page" to="/play">Játszik</router-link></button>
            </div>

            <div class="col-3">
                <input type="button" class="btn btn-primary w-100" value="Alszik">
            </div>

            <div class="col-3">
                <input type="button" class="btn btn-primary w-100" value="Vadászik">
            </div>
        </div>
        <div class="row mb-2">
            <div class="col-6">
                    <img src="https://via.placeholder.com/150" class="w-100">
            </div>
            <div class="col-6">
                <p>
                    Név: {{valasz.name}}
                </p>
                <p>
                    Típus: {{ valasz.type }}
                </p>
                <p>
                    Kor: {{ valasz.birth_date }}
                </p>
                <p>
                    Tápláltság: {{valasz.sate}}/5
                </p>
                <p>
                    Egészség: {{  valasz.wellbeing}}/5
                </p>
                <p>
                    Energia: {{valasz.energy}}/5
                </p>
                <p>
                    Játékosság: {{ valasz.happiness }}/5
                </p>
                <p>
                    Vadászat: {{valasz.fittness}}/5
                </p>
            </div>
        </div>
        <div class="row pb-2">
            <div class="col-9">

            </div>
            <div class="col-3">
                <input type="button" class="btn btn-danger w-100" value="Kijelentkezés" @click="showData()">
            </div>
        </div>
    </div>
</template>

<script>
import { FetchHelper } from '../utils/https.mjs';
export default{
    name: "IndexView",
    data(){
        return{
            valasz: [],
            token:"",
            eletkor:0
        }      
    },
    methods:{
        showData(){
            console.log(this.valasz);
        },
        Hunt(){

        }
    },
    async mounted(){
        if(sessionStorage.getItem('mypet')===null)
        {
        this.token = sessionStorage.getItem('token');
        FetchHelper.initialize(this.token);
        this.valasz = (await FetchHelper.getMyPets()).data[0];
        console.log(this.valasz);
        sessionStorage.setItem('mypet',JSON.stringify(this.valasz));
        }
        else
        {            
            this.valasz = JSON.parse(sessionStorage.getItem('mypet'));
        }
    }
}
</script>

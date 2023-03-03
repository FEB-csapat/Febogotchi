<template>
<div class="container bg-secondary rounded-2 bg-opacity-50">
        <div class="row mb-5 mt-2 pt-2">
            <div class="col-3">
                <h1>Etetés</h1>
            </div>
        </div>
        <div class="row mb-2 bg-secondary">
            <table class="table table-striped">
                <tr v-for="item in foods">
                    <td class="fs-6">{{item}}</td>
                    <td><span class="badge btn bg-success fs-6 mt-2" @click="Eat()">Etetés</span></td>
                </tr>
            </table>  
        </div>
        <div class="row">
            <h2 class="text-center">
                Tápláltság: {{resp.energy}}/5
            </h2>
        </div>
        <div class="row pb-2">
            <div class="col-9">

            </div>
            <div class="col-3">
                <button class="btn btn-primary w-100"><router-link class="nav-link active" aria-current="page" to="/">Vissza a főoldalra</router-link></button>
            </div>
        </div>
    </div>
</template>
<script>
import { FetchHelper } from '../utils/https.mjs';
export default{
    data(){
        return{
            token:"",
            foods: ["Csirke","Csont"],
            resp: []
        }
    },
    methods:{
        async Eat(){
            this.resp = (await FetchHelper.MyPetDoAction(this.resp.id,"eat")).data;
            alert("Sikeres etetés!");
        }
    },
    async mounted(){
        this.token = sessionStorage.getItem('token');
        FetchHelper.initialize(this.token);
        this.resp = (await FetchHelper.getMyPets()).data[0];
    },
    name: "FeedView"
}
</script>
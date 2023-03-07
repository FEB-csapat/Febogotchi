<template>
<div class="container bg-secondary rounded-2 bg-opacity-50">
        <div class="row mb-5 mt-2 pt-2">
            <div class="col-3">
                <h1>Játszás</h1>
            </div>
        </div>
        <div class="row mb-2 bg-secondary">
            <table class="table table-striped">
                <tr v-for="item in actions">
                    <td class="fs-4">{{item}}</td>
                    <td><span class="badge btn bg-success fs-6 mt-2" @click="Play">Játék</span></td>
                </tr>
            </table>
        </div>
        <div class="row">
            <h2 class="text-center">
                Játékosság: {{resp.happiness}}
            </h2>
        </div>
        <div class="row pb-2">
            <div class="col-3">
                <button class="btn btn-primary w-100"><router-link class="nav-link active" aria-current="page" to="/index">Vissza a főoldalra</router-link></button>
            </div>
        </div>
    </div>
</template>

<script>
import { FetchHelper } from '../utils/https.mjs';
import { RouterLink } from 'vue-router';

export default{
    data(){
        return{
            token:"",
            actions: ["idle","hunt","play","cure","eat","sleep"],
            resp:[]
        }
    },
    methods:{
        async Play(){
            this.resp = (await FetchHelper.MyPetDoAction(this.resp.id,"play")).data;
            sessionStorage.setItem('mypet',JSON.stringify(this.resp));
            alert("Sikeres játék!");
        }
    },
    mounted(){
        this.token = sessionStorage.getItem('token');
        FetchHelper.initialize(this.token);
        this.resp = JSON.parse(sessionStorage.getItem('mypet'));
    },
    components:{
        RouterLink
    },
    name: "PlayView"
}
</script>
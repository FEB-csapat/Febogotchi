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
                <p class="text-end">
                    Felhasználó: Admin
                </p>
                <p>
                    Név: Blöki
                </p>
                <p>
                    Típus: kutya
                </p>
                <p>
                    Kor: 67 nap
                </p>
                <p>
                    Tápláltság: 76/100
                </p>
                <p>
                    Egészség: 84/100
                </p>
                <p>
                    Energia: 55/100
                </p>
                <p>
                    Játékosság: 99/100
                </p>
                <p>
                    Vadászat: 12/100
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
            valasz: []
        }      
    },
    methods:{
        async getData(){
            FetchHelper.initialize("asd");
            this.valasz = (await FetchHelper.getAllUsers()).data;
            console.log(this.valasz[0].name);
        },
        showData(){
            console.log(this.valasz);
        }
    },
    mounted(){
        this.getData();
    }
}
</script>

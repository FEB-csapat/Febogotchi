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
                <input type="button" class="btn btn-primary w-100" value="Alszik" @click="Sleep">
            </div>

            <div class="col-3">
                <input type="button" class="btn btn-primary w-100" value="Vadászik" @click="Hunt">
            </div>
        </div>
        <div class="row mb-2">
            <div class="col-6">
                    <img src="https://via.placeholder.com/150" class="w-100">
            </div>
            <div class="col-6">
                <p>
                    Név: {{resp.name}}
                </p>
                <p>
                    Típus: {{ resp.type }}
                </p>
                <p>
                    Kor: {{ resp.birth_date }}
                </p>
                <p>
                    Tápláltság: {{resp.sate}}/5
                </p>
                <p>
                    Egészség: {{  resp.wellbeing}}/5
                </p>
                <p>
                    Energia: {{resp.energy}}/5
                </p>
                <p>
                    Játékosság: {{ resp.happiness }}/5
                </p>
                <p>
                    Vadászat: {{resp.fittness}}/5
                </p>
                <p>
                    Jelenlegi állapot: {{ resp.status }}
                </p>
                <p>
                    Időtartam: {{ resp.status }}
                </p>    
            </div>
        </div>
        <div class="row pb-2">
            <div class="col-9">

            </div>
            <div class="col-3">
                <input type="button" class="btn btn-danger w-100" value="Kijelentkezés" @click="logOut">
            </div>
        </div>
    </div>
</template>

<script>
import router from '../router';
import { FetchHelper } from '../utils/https.mjs';

export default{
    name: "IndexView",
    data(){
        return{
            resp: [],
            token:"",
            eletkor:0
        }      
    },
    methods:{
        showData(){
            console.log(this.resp);
        },
        async Hunt(){
            this.resp = (await FetchHelper.MyPetDoAction(this.resp.id,"hunt")).data;
            sessionStorage.setItem('mypet',JSON.stringify(this.resp));
            alert("Sikeres vadászat!");
        },
        async Sleep(){
            this.resp = (await FetchHelper.MyPetDoAction(this.resp.id,"sleep")).data;
            sessionStorage.setItem('mypet',JSON.stringify(this.resp));
            alert("Sikeres alvás!");
        },
        logOut(){
            router.push('/login');
            sessionStorage.clear();
        }
    },
    async mounted(){
        this.token = sessionStorage.getItem('token');
        FetchHelper.initialize(this.token);
        if(sessionStorage.getItem('mypet')===null)
        {
        this.resp = (await FetchHelper.getMyPets()).data[0];
        console.log(this.resp);
        sessionStorage.setItem('mypet',JSON.stringify(this.resp));
        }
        else
        {            
            this.resp = JSON.parse(sessionStorage.getItem('mypet'));
        }
    }
}
</script>

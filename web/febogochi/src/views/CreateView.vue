<template>
<div class="container">
    <div class="row">
        <form>
            <div class="mb-3">
                <label for="petname" class="form-label">Mi legyen az állat neve?</label>
                <input type="text" id="petname" v-model="petname" class="from-control">
            </div>
            <div class="mb-3">
                <label for="pettype" class="form-label">Mi legyen az állat típusa?</label>
                <select id="pettype" v-model="selectedtype" class="from-select">
                    <option value=""> --Válassz egy típust!-- </option>
                    <option v-for="(type, index) in avibtypes" :key="index" :value="type.id" >{{type.type}}</option>
                </select>
            </div>
            <button class="btn btn-success form-control" @click.prevent="create()">Állat létrehozása</button>
        </form>

    </div>
</div>
</template>
<script>
import { login } from '../utils/login.mjs';
import { FetchHelper } from '../utils/https.mjs';
export default{
    data(){
        return{
            petname:"",
            selectedtype:0,
            avibtypes:[],
            token:""
        }
    },
    methods:{
        create(){
            const jsonData = JSON.stringify(this.petData);
            FetchHelper.createPet(jsonData);
        }
    },
    async mounted(){
        this.token = sessionStorage.getItem('token');
        FetchHelper.initialize(this.token);
        this.avibtypes = (await FetchHelper.getAllPetTypes()).data;
    },
    computed:{
        petData(){
            return{
                name:this.petname,
                pet_type_id: this.selectedtype
            }
        }
    },
    name:"CreateView",
}

</script>
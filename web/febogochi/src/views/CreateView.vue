<template>
<div class="container bg-secondary rounded-2 bg-opacity-50 p-3 m-4">
    <div class="row">
        <form>
            <div class="mb-3">
                <label for="petname_textbox" class="form-label">Mi legyen az állat neve?</label>
                <input id="petname_textbox" type="text" v-model="petname" class="from-control">
            </div>
            <div class="mb-3">
                <label for="pettype" class="form-label">Mi legyen az állat típusa?</label>
                <select id="option_selector" v-model="selectedtype">
                    <img src="../images/cat_1.png" class="w-100" style="image-rendering: pixelated;">
                    <option id="cat_1_option" value='1'  style="background-image:url('../images/cat_1.png');" >Macska 1</option>
                    <option id="cat_2_option" value='2' style="background-image:url('../images/cat_2.png');">Macska 2</option>
                    <option id="dog_1_option" value='3' style="background-image:url('../images/dog_1.png');">Kutya 1</option>
                    <option id="dog_2_option" value='4' style="background-image:url('../images/dog_2.png');">Kutya 2</option>
                </select> 

                <img src="{{this.selectedtype}}.png" alt="">
            </div>
            <button id="create_button" class="btn btn-success form-control" @click.prevent="create()">Állat létrehozása</button>
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
            selectedtype:"",
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
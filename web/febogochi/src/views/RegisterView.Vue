<template>
<div class="container">
    <div class="row w-75 bg-secondary m-auto">
        <form>
  <div class="mb-3">
    <label for="username" class="form-label">Felhasználónév</label>
    <input type="text" class="form-control" v-model="username">
  </div>
  <div class="mb-3">
    <label for="password" class="form-label">Jelszó</label>
    <input type="password" class="form-control" v-model="password">
  </div>
  <div class="mb-3">
    <label for="passwordconfirmation" class="form-label">Jelszó újra</label>
    <input type="password" class="form-control" v-model="passwordagain">
    <div id="AccountHelp" class="form-text">Soha ne ossza meg bejelentkezési adatait senkivel!</div>
  </div>
  <button type="submit" class="btn btn-primary mb-3" @click="SendData()"><router-link class="nav-link active" aria-current="page" to="/login">Regisztráció</router-link></button>
</form>
    </div>
</div>
</template>

<script>
import { RouterLink } from 'vue-router';
import {login} from "../utils/login.mjs";
export default{
  data(){
    return{
      username:"",
      password:"",
      passwordagain:"",
      usertoken: ""
    }
  },
  methods:{
    Listdata(){
      console.log(this.loginData);
    },
    Showtoken(){
      console.log(this.usertoken);
    },
    SendData(){
      const jsonData = JSON.stringify(this.loginData)      
       login.post("register",jsonData)
       .then(response=>alert("Sikeres regisztráció! Kérlek, jelentkezz be."))
       .catch(error => alert(error));
    }
  },
  components:{
    RouterLink
  },
  computed:{
    loginData(){
      return{
        name: this.username,
        password: this.password
      }
    }
  },
    name: "RegisterView"
}
</script>
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
  <button type="submit" class="btn btn-primary mb-3" @click.prevent="CheckData()"><router-link class="nav-link active" aria-current="page" to="/login">Regisztráció</router-link></button>
</form>
    </div>
</div>
</template>

<script>
import { RouterLink } from 'vue-router';
import {login} from "../utils/login.mjs";
import router from '../router';
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
    CheckData(){
      if(this.password === this.passwordagain){
        this.SendData();
      }
      else
      {
        alert("A két jelszó nem egyezik meg!");
        this.password = null;
        this.passwordagain=null;
      }
    },
    SendData(){
      const jsonData = JSON.stringify(this.loginData)      
       login.post("register",jsonData)
       .then(()=>{if(confirm("Sikeres regisztráció, kérlek jelentkezz be")){router.push("/login")}})
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
  }
}
</script>
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
    <div id="AccountHelp" class="form-text">Soha ne ossza meg bejelentkezési adatait senkivel!</div>
  </div>
  <div>
  <button type="submit" class="btn btn-primary mb-3" @click="Login">bejelentkezés</button>
  <button class="btn btn-primary mb-3 float-end"><router-link class="nav-link active" aria-current="page" to="/register">Regisztráció</router-link></button>

  </div>
</form>
    </div>
</div>
</template>

<script>
import { RouterLink } from 'vue-router';
import { login } from '../utils/login.mjs';
import router from '@/router';
export default{
  data(){
    return{
      username:"",
      password:""
    }
  },
  methods:{
    Listdata(){
      console.log(this.username + " " + this.password);
    },
    Login(){
      const jsonData = JSON.stringify(this.loginData);
      login.post('login',jsonData)
      .then(response=>localStorage.setItem('token',response.data.token))
      .catch(error=> alert(error));
      router.push("/");
    }
  },
  computed:{
    loginData(){
      return{
        name: this.username,
        password: this.password
      }
    }
  },
  components:{
    RouterLink
  },
    name: "LoginView"
}
</script>
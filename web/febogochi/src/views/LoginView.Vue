<template>
<div class="container bg-secondary rounded-2 bg-opacity-50 p-3 m-4">
    <div class="row">
        <form>
          <div class="mb-3">
            <label for="username" class="form-label">Felhasználónév</label>
            <input id="username_textbox" type="text" class="form-control" v-model="username">
          </div>
          <div class="mb-3">
            <label for="password" class="form-label">Jelszó</label>
            <input id="password_textbox" type="password" class="form-control" v-model="password">
            <div id="AccountHelp" class="form-text">Soha ne ossza meg bejelentkezési adatait senkivel!</div>
          </div>
          <div>
            <button  id="submit_button" type="submit" class="btn btn-primary mb-3" @click.prevent="Login">bejelentkezés</button>
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
import { FetchHelper } from '../utils/https.mjs';
export default{
  data(){
    return{
      username:"",
      password:""
    }
  },
  methods:{
    Login(){
      const jsonData = JSON.stringify(this.loginData);
      login.post('login',jsonData)
      .then(response=>{
        sessionStorage.setItem('token',response.data.token);
        FetchHelper.initialize(response.data.token);
        return FetchHelper.getMyPets();
      })
      .then(response=>{
        if(response.data.length===0){
          router.push('/create');
        }
        else
        {
          sessionStorage.setItem('mypet',JSON.stringify(response.data[0]));
          router.push('/index');
        }
      })
      .catch(error=> alert(error.response.data.message));
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
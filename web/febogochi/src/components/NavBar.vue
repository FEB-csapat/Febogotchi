<template>
    <nav class="navbar navbar-expand-lg bg-body-tertiary bg-success rounded-bottom mb-3">
        <div class="container-fluid">
          <router-link class="navbar-brand" to="/"><h3>Repülőgép járatok</h3></router-link>
          <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
            <span class="navbar-toggler-icon"></span>
          </button>
          <div class="collapse navbar-collapse" id="navbarSupportedContent">
            <ul class="navbar-nav me-auto mb-2 mb-lg-0">
              <li class="nav-item">
                <router-link class="nav-link active" aria-current="page" to="/">Kezdőlap</router-link>
              </li>
              <li class="nav-item">
                <router-link class="nav-link" to="/">Összegzés</router-link>
              </li>
            </ul>
          </div>
        </div>
      </nav>
</template>
<script>
import { RouterLink } from 'vue-router';

export default{
    name:"NavBar",
    components:{
        RouterLink
    }
    }
</script>
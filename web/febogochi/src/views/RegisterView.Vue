<template>
<div class="container">
    <div class="row w-75 bg-secondary m-auto">
        <form>
  <div class="mb-3">
    <label for="username" class="form-label">Felhasználónév</label>
    <input type="text" class="form-control" id="username">
  </div>
  <div class="mb-3">
    <label for="password" class="form-label">Jelszó</label>
    <input type="password" class="form-control" id="password">
  </div>
  <div class="mb-3">
    <label for="passwordconfirmation" class="form-label">Jelszó újra</label>
    <input type="password" class="form-control" id="passwordconfirmation">
    <div id="AccountHelp" class="form-text">Soha ne ossza meg bejelentkezési adatait senkivel!</div>
  </div>
  <button type="submit" class="btn btn-primary mb-3"><router-link class="nav-link active" aria-current="page" to="/login">Regisztráció</router-link></button>
</form>
    </div>
</div>
</template>

<script>
export default{
    name: "RegisterView"
}
</script>
<template>
<div class="container bg-secondary rounded-2 bg-opacity-50">
        <div class="row mb-5 mt-2 pt-2">
            <div class="col-3">
                <h1>Etetés</h1>
            </div>
        </div>
        <div class="row mb-2 bg-secondary">
            <div class="col-4 bg-secondary bg-opacity-50">Csirke (x3)</div>
        </div>
        <div class="row">
            <h2 class="text-center">
                Tápláltság: 76/100
            </h2>
        </div>
        <div class="row pb-2">
            <div class="col-9">

            </div>
            <div class="col-3">
                <button class="btn btn-primary w-100"><router-link class="nav-link active" aria-current="page" to="/">Vissza a főoldalra</router-link></button>
            </div>
        </div>
    </div>
</template>
<script>
export default{
    name: "FeedView"
}
</script>
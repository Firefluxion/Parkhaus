<template>
    <div class="home">
        <h1>{{ msg }}</h1>
        <p>Welcome to your new single-page application, built with <a href="https://vuejs.org" target="_blank">Vue.js</a>.</p>

        <router-link class="nav-link" to="TestPage">TestPage</router-link>
    </div>
</template>

<script>

    import { GarageService } from "@/services/api/garage.service.js";
    GarageService.test();

    export default {
        name: 'Home',
        props: {
            msg: String
        }
    };
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
</style>


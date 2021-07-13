<template>
    <div class="home">
        <h1>Home</h1>
        <p>Welcome to your new single-page application, built with <a href="https://vuejs.org" target="_blank">Vue.js</a>.</p>

        <router-link class="nav-link" to="TestPage">TestPage</router-link>
    </div>
</template>

<script>
    export default {
        name: 'Home',
        props: {
        }
    };
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
</style>


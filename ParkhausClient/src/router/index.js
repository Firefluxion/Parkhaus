import Vue from 'vue'
import Router from 'vue-router'
import HomePage from '../components/Home.vue'
import TestPage from '../components/Test.vue'

Vue.use(Router)

export default new Router({
    mode: 'history',
    routes: [
        { path: '/', component: HomePage },
        { path: '/TestPage', component: TestPage },
    ]
})

import {createRouter, createMemoryHistory} from 'vue-router'
import MainPage from "@/components/pages/Main-Page.vue";
import AddBotPage from "@/components/pages/Add-Bot-Page.vue";

const routes = [
    {
        path: '/',
        component: MainPage
    },
    {
        path: '/login',
        component: () => import('../components/pages/Log-In-Page.vue')
    },
    {
        path: '/addBot',
        component: AddBotPage
    },
]

const router = createRouter({
    history: createMemoryHistory(),
    routes
})

export default router
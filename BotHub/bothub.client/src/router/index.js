import {createRouter, createWebHashHistory} from 'vue-router'

const routes = [
    {
        path: '/',
        name: 'main',
        component: () => import('../components/pages/Main-Page.vue')
    },
    {
        path: '/login',
        name: 'login',
        component: () => import('../components/pages/Log-In-Page.vue')
    },
    {
        path: '/signUp',
        name: 'signUp',
        component: () => import('../components/pages/Sign-Up-Page.vue')
    },
    {
        path: '/addBot',
        name: 'addBot',
        component: () => import('../components/pages/Add-Bot-Page.vue')
    },
    {
        path: '/bot/:id',
        name: 'botInfo',
        component: () => import('../components/pages/Bot-Info-Page.vue')
    },
    {
        path: '/user/:userId',
        name: 'userInfo',
        component: () => import('../components/pages/User-Page.vue')
    },
]

const router = createRouter({
    history: createWebHashHistory(),
    routes
})

export default router
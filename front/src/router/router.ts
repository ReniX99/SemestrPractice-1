import { createRouter, createWebHistory } from 'vue-router'

const MainPage = import('@/pages/MainPage.vue')
const LoginPage = import('@/pages/LoginPage.vue')
const RegisterPage = import('@/pages/RegisterPage.vue')

const routes = [
  {
    path: '/',
    name: 'MainPage',
    component: MainPage,
  },
  {
    path: '/login',
    name: 'LoginPage',
    component: LoginPage,
  },
  {
    path: '/register',
    name: 'RegisterPage',
    component: RegisterPage,
  },
]

const router = createRouter({
  history: createWebHistory(),
  routes: routes,
})

export default router

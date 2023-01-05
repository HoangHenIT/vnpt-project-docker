import Vue from 'vue'
import Router from 'vue-router'
import MainLayout from '../layouts/MainLayout.vue'


import LoginLayout from '../layouts/LoginLayout.vue'
import Login from '../components/login/Login.vue'
Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'MainLayout',
      component: MainLayout
    },
    {
      path: '/auth',
      component: LoginLayout,
      children: [{
        path: 'login',
        name: 'Login',
        component: Login,
        meta: { title: 'Đăng nhập' }
      }]
    },
  ]
})

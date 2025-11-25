import Vue from 'vue'
import Router from 'vue-router'
import MainLayout from '../layouts/MainLayout.vue'
import Home from '../components/home/Home.vue'

import Admin from '@/modules/admin/Router.js'

// import Profile from '../components/profile/Profile.vue'
// import CreateEmployer from '../components/profile/popemloyer/CreateEmployer.vue'

import LoginLayout from '../layouts/LoginLayout.vue'
import Login from '../components/login/Login.vue'
Vue.use(Router)
const router = new Router({
  mode: "history",

  routes: [
    {
      path: '/',
      name: 'MainLayout',
      component: MainLayout,
     
      children:[
        {
          path: '',
          name: 'Home',
          component: Home,
        },
      ]
    },
    {
      path: '/auth',
      component: LoginLayout,
      meta: {
        requiresAuth: false
      },
      children: [{
        path: 'login',
        name: 'Login',
        component: Login,
        meta: {
          requiresAuth: false
        }
      }]
    },
    ...Admin,
  ]
})

router.beforeEach((to, from, next) => {
  // kiểm tra chưa có token trả về Login
  debugger
  // if(Vue.auth.ExpiresToken() == true){
  //   next({ name: 'Login' });
  //   return;
  // }
  if (to.meta.requiresAuth == undefined || to.meta.requiresAuth == null || to.meta.requiresAuth == true){
    if(Vue.auth.isAuthenticated()){
      next()
    }else{
      next({ name: 'Login' });
    }
      
  } else{
      next()
  }
  
})
export default router;

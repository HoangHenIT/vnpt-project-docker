import Vue from 'vue'
import Router from 'vue-router'
import MainLayout from '../layouts/MainLayout.vue'

import Profile from '../components/profile/Profile.vue'
import CreateEmployer from '../components/profile/popemloyer/CreateEmployer.vue'

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
          path: '/User/Profile',
          name: 'Profile',
          component: Profile,
          children:[
            {
              path: '/User/Profile/CreateEmployer',
              name: 'CreateEmployer',
              component: CreateEmployer,
            },
          ]
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
  ]
})

router.beforeEach((to, from, next) => {
  // kiểm tra chưa có token trả về Login
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

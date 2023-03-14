// The Vue build version to load with the `import` command
// (runtime-only or standalone) has been set in webpack.base.conf with an alias.
import Vue from 'vue'
import App from './App'
import router from './router'
import 'bootstrap-vue/dist/bootstrap-vue.css'
import toastPlugin from "./plugins/toastPlugin"
import BootstrapVue from 'bootstrap-vue'
import Select2 from 'v-select2-component';

// axios
import VueAxios from "vue-axios"
import axiosPlugin from "./plugins/axiosPlugin"
import Auth from './plugins/auth'

Vue.use(BootstrapVue)
Vue.use(VueAxios, axiosPlugin)
Vue.use(toastPlugin)
Vue.use(Auth)
Vue.component('select2', Select2)
// Vue.use(VueConfirmDialog)

Vue.config.productionTip = false
/* eslint-disable no-new */



new Vue({
  el: '#app',
  router,
  components: { App },
  template: '<App/>',
  data:{
    context:{
      isAuthenticated: function(){
        return Vue.auth.isAuthenticated();
      },
      authenticate: function (stringToken) {
        Vue.auth.authenticate(stringToken)
      },
      configApplication: function (clientInfo) {
        Vue.auth.saveClientInfoToStorage(clientInfo)
      },
      logOut: function(){
        Vue.auth.destroy()
      },
      getEmployerToken: function(){
        Vue.auth.getEmployerToken();
      },
      getEmployerId: function(){
        Vue.auth.getEmployerId();
      }
    }
  }, 
  methods:{
    toastSuccess: function (arg) {
      this.$toast.success(arg)
    },
    toastError: function (arg) {
      this.$toast.error(arg)
    },
    toastWarning: function (arg) {
      this.$toast.warning(arg)
    },
    toastInfo: function (arg) {
      this.$toast.info(arg)
    }
  }
})

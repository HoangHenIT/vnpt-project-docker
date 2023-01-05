// The Vue build version to load with the `import` command
// (runtime-only or standalone) has been set in webpack.base.conf with an alias.
import Vue from 'vue'
import App from './App'
import router from './router'
import BootstrapVue from 'bootstrap-vue'
import 'bootstrap-vue/dist/bootstrap-vue.css';
import toastPlugin from "./plugins/toastPlugin";
// axios
import VueAxios from "vue-axios"
import axiosPlugin from "./plugins/axiosPlugin"
import token from "./plugins/getToken"

Vue.use(BootstrapVue)
Vue.use(VueAxios, axiosPlugin)
Vue.use(toastPlugin)

Vue.config.productionTip = false
Vue.prototype.$token = token;
/* eslint-disable no-new */
new Vue({
  el: '#app',
  router,
  components: { App },
  template: '<App/>'
})

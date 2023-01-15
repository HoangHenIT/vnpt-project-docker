// The Vue build version to load with the `import` command
// (runtime-only or standalone) has been set in webpack.base.conf with an alias.
import Vue from 'vue'
import App from './App'
import router from './router'
import 'bootstrap-vue/dist/bootstrap-vue.css'
import toastPlugin from "./plugins/toastPlugin"
import BootstrapVue from 'bootstrap-vue'

import { loadCldr, setCulture, L10n } from '@syncfusion/ej2-base'
import { GridPlugin } from '@syncfusion/ej2-vue-grids'
import { DropDownTreePlugin, AutoCompletePlugin, DropDownListPlugin, ComboBoxPlugin, MultiSelectPlugin, ListBoxPlugin } from '@syncfusion/ej2-vue-dropdowns'
import { TreeGridPlugin } from '@syncfusion/ej2-vue-treegrid'
import { TreeViewPlugin } from '@syncfusion/ej2-vue-navigations'
import { SplitterPlugin } from '@syncfusion/ej2-vue-layouts'
import { CheckBoxPlugin } from '@syncfusion/ej2-vue-buttons'
import { MapsPlugin, MapsComponent } from '@syncfusion/ej2-vue-maps'
import { DiagramPlugin } from '@syncfusion/ej2-vue-diagrams'
import { TooltipPlugin, DialogPlugin } from '@syncfusion/ej2-vue-popups'
import { TextBoxPlugin, TextBoxComponent, NumericTextBoxPlugin } from '@syncfusion/ej2-vue-inputs'
import { DatePickerPlugin } from '@syncfusion/ej2-vue-calendars'
// axios
import VueAxios from "vue-axios"
import axiosPlugin from "./plugins/axiosPlugin"
import Auth from './plugins/auth'
loadCldr(
  
) 
Vue.use(BootstrapVue)
Vue.use(GridPlugin)
Vue.use(AutoCompletePlugin)
Vue.use(DropDownTreePlugin)
Vue.use(DropDownListPlugin)
Vue.use(TreeViewPlugin)
Vue.use(ListBoxPlugin)
Vue.use(ComboBoxPlugin)
Vue.use(MultiSelectPlugin)
Vue.use(SplitterPlugin)
Vue.use(TooltipPlugin)
Vue.use(DialogPlugin)
Vue.use(DatePickerPlugin)
Vue.use(TextBoxPlugin)
Vue.use(NumericTextBoxPlugin)
Vue.use(MapsPlugin)
Vue.use(MapsComponent)
Vue.use(DiagramPlugin)
Vue.use(TreeGridPlugin)
Vue.use(CheckBoxPlugin)

Vue.use(VueAxios, axiosPlugin)
Vue.use(toastPlugin)
Vue.use(Auth)

Vue.config.productionTip = false
/* eslint-disable no-new */

setCulture('vi')

L10n.load({
  vi: {
    grid: {
      EmptyRecord: 'Không có dữ liệu để hiển thị',
      GroupDropArea: 'Vùng kéo thả các cột để gộp nhóm',
      UnGroup: 'Hủy gộp nhóm',
      SaveButton: 'Lưu',
      CancelButton: 'Hủy'
    },
    dropdowns: {
      noRecordsTemplate: 'Không có dữ liệu để chọn'
    }
  }
})


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

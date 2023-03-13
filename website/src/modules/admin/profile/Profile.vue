<template>
  <div class="main-wrapper">
    <section>
      <div class="list-actions-top">
        <ul class="list">
          <li>
            <a href="javascript:void(0)" v-on:click="showModal">
              <span class="icon one-file-attach"></span> Nhập mới
            </a>
          </li>
          <li>
            <a href="javascript:void(0)" v-on:click="changeTab(1)">
              <span class="icon one-file-plus"></span>Lấy danh sách
            </a>
          </li>
          <!-- @click="$emit('onActionClick', item)" : bat su kien data cuar cpn con-->
          <li  :class="{disabled: !isEnable.deleteEmployer}">
            <a href="javascript:void(0)" :class="{disabled_color: !isEnable.deleteEmployer}">
              <span class="icon one-trash"></span>Xoá
            </a>
          </li>
        </ul>
      </div>
      <div class="page-content" style="top:105px">
          <ProfileInfo v-if="isActive == 0"/>
          <ListEmployer @onSelectedRowEmployer="onSelectedRowEmployer" v-if="isActive == 1"/>
      </div>
      <PopCreateEmployer ref="popupCreateEmployer"/>
    
    </section>
  </div>
 
</template>

<script>
import Vue from 'vue'
import ProfileInfo from './popemloyer/ProfileInfo.vue'
import PopCreateEmployer from './popemloyer/CreateEmployer.vue'
import ListEmployer from './popemloyer/ListEmployer.vue';
import { DialogUtility } from '@syncfusion/ej2-popups'
Vue.use(DialogUtility)
let DialogObj = undefined
import ProfileApi from './ProfileApi';
export default {
    name:"Profile",
    data(){
      return{
        isActive: 0,
        tab:0,
        isEnable: {
          deleteEmployer: false
        },
      }
    },
    mounted(){
      this.changeTab(0)
    },
    methods:{
        showModal() {
            this.$refs.popupCreateEmployer.showModal()
        },
        showModaList() {
            this.$refs.popupListEmployer.showModal()
        },
        changeTab(tab){
          if(tab==1){
            this.isActive = 1
          }else{
            this.isActive = 0
          }
        },
        async onSelectedRowEmployer(item){
          try{
            this.isEnable.deleteEmployer = true;
            DialogObj = DialogUtility.confirm({
                title: 'Thông báo',
                content: "<div style='padding:10px'>Bạn có chắc chắn muốn xóa người dùng không?</div>",
                okButton: {  text: 'Đồng ý', click: this.confirmDeleteEmployer },
                cancelButton: {  text: 'Hủy', click: function(){ DialogObj.hide(); return false}},
                showCloseIcon: true,
                closeOnEscape: true,
                animationSettings: { effect: 'Zoom' }
            });
          }catch(error){
            
          }
          // 
          // let response = await ProfileApi.deleteEmployer()
          // if(response.data.success){

          // }
        },
        confirmDeleteEmployer(){

        }
    },
    components:{
      ProfileInfo,
      PopCreateEmployer,
      ListEmployer
    }
};
</script>

<style>
  @import url("./profile.css");
</style>
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
          <li  :class="{disabled: !isEnable.deleteEmployer}" >
            <a href="javascript:void(0)" :class="{disabled_color: !isEnable.deleteEmployer}" @click="confirmDeleteEmployer()">
              <span class="icon one-trash"></span>Xoá
            </a>
          </li>
        </ul>
      </div>
      <div class="page-content" style="top:105px">
          <ProfileInfo  v-if="isActive == 0"/>
          <ListEmployer ref="refDataEmployer" @onSelectedRowEmployer="onSelectedRowEmployer" v-if="isActive == 1"/>
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
import ProfileApi from './ProfileApi';
import bootbox from "bootbox";
Vue.use(bootbox);
export default {
    name:"Profile",
    data(){
      return{
        isActive: 0,
        tab:0,
        isEnable: {
          deleteEmployer: false
        },
        listItem:[]
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
            this.listItem = item
            
          }catch(error){
            
          }
        },
        async confirmDeleteEmployer(){
          try{
            let response = await ProfileApi.deleteEmployer(this.axios, this.listItem.employer_id)
            if(response.data.success){
              this.$toast.success(response.data.message)
            }else{
              this.$toast.success(response.data.message)
            }
          } catch(error){

          }
          
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
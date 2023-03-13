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
          <li>
            <a href="javascript:void(0)">
              <span class="icon one-trash"></span>Xoá
            </a>
          </li>
        </ul>
      </div>
      <div class="page-content" style="top:105px">
          <ProfileInfo v-if="isActive == 0"/>
          <ListEmployer v-if="isActive == 1"/>
      </div>
      <PopCreateEmployer ref="popupCreateEmployer"/>
    
    </section>
  </div>
 
</template>

<script>
import ProfileInfo from './popemloyer/ProfileInfo.vue'
import PopCreateEmployer from './popemloyer/CreateEmployer.vue'
import ListEmployer from './popemloyer/ListEmployer.vue';
export default {
    name:"Profile",
    data(){
      return{
        isActive: 0,
        tab:0
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
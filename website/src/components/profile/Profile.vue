<template>
  <section>
    <div class="list-actions-top">
      <ul class="list">
        <li>
          <a href="javascript:void(0)" v-on:click="onclickCreate">
            <span class="icon one-file-attach"></span> Nhập mới
          </a>
        </li>
        <li>
          <a href="javascript:void(0)" v-b-modal.popup-capnhat>
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
    <div class="page-content">
        <ProfileInfo/>
    </div>
    <PopCreateEmployer ref="PopCreateEmployer"/>
  </section>
</template>

<script>
import ProfileInfo from './popemloyer/ProfileInfo.vue'
import PopCreateEmployer from './popemloyer/CreateEmployer.vue'
export default {
    name:"Profile",
    data(){
      return{

      }
    },
    methods:{
        onclickCreate(){
          this.$refs["PopCreateEmployer"].show()
        },
    },
    components:{
      ProfileInfo,
      PopCreateEmployer
    }
};
</script>

<style>
</style>
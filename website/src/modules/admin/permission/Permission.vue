<template>
  <div class="main-wrapper">
    <section>
      <div class="list-actions-top">
        <ul class="list">
          <li v-on:click="changeTab(0)">
            <a href="javascript:void(0)">
              <span class="icon one-file-attach" ></span> Nhóm quyền
            </a>
          </li>
          <li>
            <a href="javascript:void(0)">
              <span class="icon one-file-plus"></span>Lấy danh sách
            </a>
          </li>
          <!-- @click="$emit('onActionClick', item)" : bat su kien data cuar cpn con-->
          <li  :class="{disabled: !isEnable.deleteEmployer}" >
            <a href="javascript:void(0)" :class="{disabled_color: !isEnable.deleteEmployer}" >
              <span class="icon one-trash"></span>Xoá
            </a>
          </li>
        </ul>
      </div>
      <div class="page-content" style="top:105px">
        <RoleIndex ref="RolesIndex" v-show="activeTab === 0"/>
      </div>
      <!-- <PopCreateEmployer ref="popupCreateEmployer"/> -->
     
    </section>
  </div>
</template>

<script>
import RoleIndex from './grouprole/RoleIndex.vue';
export default {
    name:"PermissionIndex",
    data(){
        return{
          activeTab: 0,
          isEnable: {
              deleteEmployer: false
          },
        }
    },
    methods:{
      changeTab(index) {
          this.activeTab = index;
        },
      showRoles(){
        this.$refs.RolesIndex.showModal()
      }
    },
    mounted(){
      this.changeTab(0)
    },
    components:{
      RoleIndex
    }
}
</script>

<style>

</style>
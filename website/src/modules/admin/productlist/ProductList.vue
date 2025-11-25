<template>
  <div class="main-wrapper">
    <section>
      <div class="list-actions-top">
        <ul class="list">
          <li v-on:click="changeTab(0)">
            <a href="javascript:void(0)">
              <span class="icon one-file-attach" ></span> Danh sách sản phẩm
            </a>
          </li>
          <li v-on:click="changeTab(1)">
            <a href="javascript:void(0)">
              <span class="icon one-file-plus"></span> Phân quyền
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
          <RoleIndex ref="ProductListIndex" v-show="activeTab == 0"/>
      </div>
      <!-- <PopCreateEmployer ref="popupCreateEmployer"/> -->
     
    </section>
  </div>
</template>

<script>
import ProductListIndex from './produclists/ProductListIndex.vue'
export default {
    name:"ProductList",
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
      ProductListIndex
    }
}
</script>

<style>

</style>
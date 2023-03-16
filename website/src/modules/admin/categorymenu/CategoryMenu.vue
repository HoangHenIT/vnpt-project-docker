<template>
  <div class="main-wrapper">
    <section>
      <div class="list-actions-top">
        <ul class="list">
            <li @click="changeTab(0)">
                <a href="javascript:void(0)">
                    <span class="icon one-file-attach"></span> Danh sách menu
                </a>
            </li>
            <li  :class="{disabled: isEnable.installBtn}"  @click="changeTab(1)">
                <a href="javascript:void(0)" :class="{disabled_color: isEnable.installBtn}">
                    <span class="icon one-file-attach"></span> Nhập mới
                </a>
            </li>
            <li :class="{disabled: !isEnable.updateBtn}">
                <a href="javascript:void(0)" :class="{disabled_color: !isEnable.updateBtn}">
                    <span class="icon one-file-attach"></span> Chỉnh sửa
                </a>
            </li>
            <li :class="{disabled: !isEnable.updateBtn}">
                <a href="javascript:void(0)" :class="{disabled_color: !isEnable.updateBtn}">
                    <span class="icon one-file-attach"></span> Xóa
                </a>
            </li>
        </ul>
      </div>
      <div class="page-content" style="top:105px">
        <div class="row">
            <div class="col-lg-4 col-sm-4 col-12">
                <InstallCategoryMenu v-if="isTab ==  0"/>
            </div>
            <div class="col-lg-8 col-sm-8 col-12">
                <ListCategoryMenu  v-if="isTab == 0"/>
            </div>
        </div>
          
          
      </div>
    </section>
  </div>
</template>

<script>
import InstallCategoryMenu from './categorymenucpn/InstallCategoryMenu.vue'
import ListCategoryMenu from './categorymenucpn/ListCategoryMenu.vue'
export default {
    name:"CategoryMenu",
    data(){
        return{
            isTab: 0,
            isEnable: {
                installBtn: false,
                updateBtn: false,
                deletetBtn: false
            },
        }
    },
    mounted(){
        this.changeTab(0)
    },
    methods:{
        changeTab(isTab){
            if(isTab == 1){
                this.isTab = 1
            }
            else{
                this.isTab = 0
            }
        }
    },
    components:{
        ListCategoryMenu,
        InstallCategoryMenu
    }
}
</script>

<style>
    @import url(./categorymenu.css);
</style>
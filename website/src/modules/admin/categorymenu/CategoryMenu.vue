<template>
  <div class="main-wrapper">
    <section>
      <div class="list-actions-top">
        <ul class="list">
            <li @click="changeTab(0)">
                <a href="javascript:void(0)">
                    <span class="icon one-file-attach"></span> Danh sách nhóm
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
            <li :class="{disabled: !isEnable.deletetBtn}" v-on:click="confimDeleteCategory">
                <a href="javascript:void(0)" :class="{disabled_color: !isEnable.deletetBtn}">
                    <span class="icon one-file-attach"></span> Xóa
                </a>
            </li>
        </ul>
      </div>
      <div class="page-content h-100" style="top:105px">
        <div class="row">
            <div class="col-lg-4 col-sm-4 col-12">
                <InstallCategoryMenu ref="sentdataDataCategory" v-if="isTab ==  0"/>
            </div>
            <div class="col-lg-8 col-sm-8 col-12">
                <ListCategoryMenus ref="loadDataCategory" @onSelectedCategory="onSelectedCategory" v-if="isTab == 0"   />
            </div>
        </div>
          
          
      </div>
    </section>
  </div>
</template>

<script>
import InstallCategoryMenu from './categorymenucpn/InstallCategoryMenu.vue'
import ListCategoryMenus from './categorymenucpn/ListCategoryMenu.vue'
import CategoryAPI from './CategoryAPI'
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
            ListCategory:[]
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
        },
        onSelectedCategory(item){
            try{
                this.isEnable.deletetBtn = true;
                this.ListCategory = item
                
            }catch(error){
                this.$root.toastError(error.message.toString())
            }
        },
        async confimDeleteCategory(){
            try{
                let category_id = this.ListCategory.category_id
                let response = await CategoryAPI.DeleteCategory(this.axios, category_id)
                if(response.data.success){
                    this.$root.toastSuccess(response.data.message)
                    // call function to cpnIndex to cpnList
                    this.$refs.loadDataCategory.getAllCategory()
                }
            }catch(error){
                this.$root.toastError(error.message.toString())
            }
        },
        
    },
    components:{
        ListCategoryMenus,
        InstallCategoryMenu
    }
}
</script>

<style>
    @import url(./categorymenu.css);
</style>
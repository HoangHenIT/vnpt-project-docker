<template>
    <b-modal ref="PopRoles" size="xl" hide-footer hide-header hide-header-close body-class="modal-body p-0">
      <div class="modal-content popup-box">
          <div class="popup-header">
              <div class="title"><span class="icon one-notepad"></span> Danh mục nhóm quyền</div>
              <div class="close -ap fa fa-times" aria-hidden="true" data-dismiss="modal" @click="hideModal()">
              </div>
          </div>
          <div class="list-actions-top">
              <ul class="list">
                  <li :class="{disabled: !isEnable.isEnableList, active: activeTab === 0}" @click="changeTab(0)">
                      <a href="javascript:void(0)" :class="{disabled_color: !isEnable.isEnableList}" >
                          <span class="icon one-file-attach"></span> Danh sách nhóm quyền
                      </a>
                  </li>
                  <li :class="{disabled: !isEnable.isEnableInsert, active: activeTab === 1}"  @click="changeTab(1)">
                      <a :class="{disabled_color: !isEnable.isEnableInsert}" >
                          <span class="icon one-save" ></span>Nhập mới
                      </a>
                  </li>
                  <li :class="{disabled: !isEnable.isEnableSave}">
                      <a :class="{disabled_color: !isEnable.isEnableSave}" @click.prevent="onClickInsert()">
                          <span class="icon one-save" ></span>Ghi lại
                      </a>
                  </li>
                  <li :class="{disabled: !isEnable.isEnableUpdate}">
                      <a :class="{disabled_color: !isEnable.isEnableUpdate}">
                          <span class="icon one-save" ></span>Chỉnh sửa
                      </a>
                  </li>
                  <li :class="{disabled: !isEnable.isEnableDelete}">
                      <a :class="{disabled_color: !isEnable.isEnableDelete}">
                          <span class="icon one-save" ></span>Xóa
                      </a>
                  </li>
                  <li>
                      <a href="#">
                          <span class="icon nc-icon-glyph ui-1_circle-remove"></span>Hủy
                      </a>
                  </li>
                  
              </ul>
          </div>
          <div class="popup-body">
              <div class="box-form"  v-show="activeTab === 0" >
                  <div class="legend-title">Danh sách nhóm quyền</div>
                  <div class="row p-3">
                     <KTable class="w-100" ref="tabList" :columns="columnsRole" :dataSources="listRolers" :allowFilter="true"/>
                  </div>
              </div>
              <div class="box-form"  v-show="activeTab === 1" >
                  <div class="legend-title">Thông tin nhóm quyền</div>
                  <div class="row p-3">
                     <InstallRole ref="tabInsert"></InstallRole>
                  </div>
              </div>
          </div>
      </div>
    </b-modal>
</template>

<script>
import KTable from '../../../../share/tablecpn/KTable.vue'
import InstallRole from './rolecpn/InstallRole.vue'
import PermisionAPI from '../PermissionAPI'
export default {
    name:"RoleIndex",
    data(){
      return{
        activeTab: 0,
        isEnable:{
          isEnableList:false,
          isEnableSave:false,
          isEnableInsert: false,
          isEnableUpdate: false,
          isEnableDelete:false,
        },
        columnsRole:[
          {
            field:'role_name',
            label:'Tên nhóm quyền',
            allowFilter: true
          },
          {
            field:'note',
            label:'Ghi chú',
            allowFilter: true
          },
          {
            field:'active',
            label:'Trạng thái',
            allowFilter: true
          }
        ],
        listRolers:[]
      }
    },
    created(){
      this.changeTab(this.activeTab)
      this.getAllGroupRoles()
    },
    methods:{
        showModal() {
          this.$refs["PopRoles"].show();
        },
        hideModal() {
          this.$refs["PopRoles"].hide();
        },
        changeTab(index) {
          this.activeTab = index;
          if(this.activeTab === 0){
            this.isEnable.isEnableInsert = true
            this.isEnable.isEnableList = false
            this.isEnable.isEnableSave = false
          }
          if(this.activeTab === 1){
              this.isEnable.isEnableInsert = false
              this.isEnable.isEnableList = true
              this.isEnable.isEnableSave = true
          }
        },
        async getAllGroupRoles(){
          try{
            this.listRolers = []
            let response = await PermisionAPI.getAllGroupRoles(this.axios)
            if(response.data.success){
              response.data.data.forEach(element => {
                  let item = {
                    role_name: element.role_name,
                    note: element.note,
                    active: element.active == true?"Hoạt động":"Khóa",
                  }
                  this.listRolers.push(item)
              });
            }
          }catch(error){
            this.$root.toastError(error.message.toString())
          }
        },
        onClickInsert(){
          this.$refs.tabInsert.InstallRoles()
          this.getAllGroupRoles()
          this.changeTab(0)
        }
    },
    components:{
      InstallRole,
      KTable
    }
}
</script>

<style>

</style>
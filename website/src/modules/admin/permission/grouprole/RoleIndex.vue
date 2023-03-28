<template>
  <div>
      <div class="box-form"  v-show="activeTab === 0" >
        <ActionTop :actions="actions" @onActionClick="onActionClick"/>
        
        <div class="box-form mt-2">
            <div class="legend-title">Thông tin nhóm quyền</div>
            <div class="row">
              <div class="col-sm-6 col-md-6 col-12">
                  <div class="info-row">
                      <div class="key w150">Tên nhóm quyền <k-required-marker/></div>
                      <div class="value">
                          <input type="text" class="form-control" ref="inputName" v-model="role_name">
                      </div>
                  </div>
                  <div class="info-row">
                    <div class="key w100 k-w">Trạng thái <k-required-marker/></div>
                      <div class="value">
                          <div class="select-custom" >
                              <select2 v-model="active" :options="this.listActive" > </select2>
                          </div> 
                      </div>
                  </div>
              </div>
              <div class="col-sm-6 col-md-6 col-12">
                <div class="info-row">
                      <div class="key w150">Ghi chú</div>
                      <div class="value">
                          <div class="select-custom">
                              <textarea type="text" style="height: 90px;" v-model="note" class="form-control"></textarea>
                          </div>
                      </div>
                  </div>
              </div>
            </div>
        </div>
        <div class="box-form"  v-show="activeTab === 0" >
            <div class="legend-title">Danh sách nhóm quyền</div>
            <div class="row p-3">
                <KTable class="w-100" ref="tabList" 
                  :columns="columnsRole" 
                  :dataSources="dataSources" 
                  :allowFilter="true"
                  :rowSelectedIndex="rowSelectedIndex" 
                  @onSelectedRow="onSelectedRow"
                />
            </div>
        </div>
    </div>
  </div>
</template>

<script>
import KTable from '../../../../share/tablecpn/KTable.vue'
import ActionTop from '../../../../share/tablecpn/ActionTop.vue'
import PermisionAPI from '../PermissionAPI'
import KRequiredMarker from '../../../../share/KRequiredMarker.vue'
import { arrActive } from '../../../../constants'
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
        actions:[
          {
              id:'nhapmoi',
              name:'Nhập mới',
              active: true,
              icon_class:'fa fa-file-text'
          },
          {
              id:'ghilai',
              name:'Ghi lại',
              active: true,
              icon_class:'fa fa-floppy-o'
          },
          {
              id:'huy',
              name:'Huỷ',
              active: true,
              icon_class:'fa fa-times-circle'
          },
          {
              id:'xoa',
              name:'Xoá',
              active: true,
              icon_class:'fa fa-trash-o'
          }
          
      ],
        role_id: 0,
        role_name:"",
        active:"",
        note: "",
        listActive:[],
        dataSources:[],
        data_selected: null,
        rowSelectedIndex:-1,
      }
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
        clear(){
            this.role_name=''
            this.note=''
        },
        onActionClick(action){
            if(action.id=='nhapmoi'){
                this.setActiveActions(1)
            }else if(action.id=='ghilai'){
                this.ghiDuLieu()
            }else if(action.id=='huy'){
                if(this.data_selected!=null){
                    this.onSelectedRow(this.data_selected)
                }else{
                    this.setActiveActions(0)
                }
            }else if(action.id=='xoa'){
                if(this.role_id==0){
                    return
                }
                bootbox.alert('This is the default alert!');
            }
        },
        setActiveActions(kieu){
            this.actions.forEach((item)=>{
                item.active=false
            })
            if(kieu==-1){//bắt đầu
                this.actions[this.actions.findIndex(x=>x.id=='ghilai')].active=true
                this.actions[this.actions.findIndex(x=>x.id=='huy')].active=true
            }else if(kieu==0){//bắt đầu
                this.actions[this.actions.findIndex(x=>x.id=='nhapmoi')].active=true
                this.clear()
            }else if(kieu==1){//thêm mới
                this.actions[this.actions.findIndex(x=>x.id=='ghilai')].active=true
                this.actions[this.actions.findIndex(x=>x.id=='huy')].active=true
                this.clear()

            }else if(kieu==2){//Huỷ
                this.actions[this.actions.findIndex(x=>x.id=='nhapmoi')].active=true
                this.actions[this.actions.findIndex(x=>x.id=='xoa')].active=true
                this.clear()
            }else if(kieu==3){//edit
                this.actions[this.actions.findIndex(x=>x.id=='nhapmoi')].active=true
                this.actions[this.actions.findIndex(x=>x.id=='ghilai')].active=true
                this.actions[this.actions.findIndex(x=>x.id=='huy')].active=true
                this.actions[this.actions.findIndex(x=>x.id=='xoa')].active=true
            }
        },
       
        async getAllGroupRoles(){
          try{
            this.dataSources = []
            let response =  await PermisionAPI.getAllGroupRoles(this.axios)
            if(response.data.success){
                  this.dataSources = response.data.data.map((x)=>Object.assign(x,{
                      role_id:x.role_id,
                      role_name: x.role_name,
                      note: x.note,
                      active: x.active==true?'Hoạt động':'Khóa'
                  }))
                  if(this.dataSources.length > 0){
                      if(this.role_id!=0){
                          const index=this.dataSources.findIndex(x=>x.role_id==this.role_id)
                          if(index>-1){
                              this.rowSelectedIndex=index + 1
                              this.onSelectedRow(this.dataSources[index])
                          }else{
                              this.rowSelectedIndex = 1
                              this.onSelectedRow(this.dataSources[0])
                          }
                      }else{
                          this.rowSelectedIndex = 1
                          this.onSelectedRow(this.dataSources[0])
                      }
                  }
            }else{
              this.setActiveActions(-1)
            }
          }catch(error){
            this.$root.toastError(error.message.toString())
          }
        },
        // change row selected in table

        onSelectedRow(data){
            this.data_selected = data
            this.role_id = data.role_id;// Object.assign({},data)
            this.role_name = data.role_name
            this.note = data.note
            this.active = data.active == "Hoạt động"?true:false
            this.setActiveActions(3)
        },
        // install role
        async ghiDuLieu(){
            try{
                if(this.role_name.trim() == ''){
                    this.$toast.warning("Bạn chưa nhập nhóm quyền!");
                    this.$refs.inputName.focus()
                    return
                }
                let data = {
                    role_id: this.role_id,
                    role_name: this.role_name,
                    note: this.note,
                    active: this.active
                }
                // is_insert = 1 thì insert = 0 update
                let is_insert = this.actions[this.actions.findIndex(x=>x.id=='nhapmoi')].active?0:1 
                
                if(is_insert == 1){
                  this.insertRole(data)
                }else{
                  this.$box.confirm('This is the default confirm!',
                                function(result) {
                                console.log('This was logged in the callback: ' + result);
                                });
                  this.updateRole(data)
                }
                
            }catch(error){
                this.$root.toastError(error.message.toString())
            }
        },
        async insertRole(data){
          try{
              let response = await PermisionAPI.InsertRoles(this.axios, data)
              if(response.data.success){
                  this.$toast.success(response.data.message)
                  this.getAllGroupRoles()
              }else{
                this.$root.toastError(response.data.message.toString())
              }
          }catch(error){
            this.$root.toastError(error.message.toString())
          }
        },
        async updateRole(data){
          try{
              let response = await PermisionAPI.updateRoler(this.axios, data)
              if(response.data.success){
                  this.$toast.success(response.data.message)
                  this.getAllGroupRoles()
              }else{
                this.$root.toastError(response.data.message.toString())
              }
          }catch(error){
            this.$root.toastError(error.message.toString())
          }
        }
    },
    mounted(){
      this.listActive = arrActive
      this.active_select = arrActive[1].id
      this.changeTab(this.activeTab)
      this.setActiveActions(-1)
      this.getAllGroupRoles()
    },
    components:{
      KTable,
      ActionTop,
      "k-required-marker":KRequiredMarker
    }
}
</script>

<style>

</style>
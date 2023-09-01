<template>
    <div>
        <div class="box-form"  v-show="activeTab === 0" >
          <ActionTop :actions="actions" @onActionClick="onActionClick"/>
          <div class="grid-stack-box">
            <div class="box-col box-form marb0" id="boxLeft">
                <div class="legend-title">Thông tin menu</div>
                    <div class="form-control text h-auto">
                        <div class="tree-plus" style="height: 780px;overflow:auto;">
                            <div class="col-12">
                                <div class="info-row">
                                    <div class="key w150">ID Menu</div>
                                    <div class="value">
                                        <input type="text" disabled v-model="categorymenu.category_id" class="form-control">
                                    </div>
                                </div>
                            </div> 
                            <div class="col-12">
                                <div class="info-row">
                                    <div class="key w150">Tên Menu</div>
                                    <div class="value">
                                        <input type="text" ref="inputName" class="form-control" v-model="categorymenu.category_name">
                                    </div>
                                </div>
                            </div> 
                            <div class="col-12">
                                <div class="info-row">
                                    <div class="key w150">Đường dẫn menu Menu</div>
                                    <div class="value">
                                        <input type="text" ref="inputLink" class="form-control" v-model="categorymenu.category_link">
                                    </div>
                                </div>
                            </div>
                            <div class="col-12">
                                <div class="info-row">
                                    <div class="key bold red nowrap">Cấp menu</div>
                                    <div class="value">
                                        <div class="select-custom" >
                                            <select2 v-model="categorymenu.category_level" :options="this.listCapMenu" ></select2>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-12">
                                <div class="info-row">
                                    <div class="key w150">Icon menu</div>
                                    <div class="value">
                                        <input type="text" class="form-control" v-model="categorymenu.category_icon">
                                    </div>
                                </div>
                            </div>  
                            <div class="col-12">
                                <div class="info-row">
                                    <div class="key w150">Ghi chú</div>
                                    <div class="value">
                                        <input type="text"  class="form-control" v-model="categorymenu.category_note">
                                    </div>
                                </div>
                            </div>
                            <div class="col-12">
                                <div class="info-row marb0">
                                    <div class="key bold red nowrap">Menu Cha</div>
                                    <div class="value">
                                        <div class="select-custom" >
                                            <select2 v-model="categorymenu.category_cha_id" :options="this.listMenuCha" > </select2>
                                        </div>
                                    </div>
                                </div>
                            </div>  
                            <div class="col-12">
                                <div class="info-row">
                                    <div class="key w150">Vị trí</div>
                                    <div class="value">
                                        <input type="number"  class="form-control" v-model="categorymenu.position">
                                    </div>
                                </div>
                            </div>  
                            <div class="col-12">
                                <div class="info-row marb0">
                                    <div class="key bold red nowrap">Trạng thái</div>
                                    <div class="value">
                                        <div class="select-custom" >
                                            <select2 v-model="categorymenu.category_active" :options="this.listActive" > </select2>
                                        </div>
                                    </div>
                                </div>
                            </div>             
                        </div>
                    </div>

                </div>
                <div class="box-col" id="boxRight" style="height: 900px;">
                    <div class="box-form"  v-show="activeTab === 0" >
                        <div class="legend-title">Danh sách Menu</div>
                        <div class="row p-3">
                            <KTable class="w-100" ref="tabList" 
                                :columns="columnsCategory" 
                                :dataSources="dataSources" 
                                :allowFilter="true"
                                :rowSelectedIndex="rowSelectedIndex" 
                                @onSelectedRow="onSelectedRow"
                            />
                        </div>
                    </div>
                </div>
            </div>
      </div> 
    </div>
  </template>
  
  <script>
  import '../../../../assets/js/vender/split'
  import KTable from '../../../../share/tablecpn/KTable.vue'
  import ActionTop from '../../../../share/tablecpn/ActionTop.vue'
  import PermisionAPI from '../CategoryAPI'
  import KRequiredMarker from '../../../../share/KRequiredMarker.vue'
  import { arrCapMenu, arrActive } from '../../../../constants'
  export default {
      name:"Categorymenu",
      props:{
            ListMenu:{
                type:Object,
                default:()=>{}
            }
      },
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
          columnsCategory:[
                {
                    field:'category_id',
                    label:'ID menu',
                    allowFilter: true
                },
                {
                    field:'category_name',
                    label:'Tên menu',
                    allowFilter: true
                },
                {
                    field:'category_link',
                    label:'Đường đẫn menu',
                    allowFilter: true
                },
                {
                    field:'category_icon',
                    label:'Icon menu',
                    allowFilter: true
                },
                {
                    field:'category_note',
                    label:'Ghi chú',
                    allowFilter: true
                },
                {
                    field:'position',
                    label:'Vị trí menu',
                    allowFilter: true
                },
                {
                    field:'category_level',
                    label:'Cấp menu',
                    allowFilter: true
                },
                {
                    field:'category_cha_id',
                    label:'ID menu cha',
                    allowFilter: true
                },
                {
                    field:'createday',
                    label:'Ngày tạo',
                    allowFilter: true
                }
                ,
                {
                    field:'category_active',
                    label:'Trạng thái',
                    allowFilter: true
                }
            ],
            listCategory:[],
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
          categorymenu:{
                category_id: "",
                category_name: "",
                category_level: "",
                category_link: "",
                category_icon: "",
                category_note: "",
                category_active: true,
                createday: "",
                category_cha_id: "",
                position: "",
            },
            listCapMenu: [],
            listMenuCha:[]
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
         
          async getAllCategory(){
            try{
              this.dataSources = []
              let response =  await PermisionAPI.getAllCategory(this.axios)
              if(response.data.success){
                    this.dataSources = response.data.data.map((x)=>Object.assign(x,{
                        category_id: x.category_id,
                        category_name: x.category_name,
                        category_level: x.category_level,
                        category_link: x.category_link,
                        category_icon: x.category_icon,
                        category_note: x.category_note,
                        category_active: x.category_active == true?"Hoạt động":"Khóa",
                        createday: this.moment(x.createday).format("DD-MM-YYYY"),
                        category_cha_id: x.category_cha_id,
                        position: x.position
                    }))
                    this.setDataCategory(this.dataSources)
                    if(this.dataSources.length > 0){
                        console.log(this.category_id)
                        if(this.category_id!=0){
                            const index=this.dataSources.findIndex(x=>x.category_id==this.category_id)
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
              this.categorymenu.category_id = data.category_id,
              this.categorymenu.category_name = data.category_name,
              this.categorymenu.category_level = data.category_level,
              this.categorymenu.category_link = data.category_link,
              this.categorymenu.category_icon = data.category_icon,
              this.categorymenu.category_note = data.category_note,
              this.categorymenu.category_active = data.category_active == "Hoạt động"?true:false
              this.categorymenu.createday = this.moment(data.createday).format("DD-MM-YYYY"),
              this.categorymenu.category_cha_id = data.category_cha_id,
              this.categorymenu.position = data.position
              this.setActiveActions(3)
          },
          async setDataCategory(item){
            let menuChinh = [{id: "0", text:"0 - Menu Cha" }]
            let data = item.map(e=> ({id: e.category_id, text:  e.category_id +" - "+ e.category_name}))
            this.listMenuCha = menuChinh.concat(data)
            if(this.listMenuCha.length > 0){
                this.categorymenu.category_cha_id = this.listMenuCha[0].id
            }else{
                this.$root.toastError("Dữ liệu chưa có!")
            }
        },
        // insert menu
        
        async ghiDuLieu(){
            try{
                if(this.categorymenu.category_name.trim() == ''){
                    this.$toast.warning("Bạn chưa nhập Tên menu!");
                    this.$refs.inputName.focus()
                    return
                }
                if(this.categorymenu.category_link.trim() == ""){
                    this.$toast.warning("Bạn chưa nhập đường dẫn menu!");
                    this.$refs.inputLink.focus()
                    return
                }
                let data = {
                    category_id:this.categorymenu.category_cha_id,
                    category_name:this.categorymenu.category_name,
                    category_link:this.categorymenu.category_link,
                    category_level: this.categorymenu.category_level,
                    category_icon:this.categorymenu.category_icon,
                    category_note:this.categorymenu.category_note,
                    category_cha_id: this.categorymenu.category_cha_id,
                    position: this.categorymenu.position==""?"0":this.categorymenu.position,
                    category_active: Boolean(this.categorymenu.category_active)
                }
                // is_insert = 1 thì insert = 0 update
                let is_insert = this.actions[this.actions.findIndex(x=>x.id=='nhapmoi')].active?0:1 
                
                if(is_insert == 1){
                 
                  this.InsertCategory(data)
                }else{
                  
                  this.updateCategory(data)
                }
                
            }catch(error){
                this.$root.toastError(error.message.toString())
            }
        },
        async InsertCategory(data){
            try{
                let response = await PermisionAPI.InsertCategory(this.axios, data)
                if(response.data.success){
                    this.$toast.success(response.data.message)
                    this.getAllCategory()
                }else{
                    this.$root.toastError(response.data.message.toString())
                }
            }catch(error){
                this.$root.toastError(error.message.toString())
            }
        },
        async updateCategory(data){
            
            try{
                let response = await PermisionAPI.UpdateCategory(this.axios, data)
                if(response.data.success){
                    this.$toast.success(response.data.message)
                    this.getAllCategory()
                    this.loading(false);
                }else{
                  this.$root.toastError(response.data.message.toString())
                }
            }catch(error){
              this.$root.toastError(error.message.toString())
            }
        },
        clear(){
            this.categorymenu.category_id = 0,
            this.categorymenu.category_name = '',
            this.categorymenu.category_level = '',
            this.categorymenu.category_link = '',
            this.categorymenu.category_icon = '',
            this.categorymenu.category_note = '',
            this.categorymenu.category_active = true,
            this.categorymenu.createday = '',
            this.categorymenu.category_cha_id = '',
            this.categorymenu.position = ''
          },
      },
      mounted(){
        // Split(['#boxTop', '#boxBottom'], {
        //     sizes: [36, 64],
        //     direction: 'vertical',
        //     minSize:[100,300],

        // });
        Split(['#boxLeft', '#boxRight'], {
            sizes: [25, 75],
            gutterSize: 16,
            onDragEnd: function (sizes) {
            },
        });
        this.listCapMenu = arrCapMenu
        this.categorymenu.category_level = this.listCapMenu[0].id
        this.listActive = arrActive
        this.active_select = arrActive[1].id
        this.changeTab(this.activeTab)
        this.setActiveActions(-1)
        this.getAllCategory()
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
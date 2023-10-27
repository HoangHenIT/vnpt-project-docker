<template>
    <div class="main-wrapper">
        <div class="box-form">
            <div class="info-rows marb0">
                <div class="key w140">Nhóm người dùng</div>
                <div class="value ">
                    <div class="select-custom " >
                        <select2 v-model="listgroup.role_id" :options="this.listgroup" v-on:change="changePermission" ></select2>
                    </div>
                </div>
            </div>
        </div>  
        <div class="row">
            <div class="col-xl-6 col-lg-6 marb10" >
                <div class="grid-stack-box">
                    <div class="box-col box-form marb0" id="boxLeft">
                        <div class="legend-title">Nhóm menu chưa gán</div>
                        <div class="form-control text h-auto">
                            <div class="tree-plus" style="height: 740px;overflow:auto;">
                                <div class="col-12">
                                    <KTable 
                                        :columns="DanhSachNhomMenuChuaGanColums"
                                        :dataSources="DanhSachNhomMenuChuaGan"
                                        @dataCheckeds="onCheckNhomMenuChuaGan"
                                        :allowCheckBox="true"
                                        :allowFilter="true"
                                    />
                                </div>    
                            </div>
                        </div>
                    </div>
                    <div class="box-move-select-table">
                        <div class="actions">
                            <button class="btn btn-main" v-on:click="addRolePermission()">
                                <span class="fa fa-plus"> </span>
                            </button>
                            <button class="btn btn-main" v-on:click="deleteRolePermission()">
                                <span class="fa fa-minus"></span>
                            </button>
                        </div>
                    </div>
                    <div class="box-col box-form marb0" id="boxRight">
                        <div class="legend-title">Nhóm menu chưa gán</div>
                        <div class="form-control text h-auto">
                            <div class="tree-plus" style="height: 740px;overflow:auto;">
                                <div class="col-12">
                                    <div class="info-row">
                                        <KTable 
                                            :columns="DanhSachNhomMenuChuaGanColums"
                                            :dataSources="DanhSachNhomMenuDaGan"
                                            :allowCheckBox="true"
                                            :allowFilter="true"
                                            @dataCheckeds="onCheckNhomMenuDaGan"
                                        />
                                    </div>
                                </div>    
                            </div>
                        </div>
                    </div>
                </div>   
            </div>
            <div class="col-xl-6 col-lg-6 col-12 padb2 " >
                <div class="grid-stack-box">
                    <div class="box-col box-form marb0" id="boxLeft1">
                        <div class="legend-title">Nhân viên đã gán </div>
                        <div class="form-control text h-auto">
                            <div class="tree-plus" style="height: 740px;overflow:auto;">
                                <div class="col-12">
                                    <KTable 
                                        :columns="DanhSachNguoiDungColums"
                                        :dataSources="DanhSachNguoiDungDaGan"
                                        @dataCheckeds="onCheckNguoiDungDaGan"
                                        :allowCheckBox="true"
                                        :allowFilter="true"
                                    />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="box-move-select-table">
                        <div class="actions">
                            <button class="btn btn-main" v-on:click="addEmployPermission()">
                                <span class="fa fa-plus"> </span>
                            </button>
                            <button class="btn btn-main" v-on:click="removeEmployPermission()">
                                <span class="fa fa-minus"></span>
                            </button>
                        </div>
                    </div>
                    <div class="box-col box-form marb0" id="boxRight1">
                        <div class="legend-title">Nhân viên chưa gán</div>
                        <div class="form-control text h-auto">
                            <div class="tree-plus" style="height: 740px;overflow:auto;">
                                <div class="col-12">
                                    <KTable 
                                        :columns="DanhSachNguoiDungColums"
                                        :dataSources="DanhSachNguoiDungChuaGan"
                                        @dataCheckeds="onCheckNguoiDungChuaGan"
                                        :allowCheckBox="true"
                                        :allowFilter="true"
                                    />
                                </div>    
                            </div>
                        </div>
                    </div>
                </div>   
            </div>
        </div>
    </div>
    
</template>

<script>
import '../../../../assets/lib/jquery/split'
import KTable from '../../../../share/tablecpn/KTable.vue'
import PermisionAPI from '../PermissionAPI'
// import CategoryAPI from '../CategoryAPI';
export default {
    name:"Permissions",
    data(){
        return{
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
            DanhSachNhomMenuChuaGanColums:[
                {
                    field:'category_name',
                    label:'Tên menu',
                    allowFilter: true
                }
            ],
            DanhSachNguoiDungColums:[
                {
                    field:'full_name',
                    label:'Tên người dùng',
                    allowFilter: true
                }
            ],
            listCategory:[],
            listMenu:[],
            sentRowCategory:[],
            listgroup:[],
            DanhSachNhomMenuChuaGan:[],
            DanhSachNhomMenuDaGan:[],
            DataCheckNhomMenuChuaGan:[],
            DanhSachNguoiDungChuaGan:[],
            DanhSachNguoiDungDaGan:[],
            DataCheckNguoiChuaGan:[],
            DataCheckNguoiDaGan:[],
            role_id:0
        }
    },
    mounted(){
        Split(['#boxLeft1',  '#boxRight1'], {
            sizes: [50,  50],
            gutterSize: 0,
            onDragEnd: function (sizes) {
            },
        });
        Split(['#boxLeft',  '#boxRight'], {
            sizes: [50,  50],
            gutterSize: 0,
            onDragEnd: function (sizes) {
            },
        });
        this.getAllGroupRoles()
        setTimeout(() => {
            this.changePermission()
        }, 600);
    
        
    },
    methods:{
        async getAllGroupRoles(){
          try{
            this.listgroup = []
            let response =  await PermisionAPI.getAllGroupRoles(this.axios)
            if(response.data.success){
                  this.listgroup = response.data.data.map((x)=>Object.assign(x ,{
                    id: x.role_id.toString(),
                    text: x.role_name
                  }))
                  if(this.listgroup.length != 0){
                        this.listgroup.role_id =  this.listgroup[0].id
                  }
            }else{
                this.$root.toastError(response.data.message.toString())
            }
          }catch(error){
            this.$root.toastError(error.message.toString())
          }
        },
        async changePermission(){
            setTimeout(() => {
                let role_id = this.listgroup.role_id;
                this.GetDanhSachNhomMenuChuaGan(role_id)
                this.GetDanhSachNhomMenuDaGan(role_id)
                this.getDanhSachNguoiDungChuaGan(role_id)
                this.getDanhSachNguoiDungDaGan(role_id)
            }, 500);
            
        },

        async GetDanhSachNhomMenuChuaGan(data){
           try{
                this.DanhSachNhomMenuChuaGan=[]
                let response = await PermisionAPI.GetDanhSachNhomMenuChuaGan(this.axios, data)
                if(response.data.success){
                    this.DanhSachNhomMenuChuaGan = response.data.data
                }else{
                    this.$root.toastError(response.data.message.toString())
                }
           }catch(error){
                this.$root.toastError(error.message.toString())
            }
        },
        async GetDanhSachNhomMenuDaGan(data){
           try{
                this.DanhSachNhomMenuDaGan=[]
                let response = await PermisionAPI.GetDanhSachNhomMenuDaGan(this.axios, data)
                if(response.data.success){
                    this.DanhSachNhomMenuDaGan = response.data.data
                }else{
                    this.$root.toastError(response.data.message.toString())
                }
           }catch(error){
                this.$root.toastError(error.message.toString())
            }
        },
        async onCheckNhomMenuChuaGan(data){
            this.DataCheckNhomMenuChuaGan = data
        },
        async addRolePermission(){
            var listCheckNhomMenuChuaGan=[];
   
            var arrlistCheckNhomMenuChuaGan = this.DataCheckNhomMenuChuaGan
            if(arrlistCheckNhomMenuChuaGan.length == 0){
                this.$root.toastError("Bạn chưa chọn dữ liệu để gán")
            }else{
                arrlistCheckNhomMenuChuaGan.forEach((element) => {
                  let item ={
                        role_id: this.listgroup.role_id,
                        category_id: element.category_id
                    }
                    listCheckNhomMenuChuaGan.push(item)
                });
                let response = await PermisionAPI.addRolePermission(this.axios, listCheckNhomMenuChuaGan)
                if(response.data.success){
                    this.$root.toastSuccess(response.data.message.toString())
                    this.GetDanhSachNhomMenuChuaGan(this.listgroup.role_id)
                    this.GetDanhSachNhomMenuDaGan(this.listgroup.role_id)
                }else{
                    this.$root.toastError(response.data.message.toString())
                }
            }
        },
        async onCheckNhomMenuDaGan(data){
            this.DataCheckNhomMenuDaGan = data
            console.log( this.DataCheckNhomMenuDaGan)
        },
        async deleteRolePermission(){
            let listCheckNhomMenuDaGan=[]
            let arrlistCheckNhomMenuDaGan = this.DataCheckNhomMenuDaGan
            if(arrlistCheckNhomMenuDaGan.length == 0){
                this.toastError("Bạn chưa chọn dữ liệu để gán")
            }else{
                arrlistCheckNhomMenuDaGan.forEach((element) => {
                  let item ={
                        role_id: this.listgroup.role_id,
                        category_id: element.category_id
                    }
                    listCheckNhomMenuDaGan.push(item)
                });
                let response = await PermisionAPI.removeRolePermission(this.axios, listCheckNhomMenuDaGan)
                if(response.data.success){
                    this.$root.toastSuccess(response.data.message.toString())
                    this.GetDanhSachNhomMenuChuaGan(this.listgroup.role_id)
                    this.GetDanhSachNhomMenuDaGan(this.listgroup.role_id)
                }else{
                    this.$root.toastError(response.data.message.toString())
                }
            }
        },
        async getDanhSachNguoiDungChuaGan(data){
           try{
                this.DanhSachNguoiDungChuaGan=[]
                let response = await PermisionAPI.GetDanhSachNguoiDungChuaGan(this.axios, data)
                if(response.data.success){
                    this.DanhSachNguoiDungChuaGan = response.data.data
                }else{
                    this.$root.toastError(response.data.message.toString())
                }
           }catch(error){
                this.$root.toastError(error.message.toString())
            }
        },
        async getDanhSachNguoiDungDaGan(data){
           try{
                this.DanhSachNguoiDungDaGan=[]
                let response = await PermisionAPI.getDanhSachNguoiDungDaGan(this.axios, data)
                if(response.data.success){
                    this.DanhSachNguoiDungDaGan = response.data.data
                }else{
                    this.$root.toastError(response.data.message.toString())
                }
           }catch(error){
                this.$root.toastError(error.message.toString())
            }
        },

        async onCheckNguoiDungChuaGan(data){
            this.DataCheckNguoiChuaGan = data
        },
        async onCheckNguoiDungDaGan(data){
            this.DataCheckNguoiDaGan = data
        },

        async addEmployPermission(){
            var listNguoiDungChuaGan=[];
   
            var arrNguoiDungChuaGan = this.DataCheckNguoiChuaGan
            if(arrNguoiDungChuaGan.length == 0){
                this.$root.toastError("Bạn chưa chọn dữ liệu để gán")
            }else{
                arrNguoiDungChuaGan.forEach((element) => {
                  let item ={
                        role_id: parseFloat(this.listgroup.role_id),
                        employer_id: element.employer_id
                    }
                    listNguoiDungChuaGan.push(item)
                });
                let response = await PermisionAPI.insertEmployPermission(this.axios, listNguoiDungChuaGan)
                if(response.data.success){
                    this.$root.toastSuccess(response.data.message.toString())
                    this.getDanhSachNguoiDungChuaGan(this.listgroup.role_id)
                    this.getDanhSachNguoiDungDaGan(this.listgroup.role_id)
                }else{
                    this.$root.toastError(response.data.message.toString())
                }
            }
        },
        async removeEmployPermission(){
            let listCheckNguoiDungDaGan=[]
            let arrNguoiDungDaGan = this.DataCheckNguoiDaGan
            let roleID = this.listgroup.role_id
            if(arrNguoiDungDaGan.length == 0){
                this.toastError("Bạn chưa chọn dữ liệu để gán")
            }else{
                arrNguoiDungDaGan.forEach((element) => {
                  let item ={
                        role_id: roleID,
                        employer_id: element.employer_id
                    }
                    listCheckNguoiDungDaGan.push(item)
                });
                let response = await PermisionAPI.removeEmployPermission(this.axios, listCheckNguoiDungDaGan)
                if(response.data.success){
                    this.$root.toastSuccess(response.data.message.toString())
                    this.getDanhSachNguoiDungChuaGan(roleID)
                    this.getDanhSachNguoiDungDaGan(roleID)
                }else{
                    this.$root.toastError(response.data.message.toString())
                }
            }
        },
    },
    components:{
        KTable,
    }
}
</script>

<style>

</style>
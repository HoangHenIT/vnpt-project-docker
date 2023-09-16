<template>
    <div class="main-wrapper">
        <div class="box-form">
            <div class="info-row marb0">
                <div class="key w150">Nhóm người dùng</div>
                <div class="value">
                    <div class="select-custom" >
                        <select2 v-model="listgroup.role_id" :options="this.listgroup" ></select2>
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
                                    <div class="info-row">
                                        <div class="key w150">ID Menu</div>
                                        <div class="value">
                                            <!-- <input type="text" disabled v-model="categorymenu.category_id" class="form-control"> -->
                                        </div>
                                    </div>
                                </div>    
                            </div>
                        </div>
                    </div>
                    <div class="box-move-select-table">
                        <div class="actions">
                            <button class="btn btn-main">
                                <span class="fa fa-plus"> </span>
                            </button>
                            <button class="btn btn-main">
                                <span class="fa fa-plus"></span>
                            </button>
                        </div>
                    </div>
                    <div class="box-col box-form marb0" id="boxRight">
                        <div class="legend-title">Nhóm menu chưa gán</div>
                        <div class="form-control text h-auto">
                            <div class="tree-plus" style="height: 740px;overflow:auto;">
                                <div class="col-12">
                                    <div class="info-row">
                                        <div class="key w150">ID Menu</div>
                                        <div class="value">
                                            <!-- <input type="text" disabled v-model="categorymenu.category_id" class="form-control"> -->
                                        </div>
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
                                    <div class="info-row">
                                        <div class="key w150">ID Menu</div>
                                        <div class="value">
                                            <!-- <input type="text" disabled v-model="categorymenu.category_id" class="form-control"> -->
                                        </div>
                                    </div>
                                </div>    
                            </div>
                        </div>
                    </div>
                    <div class="box-move-select-table">
                        <div class="actions">
                            <button class="btn btn-main">
                                <span class="fa fa-plus"> </span>
                            </button>
                            <button class="btn btn-main">
                                <span class="fa fa-plus"></span>
                            </button>
                        </div>
                    </div>
                    <div class="box-col box-form marb0" id="boxRight1">
                        <div class="legend-title">Nhân viên chưa gán</div>
                        <div class="form-control text h-auto">
                            <div class="tree-plus" style="height: 740px;overflow:auto;">
                                <div class="col-12">
                                    <div class="info-row">
                                        <div class="key w150">ID Menu</div>
                                        <div class="value">
                                            <!-- <input type="text" disabled v-model="categorymenu.category_id" class="form-control"> -->
                                        </div>
                                    </div>
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
import KTableVue from '../../../../share/tablecpn/KTable.vue'
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
            listCategory:[],
            listMenu:[],
            sentRowCategory:[],
            listgroup:[],
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
            }else{
                this.$root.toastError(response.data.message.toString())
            }
          }catch(error){
            this.$root.toastError(error.message.toString())
          }
        },
    },
    components:{
        KTableVue
    }
}
</script>

<style>

</style>
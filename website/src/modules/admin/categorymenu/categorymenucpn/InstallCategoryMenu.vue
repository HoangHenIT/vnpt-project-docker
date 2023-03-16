<template>
    <div class="row">
        <div class="col-12">
            <div class="box-form">
                <div class="legend-title">Nhập thông tin menu</div>
                <div class="list-actions-top">
                        <ul class="list">
                            <li >
                                <a >
                                    <span class="icon one-save" ></span>Ghi lại
                                </a>
                            </li>
                            <li>
                                <a href="#">
                                    <span class="icon nc-icon-glyph ui-1_circle-remove"></span>Hủy
                                </a>
                            </li>
                            
                        </ul>
                    </div>
                <div class="row">
                    <div class="col-lg-6 col-sm-6 col-12">
                        <div class="info-row">
                            <div class="key w150">ID Menu</div>
                            <div class="value">
                                <input type="text" disabled class="form-control">
                            </div>
                        </div>
                    </div>    
                    <div class="col-lg-6 col-sm-6 col-12">
                        <div class="info-row">
                            <div class="key w150">Tên Menu</div>
                            <div class="value">
                                <input type="text" class="form-control" v-model="categorymenu.category_name">
                            </div>
                        </div>
                    </div>   
                </div>
                <div class="row">
                    <div class="col-lg-6 col-sm-6 col-12">
                        <div class="info-row">
                            <div class="key w150">Đường dẫn menu Menu</div>
                            <div class="value">
                                <input type="text" class="form-control" v-model="categorymenu.category_link">
                            </div>
                        </div>
                    </div>  
                    <div class="col-lg-6 col-sm-6 col-12">
                        <div class="info-row marb0">
                            <div class="key bold red nowrap">Cấp menu</div>
                            <div class="value">
                                <div class="select-custom" >
                                    <select2 v-model="categorymenu.category_level" :options="this.listCapMenu" ></select2>
                                </div>
                                    
                            </div>
                        </div>
                    </div>    
                </div>
                <div class="row">
                    <div class="col-lg-6 col-sm-6 col-12">
                        <div class="info-row">
                            <div class="key w150">Icon menu</div>
                            <div class="value">
                                <input type="text" class="form-control" v-model="categorymenu.category_icon">
                            </div>
                        </div>
                    </div>  
                    <div class="col-lg-6 col-sm-6 col-12">
                        <div class="info-row">
                            <div class="key w150">Ghi chú</div>
                            <div class="value">
                                <input type="text"  class="form-control" v-model="categorymenu.category_note">
                            </div>
                        </div>
                    </div>    
                </div>
                <div class="row">
                    <div class="col-lg-6 col-sm-6 col-12">
                        <div class="info-row marb0">
                            <div class="key bold red nowrap">Cấp menu</div>
                            <div class="value">
                                <div class="select-custom" >
                                    <select2 v-model="categorymenu.category_cha_id" :options="this.listMenuCha" ></select2>
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
import { arrCapMenu } from "../../../../constants"
import CategoryAPI from "../CategoryAPI"
export default {
    name:"Installcategorymenu",
    props:{
        ListMenu:{
            type:Object,
            default:()=>{}
        }
    },
    data(){
        return{
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
    mounted(){
        this.listCapMenu = arrCapMenu
        this.categorymenu.category_level = this.listCapMenu[0].id
        this.getCategoryFath()
    },
    methods:{
        async InsertCategory(){
            try{
                
                let response = await CategoryAPI.InsertCategory(this.axios, data)
            }catch(error){
                this.$root.toastError(error.message.toString())
            }
        },
        async getCategoryFath(){
            try{
                let response = await CategoryAPI.getCategoryFath(this.axios)
                if(response.data.success){
                    let data = response.data.data
                    this.listMenuCha = data.map(e=> ({id: e.category_id, text:  e.category_id +" - "+ e.category_name}))
                    if(this.listMenuCha.length > 0){
                        this.categorymenu.category_cha_id = this.listMenuCha[0].id
                    }
                }
            }catch(error){
                this.$root.toastError(error.message.toString())
            }
        }
         
    },
    components:{

    }
}
</script>

<style>

</style>
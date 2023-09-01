<template>
    <div class="row h-100">
        <div class="col-12">
            <div class="box-form h-100">
                <div class="legend-title">Nhập thông tin menu</div>
                <div class="list-actions-top">
                        <ul class="list">
                            <li @click="InsertCategory()">
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
                    <div class="col-12">
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
                                <input type="text" ref="inputName" class="form-control" v-model="categorymenu.category_name">
                            </div>
                        </div>
                    </div>   
                </div>
                <div class="row">
                    <div class="col-lg-6 col-sm-6 col-12">
                        <div class="info-row">
                            <div class="key w150">Đường dẫn menu Menu</div>
                            <div class="value">
                                <input type="text" ref="inputLink" class="form-control" v-model="categorymenu.category_link">
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
                            <div class="key bold red nowrap">Menu Cha</div>
                            <div class="value">
                                <div class="select-custom" >
                                    <select2 v-model="categorymenu.category_cha_id" :options="this.listMenuCha" > </select2>
                                </div>
                            </div>
                        </div>
                    </div>  
                    <div class="col-lg-6 col-sm-6 col-12">
                        <div class="info-row">
                            <div class="key w150">Vị trí</div>
                            <div class="value">
                                <input type="number"  class="form-control" v-model="categorymenu.position">
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
    },
    methods:{
        async InsertCategory(){
            
            try{
                if(this.categorymenu.category_name.trim() == ""){
                    this.$toast.warning("Bạn chưa nhập tên menu!");
                    this.$refs.inputName.focus()
                    return
                }
                if(this.categorymenu.category_link.trim() == ""){
                    this.$toast.warning("Bạn chưa nhập đường dẫn menu!");
                    this.$refs.inputLink.focus()
                    return
                }
                let data = {
                    category_name:this.categorymenu.category_name,
                    category_link:this.categorymenu.category_link,
                    category_level: this.categorymenu.category_level,
                    category_icon:this.categorymenu.category_icon,
                    category_note:this.categorymenu.category_note,
                    category_cha_id: this.categorymenu.category_cha_id,
                    position: this.categorymenu.position
                }
                let response = await CategoryAPI.InsertCategory(this.axios, data)
                if(response.data.success){
                    this.$root.toastSuccess(response.data.message)
                    // call cpn to cpn
                    this.$parent.$refs.loadDataCategory.getAllCategory()
                }
            }catch(error){
                this.$root.toastError(error.message.toString())
            }
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
       
         
    },
    components:{

    }
}
</script>

<style>

</style>
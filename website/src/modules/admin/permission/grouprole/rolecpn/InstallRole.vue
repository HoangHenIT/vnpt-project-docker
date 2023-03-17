<template>
     <div class="row w-100">
        <div class="col-sm-4 col-md-4 col-12">
            <div class="info-row">
                <div class="key w150">Tên nhóm quyền</div>
                <div class="value">
                    <input type="text" class="form-control" ref="inputName" v-model="role.role_name">
                </div>
            </div>
        </div>
        <div class="col-sm-8 col-md-8 col-12">
            <div class="info-row">
                <div class="key w150">Ghi chú</div>
                <div class="value">
                    <div class="select-custom">
                        <textarea type="text"  v-model="role.note" class="form-control"></textarea>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
import PermissionAPI from '../../PermissionAPI'
export default {
    name:"InstallRole",
   
    data(){
        return{
            role:{
                role_name:"",
                note: ""
            }
        }
    },
    // mounted(){
       
    // },
    methods:{
        async InstallRoles(){
            try{
                if(this.role.role_name.trim() == ""){
                    this.$toast.warning("Bạn chưa nhập nhóm quyền!");
                    this.$refs.inputName.focus()
                    return
                }
                let data = {
                    role_name: this.role.role_name,
                    note: this.role.note
                }
                let response = await PermissionAPI.InsertRoles(this.axios, data)
                if(response.data.success){
                    this.$toast.success(response.data.message)
                    this.$parent.$refs.tabList.getAllGroupRoles()
                }
            }catch(error){
                this.$root.toastError(error.message.toString())
            }
        }
    }
}
</script>

<style>

</style>
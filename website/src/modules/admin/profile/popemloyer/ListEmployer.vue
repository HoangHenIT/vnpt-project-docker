<template>
    <div class="row">
        <div class="col-12 pl-3 pr-3">
            <div class="row gutters-sm">
                <div class="col-sm-12 mb-6">
                    <div class="box-form">
                    <div class="legend-title">Lịch sử đăng nhập</div>
                    <div class="box-col">
                        <KTableVue
                        :columns="columnsHistory"
                        :dataSources="dataSources"
                        :allowFilter="true"
                        />
                    </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
import KTableVue from '../../../../share/tablecpn/KTable.vue'
import ProfileApi from '../ProfileApi'
export default {
    name:"ListEmployer",
    data(){
        return{
            columnsHistory:[
                {
                  field:'full_name',
                  label:'Họ và Tên',
                  allowFilter: true
                },
                {
                  field:'name_profile',
                  label:'Tên Profile',
                  allowFilter: true
                },
                 {
                  field:'job_name',
                  label:'Công việc',
                  allowFilter: true
                },
                {
                  field:'company',
                  label:'Công ty',
                  allowFilter: true
                },
                {
                  field:'email',
                  label:'Email',
                  allowFilter: true
                },
                {
                  field:'number_phone',
                  label:'Số điện thoại 1',
                  allowFilter: true
                },
                {
                  field:'mobile',
                  label:'Số điện thoại 2',
                  allowFilter: true
                },
                {
                  field:'username',
                  label:'Tài khoản',
                  allowFilter: true
                },
                {
                  field:'password',
                  label:'Mật khẩu',
                  allowFilter: true
                },
                {
                  field:'role_id',
                  label:'Nhóm quyền',
                  allowFilter: true
                },
                {
                  field:'role_name',
                  label:'Tên nhóm quyền',
                  allowFilter: true
                },
                {
                  field:'active',
                  label:'Trạng thái',
                  allowFilter: true
                },
                {
                  field:'address',
                  label:'Địa chỉ',
                  allowFilter: true
                },
                {
                  field:'link_website',
                  label:'Link website',
                  allowFilter: true
                },
                {
                  field:'link_git',
                  label:'Link git',
                  allowFilter: true
                },
                {
                  field:'link_facebook',
                  label:'Link mạng xã hội',
                  allowFilter: true
                }
            ],
            dataSources:[]
        }
    },
    mounted(){
        this.getAllEmployer()
    },
    methods:{
        showModal() {
            this.$refs["PopListEmployer"].show();
        },
        hideModal() {
            this.$refs["PopListEmployer"].hide();
        },
        async getAllEmployer(){
            try{
                let response = await ProfileApi.getAllEmployer(this.axios)
                if(response.data.success){
                    if(response.data.data.length > 0){
                        this.dataSources  = response.data.data;
                    }
                    else{
                        this.$toast.error(response.data.message);
                    }
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

<style scoped>
    @import url("../profile.css");
</style>
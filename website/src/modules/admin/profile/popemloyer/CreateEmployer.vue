<template>
    <b-modal ref="PopCreateEmployer" size="xl" hide-footer hide-header hide-header-close body-class="modal-body p-0">
    <div class="modal-content popup-box">
        <div class="popup-header">
            <div class="title"><span class="icon one-notepad"></span> Thêm mới người dùng</div>
            <div class="close -ap fa fa-times" aria-hidden="true" data-dismiss="modal" @click="hideModal()">
            </div>
        </div>
        <div class="list-actions-top">
            <ul class="list">
                <li >
                    <a v-on:click="insertEmployer">
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
        <div class="popup-body">
            <div class="box-form">
                <div class="legend-title">Thông tin người dùng</div>
                <div class="row p-3">
                    <div class="col-sm-6 col-12">
                        <div class="row">
                            <div class="col-sm-6 col-md-6 col-12">
                                <div class="info-row">
                                    <div class="key w150">Mã người dùng</div>
                                    <div class="value">
                                        <input type="text" disabled class="form-control">
                                    </div>
                                </div>
                            </div>
                            <div class="col-sm-6 col-md-6 col-12">
                                <div class="info-row">
                                    <div class="key w150">Tên người dùng</div>
                                    <div class="value">
                                        <div class="select-custom">
                                            <input type="text" ref="inputFullName" class="form-control" v-model="user.full_name">
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-6 col-md-6 col-12">
                                <div class="info-row">
                                    <div class="key w150">Tên Profile</div>
                                    <div class="value">
                                        <input type="text" class="form-control" v-model="user.name_profile">
                                    </div>
                                </div>
                            </div>
                            <div class="col-sm-6 col-md-6 col-12">
                                <div class="info-row">
                                    <div class="key w150">Số điện thoại 1</div>
                                    <div class="value">
                                        <div class="select-custom">
                                            <input type="text" class="form-control"  v-model="user.mobile">
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-6 col-md-6 col-12">
                                <div class="info-row">
                                    <div class="key w150">Email</div>
                                    <div class="value">
                                        <input type="text" ref="inputEmail" class="form-control" v-model="user.email">
                                    </div>
                                </div>
                            </div>
                            <div class="col-sm-6 col-md-6 col-12">
                                <div class="info-row">
                                    <div class="key w150">Số điện thoại 2</div>
                                    <div class="value">
                                        <div class="select-custom">
                                            <input type="text" class="form-control" v-model="user.number_phone">
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-6 col-md-6 col-12">
                                <div class="info-row">
                                    <div class="key w150">Tài khoản</div>
                                    <div class="value">
                                        <input type="text" ref="inputUsername" class="form-control" v-model="user.username">
                                    </div>
                                </div>
                            </div>
                            <div class="col-sm-6  col-md-6 col-12">
                                <div class="info-row">
                                    <div class="key w150">Mật khẩu</div>
                                    <div class="value">
                                        <div class="select-custom">
                                            <input type="password" class="form-control" v-model="user.password">
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        
                        <div class="row">
                            <div class="col-sm-6  col-md-6 col-12">
                                <div class="info-row marb0">
                                    <div class="key bold red nowrap">Quyền</div>
                                    <div class="value">
                                        <div class="select-custom" >
                                            <select2 v-model="user.role_id" :options="listRolers" ></select2>
                                        </div>
                                            
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-6 col-12">
                        <div class="info-row">
                            <div class="key w100">Tên công ty</div>
                            <div class="value">
                                <input type="text" class="form-control"  v-model="user.company">
                            </div>
                        </div>
                        <div class="info-row">
                            <div class="key w100">Địa chỉ</div>
                            <div class="value">
                                <input type="text" class="form-control" v-model="user.address">
                            </div>
                        </div>
                        <div class="info-row">
                            <div class="key w100">Link Facebook</div>
                            <div class="value">
                                <input type="text" class="form-control"  v-model="user.link_facebook">
                            </div>
                        </div>
                        <div class="info-row">
                            <div class="key w100">Link GitHub</div>
                            <div class="value">
                                <input type="text" class="form-control"  v-model="user.link_git">
                            </div>
                        </div>
                        <div class="info-row">
                            <div class="key w100">Link Website</div>
                            <div class="value">
                                <input type="text" class="form-control"  v-model="user.link_website">
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    </b-modal>
  
</template>

<script>
import ProfileApi from '../ProfileApi';
export default {
  name: "CreateEmployer",
  data() {
    return {
        listRolers:[],
        user:{
            full_name: "",
            name_profile: "",
            job_name: "",
            company: "",
            email: "",
            number_phone: "",
            mobile: "",
            username: "",
            password: "",
            role_id: "",
            active: "",
            address: "",
            link_website: "",
            link_git: "",
            link_facebook: "",
        }
    };
  },
  mounted(){
    this.getAllRoler()
  },
  methods: {
    showModal() {
      this.$refs["PopCreateEmployer"].show();
    },
    hideModal() {
      this.$refs["PopCreateEmployer"].hide();
    },
    // nối chuỗi email thêm đuôi
     validateEmail(email){
        var data = "";
        if(!email.endsWith('@gmail.com')){
            data = email + "@gmail.com"
        }else{
            data = email
        }
        return data;
        
    },
    async getAllRoler(){
        try{
            let response = await ProfileApi.getAllRoler(this.axios)
            if(response.data.success){
                let data = response.data.data;
                this.listRolers = data.map(e=> ({id: e.role_id, text: e.role_name}))
                if(this.listRolers.length > 0){
                    this.user.role_id = this.listRolers[0].id
                }
                else{
                    this.$toast.error(response.data.message);
                }
            }

        }catch(error){
            this.$root.toastError(error.message.toString())
        }
    },
    async insertEmployer(){
        try{
            if(this.user.full_name.trim() == ""){
                this.$toast.warning("Bạn chưa nhập Họ và Tên!");
                this.$refs.inputFullName.focus()
                return
            }
            if(this.user.email.trim() == ""){
                this.$toast.warning("Bạn chưa nhập Email!");
                this.$refs.inputEmail.focus()
                return
            }else{
                let email = this.validateEmail(this.user.email)
            }
            if(this.user.username.trim() == ""){
                this.$toast.warning("Bạn chưa nhập Tài khoảng đăng nhập!");
                this.$refs.inputUsername.focus()
                return
            }
            let data = {
                full_name: this.user.full_name,
                name_profile: this.user.name_profile,
                job_name: this.user.job_name,
                company: this.user.company,
                email: this.validateEmail(this.user.email),
                number_phone: this.user.number_phone,
                mobile: this.user.mobile,
                username: this.user.username,
                password: this.user.password == "" ? "Vnpt@2023": this.user.password,
                role_id: this.user.role_id,
                active: true,
                address: this.user.address,
                link_website: this.user.link_website,
                link_git: this.user.link_git,
                link_facebook: this.user.link_facebook,
            }
            let response = await ProfileApi.insertEmployers(this.axios, data)
            if(response.data.success){
                this.user = response.data.message
                this.$root.toastSuccess(response.data.message)
                this.$parent.$refs.refDataEmployer.getAllEmployer()
            }
            else{
                this.$root.toastError(response.data.message.toString())
            }
        }catch(error){
            this.$root.toastError(error.message.toString())
        }
    },
    
  },
};
</script>

<style>
  @import url("../profile.css");
 
</style>
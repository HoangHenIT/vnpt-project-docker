<template>
    <div class="box-login">
        <div class="head">
            ĐĂNG NHẬP
        </div>
        <div class="form" >
            <div class="form-group">
                <div class="input-icon">
                    <input type="text" placeholder="Tên đăng nhập" class="form-control" v-model="users.username">
                    <i class="fa fa-user icon " aria-hidden="true"></i>
                </div>
            </div>
            <div class="form-group mart15">
                <div class="input-icon -show">
                    <input type="password" placeholder="Mật khẩu" class="form-control" v-model="users.password">
                    <i class="fa fa-lock icon " aria-hidden="true"></i>
                    <span @click="showPass()"><i class=" icon-show" v-bind:class="[isActive ? 'fa fa-eye-slash' : 'fa fa-eye']" aria-hidden="true"></i></span>
                    <!-- <i class=" icon-show" aria-hidden="true"></i> -->
                </div>
            </div>
            <div class="actions">
                <button class="btn btn-main" >
                    Đăng nhập
                </button>
            </div>
            <!-- <div class="form-group mart10 marb0">
                Đăng nhập bằng tài khoản
            </div> -->
            <!-- <div class="form-group social-text center">
                <div class="social-media">
                    <a href="" class="social-icon">
                        <i class="fa fa-facebook" title="Facebook" aria-hidden="true"></i>
                    </a>
                    <a href="" class="social-icon">
                        <i class="fa fa-google " title="Google" aria-hidden="true"></i>
                    </a>
                    <a href="" class="social-icon">
                        <i class="fa fa-github" title="Github" aria-hidden="true"></i>
                    </a>
                </div> 
            </div> -->
            <div class="form-group mart0 marb0">
                Đăng ký tài khoản mới <a href="">Đăng ký</a>
            </div>
        </div>
    </div>
</template>

<script>
import { mapActions, mapState, mapGetters } from 'vuex';
import AuthApi from './LoginApi';
export default {
name:"Login",
data(){
    return{
        isActive: false,
        users:{
            username:'',
            password:''
        },
    }
},
computed: {
    ...mapState('user', [
        'accessToken'
    ]),
    ...mapGetters('user', [
        'isAuthenticated'
    ])
},
mounted(){
    
},
methods:{
    ...mapActions('user', [
        'login',
        'setCurrentUser',
        'setAccessInfo',
        'clearCurrentUser'
    ]),
    showPass() {
        this.isActive=!this.isActive
        var x = document.getElementById("myPass")
        if (x.type === "password") {
            x.type = "text"
        } else {
            x.type = "password";
        }
    },
    
}
}
</script>
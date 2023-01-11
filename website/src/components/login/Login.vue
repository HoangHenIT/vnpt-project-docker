<template>
    <div class="box-login">
        <div class="head">
            ĐĂNG NHẬP
        </div>
        <div class="form" >
            <div class="form-group">
                <div class="input-icon">
                    <input type="text" placeholder="Tên đăng nhập" class="form-control" ref="inputUsername" v-model="auth.username" @keyup.enter="btnLogin">
                    <i class="fa fa-user icon " aria-hidden="true"></i>
                </div>
            </div>
            <div class="form-group mart15">
                <div class="input-icon -show">
                    <input type="password" placeholder="Mật khẩu" id="myPass" class="form-control" ref="inputPassword" v-model="auth.password" @keyup.enter="btnLogin">
                    <i class="fa fa-lock icon " aria-hidden="true"></i>
                    <span @click="showPass()"><i class=" icon-show" v-bind:class="[isActive ? 'fa fa-eye-slash' : 'fa fa-eye']" aria-hidden="true"></i></span>
                    <!-- <i class=" icon-show" aria-hidden="true"></i> -->
                </div>
            </div>
            <div class="actions">
                <button class="btn btn-main" @click="btnLogin">
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
import AuthApi from './LoginApi';
export default {
    name:"Login",
    data(){
        return{
            isActive: false,
            auth:{
                username:'',
                password:''
            }
        }
    },
    computed: {
    
    },
    created(){
        // this.$root.context.logOut();
    },  
    mounted(){
        
    },
    methods:{
        showPass() {
            this.isActive=!this.isActive
            var x = document.getElementById("myPass")
            if (x.type === "password") {
                x.type = "text"
            } else {
                x.type = "password";
            }
        },
        // Đăng nhập
        async btnLogin(){
            // check don't input
            if(this.auth.username.trim() == ""){
                this.$root.toastInfo("Bạn chưa nhập tài khoản đăng nhập")
                return;
            }
            if(this.auth.password.trim() == ""){
                this.$root.toastInfo("Bạn chưa mật khẩu đăng nhập")
                return;
            }
            try{
                let data = {
                    'username': this.auth.username,
                    'password': this.auth.password
                }
                let response = await AuthApi.login(this.axios, data)
                if(response.data.success){
                    let token = response.data.data
                    this.$root.context.configApplication(token) // Save token in Local Storage
                    this.redirectToHome()
                }else{
                    this.$root.toastError(response.data.message)
                }
            }catch(error){
                this.$root.toastError(error.message)
            }
        },
        redirectToHome() {
            this.$router.push({ name: "Profile" });
        },

        
    }
}   
</script>
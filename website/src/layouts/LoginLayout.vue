<template>
    <div class="page">
        <div class="login-wrapper">
            <div class="logo">
                <div class="text">
                    Trung tâm công nghệ thông tin VNPT
                </div>
            </div>
		    <div class="bg" ></div>
                 <router-view/>
            <div class="copyright">
                Bản quyền &copy; Trung tâm công nghệ thông tin VNPT 2021
            </div>
        </div>
    </div>
</template>

<script>

import '../assets/css/style.css'
import "../assets/bootstrap/css/bootstrap.css"
import '../components/login/login.css'

export default {
    name:"LoginLayout"

}
</script>
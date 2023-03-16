<template>
    <div class="sidebars ">
        <div class="logo_details">
            <div class="image-content">
                <img src="../../assets/img/logo.png"  alt="profile">
            </div>
            <div class="name-job">
                <div class="profile-VNPT">
                    Công Nghệ Thông Tin
                </div>
            </div>
            <!-- <i class="fa fa-vk" aria-hidden="true"></i> -->
            <!-- <span class="logo_name">VNPT</span> -->
        </div>
        <div class="nav-links">
            <li>
                <a href="">
                    <i class="fa fa-tachometer" aria-hidden="true"></i>
                    <span class="link_name"> Dashboard</span>
                </a>
                
            </li>
            <li>
                <div class="icon_links">
                    <a href="">
                        <i class="fa fa-user" aria-hidden="true"></i>
                        <span class="link_name">  My User </span>
                    </a>
                    <i class="fa fa-angle-down arrow" aria-hidden="true"></i>
                </div>
                <ul class="sub-menu">
                    <li>
                        <a class="link_name" href="" >
                            My User
                        </a>
                    </li>
                    <li>
                        <a href="/admin/profile">
                            Profile User
                        </a>
                    </li>
                </ul>
            </li>
            <li>
                <div class="icon_links">
                    <a href="">
                        <i class="fa fa-user" aria-hidden="true"></i>
                        <span class="link_name"> Danh mục Menu </span>
                    </a>
                    <i class="fa fa-angle-down arrow" aria-hidden="true"></i>
                </div>
                <ul class="sub-menu">
                    <li>
                        <a class="link_name" href="" >
                            Danh mục Menu
                        </a>
                    </li>
                    <li>
                        <a href="/admin/categorymenu">
                            Danh mục Menu
                        </a>
                    </li>
                    <li>
                        <a href="/admin/permission">
                            Phân quyền
                        </a>
                    </li>
                </ul>
            </li>
            <li>
                <div class="icon_links">
                    <a href="">
                        <i class="fa fa-user" aria-hidden="true"></i>
                        <span class="link_name"> Theo dõi PTM </span>
                    </a>
                    <i class="fa fa-angle-down arrow" aria-hidden="true"></i>
                </div>
                <ul class="sub-menu">
                    <li>
                        <a class="link_name" href="" >
                            Theo dõi PTM
                        </a>
                    </li>
                    <li>
                        <a href="" >
                            PTM Fiber & MyTv
                        </a>
                    </li>
                    <li>
                        <a href="" >
                            BC chương trình hành động
                        </a>
                    </li>
                </ul>
            </li>
            <li>
                <div class="icon_links">
                    <a href="/#/vdds/doccomments">
                        <i class="fa fa-user" aria-hidden="true"></i>
                        <span class="link_name"> Doc comments</span>
                    </a>
                    <i class="fa fa-angle-down arrow" aria-hidden="true"></i>
                </div>
               
            </li>
            <li>
                <div class="icon_links">
                    <a href="/auth/login">
                        <i class="fa fa-user" aria-hidden="true"></i>
                        <span class="link_name"> Login</span>
                    </a>
                    <!-- <i class="fa fa-angle-down arrow" aria-hidden="true"></i> -->
                </div>
               
            </li>
            <li>
                <div class="profile-details">
                    
                    <div class="profile-content">
                        <img src="../../assets/img/bg4.jpg"  alt="profile">
                    </div>
                    <div class="name-job">
                        <div class="profile-name">
                            Tạ Văn Hoàng Hên
                        </div>
                        <div class="job">
                            Version 1.0.1
                        </div>
                    </div>
                    <i class="fa fa-sign-out" aria-hidden="true" title="Đăng xuất" @click="logOut"></i>
                </div>
            </li>
        </div>
    </div>
</template>

<script>
export default {
    name:"Sidebar",
    mounted() {
        this.changEventArrowMenu();
        this.changEventMenu();
    },
    methods: {
        changEventArrowMenu() {
        let arrow = document.querySelectorAll(".arrow");
        for(var i = 0; i< arrow.length; i++){
                arrow[i].addEventListener("click",(e)=>{
                    let arrowParent = e.target.parentElement.parentElement;
                    arrowParent.classList.toggle("showMenu")
                })
        }
        },
        changEventMenu(){
            let sidebars = document.querySelector(".sidebars")
            let sidebarsBars = document.querySelector(".fa-bars")
            sidebarsBars.addEventListener("click", () => {
                sidebars.classList.toggle("closed")
            })
        },
        logOut(){
            this.$root.context.logOut()
             this.$router.push({ name: "Login" })
        }
    },
}
</script>
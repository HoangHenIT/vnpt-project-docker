<template>
    <div class="main-home">
        <Sidebar></Sidebar>
        <div class="home-section">
            <Header></Header>
            <transition name="router-anim" >
                <router-view />
            </transition>
        </div>
        <Loader/>
        <SettingColor></SettingColor>
    </div>
</template>

<script>
    import "../assets/bootstrap/css/bootstrap.min.css";
    import "../assets/lib/font-awesome/css/font-awesome.css";
    import "../assets/css/style.css"
    import '../assets/lib/jquery/jquery-3.6.0.min.js';

    import Header from '../components/layout/Header.vue';
    import Sidebar from '../components/layout/Sidebar.vue';
    import SettingColor from '../components/layout/Setting.vue'
    import Loader from '../share/Loader.vue'
export default{
    name: "LayoutMain",
    data(){
        return{
        }
    },
    created(){
        // dùng xóa tabindex sử dụng cho select2
        this.$root.$on("bv::modal::shown", (bvEvent, modalId) => {
            for(let i =0; i< document.getElementsByClassName("modal-content").length; i++){
                document.getElementsByClassName("modal-content")[i].removeAttribute("tabindex");
            }
        });
    },
    mounted: function () {
        this.addCssFile("/static/vendor/font-awesome/css/font-awesome.min.css");
        this.addCssFile("/static/vendor/bootstrap/css/bootstrap.min.css");
        this.addCssFile("/static/css/style.css");
        this.addCssFile("../components/layout/Style.css");
    },
    components:{
        Header,
        Sidebar,
        SettingColor,
        Loader,
    },
    methods:{
        addCssFile: function (path) {
            let style = document.createElement("link");
            style.type = "text/css";
            style.rel = "stylesheet";
            style.href = path;
            document.head.appendChild(style);
        },
    }
}
</script>
<style  >
    @import url(../components/layout/Style.css);
    @import url(../assets/css/style.css);
</style>
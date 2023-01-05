<template>
    <div class="main-home">
        <Sidebar></Sidebar>
        <div class="home-section">
            <Header></Header>
            <transition name="router-anim" >
                <router-view />
            </transition>
        </div>
        <SettingColor></SettingColor>
    </div>
</template>

<script>
    import "../assets/bootstrap/css/bootstrap.min.css";
    import "../assets/lib/font-awesome/css/font-awesome.css";
    
    import "../assets/css/style.css"
    import '../assets/lib/jquery/jquery-3.6.0.min.js';
    import '../components/layout/style.css';
    import Header from '../components/layout/Header.vue';
    import Sidebar from '../components/layout/Sidebar.vue';
    import SettingColor from '../components/layout/Setting.vue'
export default{
    name: "LayoutMain",
    data(){
        return{
        }
    },
    created(){
        
    },
    mounted(){
        
    },
    components:{
        Header,
        Sidebar,
        SettingColor,
    },
    methods:{
        
    }
}
</script>
<style  scoped>
    @import url(../components/layout/Style.css);
    .loader-border{
        position: fixed !important;
    }
    ::-webkit-scrollbar {
        width: 10px;
    }

    /* Track */
    ::-webkit-scrollbar-track {
        background: #f1f1f1; 
    }
    
    /* Handle */
    ::-webkit-scrollbar-thumb {
        background: #0061f2; 
    }

    /* Handle on hover */
    ::-webkit-scrollbar-thumb:hover {
        background: #0061f2; 
    }
    
</style>
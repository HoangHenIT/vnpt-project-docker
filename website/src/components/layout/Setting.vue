<template>
    <div class="color-switcher">
        <div class="switcher-btn">
            <i class="fa fa-cog" aria-hidden="true"></i>
        </div>
        <h3>Màu nền</h3>
        <div class="Theme-buttons-container">
            <div class="d-flex" >
                <h6 class="">Màu nền</h6>
                <div class="form-check form-switch">
                    <span @click="changColor">
                        <input type="color" id="head" name="head" :value="colorBg" @change="changColor" class="input-color">
                    </span>
                </div>
            </div>
            <hr class="horizontal dark my-3">
            <div class="d-flex mart10" >
                <h6 class="">Màu Chữ</h6>
                <div class="form-check form-switch">
                    <span @click="changeColor">
                        <input type="color" id="head" name="head" :value="color" @change="changeColor" class="input-color">
                    </span>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
export default {
    name: "SettingColor",
    data(){
        return{
            colorBg: '#11101d',
            color: '#ffffff'
        }
    },
    components: {
       
    },
    mounted() {
        var bg = localStorage.getItem("bgTheme") ? localStorage.getItem("bgTheme") : "#11101d"
        document.documentElement.style.setProperty("--bgTheme", bg);
        this.showChangeColor();
        this.colorBg = localStorage.getItem("bgTheme")? localStorage.getItem("bgTheme"): "#11101d"

        var changeColor = localStorage.getItem("fontColor") ? localStorage.getItem("fontColor") : "#ffffff"
        document.documentElement.style.setProperty("--fontColor", changeColor);
        this.color = localStorage.getItem("fontColor")? localStorage.getItem("fontColor"): "#ffffff"
    },
    methods:{
        showChangeColor(){
            let switcherbtn = document.querySelector(".switcher-btn")
            let colorswitcher = document.querySelector(".color-switcher")
            switcherbtn.addEventListener("click", () => {
                colorswitcher.classList.toggle("active")
            })
        },
        changColor(event){
            document.documentElement.style.setProperty("--bgTheme", event.target.value)
            localStorage.setItem("bgTheme",event.target.value);
            this.colorBg= event.target.value;
        },
        changeColor(event){
            document.documentElement.style.setProperty("--fontColor", event.target.value)
            localStorage.setItem("fontColor",event.target.value);
            this.color= event.target.value;
        }
       
    }
}
</script>

<style>

</style>
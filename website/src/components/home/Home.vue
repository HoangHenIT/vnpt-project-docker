<template>
    <section>
      <div class="page-content">
        <div class="image-home"></div>
      </div>
    </section>
  
</template>

<script>
export default {
    name:"Home",
    data(){
      return{

      }
    },
    mounted(){
        if(this.$auth.getClientInfoFromStorage()){
          this.$root.context.logOut()
        }
    },
    methods:{

    }
}
</script>

<style>
  @import url("./home.css");
</style>
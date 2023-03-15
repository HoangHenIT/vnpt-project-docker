<template>
    <div class="row">
        <div class="col-12">
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
                                            <input type="text"  class="form-control" >
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>    
                </div>
            </div>
        </div>
    </div>
</template>

<script>
export default {
    name:"InstallCategoryMenu",
    data(){
        return{
            CategoryMenu:{
                category_id: "",
                category_name: "",
                category_level: "",
                category_link: "",
                category_icon: "",
                category_note: "",
                category_active: "",
                createday: "",
                category_cha_id: "",
                position: "",
            }
        }
    },
    // mounted:{

    // },
    methods:{

    },
    components:{

    }
}
</script>

<style>

</style>
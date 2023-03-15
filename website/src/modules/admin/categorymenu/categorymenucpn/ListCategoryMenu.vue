<template>
    <div class="row">
        <div class="col-12 pl-3 pr-3">
            <div class="row gutters-sm">
                <div class="col-sm-12 mb-6">
                    <div class="box-form">
                    <div class="legend-title">Danh sách menu</div>
                    <div class="box-col">
                        <KTableVue
                        :columns="columnsCategory"
                        :dataSources="listCategory"
                        :allowFilter="true"
                        />
                    </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
import KTableVue from '../../../../share/tablecpn/KTable.vue'
import CategoryAPI from '../CategoryAPI';
export default {
    name:"ListCategoryMenu",
    data(){
        return{
            columnsCategory:[
                {
                    field:'category_id',
                    label:'ID menu',
                    allowFilter: true
                },
                {
                    field:'category_name',
                    label:'Tên menu',
                    allowFilter: true
                },
                {
                    field:'category_link',
                    label:'Đường đẫn menu',
                    allowFilter: true
                },
                {
                    field:'category_icon',
                    label:'Icon menu',
                    allowFilter: true
                },
                {
                    field:'category_note',
                    label:'Ghi chú',
                    allowFilter: true
                },
                {
                    field:'position',
                    label:'Vị trí menu',
                    allowFilter: true
                },
                {
                    field:'category_level',
                    label:'Cấp menu',
                    allowFilter: true
                },
                {
                    field:'category_cha_id',
                    label:'ID menu cha',
                    allowFilter: true
                },
                {
                    field:'createday',
                    label:'Ngày tạo',
                    allowFilter: true
                }
                ,
                {
                    field:'category_active',
                    label:'Trạng thái',
                    allowFilter: true
                }
            ],
            listCategory:[]
        }
    },
    mounted(){
        this.getAllCategory()
    },
    methods:{
        async getAllCategory(){
            try{
                let response = await CategoryAPI.getAllCategory(this.axios)
                if(response.data.success){
                    response.data.data.forEach(element => {
                        let item ={
                            category_id: element.category_id,
                            category_name: element.category_name,
                            category_level: element.category_level,
                            category_link: element.category_link,
                            category_icon: element.category_icon,
                            category_note: element.category_note,
                            category_active: element.category_active == true?"Hoạt động":"Khóa",
                            createday: this.moment(element.createday).format("DD-MM-YYYY"),
                            category_cha_id: element.category_cha_id,
                            position: element.position
                        }
                        this.listCategory.push(item)
                    });
                }
                else{
                    this.$toast.success(response.data.message)
                }
            }catch(error){
                this.$root.toastError(error.message.toString())
            }
        }
    },
    components:{
        KTableVue
    }
}
</script>

<style>

</style>
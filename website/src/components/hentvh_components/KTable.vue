<template>
  <div>
    <div class="table-content" :style="{height:tableHeight==0?'auto':(tableHeight+'px')}">
      <table id="resizeMe" class="table-result table-gachle" >
        <thead class="center">
          <tr>
            <th></th>
            <th v-if="allowCheckBox&&labelCheckColumn">Chọn</th>

            <th v-if="allowCheckBox&&!labelCheckColumn">
              <div class="check-action">
                <input type="checkbox" class="check" v-model="allCheckbox" @change="allChangeCheckbox($event)"/>
                <span class="name"></span>
              </div>
            </th>

            <th v-for="item in columns" :key="item.field" :class="{w40: item.field.toLowerCase()=='stt'}">{{item.label}}</th>
          </tr>
          <tr v-if="allowFilter">
            <th ></th>

            <th v-if="allowCheckBox">
              <div class="check-action">
                <input type="checkbox" v-if="!labelCheckColumn" :disabled="true" class="check" />
                <input type="checkbox" v-else v-model="allCheckbox" @change="allChangeCheckbox($event)" class="check" />
                <span class="name"></span>
              </div>
            </th>

            <th v-for="item in columns" :key="item.field">
              <div v-if="item.allowFilter" class="input-icon-right">
                <!-- @change input after enter search -->
                <input type="text" class="form-control" @keyup="filterChange" v-model="filterValues[item.field]" />
                <span class="icon nc-icon-outline"><i class="fa fa-search" aria-hidden="true"></i> </span>
              </div>
            </th>
          </tr>
        </thead>

        <tbody>
          <tr v-for="(item, index) in pagerData"  :key="index" @click="onSelectedRow(fromIndexPage+index+1, item)" @dblclick="doubleClickRow(fromIndexPage+index+1, item)" :class="{highlight: rowSelected==fromIndexPage+index+1}">
            <td :class="{highlight1: (rowSelected==fromIndexPage+index+1)}">
                <span class="fa fa-play text-main" v-if="rowSelected==fromIndexPage+index+1"></span>
            </td>
            <td v-if="allowCheckBox" :class="{highlight1: (rowSelected==fromIndexPage+index+1)}">
              <div class="check-action">
                <input type="checkbox" class="check" v-model="item.checked" @change="onRowCheckChange($event, item)"/>
                <span class="name"></span>
              </div>
            </td>
            <!-- selected: (rowSelected==fromIndexPage+index+1),  -->
            <td v-for="(column, i) in columns" :key="i" :class="{highlight1: (rowSelected==fromIndexPage+index+1), w40: column.field.toLowerCase()=='stt', 'text-right': typeof item[column.field] === 'number'}">{{item[column.field]}}</td>
        
          </tr>
          <tr v-if="numberRecords==0" class="empty">
            <td :colspan="totalColumns" class="text-center">
              Không có bản ghi nào để hiển thị
            </td>
          </tr>

        </tbody>
      </table>
    </div>
    <BssPagination :totalRows = "numberRecords" @change="onChangePage" :optionsNumberRowPerPage="optionsNumberRowPerPage" :nowrap="nowrap"/>
  </div>
</template>
<script>
// callback
// onSelectedRow return item
// onRowSelectedIndex return index row begin 1
// doubleClickRow return item
// dataCheckeds return data is checked
import BssPagination from './BssPagination.vue'
export default {
    name:'k-table',
    props:{
        dataSources:{
            type:Array,
            default: ()=>[],
            required: true
        },
        // column exam
        // {
        //     field: "TEN_TAIKHOAN",
        //     label: "Tên tài khoản",
        //     allowFilter: true
        // }
        columns:{
            type:Array,
            default: ()=>[],
            required: true
        },
        optionsNumberRowPerPage:{
            type:Array,
            default: function () {
                return [10, 20]
            }
        },
        allowFilter:{
            type:Boolean,
            default:false
        },
        allowCheckBox:{
            type:Boolean,
            default:false
        },
        tableHeight:{
          //exm: 120px
          type:Number,
          default:0
        },
        nowrap:{
          type:Boolean,
          default: false
        },
        //begin 1-> size row
        rowSelectedIndex:{
          type:Number,
          default:-1
        },

        labelCheckColumn:{
          type:Boolean,
          default:false
        }

    },
    data(){
        return{
            filterValues:{},
            dataSourceFilters:this.dataSources,
            pagerData:[],
            fromIndexPage:0,
            rowSelected:this.rowSelectedIndex,
            allCheckbox:false,
            dataChecks:[]
        }
    },
    methods:{
        onChangePage(data){
         // { currentPage: this.currentPage, perPage: this.perPage }
            if(data.currentPage>0){
             
              let to=data.currentPage*data.perPage
              let from =to-data.perPage
              this.fromIndexPage=from
              this.pagerData=this.dataSourceFilters.slice(from, to)
            }else{
              this.pagerData=[]
            }
           
        },
        onSelectedRow(rowIndex, item){
          this.rowSelected=rowIndex
          this.$emit('onSelectedRow', item)
          this.$emit('onRowSelectedIndex', this.rowSelected)
        },
        doubleClickRow(rowIndex, item){
          this.$emit('doubleClickRow', item)
        },
        filterChange(){
          self=this;
          this.dataSourceFilters=this.dataSources.filter((item)=>{
            var result=true;
            self.columns.forEach((column)=>{
              if(column.allowFilter&&self.filterValues[column.field]){
                result=result&&((item[column.field]!=null?item[column.field].toString().trim().toLowerCase():"").indexOf(self.filterValues[column.field].toString().trim().toLowerCase())>-1)
              }
            })
            return result;
          })
        },
        allChangeCheckbox(event){
          if (event.target.checked) {
            this.dataChecks=[]
            this.dataSources.forEach((item)=>{
              item.checked=true
              this.dataChecks.push(item)
            }) 
            this.$emit('dataCheckeds',this.dataChecks)
          }else{
            this.dataSources.forEach((item)=>{
              item.checked=false
            })
            this.dataChecks=[]
            this.$emit('dataCheckeds',this.dataChecks)
          }
        },
        onRowCheckChange(event, item){
           if (event.target.checked) {
             this.dataChecks.push(item)
           }else{
             const index = this.dataChecks.indexOf(item);
             if (index > -1) {
               this.dataChecks.splice(index, 1);
             }
           }
           this.allCheckbox=false
           this.$emit('dataCheckeds',this.dataChecks)
        },
     
        
    },
    watch: { 
      	dataSources: function(newVal, oldVal) { // watch it
           newVal.forEach((item)=>{
             item.checked=false
           })
           this.pagerData=[]

           this.dataSourceFilters=newVal 

           //reset filter
           this.filterValues={
             
           }
           this.dataChecks=[]
           this.rowSelected=this.rowSelectedIndex
           this.allCheckbox=false
        },
        rowSelectedIndex(val){
          this.rowSelected=val
        }
    },
    computed:{
      numberRecords(){
        return this.dataSourceFilters.length;
      },
      totalColumns(){
          var total=this.columns.length+1
          if(this.allowCheckBox)
            return total+1
          return total
      },
      // funRes(){
      //     debugger
      //     const table = document.getElementById('resizeMe');
      //     const cols = table.querySelectorAll('th');
      //     [].forEach.call(cols, function (col) {
      //         const resizer = document.createElement('div');
      //         resizer.classList.add('resizer');
      //         resizer.style.height = `${table.offsetHeight}px`;
      //         col.appendChild(resizer);
      //         let x = 0;
      //         let w = 0;
      //         const mouseDownHandler = function (e) {
      //           x = e.clientX;
      //           const styles = window.getComputedStyle(col);
      //           w = parseInt(styles.width, 10);
      //           document.addEventListener('mousemove', mouseMoveHandler);
      //           document.addEventListener('mouseup', mouseUpHandler);
      //         }
      //         const mouseMoveHandler = function (e) {
      //           const dx = e.clientX - x;
      //           col.style.width = `${w + dx}px`;
      //         };
      //         const mouseUpHandler = function () {
      //             document.removeEventListener('mousemove', mouseMoveHandler);
      //             document.removeEventListener('mouseup', mouseUpHandler);
      //         };
      //         resizer.addEventListener('mousedown', mouseDownHandler);
      //     });
      //   },

    },
    mounted(){
      // this.funRes();
    },
    components:{
        BssPagination
    },
}
</script>
<style scoped>

</style>
<template>
    <div class="row">
        <div class="col-md-4 mb-3">
        <div class="card">
          <div class="card-body">
            <div class="d-flex flex-column align-items-center text-center">
              <img
                src="https://bootdey.com/img/Content/avatar/avatar7.png"
                alt="Admin"
                class="rounded-circle"
                width="150"
              />
              <div class="mt-3 txt-tf">
                <h4>{{this.employer.name_profile}}</h4>
                <p class="text-secondary mb-1 ">{{this.employer.job_name}}</p>
                <p class="text-muted font-size-sm "> {{this.employer.company}} </p>
                <!-- <button class="btn btn-primary">Follow</button>
                     <button class="btn btn-outline-primary">Message</button> -->
              </div>
            </div>
          </div>
        </div>
        <div class="card mt-3">
          <ul class="list-group list-group-flush">
            <li class="list-group-item d-flex justify-content-between align-items-center flex-wrap">
              <h6 class="mb-0">
                <i class="fa fa-internet-explorer f24" aria-hidden="true"></i>
                Website
              </h6>
              <span class="text-secondary">{{this.employer.link_website}}</span>
            </li>
            <li class="list-group-item d-flex justify-content-between align-items-center flex-wrap">
              <h6 class="mb-0">
                <i class="fa fa-github f24" aria-hidden="true"></i> Github
              </h6>
              <span class="text-secondary">{{this.employer.link_git}}</span>
            </li>
            <li class="list-group-item d-flex justify-content-between align-items-center flex-wrap">
              <h6 class="mb-0">
                <i class="fa fa-facebook f24" aria-hidden="true"></i> Facebook
              </h6>
              <span class="text-secondary">{{this.employer.link_facebook}}</span>
            </li>
          </ul>
        </div>
      </div>
      <div class="col-md-8">
        <div class="card mb-3">
          <div class="card-body">
            <div class="row">
              <div class="col-sm-3">
                <h6 class="mb-0">Full Name</h6>
              </div>
              <div class="col-sm-9 text-secondary txt-tf">{{this.employer.full_name}}</div>
            </div>
            <hr />
            <div class="row">
              <div class="col-sm-3">
                <h6 class="mb-0">Email</h6>
              </div>
              <div class="col-sm-9 text-secondary">{{this.employer.email}}</div>
            </div>
            <hr />
            <div class="row">
              <div class="col-sm-3">
                <h6 class="mb-0">Phone</h6>
              </div>
              <div class="col-sm-9 text-secondary">{{this.employer.number_phone}}</div>
            </div>
            <hr />
            <div class="row">
              <div class="col-sm-3">
                <h6 class="mb-0">Mobile</h6>
              </div>
              <div class="col-sm-9 text-secondary">{{this.employer.mobile}}</div>
            </div>
            <hr />
            <div class="row">
              <div class="col-sm-3">
                <h6 class="mb-0">Address</h6>
              </div>
              <div class="col-sm-9 text-secondary txt-tf">
                {{this.employer.address}}
              </div>
            </div>
            <hr />
            <!-- <div class="row">
                    <div class="col-sm-12">
                      <a class="btn btn-info " target="__blank" href="">Edit</a>
                    </div>
                  </div> -->
          </div>
        </div>

        <div class="row gutters-sm">
          <div class="col-sm-12 mb-6">
            <div class="box-form">
              <div class="legend-title">Lịch sử đăng nhập</div>
              <div class="box-col">
                <KDataGrid
                  :columns="columnsHistory"
                  :dataSource="dataSourcesGan"
                  :showColumnCheckbox="true"
                  :enable-paging-server="false"
                  :allowPaging="true"
                  :showFilter="true"
                  ref="gridDaGan"
                  :enabledSelectFirstRow="false"
                  panelDataHeight="160px"/>
              </div>
            </div>
            <!-- <div class="card h-100">
              <div class="card-body">
                <h6 class="d-flex align-items-center mb-3">
                  <i class="material-icons text-info mr-2">assignment</i>Project
                  Status
                </h6>
                <small>Web Design</small>
                <div class="progress mb-3" style="height: 5px">
                  <div class="progress-bar bg-primary" role="progressbar" style="width: 80%" aria-valuenow="80" aria-valuemin="0" aria-valuemax="100"></div>
                </div>
                <small>Website Markup</small>
                <div class="progress mb-3" style="height: 5px">
                  <div
                    class="progress-bar bg-primary"
                    role="progressbar"
                    style="width: 72%"
                    aria-valuenow="72"
                    aria-valuemin="0"
                    aria-valuemax="100"
                  ></div>
                </div>
                <small>One Page</small>
                <div class="progress mb-3" style="height: 5px">
                  <div
                    class="progress-bar bg-primary"
                    role="progressbar"
                    style="width: 89%"
                    aria-valuenow="89"
                    aria-valuemin="0"
                    aria-valuemax="100"
                  ></div>
                </div>
                <small>Mobile Template</small>
                <div class="progress mb-3" style="height: 5px">
                  <div
                    class="progress-bar bg-primary"
                    role="progressbar"
                    style="width: 55%"
                    aria-valuenow="55"
                    aria-valuemin="0"
                    aria-valuemax="100"
                  ></div>
                </div>
                <small>Backend API</small>
                <div class="progress mb-3" style="height: 5px">
                  <div
                    class="progress-bar bg-primary"
                    role="progressbar"
                    style="width: 66%"
                    aria-valuenow="66"
                    aria-valuemin="0"
                    aria-valuemax="100"
                  ></div>
                </div>
              </div>
            </div> -->
          </div>
          
        </div>
      </div>
    </div>
</template>

<script>
import ProfileApi from '../ProfileApi'
import KDataGrid from '@/components/hentvh_components/KDataGrid'
export default {
    name:"ProfileInfo",
    data(){
      return{
        employer: [],
        listHistory: [],
        columnsHistory:[
                {
                    fieldName:'full_name',
                    headerText:'Họ và Tên',
                    allowFiltering:true,
                    width:100
                },
                {
                    fieldName:'username',
                    headerText:'Mã đăng nhập',
                    allowFiltering:true,
                    width:100
                },
                 {
                    fieldName:'system_login',
                    headerText:'Tên máy tính',
                    allowFiltering:true,
                    width:100
                },
                {
                    fieldName:'datetime_login',
                    headerText:'Ngày giờ đăng nhập',
                    allowFiltering:true,
                    width:100
                },
                {
                    fieldName:'ten_dv',
                    headerText:'Đơn vị',
                    allowFiltering:true,
                    width:100
                }
            ],
            dataSourcesGan:[],
      }
    },
    mounted(){
       this.getEmployerInfo()
       this.getHistoryLoginInEmployer()
    },
    methods:{
        getEmployerInfo(){
          this.employer = this.$auth.getEmployerToken();
        },
        async getHistoryLoginInEmployer(){
          // debugger
          let data = {
            employer_id: this.$auth.getEmployerId(),
            startDate: "01/01/2023",
            endDate: "14/01/2023",
          }
          console.log(data)
          let response = await ProfileApi.getHistoryLoginInEmployer(this.axios, data)
          if(response.data.success){
            this.dataSourcesGan = response.data.data;
          }
        }
    },
    components:{
      KDataGrid
    }
}
</script>

<style>
  
</style>
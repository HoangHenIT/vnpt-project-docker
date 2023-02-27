<template>
    <b-modal ref="PopCreateEmployer" size="xl" hide-footer hide-header hide-header-close body-class="modal-body p-0">
    <div class="modal-content popup-box">
        <div class="popup-header">
            <div class="title"><span class="icon one-notepad"></span> Thêm mới người dùng</div>
            <div class="close -ap fa fa-times" aria-hidden="true" data-dismiss="modal" @click="$refs['PopCreateEmployer'].hide()">
            </div>
        </div>
        <div class="list-actions-top">
            <ul class="list">
                <li>
                    <a href="#">
                        <span class="icon one-save"></span>Ghi lại
                    </a>
                </li>
                <li>
                    <a href="#">
                        <span class="icon nc-icon-glyph ui-1_circle-remove"></span>Hủy
                    </a>
                </li>
                
            </ul>
        </div>
        <div class="popup-body">
            <div class="box-form">
                <div class="legend-title">Thông tin người dùng</div>
                <div class="row">
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
                                            <input type="text" class="form-control">
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-6 col-md-6 col-12">
                                <div class="info-row">
                                    <div class="key w150">Tên Profile</div>
                                    <div class="value">
                                        <input type="text" class="form-control">
                                    </div>
                                </div>
                            </div>
                            <div class="col-sm-6 col-md-6 col-12">
                                <div class="info-row">
                                    <div class="key w150">Số điện thoại 1</div>
                                    <div class="value">
                                        <div class="select-custom">
                                            <input type="text" class="form-control">
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-6 col-md-6 col-12">
                                <div class="info-row">
                                    <div class="key w150">Email</div>
                                    <div class="value">
                                        <input type="text" disabled class="form-control">
                                    </div>
                                </div>
                            </div>
                            <div class="col-sm-6 col-md-6 col-12">
                                <div class="info-row">
                                    <div class="key w150">Số điện thoại 2</div>
                                    <div class="value">
                                        <div class="select-custom">
                                            <input type="text" class="form-control">
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-6 col-md-6 col-12">
                                <div class="info-row">
                                    <div class="key w150">Tài khoản</div>
                                    <div class="value">
                                        <input type="text" class="form-control">
                                    </div>
                                </div>
                            </div>
                            <div class="col-sm-6  col-md-6 col-12">
                                <div class="info-row">
                                    <div class="key w150">Mật khẩu</div>
                                    <div class="value">
                                        <div class="select-custom">
                                            <input type="text" class="form-control">
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        
                        <div class="row">
                            <div class="col-sm-6  col-md-6 col-12">
                                <div class="info-row marb0">
                                    <div class="key bold red nowrap">Quyền</div>
                                    <div class="value">
                                        <div class="select-custom" >
                                            <select2
                                                :options="listbox.map(e=> ({id: e.id, text: e.text}))" >
                                            </select2>
                                        </div>
                                            
                                    </div>
                                </div>
                            </div>
                            <div class="col-sm-6  col-md-6 col-12">
                                <div class="info-row">
                                    <div class="key w150">Trạng thái</div>
                                    <div class="value">
                                        <input type="text" class="form-control">
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-6 col-12">
                        <div class="info-row">
                            <div class="key w100">Tên công ty</div>
                            <div class="value">
                                <input type="text" class="form-control">
                            </div>
                        </div>
                        <div class="info-row">
                            <div class="key w100">Địa chỉ</div>
                            <div class="value">
                                <input type="text" class="form-control">
                            </div>
                        </div>
                        <div class="info-row">
                            <div class="key w100">Link Facebook</div>
                            <div class="value">
                                <input type="text" class="form-control">
                            </div>
                        </div>
                        <div class="info-row">
                            <div class="key w100">Link GitHub</div>
                            <div class="value">
                                <input type="text" class="form-control">
                            </div>
                        </div>
                        <div class="info-row">
                            <div class="key w100">Link Website</div>
                            <div class="value">
                                <input type="text" class="form-control">
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    </b-modal>
  
</template>

<script>
export default {
  name: "CreateEmployer",
  data() {
    return {
        listbox:[{
            id:"1",
            text: "Admin"
        },{
            id:"2",
            text: "Username"
        }]
    };
  },
//   created(){
//     this.$root.$on("bv::modal::shown", (bvEvent, modalId) => {
//         for(let i =0; i< document.getElementsByClassName("modal-content").length; i++){
//             document.getElementsByClassName("modal-content")[i].removeAttribute("tabindex");
//         }
//         // document.getElementsByClassName("modal-content")[0].removeAttribute("tabindex");
//         // document.getElementsByClassName("modal-content")[1].removeAttribute("tabindex");
//         // document.getElementsByClassName("modal-content").forEach(function (v) {
//         //     v.removeAttribute("tabindex");
//         // });
//     });
//   },
  methods: {
    showModal() {
      this.$refs["PopCreateEmployer"].show();
    },
    hideModal() {
      this.$refs["PopCreateEmployer"].hide();
    },
    
  },
};
</script>

<style>
  @import url("../profile.css");
 
</style>
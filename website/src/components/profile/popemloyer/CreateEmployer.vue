<template>
    <b-modal ref="PopCreateEmployer" size="xl" 
    hide-footer hide-header hide-header-close body-class="modal-body p-0"
>
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
                        <div class="col-sm-6 col-md-12 col-12">
                            <div class="info-row">
                                <div class="key w150">Mã người dùng</div>
                                <div class="value">
                                    <input type="text" disabled class="form-control">
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-6 col-md-12 col-12">
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
                        <div class="col-sm-6 col-md-12 col-12">
                            <div class="info-row">
                                <div class="key w150">Tên Profile</div>
                                <div class="value">
                                    <input type="text" class="form-control">
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-6 col-md-12 col-12">
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
                        <div class="col-sm-6 col-md-12 col-12">
                            <div class="info-row">
                                <div class="key w150">Email</div>
                                <div class="value">
                                    <input type="text" disabled class="form-control">
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-6 col-md-12 col-12">
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
                        <div class="col-sm-6 col-md-12 col-12">
                            <div class="info-row">
                                <div class="key w150">Tài khoản</div>
                                <div class="value">
                                    <input type="text" class="form-control">
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-6  col-md-12 col-12">
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
                        <div class="col-sm-6 col-md-12 col-12">
                            <div class="info-row">
                                <div class="key w150">Quyền</div>
                                <div class="value">
                                    <div class="select-custom">
                                        <input type="text" class="form-control">
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-6  col-md-12 col-12">
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
    <!-- <div class="modal" id="PopCreateEmployer">
        <div class="modal-dialog">
            <div class="modal-content popup-box">
                <div class="popup-header">
                    <div class="title"><span class="icon one-notepad"></span> Sửa đổi thông tin cáp</div>
                    <div class="close -ap icon-close" data-dismiss="modal">
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
                        <div class="legend-title">Thông tin thuê bao</div>
                        <div class="row">
                            <div class="col-sm-6 col-12">
                                <div class="row">
                                    <div class="col-sm-6 col-12">
                                        <div class="info-row">
                                            <div class="key w100">Dịch vụ VT</div>
                                            <div class="value">
                                                <div class="select-custom">
                                                    <select name="" id="" class="form-control">
                                                        <option value=""></option>
                                                    </select>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-sm-6 col-12">
                                        <div class="info-row">
                                            <div class="key w60">Loại TB</div>
                                            <div class="value">
                                                <div class="select-custom">
                                                    <select name="" id="" class="form-control">
                                                        <option value=""></option>
                                                    </select>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="info-row">
                                    <div class="key w100">Số máy/Acc</div>
                                    <div class="value">
                                        <div class="input-more-button">
                                            <button class="btn">
                                                <span class="-ap icon-more_horiz"></span>
                                            </button>
                                            <input type="text" class="form-control highlight">
                                        </div>
                                    </div>
                                </div>
                                <div class="info-row">
                                    <div class="key w100">Trạng thái TB</div>
                                    <div class="value">
                                        <input type="text" class="form-control italic red" value="Hoạt động bình thường">
                                    </div>
                                </div>
                            </div>
                            <div class="col-sm-6 col-12">
                                <div class="info-row">
                                    <div class="key w100">Tên thuê bao</div>
                                    <div class="value">
                                        <input type="text" class="form-control">
                                    </div>
                                </div>
                                <div class="info-row">
                                    <div class="key w100">Địa chỉ LĐ</div>
                                    <div class="value">
                                        <input type="text" class="form-control">
                                    </div>
                                </div>
                                <div class="info-row">
                                    <div class="key w100">Ghi chú</div>
                                    <div class="value">
                                        <input type="text" class="form-control">
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="box-form">
                        <div class="row">
                            <div class="col-sm-6 col-12">
                                <div class="legend-title">Thông tin cáp mới</div>
                                <div class="row">
                                    <div class="col-sm-6 col-12">
                                        <div class="info-row">
                                            <div class="key w100">Loại cáp</div>
                                            <div class="value">
                                                <div class="select-custom">
                                                    <select name="" id="" class="form-control">
                                                        <option value=""></option>
                                                    </select>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-sm-6 col-12">
                                        <div class="info-row">
                                            <div class="key">Mã LT mới</div>
                                            <div class="value">
                                                <input type="text" class="form-control text-main highlight" value="0">
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-6 col-12">
                                        <div class="info-row">
                                            <div class="key w100">Tuyến cáp</div>
                                            <div class="value">
                                                <input type="text" class="form-control highlight" >
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-sm-6 col-12">
                                        <div class="info-row">
                                            <div class="key">Liên tủ</div>
                                            <div class="value">
                                                <input type="text" class="form-control highlight">
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-6 col-12">
                                        <div class="info-row">
                                            <div class="key w100">Hộp cáp ngọn</div>
                                            <div class="value">
                                                <input type="text" class="form-control highlight" >
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-sm-6 col-12">
                                        <div class="info-row">
                                            <div class="key">Cự ly (*)</div>
                                            <div class="value">
                                                <input type="text" class="form-control highlight">
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-6 col-12">
                                        <div class="info-row">
                                            <div class="key w100">Tủ cáp gốc (*)</div>
                                            <div class="value">
                                                <input type="text" class="form-control highlight" >
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-sm-6 col-12">
                                        <div class="info-row">
                                            <div class="key">Tủ cáp ngọn</div>
                                            <div class="value">
                                                <input type="text" class="form-control highlight">
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-6 col-12">
                                        <div class="info-row">
                                            <div class="key w100">Đôi cáp gốc (*)</div>
                                            <div class="value">
                                                <input type="text" class="form-control highlight" >
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-sm-6 col-12">
                                        <div class="info-row">
                                            <div class="key">Đôi cáp ngọn (*)</div>
                                            <div class="value">
                                                <input type="text" class="form-control highlight">
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-6 col-12">
                                        <div class="info-row">
                                            <div class="key w100">Cáp gốc (*)</div>
                                            <div class="value">
                                                <input type="text" class="form-control highlight" >
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-sm-6 col-12">
                                        <div class="info-row">
                                            <div class="key">Cáp ngọn (*)</div>
                                            <div class="value">
                                                <input type="text" class="form-control highlight">
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-sm-6 col-12">
                                <div class="legend-title">Thông tin cáp hiện tại</div>
                                <div class="row">
                                    <div class="col-sm-6 col-12">
                                        <div class="info-row">
                                            <div class="key w100">Loại cáp</div>
                                            <div class="value">
                                                <div class="select-custom">
                                                    <select name="" id="" class="form-control">
                                                        <option value=""></option>
                                                    </select>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-sm-6 col-12">
                                        <div class="info-row">
                                            <div class="key">Mã LT mới</div>
                                            <div class="value">
                                                <input type="text" class="form-control text-main" value="0">
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-6 col-12">
                                        <div class="info-row">
                                            <div class="key w100">Tuyến cáp</div>
                                            <div class="value">
                                                <input type="text" class="form-control" >
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-sm-6 col-12">
                                        <div class="info-row">
                                            <div class="key">Liên tủ</div>
                                            <div class="value">
                                                <input type="text" class="form-control">
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-6 col-12">
                                        <div class="info-row">
                                            <div class="key w100">Hộp cáp ngọn</div>
                                            <div class="value">
                                                <input type="text" class="form-control" >
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-sm-6 col-12">
                                        <div class="info-row">
                                            <div class="key">Cự ly</div>
                                            <div class="value">
                                                <input type="text" class="form-control">
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-6 col-12">
                                        <div class="info-row">
                                            <div class="key w100">Tủ cáp gốc</div>
                                            <div class="value">
                                                <input type="text" class="form-control" >
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-sm-6 col-12">
                                        <div class="info-row">
                                            <div class="key">Tủ cáp ngọn</div>
                                            <div class="value">
                                                <input type="text" class="form-control">
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-6 col-12">
                                        <div class="info-row">
                                            <div class="key w100">Đôi cáp gốc</div>
                                            <div class="value">
                                                <input type="text" class="form-control" >
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-sm-6 col-12">
                                        <div class="info-row">
                                            <div class="key">Đôi cáp ngọn</div>
                                            <div class="value">
                                                <input type="text" class="form-control">
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-6 col-12">
                                        <div class="info-row">
                                            <div class="key w100">Cáp gốc</div>
                                            <div class="value">
                                                <input type="text" class="form-control" >
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-sm-6 col-12">
                                        <div class="info-row">
                                            <div class="key">Cáp ngọn</div>
                                            <div class="value">
                                                <input type="text" class="form-control">
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
        
    </div> -->
</template>

<script>
export default {
  name: "CreateEmployer",
  data() {
    return {};
  },
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

<style scoped>
  @import url("../profile.css");
</style>
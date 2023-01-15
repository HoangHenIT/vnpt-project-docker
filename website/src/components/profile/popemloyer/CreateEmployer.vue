<template>
  <b-modal class="modal" ref="PopCreateEmployer">
        <div class="modal-dialog" style="width: 100%; max-width:1220px;">
            <div class="modal-content popup-box">
                <div class="popup-header">
                    <div class="title"><span class="icon one-notepad"></span> Thay đổi chủ quản</div>
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
                                <span class="icon nc-icon-glyph ui-1_circle-remove"></span>Huỷ
                            </a>
                        </li>
                        
                    </ul>
                </div>
                <div class="popup-body">
                    
                    <div class="box-form">
                        <div class="legend-title">Thông tin hợp đồng</div>
                        <div class="row">
                            <div class="col-sm-4 col-12">
                                <div class="info-row">
                                    <div class="key w100">Số máy/Acc</div>
                                    <div class="value">
                                        <div class="input-more-button">
                                            <button class="btn">
                                                <span class="-ap icon-more_horiz"></span>
                                            </button>
                                            <input type="text" class="form-control ">
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-sm-8 col-12">
                                <div class="info-row">
                                    <div class="key w100">Dịch vụ</div>
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
                        <div class="row">
                            <div class="col-sm-4 col-12">
                                <div class="info-row">
                                    <div class="key w100">Trạng thái TB</div>
                                    <div class="value">
                                        <input type="text" class="form-control ">
                                    </div>
                                </div>
                            </div>
                            <div class="col-sm-8 col-12">
                                <div class="info-row">
                                    <div class="key w100">Tên thuê bao</div>
                                    <div class="value">
                                        <input type="text" class="form-control ">
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-4 col-12">
                                <div class="info-row">
                                    <div class="key w100">Chủ quản</div>
                                    <div class="value">
                                        <div class="select-custom">
                                            <select name="" id="" class="form-control">
                                                <option value=""></option>
                                            </select>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-sm-8 col-12">
                                <div class="info-row">
                                    <div class="key w100">Địa chỉ TB</div>
                                    <div class="value">
                                        <input type="text" class="form-control ">
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-4 col-12">
                                <div class="info-row">
                                    <div class="key w100">Chủ quản LĐ</div>
                                    <div class="value">
                                        <div class="select-custom">
                                            <select name="" id="" class="form-control">
                                                <option value=""></option>
                                            </select>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-sm-8 col-12">
                                <div class="info-row">
                                    <div class="key w100">Địa chỉ LĐ(*)</div>
                                    <div class="value">
                                        <input type="text" class="form-control ">
                                    </div>
                                </div>
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
        </div>
    
    </b-modal>
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
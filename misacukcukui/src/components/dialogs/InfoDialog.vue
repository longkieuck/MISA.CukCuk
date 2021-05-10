<template>
    <div>
        <div class="dialog-box"></div>
        <div class="dialog-content">
            <div class="header-dialog-box">
                <div class="dialog-title">Thông tin nhân viên</div>
                <div class="option-user-box">
                    <a-checkbox>
                        Là khách hàng
                    </a-checkbox>
                    <a-checkbox>
                        Là nhà cung cấp
                    </a-checkbox>
                </div>
                <div class="top-right-option">
                    <div class="btn-help"></div>
                    <div class="btn-close"></div>
                </div>
            </div>
            <div class="content-dialog-box">
                <div class="line-input">
                    <div class="item-input">
                        <div class="title-input">Mã <span style="color:red">*</span></div>
                        <input type="text" class="input-type1">
                    </div>
                    <div class="item-input space-type1">
                        <div class="title-input">Tên <span style="color:red">*</span></div>
                        <input type="text" class="input-type2">
                    </div>
                    <div class="item-input space-type2">
                        <div class="title-input">Ngày sinh</div>
                        <input type="date" class="input-type3">
                    </div>
                    <div class="item-input gender">
                        <div class="title-input margin-gender-option">Giới tính<span style="color:red">*</span></div>
                        <a-radio-group>
                            <a-radio :value="1">
                                Nam
                            </a-radio>
                            <a-radio :value="2">
                                Nữ
                            </a-radio>
                            <a-radio :value="3">
                                Khác
                            </a-radio>
                        </a-radio-group>
                    </div>
                </div>
                <div class="line-input">
                    <div class="item-input">
                        <div class="title-input">Đơn vị <span style="color:red">*</span></div>
                        <input type="text" class="input-type4">
                    </div>
                    <div class="item-input space-type2">
                        <div class="title-input">Số CMND</div>
                        <input type="text" class="input-type5">
                    </div>
                    <div class="item-input space-type1">
                        <div class="title-input">Ngày cấp</div>
                        <input type="date" class="input-type3">
                    </div>
                </div>
                <div class="line-input">
                    <div class="item-input">
                        <div class="title-input">Chức danh</div>
                        <input type="text" class="input-type4">
                    </div>
                    <div class="item-input space-type2">
                        <div class="title-input">Nơi cấp</div>
                        <input type="text" class="input-type4">
                    </div>
                </div>
                <div class="line-input">
                    <div class="item-input">
                        <div class="title-input">Địa chỉ</div>
                        <input type="text" class="input-type6">
                    </div>
                </div>
                <div class="line-input">
                    <div class="item-input">
                        <div class="title-input">Điện thoại di động</div>
                        <input type="text" class="input-type7">
                    </div>
                    <div class="item-input space-type1">
                        <div class="title-input">Điện thoại cố định</div>
                        <input type="text" class="input-type7">
                    </div>
                    <div class="item-input space-type1">
                        <div class="title-input">Email</div>
                        <input type="text" class="input-type7" placeholder="example@gmail.com">
                    </div>
                </div>
                <div class="line-input">
                    <div class="item-input">
                        <div class="title-input">Tài khoản ngân hàng</div>
                        <input type="text" class="input-type7">
                    </div>
                    <div class="item-input space-type1">
                        <div class="title-input">Tên ngân hàng</div>
                        <input type="text" class="input-type7">
                    </div>
                    <div class="item-input space-type1">
                        <div class="title-input">Chi nhánh</div>
                        <input type="text" class="input-type7">
                    </div>
                </div>
            </div>
            <div class="footer-dialog-box">
                <div>
                    <div class="white-button">Huỷ</div>
                </div>
                <div class="right-bottom-button">
                    <div class="white-button">Cất</div>
                    <div class="green-button">Cất và Thêm</div>
                </div>
            </div>
        </div>
    </div> 
</template>

<script>
    export default {
        
    }
</script>

<style>
@import '../../assets/css/dialogs/infodialog.css';
</style>
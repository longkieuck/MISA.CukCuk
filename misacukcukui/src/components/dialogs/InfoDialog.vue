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
          <div class="btn-close" @click="closeDialogInfo"></div>
        </div>
      </div>
      <div class="content-dialog-box">
        <div class="line-input">
          <div class="item-input">
            <div class="title-input">Mã <span style="color:red">*</span></div>
            <input
              disabled
              type="text"
              class="input-type1"
              v-model="employeeCode"
            />
          </div>
          <div class="item-input space-type1">
            <div class="title-input">Tên <span style="color:red">*</span></div>
            <input
              type="text"
              class="input-type2"
              v-model="employee.fullName"
            />
          </div>
          <div class="item-input space-type2">
            <div class="title-input">Ngày sinh</div>
            <input
              type="date"
              class="input-type3"
              v-model="dateOfBirthFormat"
            />
          </div>
          <div class="item-input gender">
            <div class="title-input margin-gender-option">Giới tính</div>
            <a-radio-group v-model="employee.gender">
              <a-radio :value="0">
                Nam
              </a-radio>
              <a-radio :value="1">
                Nữ
              </a-radio>
              <a-radio :value="2">
                Khác
              </a-radio>
            </a-radio-group>
          </div>
        </div>
        <div class="line-input">
          <div class="item-input">
            <div class="title-input">
              Đơn vị <span style="color:red">*</span>
            </div>
            <!-- <input type="text" class="input-type4" v-model="employee.departmentName"> -->
            <select class="input-type4" v-model="employee.departmentName">
              <option v-for="d in departments" :key="d.departmentId">{{
                d.departmentName
              }}</option>
            </select>
          </div>
          <div class="item-input space-type2">
            <div class="title-input">Số CMND</div>
            <input
              type="text"
              class="input-type5"
              v-model="employee.identifyNumber"
            />
          </div>
          <div class="item-input space-type1">
            <div class="title-input">Ngày cấp</div>
            <input
              type="date"
              class="input-type3"
              v-model="identifyDateFormat"
            />
          </div>
        </div>
        <div class="line-input">
          <div class="item-input">
            <div class="title-input">Chức danh</div>
            <input
              type="text"
              class="input-type4"
              v-model="employee.positionName"
            />
          </div>
          <div class="item-input space-type2">
            <div class="title-input">Nơi cấp</div>
            <input
              type="text"
              class="input-type4"
              v-model="employee.identifyPlace"
            />
          </div>
        </div>
        <div class="line-input">
          <div class="item-input">
            <div class="title-input">Địa chỉ</div>
            <input type="text" class="input-type6" v-model="employee.address" />
          </div>
        </div>
        <div class="line-input">
          <div class="item-input">
            <div class="title-input">Điện thoại di động</div>
            <input
              type="text"
              class="input-type7"
              v-model="employee.phoneNumber"
            />
          </div>
          <div class="item-input space-type1">
            <div class="title-input">Điện thoại cố định</div>
            <input
              type="text"
              class="input-type7"
              v-model="employee.constantPhoneNumber"
            />
          </div>
          <div class="item-input space-type1">
            <div class="title-input">Email</div>
            <input
              type="text"
              class="input-type7"
              placeholder="example@gmail.com"
              v-model="employee.email"
            />
          </div>
        </div>
        <div class="line-input">
          <div class="item-input">
            <div class="title-input">Tài khoản ngân hàng</div>
            <input
              type="text"
              class="input-type7"
              v-model="employee.bankAccount"
            />
          </div>
          <div class="item-input space-type1">
            <div class="title-input">Tên ngân hàng</div>
            <input
              type="text"
              class="input-type7"
              v-model="employee.bankName"
            />
          </div>
          <div class="item-input space-type1">
            <div class="title-input">Chi nhánh</div>
            <input
              type="text"
              class="input-type7"
              v-model="employee.bankBranch"
            />
          </div>
        </div>
      </div>
      <div class="footer-dialog-box">
        <div>
          <div class="white-button" @click="closeDialogInfo">Huỷ</div>
        </div>
        <div class="right-bottom-button">
          <div class="white-button" @click="closeDialogInfo">Cất</div>
          <div class="green-button" @click="btnEditOrAdd">Cất và Thêm</div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import moment from "moment";
import { mapActions, mapState } from "vuex";
export default {
  computed: {
    ...mapState({
      isEdit: (state) => state.isEdit,
      isAdd: (state) => state.isAdd,
      isShow: (state) => state.isShow,
      employee: (state) => state.employee,
      departments: (state) => state.departments,
      newEmployeeCode:(state)=>state.newEmployeeCode
    }),
    employeeCode:{
        get(){
            if(this.isAdd) return this.newEmployeeCode
            else return this.employee.employeeCode
        },
        set(){

        }
    },
    dateOfBirthFormat: {
      get() {
        if (this.employee.dateOfBirth == null) return "";
        return moment(this.employee.dateOfBirth).format("YYYY-MM-DD");
      },
      set(val) {
        this.employee.dateOfBirth = val;
      },
    },
    identifyDateFormat: {
      get() {
        if (this.employee.identifyDate == null) return "";
        return moment(this.employee.identifyDate).format("YYYY-MM-DD");
      },
      set(val) {
        this.employee.identifyDate = val;
      },
    },
  },
  methods: {
    ...mapActions(["closeDialogInfo", "editOrAdd","loadEmployee","closeDialogInfo","showDialogNotify"]),
    btnEditOrAdd(){
    let isAdd = this.isAdd
    this.editOrAdd({callbackSuccess:()=>{
      this.openNotificationWithIcon(isAdd)
      this.loadEmployee()
      this.closeDialogInfo()
      
    },callbackFail:()=>{
      let employeeCode = this.newEmployeeCode
      this.showDialogNotify(employeeCode)
    }
    })     
    },
    openNotificationWithIcon(isAdd) {
      this.$notification['success']({
        message: 'Thành công!',
        description:
          isAdd?'Thêm thành công!':'Sửa thành công!',
        duration:2
      });
    },
  },
};
</script>

<style>
@import "../../assets/css/dialogs/infodialog.css";
</style>

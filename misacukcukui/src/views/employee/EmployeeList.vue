<template>
  <div>
    <div class="container">
      <div class="header">
        <div class="header-name">Nhân viên</div>
        <div class="btn-add" @click="btnAdd">Thêm mới nhân viên</div>
      </div>
      <div class="content">
        <div class="top-content">
          <div class="input-search">
            <input
              placeholder="Tìm theo mã, tên nhân viên"
              type="text"
              class="input"
            />
            <div class="icon-search"></div>
          </div>
          <div class="export"></div>
          <div class="refresh" @click="loadData"></div>
        </div>
        <div class="grid-data">
          <table>
            <thead>
              <tr>
                <th style="min-width:30px">
                  <a-checkbox></a-checkbox>
                  <div class="border-checkbox-th"></div>
                </th>
                <th style="min-width:150px">Mã nhân viên</th>
                <th style="min-width:250px">Tên nhân viên</th>
                <th style="min-width:120px">Giới tính</th>
                <th style="min-width:150px">Ngày sinh</th>
                <th style="min-width:200px">Số CMND</th>
                <th style="min-width:250px">Chức danh</th>
                <th style="min-width:250px">Tên đơn vị</th>
                <th style="min-width:150px">Số tài khoản</th>
                <th style="min-width:250px">Tên ngân hàng</th>
                <th style="min-width:200px">Chi nhánh TK ngân hàng</th>
                <th style="min-width:120px" class="action">Chức năng</th>
              </tr>
            </thead>
            <tbody>
              <tr
                v-for="e in employees"
                :key="e.EmployeeId"
                @dblclick="showDialogForEdit(e)"
              >
                <td style="min-width:30px">
                  <a-checkbox></a-checkbox>
                  <div class="border-checkbox-td"></div>
                </td>
                <td>{{ e.employeeCode }}</td>
                <td>{{ e.fullName }}</td>
                <td>{{ e.genderName }}</td>
                <td>{{ e.dateOfBirth | formatDate }}</td>
                <td>{{ e.identifyNumber }}</td>
                <td>{{ e.positionName }}</td>
                <td>{{ e.departmentName }}</td>
                <td>{{ e.bankAccount }}</td>
                <td>{{ e.bankName }}</td>
                <td>{{ e.bankBranch }}</td>
                <td class="action">
                    
                  <div class="edit-text" @click="showDialogForEdit(e)">Sửa</div>
                  <a-dropdown :trigger="['click']">
                    <a>
                      <a-icon style="margin-left:5px;font-weight:600" type="down" />
                    </a>
                    <a-menu slot="overlay">
                      <a-menu-item key="0">
                        <a>Nhân bản</a>
                      </a-menu-item>
                      <a-menu-item @click="btnDelete(e.employeeId)" key="1">
                        <a>Xóa</a>
                      </a-menu-item>
                      <a-menu-item key="2">
                        Ngừng sử dụng
                      </a-menu-item>
                    </a-menu>
                  </a-dropdown>
                </td>
              </tr>
            </tbody>
          </table>
        </div>
      </div>
    </div>
    <InfoDialog v-show="isShow" />
    <NotifyDialog v-show="true"/>
  </div>
</template>

<script>
import moment from "moment";

import { mapActions, mapState } from "vuex";
import NotifyDialog from '../../components/dialogs/NotifyDialog.vue'
import InfoDialog from "../../components/dialogs/InfoDialog.vue";
export default {
  components: {
    InfoDialog,
    NotifyDialog
  },
  created() {
    this.loadData();
  },
  computed: {
    ...mapState({
      isEdit: (state) => state.isEdit,
      isAdd: (state) => state.isAdd,
      isShow: (state) => state.isShow,
      isShowNotifyDelete:(state)=>state.isShowNotifyDelete,
      employees: (state) => state.employees,
    }),
  },
  methods: {
    ...mapActions([
      "loadEmployee",
      "loadDepartment",
      "showDialogForAdd",
      "showDialogForEdit",
      "getNewEmployeeCode",
      "deleteEmployee"
    ]),
    loadData() {
      this.loadEmployee();
      this.loadDepartment();
    },
    btnAdd() {
      this.showDialogForAdd();
      this.getNewEmployeeCode();
    },
    btnDelete(employeeId){
        this.deleteEmployee({employeeId,callback:()=>{
            this.loadEmployee();
        }})
    }
  },
  mounted: function() {},
  filters: {
    formatDate: function(value) {
      if (value == null) return "";
      return moment(value).format("DD/MM/YYYY");
    },
  },
};
</script>

<style>
@import "../../assets/css/components/table.css";
@import "../../assets/css/views/employee.css";
</style>

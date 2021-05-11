<template>
  <div>
    <div class="dialog-box-notify"></div>
    <div class="dialog-notify-content">
      <div class="content-box">
        <div class="notify-icon"></div>
        <div class="content-text">
          {{messageContent}}
        </div>
      </div>
      <div class="line"></div>
      <div>
        <div class="btn-cancel" v-show="isDelete" @click="closeDialogNotify">Hủy</div>
        <div class="btn-accept" @click="btnAccept">Đồng ý</div>
      </div>
    </div>
  </div>
</template>

<script>
import { mapActions, mapState } from "vuex";
export default {
  computed:{
    ...mapState({
      isDelete:(state)=>state.isDelete,
      messageContent:(state)=>state.messageContent,
      employeeId:(state)=>state.employee.employeeId,
      employeeCode:(state)=>state.employee.employeeCode
    })
  },
  methods:{
    ...mapActions([
      'deleteEmployee',
      'closeDialogNotify',
      'getNewEmployeeCode',
      'loadEmployee'
    ]),
    btnAccept(){
        if(this.isDelete){
          let employeeId = this.employeeId
          this.deleteEmployee({employeeId,callback:()=>{
              this.loadEmployee();
              this.openNotificationWithIcon()
          }})
          this.closeDialogNotify()
        }else{
          this.getNewEmployeeCode()
          this.closeDialogNotify()
        }
    },
    openNotificationWithIcon() {
      this.$notification['success']({
        message: 'Thành công!',
        description:
          'Xoá thành công!',
        duration:2
      });
    },
  }
};
</script>

<style>
@import "../../assets/css/dialogs/notifydialog.css";
</style>

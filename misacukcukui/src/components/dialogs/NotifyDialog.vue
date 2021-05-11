<template>
  <div>
    <div class="dialog-box"></div>
    <div class="dialog-notify-content">
      <div class="content-box">
        <div class="notify-icon"></div>
        <div class="content-text">
          Mã nhân viên NV-0001 đã tồn tại trong hệ thống vui lòng kiểm tra lại.
        </div>
      </div>
      <div class="line"></div>
      <div>
        <div class="btn-cancel" v-if="false">Hủy</div>
        <div class="btn-accept">Đồng ý</div>
      </div>
    </div>
  </div>
</template>

<script>
export default {};
</script>

<style>
@import "../../assets/css/dialogs/notifydialog.css";
</style>

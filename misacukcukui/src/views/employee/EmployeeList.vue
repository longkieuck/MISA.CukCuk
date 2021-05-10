<template>
    <div>
        <div class="container">
            <div class="header">
                <div class="header-name">Nhân viên</div>
                <div class="btn-add">Thêm mới nhân viên</div>
            </div>
            <div class="content">
                <div class="top-content">
                    <div class="input-search">
                        <input placeholder="Tìm theo mã, tên nhân viên" type="text" class="input">
                        <div class="icon-search"></div>
                    </div>
                    <div class="export"></div>
                    <div class="refresh"></div>
                </div>
                <div class="grid-data"></div>
            </div>
        </div>
        <!-- <InfoDialog/> -->
        <!-- <NotifyDialog/> -->
    </div>
</template>

<script>
    // import NotifyDialog from '../../components/dialogs/NotifyDialog.vue'
    // import InfoDialog from '../../components/dialogs/InfoDialog.vue'
    export default {
        components:{
            // InfoDialog,
            // NotifyDialog
        }
    }

</script>

<style>
@import '../../assets/css/views/employee.css';
</style>
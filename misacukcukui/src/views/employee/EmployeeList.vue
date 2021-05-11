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
                <div class="grid-data">
                    <table>
                        <thead>
                            <tr>
                                <th style="min-width:30px"><a-checkbox></a-checkbox></th>
                                <th style="min-width:150px">Mã nhân viên</th>
                                <th  style="min-width:250px">Tên nhân viên</th>
                                <th  style="min-width:120px">Giới tính</th>
                                <th  style="min-width:150px">Ngày sinh</th>
                                <th  style="min-width:200px">Số CMND</th>
                                <th  style="min-width:250px">Chức danh</th>
                                <th  style="min-width:250px">Tên đơn vị</th>
                                <th  style="min-width:150px">Số tài khoản</th>
                                <th  style="min-width:250px">Tên ngân hàng</th>
                                <th  style="min-width:200px">Chi nhánh TK ngân hàng</th>
                                <th  style="min-width:120px" class="action">Chức năng</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td style="min-width:30px"><a-checkbox></a-checkbox></td>
                                <td>Mã nhân viên</td>
                                <td>Tên nhân viên</td>
                                <td>Giới tính</td>
                                <td >Ngày sinh</td>
                                <td>Số CMND</td>
                                <td>Chức danh</td>
                                <td>Tên đơn vị</td>
                                <td >Số tài khoản</td>
                                <td>Tên ngân hàng</td>
                                <td>Chi nhánh TK ngân hàng</td>
                                <td class="action">Chức năng</td>
                            </tr>
                        </tbody>    
                    </table>    
                </div>
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
@import '../../assets/css/components/table.css';
@import '../../assets/css/views/employee.css';
</style>
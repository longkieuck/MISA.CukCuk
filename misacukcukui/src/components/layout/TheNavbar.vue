<template>
    <div id="navbar">
        <div class="logo-box">
            <div class="toggle"></div>
            <div class="logo"></div>
        </div>
        <div class="menu">
            <div class="menu-item" v-for="navbar in navbars" :key="navbar.icon">
                <div class="menu-item-logo" :class="navbar.icon"></div>
                <div class="menu-item-title">{{navbar.text}}</div>
            </div>
        </div>
    </div>
</template>

<script>
    export default {
        data(){
            return{
                navbars:[
                    {"icon":"dashboard","text":"Tổng quan"},
                    {"icon":"cash","text":"Tiền mặt"},
                    {"icon":"bank","text":"Tiền gửi"},
                    {"icon":"pu","text":"Mua hàng"},
                    {"icon":"sale","text":"Bán hàng"},
                    {"icon":"invoice","text":"Quản lý hoá đơn"},
                    {"icon":"stock","text":"Kho"},
                    {"icon":"tools","text":"Công cụ dụng cụ"},
                    {"icon":"assets","text":"Tài sản cố định"},
                    {"icon":"tax","text":"Thuế"},
                    {"icon":"price","text":"Giá thành"},
                    {"icon":"general","text":"Tổng hợp"},
                    {"icon":"budget","text":"Ngân sách"},
                    {"icon":"report","text":"Báo cáo"},
                    {"icon":"finance","text":"Phân tích tài chính"},
                ]
            }
        }                                                                       
    }
</script>

<style>
@import '../../assets/css/layout/navbar.css';
</style>
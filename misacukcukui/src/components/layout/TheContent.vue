<template>
    <div id="content">
        <EmployeeList/>
    </div>
</template>

<script>
    import EmployeeList from'../../views/employee/EmployeeList';
    export default {
        components:{
            EmployeeList
        }
    }
</script>

<style>
@import '../../assets/css/layout/content.css';
</style>
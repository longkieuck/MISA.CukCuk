import Vue from 'vue'
import Vuex from 'vuex'
import axios from 'axios'
Vue.use(Vuex)
const initEmployee = {
    "employeeCode": "",
    "gender": null,
    "genderName": "",
    "dateOfBirth": null,
    "identifyNumber": "",
    "positionName": "",
    "departmentName": "",
    "bankAccount": "",
    "bankName": "",
    "bankBranch": "",
    "fullName": "",
    "identifyDate": null,
    "identifyPlace": "",
    "address": "",
    "phoneNumber": "",
    "constantPhoneNumber": "",
    "email": ""
}
export const store = new Vuex.Store({
    state: {
        employees: [],
        departments: [],
        employee: {...initEmployee },
        newEmployeeCode: "",
        isAdd: false,
        isEdit: false,
        isShow: false,
        isShowNotifyDialog: false,
        isDelete: false,
        messageContent: "",
        totalRecords: 0,
        totalPages: 0,
        pageIndex: 1,
        pageSize: 10,
        search: ""
    },
    actions: {
        loadEmployee: (context) => {
            axios
                .get('https://localhost:44378/api/v1/Employees/Filter?Page=' + context.state.pageIndex + '&PageSize=' + context.state.pageSize + '&Search=' + context.state.search)
                .then(res => {
                    context.commit('loadEmployee', res.data)
                })
                .catch(e => console.log(e.response, "err loading employee"))

        },
        loadDepartment: (context) => {
            axios
                .get('https://localhost:44378/api/v1/Departments')
                .then(res => {
                    context.commit('loadDepartment', res.data)
                })
                .catch(e => console.log(e.response, "err loading department"))

        },
        refreshEmployee: (context) => {
            context.commit('refreshEmployee')
        },
        showDialogForEdit: (context, employee) => {
            context.commit('showDialogForEdit', employee)
        },
        showDialogForAdd: (context) => {
            context.commit('showDialogForAdd')
        },
        closeDialogInfo: (context) => {
            context.commit('closeDialogInfo')
        },
        editOrAdd: (context, payload) => {
            if (context.state.isAdd) {
                context.state.employee.employeeCode = context.state.newEmployeeCode
                axios.post('https://localhost:44378/api/v1/Employees', context.state.employee).then(() => payload.callbackSuccess())
                    .catch(() => payload.callbackFail())
            } else {
                axios
                    .put('https://localhost:44378/api/v1/Employees', context.state.employee).then(() => payload.callbackSuccess())
            }
        },
        getNewEmployeeCode: (context) => {
            axios
                .get('https://localhost:44378/api/v1/Employees/NewEmployeeCode')
                .then(res => {
                    context.commit('getNewEmployeeCode', res.data)
                })
                .catch(e => console.log(e.response, "err loading new employee code"))
        },
        deleteEmployee: (context, payload) => {
            axios
                .delete('https://localhost:44378/api/v1/Employees/' + payload.employeeId).then(() => payload.callback())
        },
        closeDialogNotify: (context) => {
            context.commit('closeDialogNotify')
        },
        showDialogConfirmDelete: (context, employee) => {
            context.commit('showDialogConfirmDelete', employee)
        },
        showDialogNotify: (context, employeeCode) => {
            context.commit('showDialogNotify', employeeCode)
        },
        changePageSize: (context, value) => {
            context.commit('changePageSize', value)
        },
        changeSearchText: (context, value) => {
            context.commit('changeSearchText', value)
        },
        changePage: (context, value) => {
            context.commit('changePage', value)
        },
    },
    mutations: {
        loadEmployee(state, response) {
            state.employees = response.data
            state.totalPages = response.totalPages
            state.totalRecords = response.totalRecords
        },
        loadDepartment(state, departments) {
            state.departments = departments
            console.log(departments)
        },
        refreshEmployee(state) {
            state.employee = {}
        },
        showDialogForEdit(state, employee) {
            state.employee = employee
            state.isShow = true
            state.isEdit = true
        },
        showDialogForAdd(state) {
            state.isShow = true,
                state.isAdd = true
        },
        closeDialogInfo(state) {
            state.isShow = false
            state.isAdd = false
            state.isEdit = false
            state.employee = {...initEmployee }
        },
        getNewEmployeeCode(state, newEmployeeCode) {
            state.newEmployeeCode = newEmployeeCode
            state.employee.employeeCode = newEmployeeCode
        },
        closeDialogNotify(state) {
            state.isShowNotifyDialog = false
            state.employee = {...initEmployee }
            state.messageContent = ""
        },
        showDialogConfirmDelete(state, employee) {
            state.employee = employee
            state.isShowNotifyDialog = true
            state.isDelete = true
            state.messageContent = "Bạn có chắc chắn muốn xoá nhân viên có mã là " + employee.employeeCode
        },
        showDialogNotify(state, employeeCode) {
            state.isShowNotifyDialog = true
            state.isDelete = false
            state.messageContent = "Mã nhân viên " + employeeCode + " đã tồn tại trong hệ thống, vui lòng kiểm tra lại!"
        },
        changePageSize(state, value) {
            state.pageSize = value
        },
        changeSearchText(state, value) {
            state.search = value
        },
        changePage(state, value) {
            state.pageIndex = value
        }

    }
});
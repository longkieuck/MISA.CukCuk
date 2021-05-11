import Vue from 'vue'
import Vuex from 'vuex'
import axios from 'axios'
Vue.use(Vuex)

export const store = new Vuex.Store({
    state:{
        employees:[],
        departments:[],
        employee:{},
        newEmployeeCode:"",
        isAdd:false,
        isEdit:false,
        isShow:false,
        isShowNotifyDelete:false,
        messageContent:""
    },
    actions:{
        loadEmployee:(context)=>{
            axios
            .get('https://localhost:44378/api/v1/Employees')
            .then(res=>{
                context.commit('loadEmployee',res.data)
            })
            .catch(e=>console.log(e.response,"err loading employee"))
            
        },
        loadDepartment:(context)=>{
            axios
            .get('https://localhost:44378/api/v1/Departments')
            .then(res=>{
                context.commit('loadDepartment',res.data)
            })
            .catch(e=>console.log(e.response,"err loading department"))
            
        },
        refreshEmployee:(context)=>{
            context.commit('refreshEmployee')
        },
        showDialogForEdit:(context,employee)=>{
            context.commit('showDialogForEdit',employee)
        },
        showDialogForAdd:(context)=>{
            context.commit('showDialogForAdd')
        },
        closeDialogInfo:(context)=>{
            context.commit('closeDialogInfo')
        },
        editOrAdd:(context,callback)=>{
            if(context.state.isAdd){
                context.state.employee.employeeCode = context.state.newEmployeeCode
                axios.post('https://localhost:44378/api/v1/Employees',context.state.employee).then(()=>callback())
            }else{
                axios
                .put('https://localhost:44378/api/v1/Employees',context.state.employee).then(()=>callback())
            }
        },
        getNewEmployeeCode:(context)=>{
            axios
            .get('https://localhost:44378/api/v1/Employees/NewEmployeeCode')
            .then(res=>{
                context.commit('getNewEmployeeCode',res.data)
            })
            .catch(e=>console.log(e.response,"err loading new employee code"))
        },
        deleteEmployee:(context,payload)=>{
            axios
            .delete('https://localhost:44378/api/v1/Employees/'+payload.employeeId).then(()=>payload.callback())
        }
    },
    mutations:{
        loadEmployee(state,employees){
            state.employees=employees
        },
        loadDepartment(state,departments){
            state.departments=departments
            console.log(departments)
        },
        refreshEmployee(state){
            state.employee={}
        },
        showDialogForEdit(state,employee){
            state.employee=employee
            state.isShow=true
            state.isEdit=true
        },
        showDialogForAdd(state){
            state.isShow=true,
            state.isAdd=true
        },
        closeDialogInfo(state){
            state.isShow=false,
            state.isAdd=false,
            state.isEdit=false,
            state.employee={}
        },
        getNewEmployeeCode(state,newEmployeeCode){
            state.newEmployeeCode=newEmployeeCode
            state.employee.employeeCode=newEmployeeCode
        }
    }
});
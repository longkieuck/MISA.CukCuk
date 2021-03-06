import Vue from 'vue'
import App from './App.vue'
import Antd from 'ant-design-vue';
import 'ant-design-vue/dist/antd.css';
import {store} from './components/store/store'

Vue.config.productionTip = false


Vue.use(Antd);
new Vue({
    store,
    render: h => h(App),
}).$mount('#app')
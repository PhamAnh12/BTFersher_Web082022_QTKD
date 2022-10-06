import { createApp } from 'vue'
import App from './App.vue'
import router  from './router/router';
import FloatingVue from 'floating-vue';
import 'floating-vue/dist/style.css';
import 'vue-date-pick/dist/vueDatePick.css';
import Datepicker from '@vuepic/vue-datepicker';
import '@vuepic/vue-datepicker/dist/main.css';
const app = createApp(App);
app.use(FloatingVue);
app.use(router);
app.component('datePicker', Datepicker);
app.mount('#app');

 
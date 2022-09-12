<template>
  <NavBarComponent></NavBarComponent>
  <div class="main">
  <HeaderComponent></HeaderComponent>
  <EmployeeListComponent></EmployeeListComponent>
  </div>
</template>

<script>

import NavBarComponent from './components/NavBar.vue';
import HeaderComponent from './components/Header.vue';
import EmployeeListComponent from './components/EmployeeList.vue'
export default {
  name: 'App',
  components: {
    NavBarComponent,
    HeaderComponent,
    EmployeeListComponent,
    
  }
}
</script>

<style>
@import url(./assets/css/main.css); 
@import url(./assets/css/layout/employee.css);
</style>

<template>
  <NavBarComponent></NavBarComponent>
  <div class="main">
   <HeaderComponent></HeaderComponent>
   <ContentComponents></ContentComponents>
  </div>
</template>

<script>

import NavBarComponent from './components/layout/TheNavBar.vue';
import HeaderComponent from './components/layout/TheHeader.vue';
import ContentComponents from './components/layout/TheContent.vue'

export default {
  name: 'App',
  components: {
    NavBarComponent,
    HeaderComponent,
    ContentComponents,
    
  }
}
</script>

<style>
@import url(./assets/css/main.css); 
@import url(./assets/css/layout/employee.css);
</style>

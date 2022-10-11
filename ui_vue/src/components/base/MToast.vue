<template>
 <div></div>
      <div class="toast">
        <div class="toast__left">
          <div class="item__icon">
           <div class="icon__toast--success"></div>
         </div>
         <div class="toast__text">
           <div class="toast__text--success">
           Thành Công
           </div>
           <div >{{textToast}}</div>
         </div>
        </div>
        <div class="toast__right">
         <div class="icon__16 icon__toast__close"></div>
        </div>
      </div>
 
</template>
<script>
export default {
   name : 'ToastComponent',
   props:{
      textToast: String
   }
}
</script>
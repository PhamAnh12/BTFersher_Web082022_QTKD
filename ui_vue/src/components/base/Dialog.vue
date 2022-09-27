<template>
        <!-- dialog input -->
        <div class="dialog">
            <div class="dialog__container content__center">
              <div class="dialog__content wd__dialog__error" >
                <div class="dialog__header">
               
                </div>
                <div class="dialog__body align__items__center">
                     
                        <div class=" icon__warning"></div>
                     
                    <div class="dialog__body__text">
                       {{textPopupError}}
                        <!-- Mã nhân viên NV-0001 đã tồn tại vui lòng kiểm tra lại -->
                    </div>
                </div>
                <div class="dialog__footer align__items__center">
                    <div class="btn " @click="hideErrorFrom">Đồng ý</div>
                </div>
              </div>
            </div>
        
        </div>
 
</template>
<script>
export default {
   name : 'DialogComponent',
   emits: ["hideErrorFrom"],
   props:{
    textPopupError:String,
   },
   methods:{
    hideErrorFrom(){
      this.$emit("hideErrorFrom");
    }
   }
   
}
</script>
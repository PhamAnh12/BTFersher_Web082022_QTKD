<template>
        <!-- dialog input -->
        <div class="dialog" >
            <div class="dialog__container content__center"   >
              <div class="dialog__content wd__dialog__error"  @keypress="handleKeyDialog" >
                <div class="dialog__header">
               
                </div>
                <div class="dialog__body align__items__center">
                     
                        <div class="icon__error"></div>
                     
                    <div class="dialog__body__text">
                         {{textPopupError}} 
                    </div>
                </div>
                <div class="dialog__footer align__items__center">
                    <div class="btn " @click="hideErrorFrom"                 
                     >Đồng ý</div>
                </div>
              </div>
            </div>
        
        </div>
 
</template>
<script>
import Enum from '../../script/common/enumeration'
export default {
   name : 'DialogComponent',
   emits: ["hideErrorFrom"],
   props:{
    textPopupError:String,
   },
   methods:{
     /*
     * Hàm dùng để đóng ErrorFrom
     * PCTUANANH(30/09/2022)
     */
    hideErrorFrom(){
      this.$emit("hideErrorFrom");
    },
     /*
     * Hàm dùng để  xử lý sự kiện bàn phím ấn Enter sẽ ẩn Error From đi
     * PCTUANANH(30/09/2022)
     */
    handleKeyDialog(e){
      if(e.keyCode === Enum.keyCode.ENTER ){
           e.preventDefault();
          this.$emit("hideErrorFrom");
      }
    }
   }
   
}
</script>
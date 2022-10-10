<template>
        <!-- dialog input -->
        <div class="dialog" >
            <div class="dialog__container content__center"   >
              <div class="dialog__content wd__dialog__error"  @keypress="handleKeyDialog" >
                <div class="dialog__header">
               
                </div>
                <div class="dialog__body align__items__center">
                     
                        <div :class="class__icon"
                        ></div>
                     
                    <div class="dialog__body__text">
                         {{textPopupError}} 
                    </div>
                </div>
                  <div class=" dialog__footer  align__items__center" :class="{'dialog__footer__valiFrontend':isFooterFE}">
                    <div class="btn " @click="hideErrorFrom"                 
                     >{{textFooterBtn}}</div>
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
    isFooterFE:Boolean,
    isFooterBE:Boolean,
   },
   created(){
    if(this.isFooterFE){
      this.class__icon = "icon__error";
      this.textFooterBtn= "Đóng"
    }
    else{
      this.class__icon ="icon__warning"
      this.textFooterBtn= "Đồng ý"
    }
   },
   data() {
    return {
      class__icon:"",
      textFooterBtn:""
    }
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
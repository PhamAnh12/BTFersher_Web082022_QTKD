<template>
  <div class="content__footer">
    <div class="content__footer_left">
      Tổng số <b>{{ totalRecords }}</b> bản ghi
    </div>
    <div class="content__footer__right">
       <div class="dropList__page"
       :class="{'dropList__page__active':isShow }"
       >
        <div class="dropList__text">{{text}}</div>
        <div class="dropList__data"  v-show="isShow">
                <div class="data__item" v-for="(recordPage,index) in listRecordPages "
                :key="index"
                @click="selectRecordPage(recordPage,index)"
                :class="{'dropList__active': indexRecord==index }"
               >
               {{recordPage.textData}}</div>
               
               
        </div>
        <div class="dropList__icon" 
            :class="{choose__dropList__icon:isShow }"
           >
            <div class="dropList__icon__drop"
            :class="{'dropList__icon__drop__rotate':isShow }"
             @click="isShow =! isShow"></div>
             
        </div>
    </div>
      <div class="page">
        <div class="page--dislabel page__text">Trước</div>
        <div class="page__number paging__number--active">1</div>
        <div class="page__number">2</div>
        <div class="page__number">3</div>
        <div class="page__icon">...</div>
        <div class="page__number">52</div>
        <div class="page__text">Sau</div>
      </div>
    </div>
  </div>
</template>
<script>
import Enumeration from '../../script/common/enumeration'
export default {
  name: "PageComponent",
  props: {
     totalRecords : Number
  },
  created(){
  
  },
 emits:["selectRecordPage"],
  data() {
    return {
       text: '-- Tùy chọn --',
       isShow: false,
       listRecordPages :  Enumeration.listRecordPages,
       indexRecord: null
    }
  },
  methods:{
     /*
     * Hàm dùng để  lựa số bản ghi trên trang 
     * PCTUANANH(30/09/2022)
     */
    selectRecordPage(recordPage,index){
        this.text = recordPage.textData;
        this.indexRecord = index;
        this.$emit("selectRecordPage",recordPage.num);
        this.isShow = false;
    }
  }
};
</script>

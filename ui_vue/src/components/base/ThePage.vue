<template>
  <div class="content__footer">
    <div class="content__footer_left">
      Tổng số <b>{{ totalRecords }}</b> bản ghi
    </div>
    <div class="content__footer__right">
      <div class="dropList__page" :class="{ dropList__page__active: isShow }">
        <div class="dropList__text">{{ text }}</div>
        <div class="dropList__data" v-show="isShow">
          <div
            class="data__item"
            v-for="(recordPage, index) in listRecordPages"
            :key="index"
            @click="getRecordPage(recordPage, index)"
            :class="{ dropList__active: indexRecord == index }"
          >
            {{ recordPage.textData }}
          </div>
        </div>
        <div class="dropList__icon" :class="{ choose__dropList__icon: isShow }">
          <div
            class="dropList__icon__drop"
            :class="{ dropList__icon__drop__rotate: isShow }"
            @click="isShow = !isShow"
          ></div>
        </div>
      </div>

      <paginate
        :page-count="pageCount"
        :page-range="3"
        :margin-pages="2"
        :click-handler="pagingHandle"
        :prev-text="'Trước'"
        :next-text="'Sau'"
        :container-class="'page'"
        :page-class="'page__number'"
        :active-class="'paging__number--active'"
        :disabled-class="'page--disable'"
        :initial-page="1"
      >
      </paginate>
    </div>
  </div>
</template>
<script>
import Enumeration from "../../script/common/enumeration";
import Paginate from "vuejs-paginate-next";
export default {
  name: "PageComponent",
  components: {
    paginate: Paginate,
  },

  props: {
    totalRecords: Number,
    recordNumber: Number,
    pageCount : Number
  },
  created() {
     this.indexRecord  = 3,
     this.text = "50 bản ghi trên một trang"
  },
  emits: ["getRecordPage","pagingEmployee"],
  data() {
    return {
      text: "---- Tùy chọn ----",
      isShow: false,
      listRecordPages: Enumeration.listRecordPages,
      indexRecord: null,
     
    };
  },
  methods: {
    /*
     * Hàm dùng để  lựa số bản ghi trên trang
     * PCTUANANH(30/09/2022)
     */
    getRecordPage(recordPage, index) {
      this.text = recordPage.textData;
      this.indexRecord = index;
      this.$emit("getRecordPage", recordPage.num);
      this.isShow = false;
    },
     /*
     * Hàm dùng để  lựa số bản ghi trên trang
     * PCTUANANH(30/09/2022)
     */
    pagingHandle(numPage){
     this.$emit("pagingEmployee",numPage);
     
    }
  },
};
</script>

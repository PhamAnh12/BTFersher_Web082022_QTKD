<template>
  <div class="header">
    <div class="header__title">
      <div class="item__icon">
        <div class="icon__16 icon__menu"></div>
      </div>
      <div class="header__option"
      v-tooltip="{
          content: 'Chức năng đang thi công',
        }"
      >
        <div class="header__option__text">
          CÔNG TY TNHH SẢN XUẤT-THƯƠNG MẠI-DỊCH VỤ QUI PHÚC
        </div>
        <div class="icon__16 item__icon">
        <div class="icon__option"></div>
        </div>
      </div>
    </div>
    <div class="header__account">
      <div
        class="headder__account__notification"
        v-tooltip="{
          content: 'Chức năng đang thi công',
        }"
      >
        <div class="item__icon">
          <div class="icon__24 icon__notification"></div>
        </div>
      </div>
      <div
        class="account__container"
        v-tooltip="{
          content: 'Chức năng đang thi công',
        }"
      >
        <div class="account__img icon__acc__img"></div>
        <div class="account__text">Phạm Công Tuấn Anh</div>
        <div class="icon__account__down"></div>
      </div>
    </div>
  </div>
</template>
<script>
export default {
  name: "TheHeader",
};
</script>

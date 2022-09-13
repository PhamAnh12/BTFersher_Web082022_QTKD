<template>
  <!-- Form nhập -->
  <div class="modal">
    <div class="modal__container">
      <div class="modal__content">
        <div class="modal__header">
          <div class="modal__header__left">
            <h1 class="header__title">Thông tin nhân viên</h1>
            <input class="" type="checkbox" id="" />
            <label for="">Là khách hàng</label>
            <input class="" type="checkbox" id="" />
            <label for="">Là nhà cung cấp</label>
          </div>
          <div class="modal__header__rigth">
            <div class="item__icon modal__header__icon">
              <div class="icon__18 icon__help"></div>
            </div>
            <div
              class="item__icon modal__header__icon margin__letf_8"
              @click="closeModal"
            >
              <div class="icon__18 icon__close"></div>
            </div>
          </div>
        </div>
        <div class="modal__body">
          <div class="modal__body__row">
            <div class="body__row__left">
              <div class="container__input input__160">
                <label class="input__label" for=""
                  >Mã <span class="required">*</span>
                </label>
                <input
                  id="empCode"
                  tabindex="1"
                  class="input"
                  type="text"
                  placeholder="Mã nhân viên"
                  v-model="employee.employeeCode"
                />
              </div>
              <div class="container__input input__margin_6 input__320">
                <label class="input__label" for=""
                  >Họ và tên <span class="required">*</span></label
                >
                <input
                  tabindex="2"
                  class="input"
                  type="text"
                  placeholder="Họ tên đấy đủ"
                  v-model="employee.employeeName"
                />
              </div>
            </div>
            <div class="body__row__rigth">
              <div class="container__input input__160">
                <label class="input__label" for=""> Ngày sinh </label>
                <input
                  tabindex="3"
                  class="input"
                  type="date"
                  v-model="employee.dateOfBirth"
                />
              </div>
              <div class="container__input input__margin_16 input__320">
                <label class="input__label" for=""> Giới tính </label>
                <div class="container__gender">
                  <input type="radio" name="gender" id="male" value="0" />
                  <label for="male">Nam</label>
                  <input type="radio" name="gender" id="female" value="1" />
                  <label for="">Nữ</label>
                  <input type="radio" name="gender" id="other" value="2" />
                  <label for="other">Khác</label>
                </div>
              </div>
            </div>
          </div>
          <div class="modal__body__row">
            <div class="body__row__left">
              <div class="container__input input__480">
                <label class="input__label" for=""
                  >Đơn vị <span class="required">*</span></label
                >
                <input
                  tabindex="7"
                  class="input"
                  type="text"
                  v-model="employee.departmentName"
                />
              </div>
            </div>
            <div class="body__row__rigth">
              <div class="container__input input__320">
                <label class="input__label" for="">Số CMND</label>
                <input
                  tabindex="9"
                  class="input"
                  type="text"
                  placeholder="Số chứng minh nhân dân"
                  v-model="employee.identityNumber"
                />
              </div>
              <div class="container__input input__margin_6 input__160">
                <label class="input__label" for="">Ngày cấp</label>
                <input
                  tabindex="10"
                  class="input"
                  type="date"
                  v-model="employee.identityIssuedDate"
                />
              </div>
            </div>
          </div>
          <div class="modal__body__row">
            <div class="body__row__left">
              <div class="container__input input__480">
                <label class="input__label" for="">Chức danh</label>
                <input
                  tabindex="8"
                  class="input"
                  type="text"
                  placeholder="Chức danh"
                  v-model="employee.positionName"
                />
              </div>
            </div>
            <div class="body__row__rigth">
              <div class="container__input input__480">
                <label class="input__label" for="">Nơi cấp</label>
                <input
                  tabindex="11"
                  class="input"
                  type="text"
                  placeholder="Nơi cấp"
                  v-model="employee.identityIssuedPlace"
                />
              </div>
            </div>
          </div>
          <div class="modal__body__row margin__top_16">
            <div class="container__input">
              <label class="input__label" for="">Địa chỉ</label>
              <input
                tabindex="12"
                class="input"
                type="text"
                placeholder="Địa chỉ"
                v-model="employee.address"
              />
            </div>
          </div>
          <div class="modal__body__row">
            <div class="container__input input__240">
              <label class="input__label" for="">ĐT di động </label>
              <input
                tabindex="13"
                class="input"
                type="text"
                placeholder="Điện thoại di động"
                v-model="employee.phoneNumbermobile"
              />
            </div>
            <div class="container__input input__margin_6 input__240">
              <label class="input__label" for="">ĐT có định </label>
              <input
                tabindex="14"
                class="input"
                type="text"
                placeholder="Điện thoại cố định"
                v-model="employee.phoneNumberlandline"
              />
            </div>
            <div class="container__input input__margin_6 input__240">
              <label class="input__label" for="">Email </label>
              <input
                tabindex="15"
                class="input"
                type="text"
                placeholder="Email"
                v-model="employee.email"
              />
            </div>
          </div>
          <div class="modal__body__row">
            <div class="container__input input__240">
              <label class="input__label" for="">Tài khoản ngân hàng </label>
              <input
                tabindex="16"
                class="input"
                type="text"
                placeholder="Tài khoản ngân hàng"
                v-model="employee.accountBank"
              />
            </div>
            <div class="container__input input__margin_6 input__240">
              <label class="input__label" for="">Tên ngân hàng </label>
              <input
                tabindex="17"
                class="input"
                type="text"
                placeholder="Tên ngân hàng"
                v-model="employee.nameBank"
              />
            </div>
            <div class="container__input input__margin_6 input__240">
              <label class="input__label" for=""> Chi nhánh </label>
              <input
                tabindex="18"
                class="input"
                type="text"
                placeholder="Chi nhánh"
                v-model="employee.branchBank"
              />
            </div>
          </div>
        </div>
        <div class="modal__footer">
          <div class="btn__base content__center" @click="closeModal">Hủy</div>
          <div class="modal__footer__rigth">
            <div class="btn__base content__center">Cất</div>
            <div class="btn margin__letf_8">Cất và thêm</div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
export default {
  name: "EmployeeDetailComponent",
  props: {
    employeeSelect: Object,
  },
  created() {
    this.employee = this.employeeSelect;
  },
  data() {
    return {
      employee: {},
    };
  },
  methods: {
    /*
     * Hàm dùng để đóng modal
     * PCTUANANH(12/09/2022)
     */
      closeModal() {
      this.$emit("hideModal");
    },
  },
};
</script>

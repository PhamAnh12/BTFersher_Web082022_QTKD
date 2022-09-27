<template>
  <!-- Form nhập -->
  <div class="modal" @keypress.esc="isCloseModal()">
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
              @click="isCloseModal"
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
                  tabindex="1"
                  class="input"
                  type="text"
                  placeholder="Mã nhân viên "
                  v-model="employee.employeeCode"
                  errorCode="errorCode"
                  ref="empCode"
                  :class="{ input__error: errors.errorCode }"
                  @blur="blurValidate"
                />
                <div :class="{ input__show__error: errors.errorCode }">
                  {{ errors.errorCode }}
                </div>
              </div>
              <div class="container__input input__margin_6 input__320">
                <label class="input__label" for=""
                  >Họ và tên <span class="required">*</span></label
                >
                <input
                  tabindex="2"
                  class="input"
                  type="text"
                  placeholder="Tên nhân viên"
                  ref="empName"
                  errorCode="errorName"
                  v-model="employee.employeeName"
                  :class="{ input__error: errors.errorName }"
                  @blur="blurValidate"
                />
                <div :class="{ input__show__error: errors.errorName }">
                  {{ errors.errorName }}
                </div>
              </div>
            </div>
            <div class="body__row__rigth">
              <div class="container__input input__160">
                <label class="input__label" for=""> Ngày sinh </label>
                <input
                  tabindex="5"
                  class="input input_date"
                  type="date"
                  :max="maxDate"
                  v-model="employee.dateOfBirth"
                />
              </div>
              <div class="container__input input__margin_16 input__320">
                <label class="input__label" for=""> Giới tính </label>
                <div class="container__gender">
                  <input
                    type="radio"
                    name="gender"
                    id="male"
                    value="0"
                    tabindex="6"
                    checked
                    v-model="employee.gender"
                  />
                  <label for="male">Nam</label>
                  <input
                    type="radio"
                    name="gender"
                    id="female"
                    value="1"
                    tabindex="7"
                    v-model="employee.gender"
                  />
                  <label for="">Nữ</label>
                  <input
                    type="radio"
                    name="gender"
                    id="other"
                    value="2"
                    tabindex="8"
                    v-model="employee.gender"
                  />
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

                <MCombobox
                  :url="urlDepartment"
                  propValue="departmentID"
                  propText="departmentName"
                  @getValueDepart="getValueDepart"
                  :departmentName="employee.departmentName"
                  :errorDepartment="errors.errorDepartment"
                  tabindex="3"
                  errorCode="errorDepartment"
                ></MCombobox>
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
                  class="input input_date"
                  :max="maxDate"
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
                  tabindex="4"
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
                  placeholder="Nơi cấp chứng minh nhân dân"
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
                placeholder="Số địa thoại di động"
                v-model="employee.phoneNumberMobile"
              />
            </div>
            <div class="container__input input__margin_6 input__240">
              <label class="input__label" for="">ĐT có định </label>
              <input
                tabindex="14"
                class="input"
                type="text"
                placeholder="Số điện thoại cố định"
                v-model="employee.phoneNumberLandline"
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
                placeholder="Chi nhánh ngân hàng"
                v-model="employee.branchBank"
              />
            </div>
          </div>
        </div>
        <div class="modal__footer">
          <div class="btn__base content__center" @click="closeModal">Hủy</div>
          <div class="modal__footer__rigth">
            <div class="btn__base content__center" @click="saveModal">Cất</div>
            <div class="btn margin__letf_8" @click="saveModalAdd">
              Cất và thêm
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
  <DialogFormClose
    v-if="isCloseForm"
    @closeModal="closeModal"
    @hideCloseForm="hideCloseForm"
    @saveModal="saveModal"
  ></DialogFormClose>
  <DialogError
    v-if="isErrorFrom"
    @hideErrorFrom="hideErrorFrom"
    :textPopupError="textPopupError"
  ></DialogError>
</template>
<script>
import Common from "../../script/common/common";
import Enumeration from "../../script/common/enumeration";
import DialogFormClose from "../../components/base/DialogFormClose.vue";
import MCombobox from "../../components/base/msCombobox/MCombobox.vue";
import DialogError from "../../components/base/Dialog.vue";
var urlBase = process.env.VUE_APP_URL;
export default {
  name: "EmployeeDetailComponent",
  components: {
    DialogFormClose,
    MCombobox,
    DialogError,
  },
  props: {
    employeeSelect: Object,
    formMode: Number,
  },
  // Khai báo các emit từ componet cha
  emits: [
    "notLoadingData",
    "loadingData",
    "hideModal",
    "showModal",
    "resetModal",
  ],
  created() {
    this.employee = this.employeeSelect;
    this.employeeOld = this.employee;
  },
  mounted() {
    /*
     *Dùng để focus vào ô đầu tiên
     */
    this.$refs.empCode.focus();
    /*
     *Dùng để thêm một mã nhân viên tự động tăng
     */
    this.newEmployeeCode();
    /*
     *Dùng để format ngày tháng
     */
    this.formatDateEmployee();
  },
  beforeUpdate() {
    this.changeData = true;
  },
  data() {
    return {
      employee: {},
      isCloseForm: false,
      changeData: false,
      maxDate: Common.maxDate(),
      employeeOld: {},
      employeeNew: {},
      errors: {
        errorCode: "",
        errorName: "",
        errorDepartment: "",
      },
      urlDepartment: `${urlBase}/Departments`,
      SaveMode: Enumeration.SaveMode.Save,
      isErrorFrom: false,
      textErrorPopup: "",
    };
  },
  methods: {
    ///
    /// Các hàm  dùng để format
    ///
    /*
     * Hàm dùng để format form khi lưu vào
     * PCTUANANH(16/09/2022)
     */
    formatInputForm() {
      try {
        this.traneGenderNumber();
      } catch (error) {
        console.log(error);
      }
    },
    /*
     * Hàm dùng để format ngày tháng trong employee
     * PCTUANANH(16/09/2022)
     */
    formatDateEmployee() {
      try {
        if (this.formMode == Enumeration.FormMode.Edit) {
          this.employee.dateOfBirth = Common.formatDate2(
            this.employee.dateOfBirth
          );
          this.employee.identityIssuedDate = Common.formatDate2(
            this.employee.identityIssuedDate
          );
        }
      } catch (error) {
        console.log(error);
      }
    },

    /*
     * Hàm dùng để format giới tính từ chuỗi sang số
     * PCTUANANH(16/09/2022)
     */
    traneGenderNumber() {
      try {
        if (!this.employee.gender) {
          this.employee.gender = 0;
        } else {
          this.employee.gender = Number(this.employee.gender);
        }
      } catch (error) {
        console.log(error);
      }
    },
    /*
     * Hàm dùng để  thêm mới một mã nhân viên tự động tăng
     * PCTUANANH(13/09/2022)
     */
    newEmployeeCode() {
      try {
        if (this.formMode == Enumeration.FormMode.Add) {
          fetch(`${urlBase}/Employees/new-code`)
            .then((res) => res.text())
            .then((res) => {
              this.employee.employeeCode = res;
            })
            .catch((error) => {
              console.log("Error! Could not reach the API. " + error);
            });
        }
      } catch (error) {
        console.log(error);
      }
    },
    ///
    /// Các hàm để xử  lý đóng
    ///
    /*
     * Hàm dùng để đóng modal bằng nút Hủy
     * PCTUANANH(18/09/2022)
     */
    closeModal() {
      try {
        this.$emit("notLoadingData");
        this.$emit("hideModal");
      } catch (error) {
        console.log(error);
      }
    },
    /*
     * Hàm dùng để đóng modal bằng nút X
     * PCTUANANH(18/09/2022)
     */
    isCloseModal() {
      try {
        if (!this.changeData) {
          this.closeModal();
        } else {
          this.isCloseForm = true;
        }
      } catch (error) {
        console.log(error);
      }
    },
    /*
     * Hàm dùng để ẩn form close bằng nút hủy
     * PCTUANANH(18/09/2022)
     */
    hideCloseForm() {
      try {
        this.isCloseForm = false;
      } catch (error) {
        console.log(error);
      }
    },
    /*
     * Hàm dùng để ẩn popup show Error
     * PCTUANANH(28/09/2022)
     */
    hideErrorFrom() {
      try {
        this.isErrorFrom = false;
        this.$refs.empCode.focus();
      } catch (error) {
        console.log(error);
      }
    },
    /*
     * Hàm dùng để validate
     * PCTUANANH(24/09/2022)
     */
    validate() {
      let isValidate = true;
      this.errors = {
        code: "",
        errorName: "",
        errorDepartment: "",
      };
      if (!this.employee.employeeCode) {
        this.errors.errorCode = Enumeration.Errors.errorCode;
        isValidate = false;
      }
      if (!this.employee.employeeName) {
        this.errors.errorName = Enumeration.Errors.errorName;
        isValidate = false;
      }
      if (!this.employee.departmentID) {
        this.errors.errorDepartment = Enumeration.Errors.errorDepartment;
        isValidate = false;
      }

      return isValidate;
    },
    /*
     * Hàm dùng để blur validate
     * PCTUANANH(27/09/2022)
     */
    blurValidate(e) {
      let errorCode = e.currentTarget.getAttribute("errorCode");
      if (e.currentTarget.value) {
        this.errors[errorCode] = "";
      } else {
        this.errors[errorCode] = Enumeration.Errors[errorCode];
      }
    },
    /*
     * Hàm dùng  validatebackend
     * PCTUANANH(28/09/2022)
     */
    validateBackend(response) {
      if (response.userMsg) {
        this.isErrorFrom = true;
        this.textPopupError = response.userMsg;
      }
      else{
        if( this.SaveMode == Enumeration.SaveMode.Save){
            this.$emit("loadingData");
            this.$emit("hideModal");
        } 
      }
    },
    /*
     * Hàm dùng để giá trị của Department
     * PCTUANANH(24/09/2022)
     */
    getValueDepart(department) {
      this.employee.departmentID = department.departmentID;
      this.employee.departmentName = department.departmentName;
      if (this.employee.departmentID) {
        this.errors.errorDepartment = "";
      }
    },
    ///
    /// Các hàm dùng để lưu
    ///
    handleSave() {
      try {
        if (!this.validate()) {
          this.isCloseForm = false;
        }
        if (this.validate()) {
          // sửa nhân viên
          if (this.formMode === Enumeration.FormMode.Edit) {
            this.saveEditEmployee();
          }
          // thêm mới nhân viên
          else if (this.formMode === Enumeration.FormMode.Add) {
            this.saveAddEmployee();
          }
        }
      } catch (error) {
        console.log(error);
      }
    },
    /*
     * Hàm dùng để lưu  modal
     * PCTUANANH(12/09/2022)
     */
    saveModal() {
      try {
        this.SaveMode = Enumeration.SaveMode.Save;
        this.handleSave();

      } catch (error) {
        console.log(error);
      }
    },
    /*
     * Hàm dùng để lưu  modal và thêm mới modal
     * PCTUANANH(12/09/2022)
     */
    saveModalAdd() {
      try {
        this.SaveMode = Enumeration.SaveMode.SaveAdd;
        this.handleSave();
        this.$emit("loadingData");
        this.$emit("hideModal");
        
      } catch (error) {
        console.log(error);
      }
    },
    ///
    /// Các hàm  để  thêm, sửa  gọi đến API
    ///
    /*
     * Hàm dùng để gọi api để sửa nhân viên
     * PCTUANANH(16/09/2022)
     */
    saveEditEmployee() {
      try {
        this.formatInputForm();
        let data = this.employee;
        let url = `${urlBase}/Employees/${this.employee.employeeID}`;
        fetch(url, {
          method: "PUT",
          headers: {
            "Content-Type": "application/json",
          },
          body: JSON.stringify(data),
        })
          .then((response) => response.json())
          .then((response) => {
            this.validateBackend(response);
          })
          .catch((error) => {
            console.log(data);
            console.error("Error:", error);
          });
      } catch (error) {
        console.log(error);
      }
    },
    /*
     * Hàm dùng để gọi api để thêm mới nhân viên
     * PCTUANANH(16/09/2022)
     */
    saveAddEmployee() {
      try {
        this.formatInputForm();
        let data = this.employee;
        let url = `${urlBase}/Employees`;
        fetch(url, {
          method: "POST",
          headers: {
            "Content-Type": "application/json",
          },
          body: JSON.stringify(data),
        })
          .then((response) => response.json())
          .then((response) => {
            this.validateBackend(response);
          })
          .catch((error) => {
            console.error("Error:", error);
          });
      } catch (error) {
        console.log(error);
      }
    },
  },
};
</script>

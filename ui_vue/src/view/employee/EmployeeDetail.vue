<template>
  <!-- Form nhập -->
  <div class="modal">
    <div class="modal__container" @keydown="handleKeyModel">
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
            <div
              class="item__icon modal__header__icon"
              v-tooltip.bottom="{
                content: 'Trợ giúp(F1)',
              }"
            >
              <div class="icon__18 icon__help"></div>
            </div>
            <div
              class="item__icon modal__header__icon margin__letf_8"
              @click="isCloseModal"
              v-tooltip.bottom="{
                content: 'Đóng (ESC)',
              }"
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
                  class="input"
                  type="text"
                  placeholder="Mã nhân viên "
                  maxlength="25"
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
                  class="input"
                  type="text"
                  maxlength="100"
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
                <datePicker
                  placeholder="DD/MM/YYYY"
                  :enterSubmit="true"
                  :tabSubmit="true"
                  :maxDate="new Date()"
                  :minDate="minDate"
                  locale="vn"
                  format="dd/MM/yyyy"
                  textInput
                  :dayNames="['T2', 'T3', 'T4', 'T5', 'T6', 'T7', 'CN']"
                  autoApply
                  utc
                  v-model="employee.dateOfBirth"
                />
                <!-- <input
                  tabindex="5"
                  class="input input_date"
                  type="date"
                  :max="maxDate"
                  v-model="employee.dateOfBirth"
                  :class="{ input__error: errors.errorDate }"
                  dateError="dateError"
                /> -->
                <div :class="{ input__show__error: errors.errorDate }">
                  {{ errors.errorDate }}
                </div>
              </div>
              <div class="container__input input__margin_16 input__320">
                <label class="input__label" for=""> Giới tính </label>
                <div class="container__gender">
                  <input
                    type="radio"
                    name="gender"
                    id="male"
                    value="0"
                    checked
                    v-model="employee.gender"
                  />
                  <label for="male">Nam</label>
                  <input
                    type="radio"
                    name="gender"
                    id="female"
                    value="1"
                    v-model="employee.gender"
                  />
                  <label for="">Nữ</label>
                  <input
                    type="radio"
                    name="gender"
                    id="other"
                    value="2"
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
                  @blurValidate="blurValidate"
                  :departmentName="employee.departmentName"
                  :errorDepartment="errors.errorDepartment"
                  ref="empDepartment"
                ></MCombobox>
              </div>
            </div>
            <div class="body__row__rigth">
              <div class="container__input input__320">
                <label
                  class="input__label"
                  for=""
                  v-tooltip.left="{
                    content: 'Số chứng minh nhân dân',
                  }"
                  >Số CMND</label
                >
                <input
                  class="input"
                  type="text"
                  maxlength="15"
                  placeholder="Số chứng minh nhân dân"
                  v-model="employee.identityNumber"
                />
              </div>
              <div class="container__input input__margin_6 input__160">
                <label class="input__label" for="">Ngày cấp</label>
                <datePicker
                  placeholder="DD/MM/YYYY"
                  :enterSubmit="true"
                  :tabSubmit="true"
                  :maxDate="new Date()"
                  :minDate="minDate"
                  locale="vn"
                  format="dd/MM/yyyy"
                  textInput
                  :dayNames="['T2', 'T3', 'T4', 'T5', 'T6', 'T7', 'CN']"
                  autoApply
                  utc
                  v-model="employee.identityIssuedDate"
                />
                <!-- <input
                  tabindex="10"
                  class="input input_date"
                  :max="maxDate"
                  type="date"
                  v-model="employee.identityIssuedDate"
                /> -->
              </div>
            </div>
          </div>
          <div class="modal__body__row">
            <div class="body__row__left">
              <div class="container__input input__480">
                <label class="input__label" for="">Chức danh</label>
                <input
                  class="input"
                  type="text"
                  maxlength="50"
                  placeholder="Chức danh"
                  v-model="employee.positionName"
                />
              </div>
            </div>
            <div class="body__row__rigth">
              <div class="container__input input__480">
                <label class="input__label" for="">Nơi cấp</label>
                <input
                  class="input"
                  type="text"
                  maxlength="150"
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
                class="input"
                type="text"
                maxlength="255"
                placeholder="Địa chỉ"
                v-model="employee.address"
              />
            </div>
          </div>
          <div class="modal__body__row">
            <div class="container__input input__240">
              <label
                class="input__label"
                for=""
                v-tooltip.left="{
                  content: 'Số điện thoại di động',
                }"
                >ĐT di động
              </label>
              <input
                class="input"
                type="text"
                placeholder="Số địa thoại di động"
                v-model="employee.phoneNumberMobile"
              />
            </div>
            <div class="container__input input__margin_6 input__240">
              <label
                class="input__label"
                for=""
                v-tooltip.left="{
                  content: 'Số điện thoại cố định',
                }"
                >ĐT cố định
              </label>
              <input
                class="input"
                type="text"
                placeholder="Số điện thoại cố định"
                v-model="employee.phoneNumberLandline"
              />
            </div>
            <div class="container__input input__margin_6 input__240">
              <label class="input__label" for="">Email </label>
              <input
                class="input"
                type="text"
                maxlength="100"
                placeholder="Email"
                errorCode="errorEmail"
                ref="empEmail"
                v-model="employee.email"
                :class="{ input__error: errors.errorEmail }"
                @blur="blurValidate"
              />
              <div :class="{ input__show__error: errors.errorEmail }">
                {{ errors.errorEmail }}
              </div>
            </div>
          </div>
          <div class="modal__body__row">
            <div class="container__input input__240">
              <label class="input__label" for="">Tài khoản ngân hàng </label>
              <input
                class="input"
                type="text"
                maxlength="20"
                placeholder="Tài khoản ngân hàng"
                v-model="employee.accountBank"
              />
            </div>
            <div class="container__input input__margin_6 input__240">
              <label class="input__label" for="">Tên ngân hàng </label>
              <input
                class="input"
                type="text"
                maxlength="50"
                placeholder="Tên ngân hàng"
                v-model="employee.nameBank"
              />
            </div>
            <div class="container__input input__margin_6 input__240">
              <label class="input__label" for=""> Chi nhánh </label>
              <input
                class="input"
                type="text"
                maxlength="50"
                placeholder="Chi nhánh ngân hàng"
                v-model="employee.branchBank"
              />
            </div>
          </div>
        </div>
        <div class="modal__footer">
          <div class="btn__base content__center" @click="closeModal">Hủy</div>
          <div class="modal__footer__rigth">
            <div
              class="btn__base content__center"
              v-tooltip="{
                content: 'Cất (Ctrl + S)',
              }"
              @click="saveModal"
              @keypress.enter="saveModal"
            >
              Cất
            </div>
            <div
              class="btn margin__letf_8"
              v-tooltip="{
                content: 'Cất (Ctrl + Shift + S)',
              }"
              @click="saveModalAdd"
              @keypress.enter="saveModalAdd"
            >
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
    :isFooterFE="isFooterFE"
    :isFooterBE="isFooterBE"
  ></DialogError>
</template>
<script>
import Common from "../../script/common/common";
import Enum from "../../script/common/enumeration";
import DialogFormClose from "../../components/base/MDialogFormClose.vue";
import MCombobox from "../../components/base/msCombobox/MCombobox.vue";
import DialogError from "../../components/base/MDialog.vue";
const urlBase = process.env.VUE_APP_URL;
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
    "handleToast",
  ],
  created() {
    this.employee = this.employeeSelect;
  },
  mounted() {
    /*
     *Dùng để focus vào ô đầu tiên
     */
    this.$refs.empCode.focus();
    //Thêm mã nhân viên mới khi mới from thêm mới
    if (this.formMode === Enum.FormMode.Add) {
      this.newEmployeeCode();
    }
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
      errors: {
        errorCode: "",
        errorName: "",
        errorDepartment: "",
        errorEmail: "",
        errorDate: "",
      },
      urlDepartment: `${urlBase}/Departments`,
      saveMode: Enum.SaveMode.Save,
      isErrorFrom: false,
      textErrorPopup: "",
      refName: " ",
      isFooterFE: false,
      isFooterBE: false,
      minDate: new Date("1900-01-01"),
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
      this.traneGenderNumber();
    },
    /*
     * Hàm dùng để format ngày tháng trong employee
     * PCTUANANH(16/09/2022)
     */
    formatDateEmployee() {
      if (this.formMode == Enum.FormMode.Edit) {
        this.employee.dateOfBirth = Common.formatDate2(
          this.employee.dateOfBirth
        );
        this.employee.identityIssuedDate = Common.formatDate2(
          this.employee.identityIssuedDate
        );
      }
    },

    /*
     * Hàm dùng để format giới tính từ chuỗi sang số
     * PCTUANANH(16/09/2022)
     */
    traneGenderNumber() {
      if (!this.employee.gender) {
        this.employee.gender = 0;
      } else {
        this.employee.gender = Number(this.employee.gender);
      }
    },
    /*
     * Hàm dùng để  thêm mới một mã nhân viên tự động tăng
     * PCTUANANH(13/09/2022)
     */
    newEmployeeCode() {
      try {
        fetch(`${urlBase}/Employees/new-code`)
          .then((res) => res.text())
          .then((res) => {
            this.employee.employeeCode = res;
          })
          .catch((error) => {
            console.log("Error! Could not reach the API. " + error);
            this.showErrorServer();
          });
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
      this.$emit("notLoadingData");
      this.$emit("hideModal");
    },
    /*
     * Hàm dùng để đóng modal bằng nút X
     * PCTUANANH(18/09/2022)
     */
    isCloseModal() {
      if (this.formMode === Enum.FormMode.Add) {
        if (this.employee != {}) {
          this.isCloseForm = true;
        } else {
          this.isCloseForm = false;
          this.closeModal();
        }
      } else {
        this.isCloseForm = true;
      }
    },
    /*
     * Hàm dùng để ẩn form close bằng nút hủy
     * PCTUANANH(18/09/2022)
     */
    hideCloseForm() {
      this.isCloseForm = false;
    },
    /*
     * Hàm dùng để ẩn popup show Error
     * PCTUANANH(28/09/2022)
     */
    hideErrorFrom() {
      this.isErrorFrom = false;
      if (this.isFooterFE) {
        if (this.refName) {
          if (this.refName === "empDepartment") {
            this.$refs.empDepartment.departmentForcus();
          } else {
            this.$refs[this.refName].focus();
          }
        }
      } else {
        this.$refs.empCode.focus();
      }
    },
    /*
     * Hàm dùng để validate
     * PCTUANANH(24/09/2022)
     */
    validate() {
      let isValidate = true;
      this.errors = {
        errorCode: "",
        errorName: "",
        errorDepartment: "",
        errorEmail: "",
      };
      if (!this.employee.employeeCode) {
        this.errors.errorCode = Enum.Errors.errorCode;
        isValidate = false;
      }
      if (!this.employee.employeeName) {
        this.errors.errorName = Enum.Errors.errorName;
        isValidate = false;
      }
      if (!this.employee.departmentID) {
        this.errors.errorDepartment = Enum.Errors.errorDepartment;
        isValidate = false;
      }
      if (this.employee.email) {
        if (!/^[\w-.]+@([\w-]+.)+[\w-]{2,4}$/.test(this.employee.email)) {
          this.errors.errorEmail = Enum.Errors.errorEmail;
          isValidate = false;
        }
      }

      this.validateSave();
      return isValidate;
    },
    /*
     * Hàm dùng để  validate khi cất
     * PCTUANANH(10/10/2022)
     */
    validateSave() {
      if (!this.employee.employeeCode) {
        this.isErrorFrom = true;
        this.textPopupError = Enum.Errors.errorCode;
        this.refName = "empCode";
        this.isFooterFE = true;
        return;
      }
      if (!this.employee.employeeName) {
        this.isErrorFrom = true;
        this.textPopupError = Enum.Errors.errorName;
        this.refName = "empName";
        this.isFooterFE = true;
        return;
      }
      if (!this.employee.departmentID) {
        this.isErrorFrom = true;
        this.textPopupError = Enum.Errors.errorDepartment;
        this.refName = "empDepartment";
        this.isFooterFE = true;
        return;
      }
      if (this.employee.email) {
        if (!/^[\w-.]+@([\w-]+.)+[\w-]{2,4}$/.test(this.employee.email)) {
          this.isErrorFrom = true;
          this.textPopupError = Enum.Errors.errorEmail;
          this.refName = "empEmail";
          this.isFooterFE = true;
          return;
        }
      }
    },
    /*
     * Hàm dùng để blur validate
     * PCTUANANH(27/09/2022)
     */
    blurValidate(e) {
      let errorCode = e.currentTarget.getAttribute("errorCode");
      if (errorCode === "errorEmail") {
        if (e.currentTarget.value) {
          let valueEmial = e.currentTarget.value;
          if (!/^[\w-.]+@([\w-]+.)+[\w-]{2,4}$/.test(valueEmial)) {
            this.errors[errorCode] = Enum.Errors[errorCode];
          } else {
            this.errors[errorCode] = "";
          }
        }
      } else if (e.currentTarget.value) {
        this.errors[errorCode] = "";
      } else {
        this.errors[errorCode] = Enum.Errors[errorCode];
      }
    },
    /*
     * Hàm dùng  validate backend
     * PCTUANANH(28/09/2022)
     */
    validateBackend(response, employeeCode) {
      if (
        response.errorCode &&
        response.errorCode === Enum.resErrorCodes.errorDuplicate
      ) {
        this.isErrorFrom = true;
        this.textPopupError = `${Enum.textErrorBackend.textCodeLeft} <${employeeCode}> ${Enum.textErrorBackend.textCodeRight}`;
      } else {
        {
          if (this.saveMode === Enum.SaveMode.Save) {
            this.$emit("loadingData");
            this.$emit("hideModal");
          }
          // Nếu là Cất và thêm thì sẽ reset lại from, và mã nhân viên tăng thêm
          if (this.saveMode === Enum.SaveMode.SaveAdd) {
            this.$emit("loadingData");
            setTimeout(() => {
              this.$emit("notLoadingData");
            }, 500);
            this.$emit("resetModal");
            this.employee = {};
            this.newEmployeeCode();
            this.$refs.empCode.focus();
            this.$refs.empDepartment.textInput = "";
            this.$refs.empDepartment.indexItemSelected = null;
          }
        }
      }
    },
    /*
     * Hàm dùng  hiện lỗi khi có lỗi từ server
     * PCTUANANH(10/10/2022)
     */
    showErrorServer() {
      this.isErrorFrom = true;
      this.textPopupError = Enum.textErrorBackend.textServer;
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
          if (this.formMode === Enum.FormMode.Edit) {
            this.saveEditEmployee();
            this.$emit("handleToast", Enum.textToast.updateSuccess);
          }
          // thêm mới nhân viên
          else if (this.formMode === Enum.FormMode.Add) {
            this.saveAddEmployee();
            this.$emit("handleToast", Enum.textToast.addSuccess);
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
      this.saveMode = Enum.SaveMode.Save;
      this.handleSave();
    },
    /*
     * Hàm dùng để lưu  modal và thêm mới modal
     * PCTUANANH(12/09/2022)
     */
    saveModalAdd() {
      this.saveMode = Enum.SaveMode.SaveAdd;
      this.handleSave();
    },
    /*
     * Hàm dùng để lưu  modal và thêm mới modal
     * PCTUANANH(03/10/2022)
     */
    handleKeyModel(e) {
      if (e.keyCode === Enum.keyCode.ESC) {
        e.preventDefault();
        this.isCloseModal();
      }
      if (e.keyCode === Enum.keyCode.S && e.ctrlKey) {
          e.preventDefault();
          this.saveModal();
        }
      if (e.keyCode === (Enum.keyCode.S && e.ctrlKey && e.shiftKey)) {
          e.preventDefault();
          this.saveModalAdd();
        }
      }
    ,
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
            this.validateBackend(response, data.employeeCode);
          })
          .catch((error) => {
            console.error("Error:", error);
            this.showErrorServer();
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
            this.validateBackend(response, data.employeeCode);
          })
          .catch((error) => {
            console.error("Error:", error);
            this.showErrorServer();
          });
      } catch (error) {
        console.log(error);
      }
    },
  },
};
</script>

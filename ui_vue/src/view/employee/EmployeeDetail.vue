<template>
  <!-- Form nhập -->
  <div class="modal">
    <div class="modal__container">
      <div class="modal__content">
        <div class="modal__header">
          <div class="modal__header__left">
            <h1 class="header__title">Thông tin nhân viên</h1>
            <input
              class=""
              type="checkbox"
              id=""
              v-model="employee.isCustomer"
            />
            <label for="">Là khách hàng</label>
            <input
              class=""
              type="checkbox"
              id=""
              v-model="employee.isSupplier"
            />
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
                  id="empCode"
                  tabindex="1"
                  class="input"
                  type="text"
                  placeholder="Mã nhân viên"
                  v-model="employee.employeeCode"
                  ref="input_focus"
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
                  <input
                    type="radio"
                    name="gender"
                    id="male"
                    value="0"
                    tabindex="4"
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
                <input
                  tabindex="5"
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
                  tabindex="7"
                  class="input"
                  type="text"
                  placeholder="Số chứng minh nhân dân"
                  v-model="employee.identityNumber"
                />
              </div>
              <div class="container__input input__margin_6 input__160">
                <label class="input__label" for="">Ngày cấp</label>
                <input
                  tabindex="8"
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
                  tabindex="6"
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
                  tabindex="9"
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
                tabindex="10"
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
                tabindex="11"
                class="input"
                type="text"
                placeholder="Điện thoại di động"
                v-model="employee.phoneNumberMobile"
              />
            </div>
            <div class="container__input input__margin_6 input__240">
              <label class="input__label" for="">ĐT có định </label>
              <input
                tabindex="12"
                class="input"
                type="text"
                placeholder="Điện thoại cố định"
                v-model="employee.phoneNumberLandline"
              />
            </div>
            <div class="container__input input__margin_6 input__240">
              <label class="input__label" for="">Email </label>
              <input
                tabindex="13"
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
                tabindex="14"
                class="input"
                type="text"
                placeholder="Tài khoản ngân hàng"
                v-model="employee.accountBank"
              />
            </div>
            <div class="container__input input__margin_6 input__240">
              <label class="input__label" for="">Tên ngân hàng </label>
              <input
                tabindex="15"
                class="input"
                type="text"
                placeholder="Tên ngân hàng"
                v-model="employee.nameBank"
              />
            </div>
            <div class="container__input input__margin_6 input__240">
              <label class="input__label" for=""> Chi nhánh </label>
              <input
                tabindex="16"
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
  @hideCloseForm = "hideCloseForm"
  @saveModal = "saveModal"
   ></DialogFormClose>
</template>
<script>
import Common from "../../script/common/common";
import Enumeration from "../../script/common/enumeration";
import DialogFormClose from "../../components/base/DialogFormClose.vue"
export default {
  name: "EmployeeDetailComponent",
  components: {
     DialogFormClose,
  },
  props: {
    employeeSelect: Object,
    formMode: Number,
  },
  // Khai báo các emit từ componet cha
  emits:['notLoadData','loadData','hideModal','showModal'],
  created() {
    this.employee = this.employeeSelect;
  },
  mounted() {
    /*
     *Dùng để focus vào ô đầu tiên
     */
    this.$refs.input_focus.focus();
    /*
     *Dùng để thêm một mã nhân viên tự động tăng
     */
    this.newEmployeeCode();
    /*
     *Dùng để format ngày tháng
     */
    this.formatDateEmployee();
  },
  watch: {},
  data() {
    return {
      employee: {},
      isCloseForm: false,
    };
  },
  methods: {
    /*
     * Hàm dùng để đóng modal bằng nút Hủy
     * PCTUANANH(18/09/2022)
     */
    closeModal() {
      try {
        this.$emit("notLoadData");
        this.$emit("hideModal");
      } catch (error) {
        console.log(error);
      }
    },
     /*
     * Hàm dùng để đóng modal bằng nút X
     * PCTUANANH(18/09/2022)
     */
    isCloseModal(){
       try {
        this.isCloseForm = true;
       } catch (error) {
        console.log(error);
       }
    },
     /*
     * Hàm dùng để ẩn form close bằng nút hủy
     * PCTUANANH(18/09/2022)
     */
    hideCloseForm(){
      try {
        this.isCloseForm = false; 
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
        // sửa nhân viên
        if (this.formMode === Enumeration.FormMode.Edit) {
          this.saveEditEmlpoyee();
          
           
        }
        // thêm mới nhân viên
        else if (this.formMode === Enumeration.FormMode.Add) {
          this.saveAddEmlpoyee();
        }
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
       
        this.saveModal();
        this.$emit("showModal");

        

     
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
          this.employee.employeeCode = Common.newEmployeeCode();
        }
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
     * Hàm dùng để gọi api để sửa nhân viên
     * PCTUANANH(16/09/2022)
     */
    saveEditEmlpoyee() {
      try {
        this.formatInputForm();
        let data = this.employee;
        let url = `http://localhost:3000/employees/${this.employee.id}`;
        fetch(url, {
          method: "PUT",
          headers: {
            "Content-Type": "application/json",
          },
          body: JSON.stringify(data),
        })
          .then((response) => response.json())
          .then(() => {
            this.$emit("loadData");
             this.$emit("hideModal");
          })
          .catch((error) => {
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
    saveAddEmlpoyee() {
      try {
        this.formatInputForm();
        let data = this.employee;
        let url = `http://localhost:3000/employees`;
        fetch(url, {
          method: "POST",
          headers: {
            "Content-Type": "application/json",
          },
          body: JSON.stringify(data),
        })
          .then((response) => response.json())
          .then((response) => {
            console.log(response);
            this.$emit("loadData");
            this.$emit("hideModal");          
          })
          .catch((error) => {
            console.error("Error:", error);
          });
      } catch (error) {
        console.log(error);
      }
    },
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
     * Hàm dùng để format giới tính từ chuỗi sang số
     * PCTUANANH(16/09/2022)
     */
    traneGenderNumber() {
      try {
      if( !this.employee.gender ){
         this.employee.gender =  0;
      } 
      else{
      this.employee.gender = Number(this.employee.gender);
       
      } 
      } catch (error) {
        console.log(error);
      }
    },
  },
};
</script>

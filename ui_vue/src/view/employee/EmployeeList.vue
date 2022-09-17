<template>
  <div class="content">
    <div class="content__header">
      <h3>Nhân viên</h3>
      <div class="btn content__center" @click="showModal">
        Thêm mới nhân viên
      </div>
    </div>
    <div class="content__body">
      <div class="content__body__wrapper">
        <div class="content__body__wrapper">
          <div class="container__sidebar">
            <div class="container__input input__search">
              <input
                id="search"
                class="input input__icon"
                type="text"
                placeholder="Tìm theo mã, tên nhân viên "
              />
              <div class="icon__18 icon__search"></div>
            </div>
            <div class="item__icon">
              <div class="icon__24 icon__load"></div>
            </div>
          </div>
          <div class="container__table">
            <table class="table">
              <thead>
                <tr>
                  <th class="center__checkbox">
                    <input type="checkbox" class="checkbox__table" />
                  </th>
                  <th class="" style="min-width: 100px">MÃ NHÂN VIÊN</th>
                  <th class="" style="min-width: 250px">TÊN NHÂN VIÊN</th>
                  <th class="" style="min-width: 100px">GIỚI TÍNH</th>
                  <th class="align-center" style="min-width: 100px">
                    NGÀY SINH
                  </th>
                  <th class="" style="min-width: 150px">SỐ CMND</th>
                  <th class="" style="min-width: 100px">CHỨC DANH</th>
                  <th class="" style="min-width: 100px">TÊN ĐƠN VỊ</th>
                  <th class="" style="min-width: 150px">SỐ TÀI KHOẢN</th>
                  <th class="" style="min-width: 100px">TÊN NGÂN HÀNG</th>
                  <th class="" style="min-width: 150px">CHI NHÁNH NGÂN HÀNG</th>
                  <th class="align-center function" style="min-width: 100px">
                    CHỨC NĂNG
                  </th>
                </tr>
              </thead>
              <tbody>
                <tr
                  v-for="(employee, index) in employees"
                  :key="index"
                  @dblclick="showFormEdit(employee)"
                  ref="employee__item"
                  @click="clickEmployee(index)"
                  :class="{ trClick: isClick && indexEmployee == index }"
                >
                  <td class="center__checkbox">
                    <input
                      class="checkbox__table"
                      type="checkbox"
                      @dblclick.stop
                    />
                    <div class="loading__container" v-if="isLoading">
                      <div class="loading loading__checkbox"></div>
                    </div>
                  </td>
                  <td class="">
                    {{ employee.employeeCode }}
                    <Loading v-if="isLoading"></Loading>
                  </td>
                  <td class="">
                    {{ employee.employeeName }}
                    <Loading v-if="isLoading"></Loading>
                  </td>
                  <td class="">
                    {{ showGenderName(employee.gender) }}
                    <Loading v-if="isLoading"></Loading>
                  </td>
                  <td class="align-center">
                    {{ formatDateEmployee(employee.dateOfBirth) }}
                    <Loading v-if="isLoading"></Loading>
                  </td>
                  <td class="">
                    {{ employee.identityNumber }}
                    <Loading v-if="isLoading"></Loading>
                  </td>
                  <td class="">
                    {{ employee.positionName }}
                    <Loading v-if="isLoading"></Loading>
                  </td>
                  <td class="">
                    {{ employee.departmentName }}
                    <Loading v-if="isLoading"></Loading>
                  </td>
                  <td class="">
                    {{ employee.accountBank }}
                    <Loading v-if="isLoading"></Loading>
                  </td>
                  <td class="">
                    {{ employee.nameBank }}
                    <Loading v-if="isLoading"></Loading>
                  </td>
                  <td class="">
                    {{ employee.branchBank }}
                    <Loading v-if="isLoading"></Loading>
                  </td>
                  <td class="align-center function" @dblclick.stop>
                    <div class="function__container">
                      <div class="function__content content__center">
                        <div
                          class="function-text"
                          @click="showFormEdit(employee)"
                        >
                          Sửa
                        </div>
                        <div
                          class="function__icon"
                          @click="showFunction($event, index)"
                          :class="{
                            'function__icon--show':
                              isShowFunction && indexEmployee == index,
                          }"
                        ></div>
                      </div>
                      <div
                        class="function__list"
                        v-show="isShowFunction && indexEmployee == index"
                      >
                        <div class="function__item">Nhân bản</div>
                        <div
                          class="function__item function__item--active"
                          @click="
                            showDialogDelete(employee.id, employee.employeeCode)
                          "
                        >
                          Xóa
                        </div>
                        <div class="function__item">Ngưng sử dụng</div>
                      </div>
                    </div>
                    <Loading v-if="isLoading"></Loading>
                  </td>
                </tr>
              </tbody>
            </table>
          </div>
        </div>
        <PageComponent> </PageComponent>
      </div>
    </div>
  </div>
  <DialogDelete
    v-if="isShowDelete"
    :employeeCode="employeeCode"
    @hideDialogDelete="hideDialogDelete"
    @handleDeleteEmployee="handleDeleteEmployee"
    @click.stop
  ></DialogDelete>
  <EmployeeDetail
    v-if="isShow"
    @hideModal="hideModal"
    @showModal="showModal"
    :employeeSelect="employeeSelect"
    :formMode="formMode"
    @notLoadData="notLoadData"
    @LoadData="LoadData"
   
  ></EmployeeDetail>

  <LoadingData v-if="isLoadingData"></LoadingData> 
</template>
<script>
import Common from "../../script/common/common";
import Enumeration from "../../script/common/enumeration";
import EmployeeDetail from "./EmployeeDetail.vue";
import PageComponent from "../../components/base/Page.vue";
import Loading from "../../components/base/Loading.vue";
import DialogDelete from "../../components/base/DialogDelete.vue";
 import LoadingData from "../../components/base/LoadingData.vue"
export default {
  name: "EmployeeList",
  components: {
    EmployeeDetail,
    PageComponent,
    Loading,
    DialogDelete,
    LoadingData 
  },
  created() {
    this.isLoading = true;
    this.getListEmployee();
    
  },
  data() {
    return {
      employees: [],
      employeeSelect: {},
      isShow: false,
      isLoading: false,
      isLoadingData:false,
      isShowFunction: false,
      indexEmployee: "",
      formMode: Enumeration.FormMode.Add,
      isClick: false,
      isShowDelete: false,
      employeeID: "",
      employeeCode: "",
    };
  },
  methods: {
    /*
     * Hàm dùng để  lấy danh sách nhân viên
     * PCTUANANH(12/09/2022)
     */
    getListEmployee() {
      try {
        fetch("http://localhost:3000/employees?_sort=id&_order=desc")
          .then((res) => res.json())
          .then((res) => {
            console.log(res);
            this.employees = res;
            setTimeout(() => (this.isLoading = false), 1000);  
            setTimeout(() => (this.isLoadingData = false), 1000);            
            
          })
          .catch((error) => {
            console.log("Error! Could not reach the API. " + error)
            
          });
      } catch (error) {
        console.log(error);
      }
    },
    /*
     * Hàm dùng để hiển thị modal thêm mới nhân viên
     * PCTUANANH(12/09/2022)
     */
    showModal() {
      try {
        this.isShow = true;
        this.formMode = Enumeration.FormMode.Add;
        this.employeeSelect = {};
      } catch (error) {
        console.log(error);
      }
    },

    /*
     * Hàm dùng để db  click  để sửa
     * PCTUANANH(12/09/2022)
     */
    showFormEdit(employee) {
      try {
        this.employeeSelect = employee;
        this.isShow = true;
        this.formMode = Enumeration.FormMode.Edit;
      } catch (error) {
        console.log.error;
      }
    },
    /*
     * Hàm dùng hiển thị các chức năng
     * PCTUANANH(12/09/2022)
     */
    showFunction(event, index) {
      try {
        this.indexEmployee = index;
        this.isShowFunction = !this.isShowFunction;
      } catch (error) {
        console.log.error;
      }
    },
    /*
     * Hàm dùng để ẳn modal
     * PCTUANANH(12/09/2022)
     */
    hideModal() {
      try {
        this.isShow = false;
        if (this.isLoadingData == true) {
          this.getListEmployee();
        }
      } catch (error) {
        console.log.error;
      }
    },
    /*
     * Hàm dùng để format ngày tháng hiện thị danh sách employee
     * PCTUANANH(16/09/2022)
     */
    formatDateEmployee(date) {
      try {
        let dateFormat = Common.formatDate(date);
        return dateFormat;
      } catch (error) {
        console.log(error);
      }
    },
    /*
     * Hàm dùng để hiển thị  giới tính từ các số "0,1,2"sang "Nam, Nữ, Khác"
     * PCTUANANH(16/09/2022)
     */
    showGenderName(gender) {
      try {
        let genderName = Common.formatGender(gender);
        return genderName;
      } catch (error) {
        console.log(error);
      }
    },
    /*
     * Hàm dùng để không load lại dữ liệu khi ấn nút hủy
     * PCTUANANH(16/09/2022)
     */
    notLoadData() {
      this.isLoadingData = false;
    },
    /*
     * Hàm dùng để  load lại dữ liệu khi ấn nút  cất hoặc cất thêm
     * PCTUANANH(16/09/2022)
     */
    LoadData() {
      this.isLoadingData = true; 
    
    
    },
    /*
     * Hàm dùng để   click vào Employee
     * PCTUANANH(16/09/2022)
     */
    clickEmployee(index) {
      this.indexEmployee = index;
      this.isClick = true;
    },
    /*
     * Hàm dùng  để xử xóa nhân viên theo id
     * PCTUANANH(16/09/2022)
     */
    handleDeleteEmployee() {
      this.isShowDelete = false;
      this.deleteEmployee(this.employeeID);
      this.isClick = false;
    },
    /*
     * Hàm dùng  để hiển thị Dialog xóa
     * PCTUANANH(16/09/2022)
     */

    showDialogDelete(employeeID, employeeCode) {
      this.employeeID = employeeID;
      this.employeeCode = employeeCode;
      this.isShowDelete = true;
      this.isShowFunction = false;
    },
    /*
     * Hàm dùng  để ẩn  Dialog xóa
     * PCTUANANH(16/09/2022)
     */
    hideDialogDelete() {
      this.isShowDelete = false;
    },

    /*
     * Hàm dùng  gọi APi   để xóa nhân viên theo id
     * PCTUANANH(16/09/2022)
     */
    deleteEmployee(employeeID) {
      try {
        let url = `http://localhost:3000/employees/${employeeID}`;
        fetch(url, {
          method: "DELETE",
        })
          .then((res) => res.json())
          .then(() => {
          
            this.isShowFunction = false;
            this.LoadData();
            this.getListEmployee();          
          })
          .catch((error) => {
            throw error;
          });
      } catch (error) {
        console.log(error);
      }
    },
  },
};
</script>

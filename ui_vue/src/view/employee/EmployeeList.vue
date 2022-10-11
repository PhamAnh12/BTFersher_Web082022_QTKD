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
            <div class="sidebar__left">
              <div class="sidebar__delete__list" @click="showDeleteMultiple">
                <div class="delete__list__text">Thực hiện hàng loạt</div>
                <div class="item__icon icon__16">
                  <div
                    :class="{
                      icon__delete__list: listSelectedEmp.length <= 1,
                      'icon__delete__list--acv': listSelectedEmp.length > 1,
                    }"
                  ></div>
                </div>
              </div>
              <div
                class="delete__list"
                v-if="isShowDeleteMultiple"
                @click="deleteMultiple"
              >
                Xóa
              </div>
            </div>
            <div class="sidebar__right">
              <div class="container__input input__search">
                <input
                  id="search"
                  class="input input__icon"
                  type="text"
                  placeholder="Tìm theo mã, tên nhân viên "
                  v-model="search"
                  @input="searchEmployee"
                  @keyup.enter="searchEmployee"
                />
                <div
                  class="icon__18 icon__search"
                  @click="searchEmployee"
                ></div>
              </div>
              <div class="btn__sidebar">
                <div
                  class="item__icon btn__sidebar__item"
                  @click="reload"
                  v-tooltip="{
                    content: 'Lấy lại dữ liệu',
                  }"
                >
                  <div class="icon__24 icon__load"></div>
                </div>
                <div
                  class="item__icon btn__sidebar__item"
                  @click="exportEmployee"
                  v-tooltip="{
                    content: 'Xuất ra Excel',
                  }"
                >
                  <div class="icon__24 icon__export"></div>
                </div>
              </div>
            </div>
          </div>
          <div class="container__table" ref="scrollbar">
            <table class="table">
              <thead>
                <tr>
                  <th
                    class="
                      checkbox__tb__container
                      sticky__col
                      th__sticky__col
                      sticky__col__checkbox
                    "
                  >
                    <input
                      type="checkbox"
                      class="checkbox__table"
                      @click="selectAllEmployee"
                      :checked="isCheckedAll"
                    />
                  </th>
                  <th class="th__wd__code">MÃ NHÂN VIÊN</th>
                  <th class="th__wd">TÊN NHÂN VIÊN</th>
                  <th class="th__wd__gender">GIỚI TÍNH</th>
                  <th class="align-center th__wd__date">NGÀY SINH</th>
                  <th
                    class="th__wd"
                    v-tooltip.left-start="{
                      content: 'Số chứng minh nhân dân',
                    }"
                  >
                    SỐ CMND
                  </th>
                  <th class="th__wd" style="">CHỨC DANH</th>
                  <th class="th__wd" style="">TÊN ĐƠN VỊ</th>
                  <th class="th__150" style="">SỐ TÀI KHOẢN</th>
                  <th class="th__150" style="">TÊN NGÂN HÀNG</th>
                  <th class="th__150" style="border-right: none !important">
                    CHI NHÁNH NGÂN HÀNG
                  </th>
                  <th
                    class="
                      align-center
                      function
                      th__wd__function
                      sticky__col
                      th__sticky__col th__border__left
                    "
                  >
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
                  <td
                    class="
                      checkbox__tb__container
                      td__checkbox__sticky
                      sticky__col sticky__col__checkbox
                    "
                    :class="{ trClick: isClick && indexEmployee == index }"
                  >
                    <input
                      class="checkbox__table"
                      type="checkbox"
                      :checked="isCheckedAll"
                      @input="selectEmployee(employee.employeeID)"
                      @dblclick.stop
                    />
                    <div class="loading__container" v-if="isLoading">
                      <div class="loading loading__checkbox"></div>
                    </div>
                  </td>
                  <td class="td__loading">
                    {{ employee.employeeCode }}
                    <loading v-if="isLoading"></loading>
                  </td>
                  <td class="td__loading">
                    {{ employee.employeeName }}

                    <loading v-if="isLoading"></loading>
                  </td>
                  <td class="td__loading">
                    {{ showGenderName(employee.gender) }}
                    <loading v-if="isLoading"></loading>
                  </td>
                  <td class="align-center td__loading">
                    {{ formatDateEmployee(employee.dateOfBirth) }}
                    <loading v-if="isLoading"></loading>
                  </td>
                  <td class="td__loading">
                    {{ employee.identityNumber }}
                    <loading v-if="isLoading"></loading>
                  </td>
                  <td class="td__loading">
                    {{ employee.positionName }}
                    <loading v-if="isLoading"></loading>
                  </td>
                  <td class="td__loading">
                    {{ employee.departmentName }}
                    <loading v-if="isLoading"></loading>
                  </td>
                  <td class="td__loading">
                    {{ employee.accountBank }}
                    <loading v-if="isLoading"></loading>
                  </td>
                  <td class="td__loading">
                    {{ employee.nameBank }}
                    <loading v-if="isLoading"></loading>
                  </td>
                  <td class="td__loading" style="border-right: none">
                    {{ employee.branchBank }}
                    <loading v-if="isLoading"></loading>
                  </td>

                  <td
                    class="
                      align-center
                      function function__sticky
                      sticky__col
                      td__border__left
                    "
                    :class="{ trClick: isClick && indexEmployee == index }"
                    @dblclick.stop
                  >
                    <div class="function__content content__center">
                      <div
                        class="function-text"
                        @click="showFormEdit(employee)"
                      >
                        Sửa
                      </div>
                      <div
                        class="function__icon"
                        @click="
                          showFunction(
                            $event,
                            index,
                            employee.employeeID,
                            employee.employeeCode,
                            employee
                          )
                        "
                        :class="{
                          'function__icon--show':
                            isShowFunction && indexEmployee == index,
                        }"
                      ></div>
                    </div>
                    <loading v-if="isLoading"></loading>
                  </td>
                </tr>
              </tbody>
            </table>
          </div>
        </div>
        <pageComponent
          :totalRecords="totalRecords"
          :recordNumber="recordNumber"
          :pageCount="pageCount"
          @getRecordPage="getRecordPage"
          @pagingEmployee="pagingEmployee"
        >
        </pageComponent>
      </div>
    </div>
  </div>
  <dialogDelete
    v-if="isShowDelete"
    :employeeCode="employeeCode"
    @hideDialogDelete="hideDialogDelete"
    @handleDeleteEmployee="handleDeleteEmployee"
    @click.stop
  ></dialogDelete>
  <employeeDetail
    v-if="isShow"
    :employeeSelect="employeeSelect"
    :formMode="formMode"
    @notLoadingData="notLoadingData"
    @loadingData="loadingData"
    @hideModal="hideModal"
    @showModal="showModal"
    @resetModal="resetModal"
    @handleToast="handleToast"
  ></employeeDetail>
  <toast
    v-if="isShowToast"
    :textToast="textToast"
 
  ></toast>
  <loadData v-if="isLoadingData"></loadData>

  <div
    class="function__list"
    v-if="isShowFunction"
    :style="{ top: `${topDropList}px`, left: `${leftDorpList}px` }"
  >
    <div class="function__item" @click="replicationEmployee">Nhân bản</div>
    <div
      class="function__item function__item--active"
      @click="showDialogDelete"
    >
      Xóa
    </div>
    <!-- <div class="function__item">Ngưng sử dụng</div> -->
  </div>
</template>
<script>
import Common from "../../script/common/common";
import Enum from "../../script/common/enumeration";
import employeeDetail from "./EmployeeDetail.vue";
import pageComponent from "../../components/base/MPage.vue";
import loading from "../../components/base/MLoad.vue";
import dialogDelete from "../../components/base/MDialogDelete.vue";
import loadData from "../../components/base/MLoadData.vue";
import toast from "../../components/base/MToast.vue";

const urlBase = process.env.VUE_APP_URL;
export default {
  name: "EmployeeList",
  components: {
    employeeDetail,
    pageComponent,
    loading,
    dialogDelete,
    loadData,
    toast,
  },
  created() {
    this.isLoading = true;
    this.recordNumber = JSON.parse(localStorage.getItem("recordNumberPage"));
    this.getListEmployee();
  },
  data() {
    return {
      //Object Employee
      employees: [],
      employeeSelect: {},
      empReplication: {},
      indexEmployee: null,
      employeeID: "",
      employeeCode: "",
      //Show
      isShow: false,
      isShowFunction: false,
      isShowDelete: false,
      isShowToast: false,
      //Loading
      isLoading: false,
      isLoadingData: false,
      formMode: Enum.FormMode.Add,
      isClick: false,
      //Filter
      search: "",
      totalRecords: 0,
      recordNumber: 0,
      numPage: 1,
      pageCount: 1,
      topDropList: 0,
      leftDorpList: 0,
      textToast: "",
      //Xóa nhiều
      isShowDeleteMultiple: false,
      isCheckedAll: false,
      listSelectedEmp: [],
    };
  },
  methods: {
    ///
    /// Các hàm để format
    ///
    /*
     * Hàm dùng để format ngày tháng hiện thị danh sách employee
     * PCTUANANH(16/09/2022)
     */
    formatDateEmployee(date) {
      let dateFormat = Common.formatDate(date);
      return dateFormat;
    },
    /*
     * Hàm dùng để hiển thị  giới tính từ các số "0,1,2"sang "Nam, Nữ, Khác"
     * PCTUANANH(16/09/2022)
     */
    showGenderName(gender) {
      let genderName = Common.formatGender(gender);
      return genderName;
    },
    ///
    /// Các hàm dùng để show, hiển thị
    ///
    /*
     * Hàm dùng để hiển thị modal thêm mới nhân viên
     * PCTUANANH(12/09/2022)
     */
    showModal() {
      this.isShow = true;
      this.formMode = Enum.FormMode.Add;
      this.employeeSelect = {};
    },
    /*
     * Hàm dùng để reset  modal thêm mới nhân viên
     * PCTUANANH(10/10/2022)
     */
    resetModal() {
      this.formMode = Enum.FormMode.Add;
    },
    /*
     * Hàm dùng hiển thị các chức năng
     * PCTUANANH(12/09/2022)
     */
    showFunction(event, index, employeeID, employeeCode, empReplication) {
      this.employeeID = employeeID;
      this.employeeCode = employeeCode;
      this.indexEmployee = index;
      this.empReplication = empReplication;
      this.isShowFunction = !this.isShowFunction;
      //get element được chọn
      this.topDropList = event.target.getBoundingClientRect().y + 24;
      this.leftDorpList = event.target.getBoundingClientRect().x - 72;
    },
    /*
     * Hàm dùng  để hiển thị Dialog xóa
     * PCTUANANH(16/09/2022)
     */
    showDialogDelete() {
      this.isShowDelete = true;
      this.isShowFunction = false;
    },
    /*
     * Hàm dùng  để hiện Toast
     * PCTUANANH(16/09/2022)
     */
    showToast() {
      this.isShowToast = true;
      setTimeout(() => {
        this.isShowToast = false;
      }, 1500);
    },
    ///
    /// Các hàm dùng để hide, ẩn đi
    ///
    /*
     * Hàm dùng để ẩn modal
     * PCTUANANH(12/09/2022)
     */
    hideModal() {
      this.isShow = false;
      if (this.isLoadingData) {
        this.getListEmployee();
      }
    },
    /*
     * Hàm dùng  để ẩn  Dialog xóa
     * PCTUANANH(16/09/2022)
     */
    hideDialogDelete() {
      this.isShowDelete = false;
      this.getListEmployee();
    },
    /*
     * Hàm dùng  để ẩn  Toast
     * PCTUANANH(16/09/2022)
     */
    hideToast() {
      this.isShowToast = false;
    },
    ///
    /// Các hàm xử lý loading dữ liệu
    ///
    /*
     * Hàm dùng để không load lại dữ liệu khi ấn nút hủy
     * PCTUANANH(16/09/2022)
     */
    notLoadingData() {
      this.isLoadingData = false;
    },
    /*
     * Hàm dùng để  load lại dữ liệu khi ấn nút  cất hoặc cất thêm
     * PCTUANANH(16/09/2022)
     */
    loadingData() {
      this.isLoadingData = true;
    },
     /*
     * Hàm dùng để  xử show toast
     * PCTUANANH(10/10/2022)
     */
    handleToast(textToast){
      this.showToast();
      this.textToast = textToast;
    },
    ///
    /// Các hàm để sử lý các sự kiện
    ///
    /*
     * Hàm dùng để   click vào Employee
     * PCTUANANH(16/09/2022)
     */
    clickEmployee(index) {
      this.indexEmployee = index;
      this.isClick = true;
    },
    /*
     * Hàm dùng để db  click  để sửa
     * PCTUANANH(12/09/2022)
     */
    showFormEdit(employee) {
      this.employeeSelect = employee;
      this.isShow = true;
      this.isShowFunction = false;
      this.formMode = Enum.FormMode.Edit;
    },
    /*
     * Hàm dùng  để xử xóa nhân viên theo id
     * PCTUANANH(16/09/2022)
     */
    handleDeleteEmployee() {
      try {
        this.isShowDelete = false;
        this.formMode = Enum.FormMode.Delete;
        this.deleteEmployee(this.employeeID);
        this.isClick = false;
      } catch (error) {
        console.log(error);
      }
    },
    /*
     * Hàm dùng  để nhân bản nhân viên
     * PCTUANANH(04/10/2022)
     */
    replicationEmployee() {
      try {
        this.isShow = true;
        this.formMode = Enum.FormMode.Add;
        this.employeeSelect = this.empReplication;
      } catch (error) {
        console.log(error);
      }
    },
    /*
     * Hàm dùng để  xử lý tìm kiếm
     * PCTUANANH(26/09/2022)
     */
    searchEmployee() {
      if (this.search) {
        this.isLoading = true;
        setTimeout(() => this.getListEmployee(), 1000);
      }
    },
    /*
     * Hàm dùng để  xử lý lựa chọn số bản ghi trên một trang
     * PCTUANANH(26/09/2022)
     */
    getRecordPage(recordNumber) {
      this.recordNumber = recordNumber;
      localStorage.setItem("recordNumberPage", recordNumber);
      this.reload();
    },
    /*
     * Hàm dùng để  xử lý phân trang
     * PCTUANANH(26/09/2022)
     */
    pagingEmployee(numPage) {
      this.numPage = numPage;
      this.reload();
    },

    /*
     * Hàm dùng để  load lại dữ liệu
     * PCTUANANH(28/09/2022)
     */
    reload() {
      this.isLoading = true;
      this.isCheckedAll = false;
      this.getListEmployee();
    },
    /*
     * Hàm dùng để export
     * PCTUANANH(28/09/2022)
     */
    exportEmployee() {
      let url = `${urlBase}/Employees/export-excel`;
      this.isLoadingData = true;
      fetch(url)
        .then((res) => {
          return res.blob();
        })
        .then((data) => {
          var a = document.createElement("a");
          a.href = window.URL.createObjectURL(data);
          a.download = "Danh_sach_nhan_vien.xlsx";
          a.click();
        });
      setTimeout(() => (this.isLoadingData = false), 1000);
    },
    ///
    /// Các hàm dùng để gọi đển API
    ///
    /*
     * Hàm dùng để lấy danh sách nhân viên
     * PCTUANANH(28/09/2022)
     */
    getListEmployee() {
      try {
        let offset = (this.numPage - 1) * this.recordNumber;
        let url = `${urlBase}/Employees/filter?limit=${this.recordNumber}&offset=${offset}&search=${this.search}`;
        fetch(url)
          .then((res) => res.json())
          .then((res) => {
            this.employees = res.data;
            this.totalRecords = res.totalCount;
            this.pageCount =
            parseInt(this.totalRecords / this.recordNumber) + 1;
            setTimeout(() => (this.isLoading = false), 0);
            setTimeout(() => (this.isLoadingData = false), 500);
            this.indexEmployee = 0;
            this.isShowFunction = false;          
          })
          .catch((error) => {
            console.log("Error! Could not reach the API. " + error);
          });
      } catch (error) {
        console.log(error);
      }
    },

    /*
     * Hàm dùng  gọi APi   để xóa nhân viên theo id
     * PCTUANANH(16/09/2022)
     */
    deleteEmployee(employeeID) {
      try {
        let url = `${urlBase}/Employees/${employeeID}`;
        fetch(url, {
          method: "DELETE",
        })
          .then((res) => res.json())
          .then(() => {
            this.isShowFunction = false;
            this.loadingData();
            this.textToast = Enum.textToast.deleteSuccess;
            this.showToast();
            this.getListEmployee();
          })
          .catch((error) => {
            console.log("Error! Could not reach the API. " + error);
          });
      } catch (error) {
        console.log(error);
      }
    },
    /*
     * Hàm dùng  chọn tất cả
     * PCTUANANH(10/10/2022)
     */
    selectAllEmployee() {
      this.isCheckedAll = !this.isCheckedAll;
    },
    /*
     * Hàm dùng  thêm từng employeeID
     * PCTUANANH(10/10/2022)
     */
    selectEmployee(employeeID) {
      if (this.listSelectedEmp.includes(employeeID)) {
        this.listSelectedEmp = this.listSelectedEmp.filter(function (value) {
          return value != employeeID;
        });
      } else {
        this.listSelectedEmp.push(employeeID);
      }
      if (this.listSelectedEmp.length <= 1) {
        this.isShowDeleteMultiple = false;
      }
    },
    /*
     * Hàm dùng  show xóa nhiều
     * PCTUANANH(10/10/2022)
     */
    showDeleteMultiple() {
      if (this.listSelectedEmp.length > 1) {
        this.isShowDeleteMultiple = !this.isShowDeleteMultiple;
      }
    },
    /*
     * Hàm dùng  show gọi đến Api xóa nhiều
     * PCTUANANH(10/10/2022)
     */
    deleteMultiple() {
      try {
        let url = `${urlBase}/Employees/delete-batch`;
        fetch(url, {
          method: "POST",
          headers: {
            "Content-Type": "application/json",
          },
          body: JSON.stringify(this.listSelectedEmp),
        })
          .then((response) => response.json())
          .then((response) => {
            console.log(response);
            this.isCheckedAll = false;
            this.isShowDeleteMultiple = false;
            this.listSelectedEmp = [];
            this.reload();
            console.log(this.listSelectedEmp)
           
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

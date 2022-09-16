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
                  @click="getIdEmployee(index, employee.id)"
                >
                  <td class="center__checkbox">
                    <input
                      class="checkbox__table"
                      type="checkbox"
                      @dblclick.stop
                    />
                  </td>
                  <td class="">{{ employee.employeeCode }}</td>
                  <td class="">{{ employee.employeeName }}</td>
                  <td class="">{{ employee.gender }}</td>
                  <td class="align-center">
                    {{ formatDateEmployee(employee.dateOfBirth) }}
                  </td>
                  <td class="">{{ employee.identityNumber }}</td>
                  <td class="">{{ employee.positionName }}</td>
                  <td class="">{{ employee.departmentName }}</td>
                  <td class="">{{ employee.accountBank }}</td>
                  <td class="">{{ employee.nameBank }}</td>
                  <td class="">{{ employee.branchBank }}</td>
                  <td class="align-center function" @dblclick.stop>
                    <div class="function__container">
                      <div class="function__content content__center">
                        <div class="function-text">Sửa</div>
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
                        <div class="function__item function__item--active">
                          Xóa
                        </div>
                        <div class="function__item">Ngưng sử dụng</div>
                      </div>
                    </div>
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
  <EmployeeDetail
    v-if="isShow"
    @hideModal="hideModal"
    :employeeSelect="employeeSelect"
    :formMode="formMode"
  ></EmployeeDetail>
</template>
<script>
import Common from "../../script/common/common";
import Enumeration from "../../script/common/enumeration";
import EmployeeDetail from "./EmployeeDetail.vue";
import PageComponent from "../../components/base/Page.vue";
export default {
  name: "EmployeeList",
  components: {
    EmployeeDetail,
    PageComponent,
  },
  created() {
    this.getListEmployee();
  },
  data() {
    return {
      employees: [],
      isShow: false,
      isShowFunction: false,
      indexEmployee: "",
      employeeSelect: {},
      formMode: Enumeration.FormMode.Add,
    };
  },
  methods: {
    /*
     * Hàm dùng để  lấy danh sách nhân viên
     * PCTUANANH(12/09/2022)
     */
    getListEmployee() {
      try {
        fetch("http://localhost:3000/employees")
          .then((res) => res.json())
          .then((res) => {
            console.log(res);
            this.employees = res;
          })
          .catch((error) => {
            throw error;
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
        this.employeeSelect = {};
        this.formMode = Enumeration.FormMode.Add;
      } catch (error) {
        console.log(error);
      }
    },
    /*
     * Hàm dùng để ẳn modal
     * PCTUANANH(12/09/2022)
     */
    hideModal() {
      try {
        this.isShow = false;
        this.getListEmployee();
      } catch (error) {
        console.log.error;
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
        event.preventDefault();
        event.stopPropagation();
        this.indexEmployee = index;
        this.isShowFunction = !this.isShowFunction;
      } catch (error) {
        console.log.error;
      }
    },
    /*
     * Hàm dùng để format ngày tháng hiện thị danh sách employee
     * PCTUANANH(16/09/2022)
     */
    formatDateEmployee(date) {
      let dateFormat = Common.formatDate(date);
      return dateFormat;
    },
    getIdEmployee(index, id) {
      console.log(this.$refs.employee__item[index]);
      console.log(id);
    },
  },
};
</script>

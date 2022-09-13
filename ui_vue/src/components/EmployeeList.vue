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
                  <th class="center__checkbox"><input type="checkbox" /></th>
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
                  <th class="align-center" style="min-width: 100px">
                    CHỨC NĂNG
                  </th>
                </tr>
              </thead>
              <tbody>
                <tr
                  v-for="(employee, index) in employees"
                  :key="index"
                  @dblclick="dbClicktr(employee)"
                >
                  <td class="center__checkbox"><input type="checkbox" /></td>
                  <td class="">{{ employee.employeeCode }}</td>
                  <td class="">{{ employee.employeeName }}</td>
                  <td class="">{{ employee.gender }}</td>
                  <td class="align-center">{{ employee.dateOfBirth }}</td>
                  <td class="">{{ employee.identityNumber }}</td>
                  <td class="">{{ employee.positionName }}</td>
                  <td class="">{{ employee.departmentName }}</td>
                  <td class="">{{ employee.accountBank }}</td>
                  <td class="">{{ employee.nameBank }}</td>
                  <td class="">{{ employee.branchBank }}</td>
                  <td class="align-center">
                    <div class="function__container">
                      <div class="function__content">
                        <div class="function-text">Sửa</div>
                        <div
                          class="function__icon"
                          @click="isShowFunction = !isShowFunction"
                          :class="{ 'function__icon--show': isShowFunction }"
                        ></div>
                      </div>
                      <div class="function__list" v-show="isShowFunction">
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
        <div class="content__footer">
          <div class="content__footer_letf">Tổng số <b>999</b> bản ghi</div>
          <div class="content__footer__right">
            <div class="select__page">
              <select name="" id="">
                <option value="">10 bản ghi trên 1 trang</option>
                <option value="">20 bản ghi trên 1 trang</option>
                <option value="">30 bản ghi trên 1 trang</option>
                <option value="">50 bản ghi trên 1 trang</option>
                <option value="">100 bản ghi trên 1 trang</option>
              </select>
            </div>
            <div class="page">
              <div class="page--dislabel page__text">Trước</div>
              <div class="page__number pageing__number--active">1</div>
              <div class="page__number">2</div>
              <div class="page__number">3</div>
              <div class="page__icon">...</div>
              <div class="page__number">52</div>
              <div class="page__text">Sau</div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
  <EmployeeDetailComponent
    v-if="isShow"
    @hideModal="hideModal"
    :employeeSelect="employeeSelect"
  ></EmployeeDetailComponent>
</template>
<script>
import EmployeeDetailComponent from "./EmployeeDetail.vue";

export default {
  name: "EmployeeListComponent",
  components: {
    EmployeeDetailComponent,
  },
  created() {
    /*
     * Hàm dùng để  lấy danh sách nhân viên
     * PCTUANANH(12/09/2022)
     */
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
  data() {
    return {
      employees: [],
      isShow: false,
      isShowFunction: false,
      employeeSelect: {},
    };
  },
  methods: {
    /*
     * Hàm dùng để hiển thị modal thêm mới nhân viên
     * PCTUANANH(12/09/2022)
     */
    showModal() {
      try {
        this.isShow = true;
        this.employeeSelect = {};
      } catch (error) {
        console.log(error);
      }
    },
    /*
     * Hàm dùng để ẳn modal
     * PCTUANANH(12/09/2022)
     */
    hideModal() {
      this.isShow = false;
    },
    /*
     * Hàm dùng để db  click  để sửa
     * PCTUANANH(12/09/2022)
     */
    dbClicktr(employee) {
      this.employeeSelect = employee;
      this.isShow = true;
    },
  },
};
</script>

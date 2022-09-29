using Misa.Web082022.QTKD.Multilayer.Common;
using Misa.Web082022.QTKD.Multilayer.Common.Entities;

namespace Misa.Web082022.QTKD.Multilayer.BL
{
    public interface IEmployeeBL
    {
        #region Filter Employees

        /// <summary>
        /// API Lấy danh sách nhân viên cho phép lọc và phân trang
        /// </summary>
        /// <param name="search">Tìm kiếm theo Số điện thoại, tên, Mã nhân viên</param>
        /// <param name="sort">  Sắp xếp</param>
        /// <param name="limit">Số trang muốn lấy</param>
        /// <param name="offset">Thứ tự trang muốn lấy</param>
        /// <returns>Một đối tượng gồm:
        /// + Danh sách nhân viên thỏa mãn điều kiện lọc và phân trang
        /// + Tổng số nhân viên thỏa mãn điều kiện</returns>
        /// Created by: PCTUANANH(29/09/2022)
        public PagingData<Employee> FilterEmployees(string? search, string? sort, int limit, int offset);

        #endregion

        #region Get Employee by ID

        /// <summary>
        ///  lấy thông tin chi tiết của 1 nhân viên
        /// </summary>
        /// <param name="employeeid">id của nhân viên muốn lấy thông tin chi tiết</param>
        /// <returns>đối tượng nhân viên muốn lấy thông tin chi tiết</returns>
        /// created by: pctuananh(29/09/2022)
        public Employee GetEmployeeByID(Guid employeeid);

        #endregion

        #region Get New EmployeeCode

        /// <summary>
        /// api lấy mã nhân viên mới tự động tăng
        /// </summary>
        /// <returns>mã nhân viên mới tự động tăng</returns>
        /// created by: pctuananh(29/09/2022)
        public string GetNewEmployeeCode();

        #endregion

        #region Insert Employee

        /// <summary>
        /// api thêm mới một nhân viên 
        /// <param name="employee">đối tượng nhân viên mới</param>
        /// <returns>số bản ghi bị thay đổi</returns>
        /// </summary>
        /// created by: pctuananh(29/09/2022)
        public ServiceResponse InsertEmployee(Employee employee);

        #endregion

        #region Update Employee

        /// <summary>
        /// api thêm mới một nhân viên 
        /// <param name="employee">đối tượng nhân viên mới</param>
        /// <returns>số bản ghi bị thay đổi</returns>
        /// </summary>
        /// created by: pctuananh(29/09/2022)
        public ServiceResponse UpDateEmployee(Guid employeeID, Employee employee);

        #endregion

        #region Delete Employee

        /// <summary>
        /// api thêm mới một nhân viên 
        /// <param name="employee">đối tượng nhân viên mới</param>
        /// <returns>số bản ghi bị thay đổi</returns>
        /// </summary>
        /// created by: pctuananh(29/09/2022)
        public ServiceResponse DeleteEmployee(Guid employeeID);

        #endregion


    }
}

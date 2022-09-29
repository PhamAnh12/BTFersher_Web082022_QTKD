using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Misa.Web082022.QTKD.Multilayer.Common.Entities;


namespace Misa.Web082022.QTKD.Multilayer.DL
{
    public interface IEmployeeDL
    {

        #region Filter Employee

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

        #region  Get Employee By ID

        /// <summary>
        ///  Lấy thông tin chi tiết của 1 nhân viên
        /// </summary>
        /// <param name="employeeID">ID của nhân viên muốn lấy thông tin chi tiết</param>
        /// <returns>Đối tượng nhân viên muốn lấy thông tin chi tiết</returns>
        /// Created by: PCTUANANH(29/09/2022)
        public Employee GetEmployeeByID(Guid employeeID); 

        #endregion

        #region Get New EmployeeCode

        /// <summary>
        /// API Lấy mã nhân viên mới tự động tăng
        /// </summary>
        /// <returns>Mã nhân viên mới tự động tăng</returns>
        /// Created by: PCTUANANH(29/09/2022)
        public string GetNewEmployeeCode();

        #endregion

        #region Insert Employee

        /// <summary>
        /// API thêm mới một nhân viên 
        /// <param name="employee">Đối tượng nhân viên mới</param>
        /// <returns>Số bản ghi bị thay đổi</returns>
        /// </summary>
        /// Created by: PCTUANANH(29/09/2022)
        public int InsertEmployee(Employee employee);

        #endregion

        #region Update Employee

        /// <summary>
        /// API thêm mới một nhân viên 
        /// <param name="employee">Đối tượng nhân viên mới</param>
        /// <returns>Số bản ghi bị thay đổi</returns>
        /// </summary>
        /// Created by: PCTUANANH(29/09/2022)
        public int UpdateEmployee( Guid employeeID,Employee employee);

        #endregion

        #region Delete Employee

        /// <summary>
        /// API thêm mới một nhân viên 
        /// <param name="employee">Đối tượng nhân viên mới</param>
        /// <returns>Số bản ghi bị thay đổi</returns>
        /// </summary>
        /// Created by: PCTUANANH(29/09/2022)
        public int DeleteEmployee(Guid employeeID);

        #endregion

    }
}

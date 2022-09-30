using Misa.Web082022.QTKD.Multilayer.Common;
using Misa.Web082022.QTKD.Multilayer.Common.Entities;
using Misa.Web082022.QTKD.Multilayer.DL;

namespace Misa.Web082022.QTKD.Multilayer.BL
{
    public class EmployeeBL : IEmployeeBL
    {
        #region Field

        private IEmployeeDL _employeeDL;

        #endregion

        #region Controctor

        public EmployeeBL(IEmployeeDL employeeDL)
        {
            _employeeDL = employeeDL;
        }

        #endregion

        #region Method

        #region  Filter Employees

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
        public PagingData<Employee> FilterEmployees(string? search, string? sort, int limit, int offset)
        {
             return _employeeDL.FilterEmployees(search, sort, limit, offset);
            
        }

        #endregion

        #region Get Employee BY ID

        /// <summary>
        ///  Lấy thông tin chi tiết của 1 nhân viên
        /// </summary>
        /// <param name="employeeID">ID của nhân viên muốn lấy thông tin chi tiết</param>
        /// <returns>Đối tượng nhân viên muốn lấy thông tin chi tiết</returns>
        /// Created by: PCTUANANH(29/09/2022)
        public Employee GetEmployeeByID(Guid employeeID)
        {
            return _employeeDL.GetEmployeeByID(employeeID);
        }

        #endregion

        #region Get NewEmployeeCode

        /// <summary>
        /// API Lấy mã nhân viên mới tự động tăng
        /// </summary>
        /// <returns>Mã nhân viên mới tự động tăng</returns>
        /// Created by: PCTUANANH(29/09/2022)
        public string GetNewEmployeeCode()
        {
            string maxEmployeeCode = _employeeDL.GetNewEmployeeCode();
            string newEmployeeCode = "";
            if (maxEmployeeCode.Substring(0, 4) == "NV00")
            {
                newEmployeeCode = "NV00" + (Int64.Parse(maxEmployeeCode.Substring(4)) + 1).ToString();

            }
            else if (maxEmployeeCode.Substring(0, 3) == "NV0")
            {
                newEmployeeCode = "NV0" + (Int64.Parse(maxEmployeeCode.Substring(3)) + 1).ToString();

            }
            else if (maxEmployeeCode.Substring(0, 2) == "NV")
            {
                newEmployeeCode = "NV" + (Int64.Parse(maxEmployeeCode.Substring(2)) + 1).ToString();

            }
            return newEmployeeCode;

        }

        #endregion

        #region Insert Employee

        /// <summary>
        /// API thêm mới một nhân viên 
        /// <param name="employee">Đối tượng nhân viên mới</param>
        /// <returns>Số bản ghi bị thay đổi</returns>
        /// </summary>
        /// Created by: PCTUANANH(29/09/2022)
        public ServiceResponse InsertEmployee(Employee employee)
        {
            var employeeID = Guid.NewGuid();
           
            employee.EmployeeID = employeeID;
            // validate dữ liệu đầu vào
            List<string> ValidateErrors = Validation.Validate(employee);
            if (ValidateErrors.Count > 0)
            {
                string listValidateErrors = string.Join(", ", ValidateErrors);
                return new ServiceResponse
                {   
                    IsValidate = false,
                    strValidate = listValidateErrors,
                    Success = false,
                    Data = listValidateErrors
                };
            }
            else
            {
                int numberOfAffectedRows = _employeeDL.InsertEmployee(employee);
                if (numberOfAffectedRows > 0)
                {
                    return new ServiceResponse
                    {
                        IsValidate = true,
                        strValidate = "",
                        Success = true,
                        Data = employeeID
                    };
                }
                else
                {
                    return new ServiceResponse
                    {
                        IsValidate = true,
                        strValidate = "",
                        Success = false,
                        Data = null,
                    };
                }

            }

            
        }

        #endregion

        #region Update Employee

        /// <summary>
        /// API thêm mới một nhân viên 
        /// <param name="employee">Đối tượng nhân viên mới</param>
        /// <returns>Số bản ghi bị thay đổi</returns>
        /// </summary>
        /// Created by: PCTUANANH(29/09/2022)
        public ServiceResponse UpDateEmployee(Guid employeeID, Employee employee)
        {
            // validate dữ liệu đầu vào
            List<string> ValidateErrors = Validation.Validate(employee);
            if (ValidateErrors.Count > 0)
            {
                string listValidateErrors = string.Join(", ", ValidateErrors);
                return new ServiceResponse
                {
                    IsValidate = false,
                    strValidate = listValidateErrors,
                    Success = false,
                    Data = listValidateErrors
                };
            }
            else
            {
                int numberOfAffectedRows = _employeeDL.UpdateEmployee(employeeID, employee);
                if (numberOfAffectedRows > 0)
                {
                    return new ServiceResponse
                    {
                        IsValidate = true,
                        strValidate = "",
                        Success = true,
                        Data = employeeID
                    };
                }
                else
                {
                    return new ServiceResponse
                    {
                        IsValidate = true,
                        strValidate = "",
                        Success = false,
                        Data = null,
                    };
                }
            }
        }

        #endregion

        #region Delete Employee

        /// <summary>
        /// API thêm mới một nhân viên 
        /// <param name="employee">Đối tượng nhân viên mới</param>
        /// <returns>Số bản ghi bị thay đổi</returns>
        /// </summary>
        /// Created by: PCTUANANH(29/09/2022)
        public ServiceResponse DeleteEmployee(Guid employeeID)
        {
            int numberOfAffectedRows = _employeeDL.DeleteEmployee(employeeID);
            if (numberOfAffectedRows > 0)
            {
                return new ServiceResponse
                {   IsValidate= true,
                    Success = true,
                    Data = employeeID
                };
            }
            else
            {
                return new ServiceResponse
                {
                    IsValidate = true,
                    Success = false,
                    Data = ""
                };
            }
        }



        #endregion

        #endregion
    }
}

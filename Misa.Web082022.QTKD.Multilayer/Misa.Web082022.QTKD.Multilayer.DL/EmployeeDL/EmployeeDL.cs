using Dapper;
using Misa.Web082022.QTKD.Multilayer.Common.Entities;
using Misa.Web082022.QTKD.Multilayer.Common.Resource;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Misa.Web082022.QTKD.Multilayer.DL
{
    public class EmployeeDL : IEmployeeDL
    {
        #region  Filter Employee

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
            using (var mySqlConnection = new MySqlConnection(DataContext.MySqlConnectionString))
            {
                // Chuẩn bị tên Stored procedure
                string storedProcedureName =Resource.Proc_Employee_GetPaing;

                // Chuẩn bị tham số đầu vào cho stored procedure
                var parameters = new DynamicParameters();
                parameters.Add("v_Offset", offset);
                parameters.Add("v_Limit", limit);
                parameters.Add("v_Sort", sort);
                string whereCondition = "";
                if (search != null)
                {
                    whereCondition = $" EmployeeCode LIKE   \'%{search}%\' OR EmployeeName LIKE  \'%{search}%\'";
                }
                parameters.Add("v_Where", whereCondition);

                // Thực hiện gọi vào DB để chạy stored procedure với tham số đầu vào ở trên
                var multipleResults = mySqlConnection.QueryMultiple(storedProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);

                if (multipleResults != null)
                {
                    var employees = multipleResults.Read<Employee>();
                    var totalCount = multipleResults.Read<long>().Single();
                    return (new PagingData<Employee>()
                    {
                        Data = employees.ToList(),
                        TotalCount = totalCount
                    });
                }
                else
                {
                    return null;
                }
            }
        }

        #endregion

        #region  Get Employee By ID 

        /// <summary>
        ///  Lấy thông tin chi tiết của 1 nhân viên
        /// </summary>
        /// <param name="employeeID">ID của nhân viên muốn lấy thông tin chi tiết</param>
        /// <returns>Đối tượng nhân viên muốn lấy thông tin chi tiết</returns>
        /// Created by: PCTUANANH(12/07/2022)
        public Employee GetEmployeeByID(Guid employeeID)
        {

            using (var mySqlConnection = new MySqlConnection(DataContext.MySqlConnectionString))
            {

                // Chuẩn bị tên Stored procedure
                string storedProcedureName = Resource.Proc_Employee_GetByEmployeeID;

                // Chuẩn bị tham số đầu vào cho stored procedure
                var parameters = new DynamicParameters();
                parameters.Add("v_EmployeeID", employeeID);

                // Thực hiện gọi vào DB để chạy stored procedure với tham số đầu vào ở trên
                var employee = mySqlConnection.QueryFirstOrDefault<Employee>(storedProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);
                return employee;
            }

        }



        #endregion

        #region Get New EmployeeCode 

        /// <summary>
        /// API Lấy mã nhân viên mới tự động tăng
        /// </summary>
        /// <returns>Mã nhân viên mới tự động tăng</returns>
        /// Created by: PCTUANANH(29/09/2022)
        public string GetNewEmployeeCode()
        {
            using (var mySqlConnection = new MySqlConnection(DataContext.MySqlConnectionString))
            {
                // Chuẩn bị tên stored procedure
                string storedProcedureName = Resource.Proc_Employee_GetMaxEmployeeCode;

                // Thực hiện gọi vào DB để chạy stored procedure ở trên
                string maxEmployeeCode = mySqlConnection.QueryFirstOrDefault<string>(storedProcedureName, commandType: System.Data.CommandType.StoredProcedure);

                return maxEmployeeCode;

            }
        }

        #endregion

        #region Insert Employee

        /// <summary>
        /// API thêm mới một nhân viên 
        /// <param name="employee">Đối tượng nhân viên mới</param>
        /// <returns>Số bản ghi bị thay đổi</returns>
        /// </summary>
        /// Created by: PCTUANANH(29/09/2022)
        public int InsertEmployee(Employee employee)
        {
            using (var mySqlConnection = new MySqlConnection(DataContext.MySqlConnectionString))
            {
                // Chuẩn bị tên stored procedure
                string storedProcedureName =Resource.Proc_Employee_InsertEmployee;

                // Chuẩn bị tham số đầu vào cho câu lệnh INSERT INTO
              
                var parameters = new DynamicParameters();
                parameters.Add("v_EmployeeID", employee.EmployeeID);
                parameters.Add("v_EmployeeCode", employee.EmployeeCode);
                parameters.Add("v_EmployeeName", employee.EmployeeName);
                parameters.Add("v_DateOfBirth", employee.DateOfBirth);
                parameters.Add("v_Gender", employee.Gender);
                parameters.Add("v_DepartmentID", employee.DepartmentID);
                parameters.Add("v_IdentityNumber", employee.IdentityNumber);
                parameters.Add("v_IdentityIssuedDate", employee.IdentityIssuedDate);
                parameters.Add("v_IdentityIssuedPlace", employee.IdentityIssuedPlace);
                parameters.Add("v_PositionName", employee.PositionName);
                parameters.Add("v_Address", employee.Address);
                parameters.Add("v_MobilePhoneNumber", employee.MobilePhoneNumber);
                parameters.Add("v_LandlinePhoneNumber", employee.LandlinePhoneNumber);
                parameters.Add("v_Email", employee.Email);
                parameters.Add("v_AccountBank", employee.AccountBank);
                parameters.Add("v_NameBank", employee.NameBank);
                parameters.Add("v_BranchBank", employee.BranchBank);
                parameters.Add("v_CreatedDate", DateTime.Now);
                parameters.Add("v_CreatedBy", "Admin");
                parameters.Add("v_ModifiedDate", DateTime.Now);
                parameters.Add("v_ModifiedBy", "Admin");

                // Thực hiện gọi vào DB để chạy câu lệnh INSERT INTO với tham số đầu vào ở trên
                int numberOfAffectedRows = mySqlConnection.Execute(storedProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);

                return numberOfAffectedRows;
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
        public int UpdateEmployee(Guid employeeID, Employee employee)
        {
            using (var mySqlConnection = new MySqlConnection(DataContext.MySqlConnectionString))
            {
                // Chuẩn bị tên stored procedure
                string storedProcedureName =Resource.Proc_Employee_UpdateEmployee;

                // Chuẩn bị tham số đầu vào cho câu lệnh INSERT INTO
                var parameters = new DynamicParameters();
                parameters.Add("v_EmployeeID", employeeID);
                parameters.Add("v_EmployeeCode", employee.EmployeeCode);
                parameters.Add("v_EmployeeName", employee.EmployeeName);
                parameters.Add("v_DateOfBirth", employee.DateOfBirth);
                parameters.Add("v_Gender", employee.Gender);
                parameters.Add("v_DepartmentID", employee.DepartmentID);
                parameters.Add("v_IdentityNumber", employee.IdentityNumber);
                parameters.Add("v_IdentityIssuedDate", employee.IdentityIssuedDate);
                parameters.Add("v_IdentityIssuedPlace", employee.IdentityIssuedPlace);
                parameters.Add("v_PositionName", employee.PositionName);
                parameters.Add("v_Address", employee.Address);
                parameters.Add("v_MobilePhoneNumber", employee.MobilePhoneNumber);
                parameters.Add("v_LandlinePhoneNumber", employee.LandlinePhoneNumber);
                parameters.Add("v_Email", employee.Email);
                parameters.Add("v_AccountBank", employee.AccountBank);
                parameters.Add("v_NameBank", employee.NameBank);
                parameters.Add("v_BranchBank", employee.BranchBank);
                parameters.Add("v_CreatedDate", employee.CreatedDate);
                parameters.Add("v_CreatedBy", employee.CreatedBy);
                parameters.Add("v_ModifiedDate", DateTime.Now);
                parameters.Add("v_ModifiedBy", "Admin");

                // Thực hiện gọi vào DB để chạy câu lệnh INSERT INTO với tham số đầu vào ở trên
                int numberOfAffectedRows = mySqlConnection.Execute(storedProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);
                return numberOfAffectedRows;
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
        public int DeleteEmployee(Guid employeeID)
        {
            using (var mySqlConnection = new MySqlConnection(DataContext.MySqlConnectionString))
            {
                // Chuẩn bị tên Stored procedure
                string storedProcedureName = Resource.Proc_Employee_DeleteByEmployeeID;

                // Chuẩn bị tham số đầu vào cho stored procedure
                var parameters = new DynamicParameters();
                parameters.Add("v_EmployeeID", employeeID);

                // Thực hiện gọi vào DB để chạy câu lệnh DELETE với tham số đầu vào ở trên
                int numberOfAffectedRows = mySqlConnection.Execute(storedProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);
                return numberOfAffectedRows;
            }
           
        }

        #endregion


    }
}

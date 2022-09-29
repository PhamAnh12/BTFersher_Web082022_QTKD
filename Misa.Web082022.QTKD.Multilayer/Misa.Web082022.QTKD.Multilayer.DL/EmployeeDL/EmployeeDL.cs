using Dapper;
using Misa.Web082022.QTKD.Multilayer.Common;
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
        #region  Get Employee By ID 

        /// <summary>
        ///  Lấy thông tin chi tiết của 1 nhân viên
        /// </summary>
        /// <param name="employeeID">ID của nhân viên muốn lấy thông tin chi tiết</param>
        /// <returns>Đối tượng nhân viên muốn lấy thông tin chi tiết</returns>
        /// Created by: PCTUANANH(12/07/2022)
        public Employee GetEmployeeByID(Guid employeeID)
        {
            string connectionString = DataContext.MySqlConnectionString;
            var mySqlConnection = new MySqlConnection(connectionString);

            // Chuẩn bị tên Stored procedure
            string storedProcedureName = "Proc_Employee_GetByEmployeeID";

            // Chuẩn bị tham số đầu vào cho stored procedure
            var parameters = new DynamicParameters();
            parameters.Add("v_EmployeeID", employeeID);

            // Thực hiện gọi vào DB để chạy stored procedure với tham số đầu vào ở trên
            var employee = mySqlConnection.QueryFirstOrDefault<Employee>(storedProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);
            return employee;
        }

        #endregion
    }
}

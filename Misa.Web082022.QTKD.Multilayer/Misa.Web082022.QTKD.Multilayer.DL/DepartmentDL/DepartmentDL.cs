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
    public class DepartmentDL : IDepartmentDL
    {
        /// <summary>
        /// API Lấy toàn bộ danh sách phòng ban
        /// </summary>
        /// <returns>Danh sách phòng ban</returns>
        /// Created by: PCTUANANH(30/09/2022)
        public IEnumerable<Department> GetAllDepartment()
        {
            using (var mySqlConnection = new MySqlConnection(DataContext.MySqlConnectionString))
            {
                // Chuẩn bị tên Stored procedure
                string storedProcedureName = Resource.Proc_Department_Get_All;

                // Thực hiện gọi vào DB để chạy câu lệnh truy vấn ở trên
                var departments = mySqlConnection.Query<Department>(storedProcedureName, commandType: System.Data.CommandType.StoredProcedure);
                return departments;
            }

        }
    }
}

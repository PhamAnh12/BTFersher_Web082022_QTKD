using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Misa.Web082022.QTKD.Multilayer.Common;


namespace Misa.Web082022.QTKD.Multilayer.DL
{
    public interface IEmployeeDL
    {
        /// <summary>
        ///  Lấy thông tin chi tiết của 1 nhân viên
        /// </summary>
        /// <param name="employeeID">ID của nhân viên muốn lấy thông tin chi tiết</param>
        /// <returns>Đối tượng nhân viên muốn lấy thông tin chi tiết</returns>
        /// Created by: PCTUANANH(29/09/2022)
        public Employee GetEmployeeByID(Guid employeeID);

    }
}

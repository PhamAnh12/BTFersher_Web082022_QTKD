
using Misa.Web082022.QTKD.Multilayer.DL;
using System.Collections;

namespace Misa.Web082022.QTKD.Multilayer.BL
{
    public class DepartmentBL : IDepartmentBL

    {
        #region Field

        private IDepartmentDL _departmentDL;

        #endregion

        #region Controctor

        public DepartmentBL(IDepartmentDL departmentDL)
        {
            _departmentDL = departmentDL;
        }

        #endregion

        #region Get All Department

        /// <summary>
        /// API Lấy toàn bộ danh sách phòng ban
        /// </summary>
        /// <returns>Danh sách phòng ban</returns>
        /// Created by: PCTUANANH(30/09/2022)
        public IEnumerable GetAllDepartment()
        {
            return _departmentDL.GetAllDepartment();

        } 

        #endregion
    }
}

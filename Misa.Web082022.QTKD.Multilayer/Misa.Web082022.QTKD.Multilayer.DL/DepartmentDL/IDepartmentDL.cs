using Misa.Web082022.QTKD.Multilayer.Common.Entities;


namespace Misa.Web082022.QTKD.Multilayer.DL
{
     public interface IDepartmentDL
    {
        /// <summary>
        /// API Lấy toàn bộ danh sách phòng ban
        /// </summary>
        /// <returns>Danh sách phòng ban</returns>
        /// Created by: PCTUANANH(30/09/2022)

        public IEnumerable<Department> GetAllDepartment();
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Misa.Web082022.QTKD.Multilayer.BL
{
    public interface IDepartmentBL
    {
        /// <summary>
        /// API Lấy toàn bộ danh sách phòng ban
        /// </summary>
        /// <returns>Danh sách phòng ban</returns>
        /// Created by: PCTUANANH(30/09/2022) 
        public IEnumerable GetAllDepartment();
    }
}

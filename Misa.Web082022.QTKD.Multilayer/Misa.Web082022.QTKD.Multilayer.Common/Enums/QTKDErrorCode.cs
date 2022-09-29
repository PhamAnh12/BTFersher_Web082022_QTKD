using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Misa.Web082022.QTKD.Multilayer.Common
{
    /// <summary>
    /// Các mã lỗi
    /// </summary>
    public enum QTKDErrorCode
    {
        /// <summary>
        /// Lỗi do Exception
        /// </summary>
        Exception = 1,

        /// <summary>
        /// Lỗi khi lây, thêm ,sửa,xóa vào data không thành công
        /// </summary>
        ResultDatabaseFailed = 2,

        /// <summary>
        /// Lỗi do trùng mã nhân viên
        /// </summary>
        DuplicateCode = 3,

        /// <summary>
        /// Lỗi do các trường để trống
        /// </summary>
        InputValidation = 4


    }
}

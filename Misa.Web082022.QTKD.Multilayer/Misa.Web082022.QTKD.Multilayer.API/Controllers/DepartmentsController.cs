using Microsoft.AspNetCore.Mvc;
using Misa.Web082022.QTKD.Multilayer.BL;
using Misa.Web082022.QTKD.Multilayer.Common.Entities;
using Misa.Web082022.QTKD.Multilayer.Common.Enums;
using Misa.Web082022.QTKD.Multilayer.Common;
using Swashbuckle.AspNetCore.Annotations;

namespace Misa.Web082022.QTKD.Multilayer.API.Controllers
{

    [Route("api/v1/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        #region Field

        private IDepartmentBL _departmentBL;
        private ResponeErrorResult responeErrorResult;
        #endregion

        #region Controctor

        public DepartmentsController(IDepartmentBL departmentBL)
        {
            _departmentBL = departmentBL;
            responeErrorResult = new ResponeErrorResult();
        }

        #endregion

        #region Get Deapartment API

        /// <summary>
        /// API Lấy toàn bộ danh sách phòng ban
        /// </summary>
        /// <returns>Danh sách phòng ban</returns>
        /// Created by: PCTUANANH(30/09/2022)
        [HttpGet]
        [SwaggerResponse(StatusCodes.Status200OK, type: typeof(List<Department>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        public IActionResult Deapartments()
        {
            try
            {
                var departments = _departmentBL.GetAllDepartment();
                if (departments != null)
                {
                    return StatusCode(StatusCodes.Status200OK, departments);

                }
                else
                {
                    return StatusCode(StatusCodes.Status404NotFound, responeErrorResult.ErrorResultGet(HttpContext.TraceIdentifier));
                }
            }
            catch (Exception exception)
            {
                // TODO: Sau này có thể bổ sung log lỗi ở đây để khi gặp exception trace lỗi cho dễ
                return StatusCode(StatusCodes.Status400BadRequest,
                    responeErrorResult.ErrorResultException(HttpContext.TraceIdentifier));
            }
        }

        #endregion

    }
}

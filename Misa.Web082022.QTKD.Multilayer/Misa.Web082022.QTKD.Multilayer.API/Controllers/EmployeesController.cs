
using Microsoft.AspNetCore.Mvc;
using Misa.Web082022.QTKD.Multilayer.BL;
using Misa.Web082022.QTKD.Multilayer.Common;
using Misa.Web082022.QTKD.Multilayer.Common.Resource;

namespace Misa.WebDev2022.QTKD.Controllers
{

    [Route("api/v1/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        #region Field

        private IEmployeeBL _employeeBL;

        #endregion

        #region Controctor

        public EmployeesController(IEmployeeBL employeeBL)
        {
            _employeeBL = employeeBL;
        }

        #endregion

        #region  Get By ID API

        /// <summary>
        /// API Lấy thông tin chi tiết của 1 nhân viên
        /// </summary>
        /// <param name="employeeID">ID của nhân viên muốn lấy thông tin chi tiết</param>
        /// <returns>Đối tượng nhân viên muốn lấy thông tin chi tiết</returns>
        /// Created by: PCTUANANH(12/07/2022)
        [HttpGet("{employeeID}")]
        public IActionResult Employee([FromRoute] Guid employeeID)
        {
            try
            {

                var employee = _employeeBL.GetEmployeeByID(employeeID);
                // Thành công
                if (employee != null)
                {
                    return StatusCode(StatusCodes.Status200OK, employee);
                }
                else
                {

                    return StatusCode(StatusCodes.Status404NotFound, new ErrorResult(
                    QTKDErrorCode.ResultDatabaseFailed,
                    Resource.DevMsg_GetFailed,
                    Resource.UserMsg_GetFailed,
                    Resource.MoreInfo_GetFailed,
                    HttpContext.TraceIdentifier

                 )
             );
                }
            }
            // Try catch exception
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return StatusCode(StatusCodes.Status400BadRequest);
                
            }
        }

        #endregion

    }
}

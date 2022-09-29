
using Microsoft.AspNetCore.Mvc;
using Misa.Web082022.QTKD.Multilayer.BL;
using Misa.Web082022.QTKD.Multilayer.Common.Entities;
using Misa.Web082022.QTKD.Multilayer.Common.Enums;
using Misa.Web082022.QTKD.Multilayer.Common.Resource;
using MySqlConnector;
using Swashbuckle.AspNetCore.Annotations;

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

        #region GetPaging API

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
        /// Created by: PCTUANANH(12/07/2022)
        [HttpGet]
        [SwaggerResponse(StatusCodes.Status200OK, type: typeof(PagingData<Employee>))]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        public IActionResult Employees([FromQuery] string? search, [FromQuery] string? sort, [FromQuery] int limit = 100, [FromQuery] int offset = 0)
        {
            try
            {

                var filterEmployee = _employeeBL.FilterEmployees(search, sort, limit, offset);
                if (filterEmployee != null)
                {
                    return StatusCode(StatusCodes.Status200OK, filterEmployee);
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
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return StatusCode(StatusCodes.Status400BadRequest, new ErrorResult(
                     QTKDErrorCode.Exception,
                      Resource.DevMsg_Exception,
                      Resource.UserMsg_Exception,
                      Resource.MoreInfo_Exception,
                      HttpContext.TraceIdentifier
                    )
                );
            }
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
        [SwaggerResponse(StatusCodes.Status200OK, type: typeof(Employee))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        public IActionResult GetEmployeeByID([FromRoute] Guid employeeID)
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
                return StatusCode(StatusCodes.Status400BadRequest, new ErrorResult(
                     QTKDErrorCode.Exception,
                      Resource.DevMsg_Exception,
                      Resource.UserMsg_Exception,
                      Resource.MoreInfo_Exception,
                     HttpContext.TraceIdentifier
                    )
                );

            }
        }

        #endregion

        #region Get New-Code API

        /// <summary>
        /// API Lấy mã nhân viên mới tự động tăng
        /// </summary>
        /// <returns>Mã nhân viên mới tự động tăng</returns>
        /// Created by: PCTUANANH(12/07/2022)
        [HttpGet("new-code")]
        [SwaggerResponse(StatusCodes.Status200OK, type: typeof(Employee))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        public IActionResult GetNewEmployeeCode()
        {
            try
            {
                string newEmployeeCode = _employeeBL.GetNewEmployeeCode();
                // Trả về dữ liệu cho client
                return StatusCode(StatusCodes.Status200OK, newEmployeeCode);
            }

            catch (Exception exception)
            {

                Console.WriteLine(exception.Message);
                return StatusCode(StatusCodes.Status400BadRequest, new ErrorResult(
                     QTKDErrorCode.Exception,
                       Resource.DevMsg_Exception,
                      Resource.UserMsg_Exception,
                      Resource.MoreInfo_Exception,
                     HttpContext.TraceIdentifier
                    )
                );

            }
        }

        #endregion

        #region  POST Eployee API 

        /// <summary>
        /// API thêm mới một nhân viên 
        /// <param name="employee">Đối tượng nhân viên mới</param>
        /// <returns>ID của nhân viên vừa thêm mới</returns>
        /// </summary>
        /// Created by: PCTUANANH(22/09/2022)
        [HttpPost]
        [SwaggerResponse(StatusCodes.Status200OK, type: typeof(string))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        public IActionResult Employee([FromBody] Employee employee)
        {
            try
            {
                var employeeBLResponse = _employeeBL.InsertEmployee(employee);
                if (!employeeBLResponse.IsValidate)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, new ErrorResult(
                            QTKDErrorCode.InputValidation,
                            Resource.DevMsg_ValidateFailed,
                            Resource.UserMsg_ValidateFailed,
                            string.Join(", ", employeeBLResponse.Data),
                            HttpContext.TraceIdentifier
                        ));
                }
              
                if (employeeBLResponse.IsValidate && employeeBLResponse.Success)
                {
                    // Trả về dữ liệu cho client
                    return StatusCode(StatusCodes.Status201Created, employeeBLResponse.Data);
                }
                else
                {

                    return StatusCode(StatusCodes.Status400BadRequest, new ErrorResult(
                    QTKDErrorCode.ResultDatabaseFailed,
                     Resource.DevMsg_InsertFailed,
                     Resource.UserMsg_InsertFailed,
                     Resource.MoreInfo_InsertFailed,
                     HttpContext.TraceIdentifier
                   )
               );
                }
                
            }
            catch (MySqlException mySqlException)
            {
                // TODO: Sau này có thể bổ sung log lỗi ở đây để khi gặp exception trace lỗi cho dễ
                if (mySqlException.ErrorCode == MySqlErrorCode.DuplicateKeyEntry)
                {
                    Console.WriteLine(mySqlException.Message);
                    return StatusCode(StatusCodes.Status400BadRequest, new ErrorResult(
                      QTKDErrorCode.DuplicateCode,
                       Resource.DevMsg_DuplicateCode,
                      Resource.UserMsg_DuplicateCode,
                      Resource.MoreInfo_DuplicateCode,
                      HttpContext.TraceIdentifier
                     )
                 );
                }
                Console.WriteLine(mySqlException.Message);
                return StatusCode(StatusCodes.Status400BadRequest, new ErrorResult(
                    QTKDErrorCode.Exception,
                      Resource.DevMsg_Exception,
                      Resource.UserMsg_Exception,
                      Resource.MoreInfo_Exception,
                    HttpContext.TraceIdentifier
                   )
               );
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return StatusCode(StatusCodes.Status400BadRequest, new ErrorResult(
                     QTKDErrorCode.Exception,
                       Resource.DevMsg_Exception,
                      Resource.UserMsg_Exception,
                      Resource.MoreInfo_Exception,
                     HttpContext.TraceIdentifier
                    )
                );

            }
        }

        #endregion

        #region PUT API 

        /// <summary>
        /// API sửa một nhân viên 
        /// <param name="employeeID">ID của nhân viên muốn sửa</param>
        /// <param name="employee">Đối tượng nhân viên muốn sửa</param>
        /// <returns>ID của nhân viên vừa sửa</returns>
        /// </summary>
        /// Created by: PCTUANANH(18/09/2022)
        [HttpPut("{employeeID}")]
        public IActionResult Employee([FromRoute] Guid employeeID, [FromBody] Employee employee)
        {

            try
            {

                var employeeBLResponse = _employeeBL.UpDateEmployee(employeeID, employee);
                if (!employeeBLResponse.IsValidate)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, new ErrorResult(
                            QTKDErrorCode.InputValidation,
                            Resource.DevMsg_ValidateFailed,
                            Resource.UserMsg_ValidateFailed,
                            string.Join(", ", employeeBLResponse.Data),
                            HttpContext.TraceIdentifier
                        ));
                }

                if (employeeBLResponse.IsValidate && employeeBLResponse.Success)
                {
                    // Trả về dữ liệu cho client
                    return StatusCode(StatusCodes.Status200OK, employeeBLResponse.Data);
                }
                else
                {

                    return StatusCode(StatusCodes.Status400BadRequest, new ErrorResult(
                    QTKDErrorCode.ResultDatabaseFailed,
                     Resource.DevMsg_InsertFailed,
                     Resource.UserMsg_InsertFailed,
                     Resource.MoreInfo_InsertFailed,
                     HttpContext.TraceIdentifier
                   )
               );
                }
            }
            catch (MySqlException mySqlException)
            {
                // TODO: Sau này có thể bổ sung log lỗi ở đây để khi gặp exception trace lỗi cho dễ
                if (mySqlException.ErrorCode == MySqlErrorCode.DuplicateKeyEntry)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, new ErrorResult(
                    QTKDErrorCode.DuplicateCode,
                    Resource.DevMsg_DuplicateCode,
                    Resource.UserMsg_DuplicateCode,
                    Resource.MoreInfo_DuplicateCode,
                    HttpContext.TraceIdentifier
                    )
                   );
                }
                Console.WriteLine(mySqlException.Message);
                return StatusCode(StatusCodes.Status400BadRequest, new ErrorResult(
                    QTKDErrorCode.Exception,
                      Resource.DevMsg_Exception,
                      Resource.UserMsg_Exception,
                      Resource.MoreInfo_Exception,
                    HttpContext.TraceIdentifier
                   )
               );
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return StatusCode(StatusCodes.Status400BadRequest, new ErrorResult(
                     QTKDErrorCode.Exception,
                      Resource.DevMsg_Exception,
                      Resource.UserMsg_Exception,
                      Resource.MoreInfo_Exception,
                     HttpContext.TraceIdentifier
                    )
                );

            }

        }

        #endregion

        #region Delete  Eployee API

        /// <summary>
        /// API xóa mới một nhân viên 
        /// <param name="employeeID">ID của nhân viên muốn xóa</param>
        /// <returns>ID của nhân viên vừa sửa</returns>
        /// </summary>
        ///Created by: PCTUANANH(18/09/2022)
        [HttpDelete("{employeeID}")]
        public IActionResult Employee([FromRoute] Guid employeeID)
        {

            try
            {
                var employeeBLResponse = _employeeBL.DeleteEmployee(employeeID);
                if (employeeBLResponse.Success)
                {
                    // Trả về dữ liệu cho client
                    return StatusCode(StatusCodes.Status200OK, employeeID);
                }
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest, new ErrorResult(
                     QTKDErrorCode.ResultDatabaseFailed,
                     Resource.DevMsg_DeleteFailed,
                     Resource.UserMsg_DeleteFailed,
                     Resource.MoreInfo_DeleteFailed,
                     HttpContext.TraceIdentifier
                    )
                    );
                }
            }
            catch (Exception exception)
            {
                // TODO: Sau này có thể bổ sung log lỗi ở đây để khi gặp exception trace lỗi cho dễ
                Console.WriteLine(exception.Message);
                return StatusCode(StatusCodes.Status400BadRequest, new ErrorResult(
                     QTKDErrorCode.Exception,
                      Resource.DevMsg_Exception,
                      Resource.UserMsg_Exception,
                      Resource.MoreInfo_Exception,
                     HttpContext.TraceIdentifier
                    )
                );
            }

        }

        #endregion

    }
}

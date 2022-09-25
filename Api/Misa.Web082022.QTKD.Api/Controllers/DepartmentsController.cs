using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Misa.Web082022.QTKD.API.Entities.DTO;
using Misa.Web082022.QTKD.API.Enums;
using Misa.Web082022.QTKD.API.Properties;
using MISA.Web082022.QTKD.Api.Entities;
using MySqlConnector;
using Swashbuckle.AspNetCore.Annotations;


namespace MISA.WebDev2022.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        /// <summary>
        /// Chuỗi kết nối đến Database
        /// </summary>        
        private const string mySqlconnectionString = "Server=localhost;Port=3306;Database=misa.web08.qtkd.pctuananh;Uid=root;Pwd=root;";

        #region Get Deapartment API

        /// <summary>
        /// API Lấy toàn bộ danh sách phòng ban
        /// </summary>
        /// <returns>Danh sách phòng ban</returns>
        /// Created by: PCTUANANH(21/09/2022)
        [HttpGet]
        [SwaggerResponse(StatusCodes.Status200OK, type: typeof(List<Department>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        public IActionResult GetAllPositions()
        {
            try
            {
                // Khởi tạo kết nối tới DB MySQL
                string connectionString = mySqlconnectionString;

                var mySqlConnection = new MySqlConnection(connectionString);

                // Chuẩn bị tên Stored procedure
                string storedProcedureName = "Proc_Department_Get_All";

                // Thực hiện gọi vào DB để chạy câu lệnh truy vấn ở trên
                var departments = mySqlConnection.Query<Department>(storedProcedureName, commandType: System.Data.CommandType.StoredProcedure);

                // Trả về dữ liệu cho client
                if(departments != null)
                {
                    return StatusCode(StatusCodes.Status200OK, departments);

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
                // TODO: Sau này có thể bổ sung log lỗi ở đây để khi gặp exception trace lỗi cho dễ
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

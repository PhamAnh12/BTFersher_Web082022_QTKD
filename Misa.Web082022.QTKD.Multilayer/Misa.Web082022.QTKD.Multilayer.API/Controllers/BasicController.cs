using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Misa.Web082022.QTKD.Multilayer.BL;
using Misa.Web082022.QTKD.Multilayer.Common.Entities;
using MySqlConnector;
using NSwag.Annotations;

namespace Misa.Web082022.QTKD.Multilayer.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasicController<T> : ControllerBase
    {
        #region Field

        private IBaseBL<T> _recordBL;
        ResponeErrorResult responeErrorResult;

        #endregion

        #region Controctor

        public BasicController(IBaseBL<T> recordBL)
        {
            _recordBL = recordBL;
            responeErrorResult = new ResponeErrorResult();
        }

        #endregion

        #region  Get All Record

        /// <summary>
        /// API Lấy thông tin chi tiết của 1 nhân viên
        /// </summary>
        /// <returns>Tất cả bản ghi</returns>
        /// Created by: PCTUANANH(30/09/2022)
        [HttpGet]
        public IActionResult Records()
        {
            try
            {

                var records = _recordBL.GetAllRecords();
                // Thành công
                if (records != null)
                {
                    return StatusCode(StatusCodes.Status200OK, records);
                }
                else
                {

                    return StatusCode(StatusCodes.Status404NotFound, responeErrorResult.ErrorResultGet(HttpContext.TraceIdentifier));
                }
            }
            // Try catch exception
            catch (Exception exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, responeErrorResult.ErrorResultException(HttpContext.TraceIdentifier));

            }
        }

        #endregion

        #region  Get By ID API

        /// <summary>
        /// API Lấy thông tin chi tiết của 1 nhân viên
        /// </summary>
        /// <param name="ID">ID của nhân viên muốn lấy thông tin chi tiết</param>
        /// <returns>Một bản ghi</returns>
        /// Created by: PCTUANANH(30/09/2022)
        [HttpGet("{ID}")]
        public IActionResult Record([FromRoute] Guid ID)
        {
            try
            {

                var record =  _recordBL.RecordByID(ID);
                // Thành công
                if (record != null)
                {
                    return StatusCode(StatusCodes.Status200OK, record);
                }
                else
                {

                    return StatusCode(StatusCodes.Status404NotFound, responeErrorResult.ErrorResultGet(HttpContext.TraceIdentifier));
                }
            }
            // Try catch exception
            catch (Exception exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, responeErrorResult.ErrorResultException(HttpContext.TraceIdentifier));

            }
        }

        #endregion

        #region  POST  API 

        /// <summary>
        /// API thêm mới một nhân viên 
        /// <param name="record">Bản ghi mới</param>
        /// <returns>ID của bản ghi vừa thêm mới</returns>
        /// </summary>
        /// Created by: PCTUANANH(30/09/2022)
        [HttpPost]
        public IActionResult Record([FromBody] T record)
        {
            try
            {
                var recordBLResponse = _recordBL.InsertRecord(record);
                if (!recordBLResponse.IsValidate)
                {
                    string? strValidate = recordBLResponse.strValidate;
                    return StatusCode(StatusCodes.Status400BadRequest,
                    responeErrorResult.ErrorResultValidate(HttpContext.TraceIdentifier, strValidate));
                }

                if (recordBLResponse.IsValidate && recordBLResponse.Success)
                {
                    // Trả về dữ liệu cho client
                    return StatusCode(StatusCodes.Status201Created, recordBLResponse.Data);
                }
                else
                {

                    return StatusCode(StatusCodes.Status400BadRequest,
                    responeErrorResult.ErrorResultInsert(HttpContext.TraceIdentifier)
               );
                }

            }
            catch (MySqlException mySqlException)
            {
                // TODO: Sau này có thể bổ sung log lỗi ở đây để khi gặp exception trace lỗi cho dễ
                if (mySqlException.ErrorCode == MySqlErrorCode.DuplicateKeyEntry)
                {
                    Console.WriteLine(mySqlException.Message);
                    return StatusCode(StatusCodes.Status400BadRequest,
                        responeErrorResult.ErrorResultDuplicateCode(HttpContext.TraceIdentifier)
                 );
                }
                Console.WriteLine(mySqlException.Message);
                return StatusCode(StatusCodes.Status500InternalServerError,
                responeErrorResult.ErrorResultException(HttpContext.TraceIdentifier));
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return StatusCode(StatusCodes.Status500InternalServerError,
                responeErrorResult.ErrorResultException(HttpContext.TraceIdentifier));

            }
        }

        #endregion

        #region PUT API 

        /// <summary>
        /// API sửa một nhân viên 
        /// <param name="ID">ID của bản ghi muốn sửa</param>
        /// <param name="record">Đối tượng bản ghi muốn sửa</param>
        /// <returns>ID của bản ghi vừa sửa</returns>
        /// </summary>
        /// Created by: PCTUANANH(30/09/2022)
        [HttpPut("{ID}")]
        public IActionResult Employee([FromRoute] Guid ID, [FromBody] T record)
        {

            try
            {
                var recordBLResponse = _recordBL.UpdateRecord(ID,record);
                if (!recordBLResponse.IsValidate)
                {
                    string? strValidate = recordBLResponse.strValidate;
                    return StatusCode(StatusCodes.Status400BadRequest,
                    responeErrorResult.ErrorResultValidate(HttpContext.TraceIdentifier, strValidate));
                }

                if (recordBLResponse.IsValidate && recordBLResponse.Success)
                {
                    // Trả về dữ liệu cho client
                    return StatusCode(StatusCodes.Status201Created, recordBLResponse.Data);
                }
                else
                {

                    return StatusCode(StatusCodes.Status400BadRequest,
                    responeErrorResult.ErrorResultInsert(HttpContext.TraceIdentifier)
               );
                }

            }
            catch (MySqlException mySqlException)
            {
                // TODO: Sau này có thể bổ sung log lỗi ở đây để khi gặp exception trace lỗi cho dễ
                if (mySqlException.ErrorCode == MySqlErrorCode.DuplicateKeyEntry)
                {
                    Console.WriteLine(mySqlException.Message);
                    return StatusCode(StatusCodes.Status400BadRequest,
                        responeErrorResult.ErrorResultDuplicateCode(HttpContext.TraceIdentifier)
                 );
                }
                Console.WriteLine(mySqlException.Message);
                return StatusCode(StatusCodes.Status500InternalServerError,
                responeErrorResult.ErrorResultException(HttpContext.TraceIdentifier));
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return StatusCode(StatusCodes.Status500InternalServerError,
                responeErrorResult.ErrorResultException(HttpContext.TraceIdentifier));

            }
            
        }

        #endregion

        #region Delete  Eployee API

        /// <summary>
        /// API xóa mới một nhân viên 
        /// <param name="ID">ID của bản ghi muốn xóa</param>
        /// <returns>ID của bản ghi vừa sửa</returns>
        /// </summary>
        ///Created by: PCTUANANH(30/09/2022)
        [HttpDelete("{ID}")]
        public IActionResult RecordID([FromRoute] Guid ID)
        {

            try
            {
                var id = _recordBL.DeleteRecord(ID);
                if (id != null)
                {
                    // Trả về dữ liệu cho client
                    return StatusCode(StatusCodes.Status200OK, id);
                }
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest,
                     responeErrorResult.ErrorResultDelete(HttpContext.TraceIdentifier)
                    );
                }
            }
            catch (Exception exception)
            {
                // TODO: Sau này có thể bổ sung log lỗi ở đây để khi gặp exception trace lỗi cho dễ
                Console.WriteLine(exception.Message);
                return StatusCode(StatusCodes.Status500InternalServerError,
                 responeErrorResult.ErrorResultException(HttpContext.TraceIdentifier));
            }

        }

        #endregion
    }
}

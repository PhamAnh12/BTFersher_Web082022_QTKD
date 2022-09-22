using Dapper;
using Microsoft.AspNetCore.Mvc;
using MISA.Web08.QTKD.API.Entinies;
using MySqlConnector;
using Swashbuckle.AspNetCore.Annotations;

namespace MISA.Web08.QTKD.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]

    public class DepartmentsController : Controller
    {
        private const string mySqlconnectionString = "Server=localhost;Port=3306;Database=misa.web08.qtkd.pctuananh;Uid=root;Pwd=root;";
        #region Get API
        /// <summary>
        /// API lấy toàn bộ phòng ban
        /// <returns>Toàn bộ danh sách phòng ban </return>
        /// </summary>
        /// Created by: PCTUANANH(18/09/2022)
        [HttpGet]
        [Route("")]
        public IActionResult GetAllDepartments()
        {

            try
            {
                // Khởi tạo kết nối tới DB MySQL
                string connectionString = mySqlconnectionString;

                var mySqlConnection = new MySqlConnection(connectionString);

                // Chuẩn bị câu lệnh truy vấn
                string getAllDepartmentsCommand = "SELECT * FROM department;";

                // Thực hiện gọi vào DB để chạy câu lệnh truy vấn ở trên
                var departments = mySqlConnection.Query<Department>(getAllDepartmentsCommand);

                // Trả về dữ liệu cho client
                return StatusCode(StatusCodes.Status200OK, departments);

            }
            catch (Exception exception)
            {
                // TODO: Sau này có thể bổ sung log lỗi ở đây để khi gặp exception trace lỗi cho dễ
                return StatusCode(StatusCodes.Status400BadRequest, exception);
            }
        }
        #endregion

        #region Post API
        /// <summary>
        /// API thêm phòng ban mới
        /// <param name="department">Đối tượng phòng ban  mới</param>
        /// <returns>ID của phòng ban vừa thêm mới</returns>
        /// </summary>
        /// Created by: PCTUANANH(18/09/2022)
        [HttpPost]
        public IActionResult InserDepartment([FromBody] Department department)
        {
            try
            {

                department.DepartmentID = Guid.NewGuid();
                return StatusCode(StatusCodes.Status201Created, department.DepartmentID);
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest, exception);

            }

        }
        #endregion

        #region Put API
        /// <summary>
        /// API sửa một phòng ban mới
        /// <param name="departmentID">ID của phòng ban muốn sửa</param>
        /// <param name="department">Đối tượng phòng ban  muốn sửa</param>
        /// </summary>
        /// Created by: PCTUANANH(18/09/2022)
        [HttpPut("{departmentID}")]
        public IActionResult UpdateDepartment([FromRoute] Guid departmentID, [FromBody] Department department)
        {
            try
            {
                department.DepartmentID = departmentID;
                return StatusCode(StatusCodes.Status200OK, department);

            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest, exception);

            }

        }
        #endregion

        #region Delete API
        /// <summary>
        /// API xóa mới một phòng ban
        /// <param name="departmentID">ID của phòng ban muốn sửa</param>
        /// <returns>ID của phòng ban vừa xóa</returns>
        /// </summary>
        /// Created by: PCTUANANH(18/09/2022)
        [HttpDelete("{departmentID}")]
        public IActionResult DeleteDepartment([FromRoute] Guid departmentID)
        {

            try
            {
                return StatusCode(StatusCodes.Status200OK, departmentID);

            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest, exception);

            }
        }
        #endregion

    }
}

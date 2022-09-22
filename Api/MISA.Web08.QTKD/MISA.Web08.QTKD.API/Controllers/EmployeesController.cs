using Dapper;
using Microsoft.AspNetCore.Mvc;
using MISA.Web08.QTKD.API.Enum;
using MISA.Web08.QTKD.API.Entinies;
using MISA.WebDev2022.Api.Entities.DTO;
using MySqlConnector;
using Swashbuckle.AspNetCore.Annotations;

namespace MISA.Web08.QTKD.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EmployeesController : Controller
    { 

        private const string  mySqlconnectionString = "Server=localhost;Port=3306;Database=misa.web08.qtkd.pctuananh;Uid=root;Pwd=root;";
        #region Get FilterEmployee Api
        /// <summary>
        /// API lấy Filter nhân viên
        /// <param name="search">Tìm kiếm theo Số điện thoại, tên, Mã nhân viên</param>
        /// <param name="sort">  Sắp xếp</param>
        /// <param name="limit">Số trang muốn lấy</param>
        /// <param name="offset">Thứ tự trang muốn lấy</param>
        /// <returns>Một đối tượng gồm:
        /// + Danh sách nhân viên thỏa mãn điều kiện lọc và phân trang
        /// + Tổng số nhân viên thỏa mãn điều kiện</returns>
        /// </summary>
        /// Created by: PCTUANANH(20/09/2022)
        [HttpGet("")]
        public IActionResult FilterEmployee([FromQuery] string? search, [FromQuery] string? sort, [FromQuery] int? offset = 1, [FromQuery] int? limit = 10)
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, new PagingData<Employee>()
                {

                    Data = new List<Employee>
                    {
                       new Employee  {
                        EmployeeID = Guid.NewGuid(),
                        EmployeeCode = search,
                        EmployeeName = "Phạm Thế Anh",
                        DateOfBirth = new DateTime(12 / 10 / 2000),
                        Gender = Gender.Male,
                        PositionName = "Trưởng phòng",
                        DepartmentID = Guid.NewGuid(),
                        DepartmentName = "Nhân sự",
                        IdentityNumber = "030948851372",
                        IdentityIssuedDate = new DateTime(24 / 6 / 2017),
                        IdentityIssuedPlace = "Cục Cảnh sát quản lý hành chính về trật tự xã hội",
                        PositionNames = "Kế toán",
                        Address = "Số 01 Hồ Tùng Mậu, Hà Nội",
                        MobilePhoneNumber = "098 9927520",
                        LandlinePhoneNumber = "024 034-8337",
                        Email = "phamcongtuananh@gmail.com",
                        AccountBank = "099156937958",
                        NameBank = "ACB",
                        BranchBank = "Chi nhánh Thăng Long",
                        IsCustomer = true,
                        IsSupplier = false,
                        CreatedDate = new DateTime(12 / 12 / 2012),
                        CreatedBy = "Phạm Công Tuấn Anh",
                        ModifiedDate = DateTime.Now,
                        ModifiedBy = "Phạm Công Tuấn Anh"
                    },
                        new Employee  {
                        EmployeeID = Guid.NewGuid(),
                        EmployeeCode = search,
                        EmployeeName = "Phạm Thế Anh",
                        DateOfBirth = new DateTime(12 / 10 / 2000),
                        Gender = Gender.Male,
                        PositionName = "Trưởng phòng",
                        DepartmentID = Guid.NewGuid(),
                        DepartmentName = "Nhân sự",
                        IdentityNumber = "030948851372",
                        IdentityIssuedDate = new DateTime(24 / 6 / 2017),
                        IdentityIssuedPlace = "Cục Cảnh sát quản lý hành chính về trật tự xã hội",
                        PositionNames = "Kế toán",
                        Address = "Số 01 Hồ Tùng Mậu, Hà Nội",
                        MobilePhoneNumber = "098 9927520",
                        LandlinePhoneNumber = "024 034-8337",
                        Email = "phamcongtuananh@gmail.com",
                        AccountBank = "099156937958",
                        NameBank = "ACB",
                        BranchBank = "Chi nhánh Thăng Long",
                        IsCustomer = true,
                        IsSupplier = false,
                        CreatedDate = new DateTime(12 / 12 / 2012),
                        CreatedBy = "Phạm Công Tuấn Anh",
                        ModifiedDate = DateTime.Now,
                        ModifiedBy = "Phạm Công Tuấn Anh"
                        }

                    },

                    TotalCount = 2
                }); ;

               
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest, exception);
            }

        }
        #endregion

        #region  Get EmployeeByID
        /// <summary>
        /// API lấy một  nhân viên 
        /// <param name="employeeID">ID của nhân viên muốn lấy thông tin chi tiết</param>
        /// <returns>Đối tượng nhân viên muốn lấy thông tin chi tiết</returns>
        /// </summary>
        /// Created by: PCTUANANH(18/09/2022)
        [HttpGet("{employeeID}")]
        //[SwaggerResponse(StatusCodes.Status200OK, type: typeof(Employee))]
        //[SwaggerResponse(StatusCodes.Status400BadRequest)]
        //[SwaggerResponse(StatusCodes.Status500InternalServerError)]
        public Employee GetEmployeeByID([FromRoute] Guid employeeID)
        {
           
                // Khởi tạo kết nối tới DB MySQL
                string connectionString = mySqlconnectionString;
                var mySqlConnection = new MySqlConnection(connectionString);

                // Chuẩn bị tên Stored procedure
                string storedProcedureName = "Proc_Employee_GetByEmployeeID";

                // Chuẩn bị tham số đầu vào cho stored procedure
                var parameters = new DynamicParameters();
                parameters.Add("@ $EmployeeID", employeeID);

                // Thực hiện gọi vào DB để chạy stored procedure với tham số đầu vào ở trên
                var employee = mySqlConnection.QueryFirstOrDefault<Employee>(storedProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);

            // Xử lý kết quả trả về từ DB
            return employee;

        }
        #endregion

        /// <summary>
        /// API Lấy mã nhân viên mới tự động tăng
        /// </summary>
        /// <returns>Mã nhân viên mới tự động tăng</returns>
        /// Created by: PCTUANANH(12/07/2022)
        [HttpGet("new-code")]
        public IActionResult GetNewEmployeeCode()
        {
            string maxEmployeeCode = "NV0123";
            // Xử lý sinh mã nhân viên mới tự động tăng
            // Cắt chuỗi mã nhân viên lớn nhất trong hệ thống để lấy phần số
            // Mã nhân viên mới = "NV" + Giá trị cắt chuỗi ở  trên + 1

            string newEmployeeCode = "NV0" + (Int64.Parse(maxEmployeeCode.Substring(3)) + 1).ToString();

            // Trả về dữ liệu cho client
            return StatusCode(StatusCodes.Status200OK, newEmployeeCode);
        }
        #region  POST API
        /// <summary>
        /// API thêm mới một nhân viên 
        /// <param name="employee">Đối tượng nhân viên mới</param>
        /// <returns>ID của nhân viên vừa thêm mới</returns>
        /// </summary>
        /// Created by: PCTUANANH(18/09/2022)
        [HttpPost]
        public IActionResult InserEmployee([FromBody] Employee employee)
        {
            try
            {
                return StatusCode(StatusCodes.Status201Created, Guid.NewGuid());

            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest, exception);

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
        public IActionResult UpdateEmployee([FromRoute] Guid employeeID, [FromBody] Employee employee)
        {

            try
            {
                employee.EmployeeID = employeeID;
                return StatusCode(StatusCodes.Status200OK, employeeID);

            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest, exception);

            }

        }

        #endregion

        #region Delete API
        /// <summary>
        /// API xóa mới một nhân viên 
        /// <param name="employeeID">ID của nhân viên muốn xóa</param>
        /// <returns>ID của nhân viên vừa sửa</returns>
        /// </summary>
        ///Created by: PCTUANANH(18/09/2022)
        [HttpDelete("{employeeID}")]
        public IActionResult DeleteEmployee([FromRoute] Guid employeeID)
        {

            try
            {
                return StatusCode(StatusCodes.Status200OK, employeeID);
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest, exception);

            }

        }
        #endregion

        #region Batch-Delete API
        /// <summary>
        /// API  xóa nhiều
        /// <param name="batch-delete"> list ID của  các nhân viên muốn xóa</param>
        /// </summary>
        /// Created by: PCTUANANH(18/09/2022)
        [HttpPost("batch-delete")]
        public IActionResult DeleteListEmployee([FromBody] List<string> listdelete)
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK);

            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest, exception);

            }

        }
        
        #endregion


    }
}

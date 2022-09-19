using Microsoft.AspNetCore.Mvc;
using MISA.Web08.CukCuk.API.Entinies.Enum;
using MISA.Web08.QTKD.API.Entinies;

namespace MISA.Web08.QTKD.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EmployeesController : Controller
    {

        #region Get FilterEmployee Api
        /// <summary>
        /// API lấy Filter nhân viên 
        /// </summary>
        /// Created by: PCTUANANH(18/09/2022)
        [HttpGet("")]
        public IActionResult FilterEmployee([FromQuery] string? search, [FromQuery] Guid? departmentID, [FromQuery] string? sort, [FromQuery] int? offset = 1, [FromQuery] int? limit = 10)
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK,
                 new Employee
                 {
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
                  );
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
        /// </summary>
        /// Created by: PCTUANANH(18/09/2022)
        [HttpGet("{employeeID}")]
        public IActionResult GetEmployeeByID([FromRoute] Guid employeeID)
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK,
                 new Employee
                 {
                     EmployeeID = employeeID,
                     EmployeeCode = "NV0002",
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
                  );
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest, exception);
            }

        }
        #endregion

        #region  POST API
        /// <summary>
        /// API thêm mới một nhân viên 
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
        /// </summary>
        /// Created by: PCTUANANH(18/09/2022)
        [HttpPut("{employeeID}")]
        public IActionResult UpdateEmployee([FromRoute] Guid employeeID, [FromBody] Employee employee)
        {

            try
            {
                employee.EmployeeID = employeeID;
                return StatusCode(StatusCodes.Status200OK, employee);

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
        /// </summary>
        /// Created by: PCTUANANH(18/09/2022)
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
        /// </summary>
        /// Created by: PCTUANANH(18/09/2022)
        [HttpPost("batch-delete")]
        public IActionResult DeleteListEployee([FromBody] List<string> listdelete)
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

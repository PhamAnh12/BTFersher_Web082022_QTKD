using Microsoft.AspNetCore.Mvc;
using MISA.Web08.QTKD.API.Entinies;

namespace MISA.Web08.QTKD.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class DepartmentsController : Controller
    {
        #region Get API
        /// <summary>
        /// API lấy toàn bộ phòng ban
        /// </summary>
        /// Created by: PCTUANANH(18/09/2022)
        [HttpGet]
        [Route("")]
        public IActionResult GetAllDepartments()
        {

            try
            {
                return StatusCode(StatusCodes.Status200OK,
            new List<Department>
           {
                new Department
                {
                    DepartmentID =  Guid.NewGuid(),
                    DepartmentCode = "PB01",
                    DepartmentName ="Nhân sự",
                    CreatedDate = new  DateTime(12/12/2012),
                    CreatedBy = "Phạm Công Tuấn Anh",
                    ModifiedDate = DateTime.Now,
                    ModifiedBy ="Phạm Công Tuấn Anh"

                },
                  new Department
                {
                    DepartmentID =  Guid.NewGuid(),
                    DepartmentCode = "PB02",
                    DepartmentName ="Công nghệ thông tin",
                    CreatedDate = new  DateTime(12/12/2012),
                    CreatedBy = "Phạm Công Tuấn Anh",
                    ModifiedDate = DateTime.Now,
                    ModifiedBy ="Phạm Công Tuấn Anh"

                  },
                      new Department
                {
                    DepartmentID =  Guid.NewGuid(),
                    DepartmentCode = "PB02",
                    DepartmentName ="Kế toán",
                    CreatedDate = new  DateTime(12/12/2012),
                    CreatedBy = "Phạm Công Tuấn Anh",
                    ModifiedDate = DateTime.Now,
                    ModifiedBy ="Phạm Công Tuấn Anh"

                }
            }

               );
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest, exception);

            }
        }
        #endregion

        #region Post API
        /// <summary>
        /// API thêm phòng ban mới
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
        /// </summary>
        /// Created by: PCTUANANH(18/09/2022)
        [HttpPut("{depaetmentID}")]
        public IActionResult UpdateDepartment([FromRoute] Guid depaetmentID, [FromBody] Department department)
        {
            try
            {
                department.DepartmentID = depaetmentID;
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
        /// </summary>
        /// Created by: PCTUANANH(18/09/2022)
        [HttpDelete("{depaetmentID}")]
        public IActionResult DeleteDepartment([FromRoute] Guid depaetmentID)
        {

            try
            {
                return StatusCode(StatusCodes.Status200OK, depaetmentID);

            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest, exception);

            }
        }
        #endregion

    }
}

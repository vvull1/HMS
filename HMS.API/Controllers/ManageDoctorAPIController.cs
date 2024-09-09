using HMS.Core.DoctorDetails;
using HMS.Infrastructure.Interface;
using HMS.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManageDoctorAPIController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ManageDoctorAPIController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet("Get")]
        public ActionResult Get()
        {
            var data = _unitOfWork.ManageDoctor.GetAll();
            return Ok(data);
        }

        [HttpGet("GetById/{id}")]
        public APIResponse GetById(int id)
        {
            var data = _unitOfWork.ManageDoctor.GetById(id);
            if (data == null)
                return new APIResponse() { isSuccess = false, ErrorMessage = "Record not found" };
            return new APIResponse() { isSuccess = true, Data = data, Message = "Record fetch successfully" };
        }
        [HttpPost("Create")]
        public APIResponse Create(ManageDoctor manageDoctor)
        {
            try
            {
                if (manageDoctor == null)
                    return new APIResponse() { isSuccess = false, ErrorMessage = "NULL" };
                manageDoctor.Created = DateTime.Now;
                _unitOfWork.ManageDoctor.Create(manageDoctor);
                _unitOfWork.Commit();
                return new APIResponse() { isSuccess = true, Data = manageDoctor, Message = "Record Saved Successfully..!!" };
            }
            catch (Exception)
            {

                throw;
            }

        }
        [HttpPut("Update")]
        public APIResponse Update(ManageDoctor manageDoctor)
        {
            try
            {
                if (manageDoctor == null)
                    return new APIResponse() { isSuccess = false, ErrorMessage = "NULL" };
                manageDoctor.Updated = DateTime.Now;
                _unitOfWork.ManageDoctor.Update(manageDoctor);
                _unitOfWork.Commit();
                return new APIResponse() { isSuccess = true, Data = manageDoctor, Message = "Data Updated Successfully" };
            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpDelete("Delete/{id}")]
        public APIResponse Delete(int id)
        {
            if (id == 0)
                return new APIResponse() { isSuccess = false, ErrorMessage = "Invalid data" };
            _unitOfWork.ManageDoctor.Delete(id);
            _unitOfWork.Commit();
            return new APIResponse() { isSuccess = true, Message = "Record Soft deleted" };
        }
    }
}

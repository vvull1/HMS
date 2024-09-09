using HMS.Core.PatientDetails;
using HMS.Infrastructure.Interface;
using HMS.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagePatientAPIController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ManagePatientAPIController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet("Get")]
        public ActionResult Get()
        {
            var data = _unitOfWork.ManagePatient.GetAll();
            return Ok(data);
        }

        [HttpGet("GetById/{id}")]
        public APIResponse GetById(int id)
        {
            var data = _unitOfWork.ManagePatient.GetById(id);
            if (data == null)
                return new APIResponse() { isSuccess = false, ErrorMessage = "Record not found" };
            return new APIResponse() { isSuccess = true, Data = data, Message = "Record fetch successfully" };
        }
        [HttpPost("Create")]
        public APIResponse Create(ManagePatient managePatient)
        {
            try
            {
                if (managePatient == null)
                    return new APIResponse() { isSuccess = false, ErrorMessage = "NULL" };
                managePatient.Created = DateTime.Now;
                _unitOfWork.ManagePatient.Create(managePatient);
                _unitOfWork.Commit();
                return new APIResponse() { isSuccess = true, Data = managePatient, Message = "Record Saved Successfully..!!" };
            }
            catch (Exception)
            {

                throw;
            }

        }
        [HttpPut("Update")]
        public APIResponse Update(ManagePatient managePatient)
        {
            try
            {
                if (managePatient == null)
                    return new APIResponse() { isSuccess = false, ErrorMessage = "NULL" };
                managePatient.Updated = DateTime.Now;
                _unitOfWork.ManagePatient.Update(managePatient);
                _unitOfWork.Commit();
                return new APIResponse() { isSuccess = true, Data = managePatient, Message = "Data Updated Successfully" };
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
            _unitOfWork.ManagePatient.Delete(id);
            _unitOfWork.Commit();
            return new APIResponse() { isSuccess = true, Message = "Record Soft deleted" };
        }
    }
}

using HMS.Core.AppointmentDetails;
using HMS.Core.PatientDetails;
using HMS.Infrastructure.Interface;
using HMS.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManageAppointmentAPIController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ManageAppointmentAPIController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet("GetPateint")]
        public ActionResult GetPateint()
        {
            var data = _unitOfWork.ManagePatient.GetAll();
            return Ok(data);
        }
        [HttpGet("GetDoctor")]
        public ActionResult GetDoctor()
        {
            var data = _unitOfWork.ManageDoctor.GetAll();
            return Ok(data);
        }
        [HttpGet("Get")]
        public ActionResult Get()
        {
            var data = _unitOfWork.ManageAppointment.GetAppointmentDetails();
            return Ok(data);
        }

        [HttpGet("GetById/{id}")]
        public APIResponse GetById(int id)
        {
            var data = _unitOfWork.ManageAppointment.GetById(id);
            if (data == null)
                return new APIResponse() { isSuccess = false, ErrorMessage = "Record not found" };
            return new APIResponse() { isSuccess = true, Data = data, Message = "Record fetch successfully" };
        }
        [HttpPost("Create")]
        public APIResponse Create(ManageAppointment manageAppointment)
        {
            try
            {
                if (manageAppointment == null)
                    return new APIResponse() { isSuccess = false, ErrorMessage = "NULL" };
                manageAppointment.Created = DateTime.Now;
                _unitOfWork.ManageAppointment.Create(manageAppointment);
                _unitOfWork.Commit();
                return new APIResponse() { isSuccess = true, Data = manageAppointment, Message = "Record Saved Successfully..!!" };
            }
            catch (Exception)
            {

                throw;
            }

        }
        [HttpPut("Update")]
        public APIResponse Update(ManageAppointment manageAppointment)
        {
            try
            {
                if (manageAppointment == null)
                    return new APIResponse() { isSuccess = false, ErrorMessage = "NULL" };
                manageAppointment.Updated = DateTime.Now;
                _unitOfWork.ManageAppointment.Update(manageAppointment);
                _unitOfWork.Commit();
                return new APIResponse() { isSuccess = true, Data = manageAppointment, Message = "Data Updated Successfully" };
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
            _unitOfWork.ManageAppointment.Delete(id);
            _unitOfWork.Commit();
            return new APIResponse() { isSuccess = true, Message = "Record Soft deleted" };
        }
    }
}

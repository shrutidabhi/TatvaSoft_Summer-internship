using Microsoft.AspNetCore.Mvc;
using Mission.Entities;
using Mission.Services.IServices;

[ApiController]
[Route("api/[controller]")]
public class AdminUserController : ControllerBase
{
    private readonly IAdminUserService _adminUserService;

    public AdminUserController(IAdminUserService adminUserService)
    {
        _adminUserService = adminUserService;
    }

    [HttpGet]
    [Route("UserDetailList")]
    public ActionResult UserDetailList()
    {
        try
        {
            var res = _adminUserService.UserDetailsList();
            return Ok(new ResponseResult() { Data = res, Result = ResponseStatus.Success, Message = "" });
        }
        catch
        {
            return BadRequest(new ResponseResult() { Data = null, Result = ResponseStatus.Error, Message = "Failed to get user list" });
        }
    }

    [HttpDelete]
    [Route("DeleteUser")]
    public ActionResult DeleteUser([FromQuery] int id)
    {
        try
        {
            var res = _adminUserService.UserDelete(id);
            return Ok(new ResponseResult() { Data = res, Result = ResponseStatus.Success, Message = "" });
        }
        catch
        {
            return BadRequest(new ResponseResult() { Data = null, Result = ResponseStatus.Error, Message = "Failed to delete user" });
        }
    }

    [HttpPost]
    [Route("UpdateUser")]
    public ActionResult UpdateUser([FromBody] User user)
    {
        try
        {
            var result = _adminUserService.UpdateUser(user);
            if (!result)
            {
                return NotFound(new ResponseResult() { Data = null, Result = ResponseStatus.Error, Message = "User not found" });
            }

            return Ok(new ResponseResult() { Data = result, Result = ResponseStatus.Success, Message = "User updated successfully" });
        }
        catch
        {
            return BadRequest(new ResponseResult() { Data = null, Result = ResponseStatus.Error, Message = "Failed to update user" });
        }
    }
}

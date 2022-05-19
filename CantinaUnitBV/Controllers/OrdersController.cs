using ApplicationServices.Base;
using ApplicationServices.Services.Orders;
using ApplicationServices.Services.Orders.Requests;
using ApplicationServices.Services.Orders.Responses;
using ApplicationServices.Services.Users;
using ApplicationServices.Services.Users.Requests;
using ApplicationServices.Services.Users.Responses;
using CantinaUnitBV.Controllers.Base;
using Domain.Search;
using Infastructure.DataTables;
using Microsoft.AspNetCore.Mvc;

namespace CantinaUnitBV.Controllers;

[ApiController]
[Route("api/users")]
public class OrdersController : CantinaBvControllerBase
{
    private readonly IOrderService _orderService;

    public OrdersController(IOrderService userService)
    {
        _orderService = userService;
    }

    [HttpPost("search")]
    [ProducesResponseType(typeof(DtResult<UserResponse>), 200)]
    public async Task<IActionResult> SearchUsers([FromBody] DtParameters dtParameters)
    {
        var searchArgs = new SearchArgs
        {
            SearchText = dtParameters.Search.Value,
            Offset = dtParameters.Start,
            Limit = dtParameters.Length,
            SortOption = ComposeSort(dtParameters)
        };

        var users = await _orderService.GetAllOrders(searchArgs);

        return new JsonResult(new DtResult<UserResponse>
        {
            Draw = dtParameters.Draw,
            RecordsTotal = users.RecordsTotal,
            RecordsFiltered = users.RecordsFiltered,
            Data = users.Values,
        });
    }

    [HttpGet("{userId:long:required}")]
    public async Task<IActionResult> GetOrderById([FromRoute] long userId)
    {
        var user = await _orderService.GetOrderById(userId);

        return Ok(user);
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] OrderRequest request)
    {
        var result = await _orderService.AddOrder(request);

        return FromResult(result);
    }

    [HttpPut("{userId:long:required}")]
    public async Task<IActionResult> UpdateOrder([FromRoute] long userId, [FromBody] OrderUpdateRequest request)
    {
        var result = await _orderService.UpdateOrder(userId, request);

        return FromResult(result);
    }


    [HttpDelete("{userId:long:required}")]
    public async Task<IActionResult> DeleteOrder([FromRoute] long userId)
    {
        var result = await _orderService.DeleteOrder(userId);

        return FromResult(result);
    }
}
﻿using Domain.Base;
using Domain.Search;
using Infastructure.DataTables;
using Microsoft.AspNetCore.Mvc;

namespace CantinaUnitBV.Controllers.Base;

public class CantinaBvControllerBase : ControllerBase
{
    protected new IActionResult Ok()
    {
        return base.Ok(Envelope.Ok());
    }

    protected IActionResult Ok<T>(T result)
    {
        return base.Ok(Envelope.Ok(result));
    }

    protected IActionResult Error(string errorMessage)
    {
        return BadRequest(Envelope.Error(errorMessage));
    }

    protected IActionResult FromResult(Result result)
    {
        return result.IsSuccess ? Ok() : Error(result.Error);
    }

    protected IActionResult FromResult<T>(Result<T> result)
    {
        return result.IsSuccess ? Ok(result.Value) : Error(result.Error);
    }

    protected static SortOptionArgs ComposeSort(DtParameters dtParameters)
    {
        var sort = new SortOptionArgs
        {
            PropertyName = dtParameters.SortColumn,
            SortOrder = string.IsNullOrWhiteSpace(dtParameters.SortOrder) || dtParameters.SortOrder == "asc"
                ? SortOrder.Ascending
                : SortOrder.Descending
        };

        return sort;
    }
}
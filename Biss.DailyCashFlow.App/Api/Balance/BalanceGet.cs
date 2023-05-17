using Biss.DailyCashFlow.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Biss.DailyCashFlow.App.Api.Balance;

public class BalanceGet
{
    public static string Template => "/balance/{balanceDate}";
    public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
    public static Delegate Handle => Action;

    public static async Task<IResult> Action([FromRoute] DateTime balanceDate, IBalanceService service)
    {
        Domain.Entities.Balance balance = await service.GetBalanceAsync(balanceDate);        
        return Results.Ok(balance);
    }
}

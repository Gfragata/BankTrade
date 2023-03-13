using CategoryBankTrades.Infra.Context;
using CategoryBankTrades.Model;
using CategoryBankTrades.Model.Interface;
using CategoryBankTrades.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.AccessControl;
using System.Text.Json;

namespace CategoryBankTrades.Controllers
{
    [ApiController]
    [Route("BankTrades")]
    public class BankTradesController : Controller
    {
        public readonly IBankTradeService _bankTradeService;
        public BankTradesController(IBankTradeService bankTradeService)
        {
            _bankTradeService = bankTradeService;
        }

        [HttpGet("GetTrades")]
        public List<Trade> GetAllTrades()
        {
            return _bankTradeService.GetAllTrades();
        }

        [HttpPost("GetCategory")]
        public List<string> GetCategoryTrades([FromBody] List<TradesToCategory> trade)
        {
            return _bankTradeService.GetCategoryTrades(trade);
        }

        [HttpPut("NewTrade")]
        public ActionResult CreateTrade([FromQuery] double value, string? clientSector)
        {
            try
            {
                return Ok(_bankTradeService.CreateTrade(value, clientSector));
            }
            catch (Exception ex)
            {

                return NotFound(ex.Message);
            }

        }

        [HttpPost("ModifyTrade")]
        public ActionResult UpdateTrade([FromQuery] int id, double? value, string? clientSector)
        {
            try
            {
                return Ok(_bankTradeService.UpdateTrade(id, value, clientSector));
            }
            catch (Exception ex)
            {

                return NotFound(ex.Message);
            }
        }

        [HttpPost("DeleteTrade")]
        public ActionResult DeleteTrade([FromQuery] int id, bool isDeleted)
        {
            try
            {
                return Ok(_bankTradeService.DeleteTrade(id, isDeleted));
            }
            catch (Exception ex)
            {

                return NotFound(ex.Message);
            }
        }
    }
}

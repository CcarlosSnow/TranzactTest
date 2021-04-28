using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TranzactTest.Models;
using TranzactTest.Services;

namespace TranzactTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IOperation operations;

        private Shared.Util util = Shared.Util.GetInstance();

        public TestController(IOperation operations)
        {
            this.operations = operations;
        }

        [HttpPost]
        [Route("CalculateArea")]
        public IActionResult CalculateArea([FromBody] CalculateAreaRequest request)
        {
            int[] numbers = util.ConverToIntArray(request.Numbers);

            return Ok(operations.GetCurrentMaxArea(numbers));
        }
    }
}
using Finance.Application.Models;
using Finance.Infrastructure.Persistence;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Finance.API.Controllers
{
    [ApiController]
    [Route("api/paymentType")]
    public class PaymentsTypesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly FinanceDbContext _context;
        public PaymentsTypesController(IMediator mediator, FinanceDbContext context)
        {
            _mediator = mediator;
            _context = context;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _context.PaymentTypes
                .SingleOrDefault(x => x.Id == id);

            return Ok(result);
        }


        [HttpPost]
        public IActionResult Post(CreatePaymentTypeInputModel model)
        {
            var payment = model.ToEntity();

            _context.PaymentTypes.Add(payment);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = 1 }, model);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestAPI.Models;
using TestAPI.Services;

namespace TestAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoveQuoteController : ControllerBase
    {
        private readonly ILoveQuoteServices _loveQuoteServices;
        public LoveQuoteController(ILoveQuoteServices _loveQuoteServices)
        {
            this._loveQuoteServices = _loveQuoteServices;
            Helper.InitializeClient();
        }

        [HttpGet]
        public ActionResult<LoveQuote> Get()
        {
            var loveQoute = _loveQuoteServices.GetRandomLoveQuote();

            return Ok(loveQoute.Result);
        }
    }
}
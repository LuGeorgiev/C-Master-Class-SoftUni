using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppExpressionTest.Controllers
{
    public class AnotherController : Controller
    {
        public IActionResult SomeAction(int id, string query)
        {
            return NotFound();
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace PickPointAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public abstract class PickPointAPIControllerBase : ControllerBase
    {
    }
}

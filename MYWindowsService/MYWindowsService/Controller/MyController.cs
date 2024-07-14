using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace MYWindowsService.Controllers;
[Microsoft.AspNetCore.Mvc.Route("[controller]")]
[ApiController]

public class MyController:ControllerBase
{
    [HttpGet]
    public ContentResult Get()
    {
        string somecontent = "This is for Api Hosting";
        return new ContentResult
        {
            Content = somecontent,
            ContentType = "text/html"

        };


       }

  }


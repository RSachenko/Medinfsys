using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class PersonLocationsController : ControllerBase
{
    [HttpGet]
    public IActionResult GetPersonLocations()
    {
        // Здесь вы должны вернуть данные о перемещении клиентов и сотрудников
        // Просто вернем заглушку для примера
        var dummyData = new
        {
            Clients = new[]
            {
                new { PersonCode = "Client1", PersonRole = "Client", LastSecurityPointNumber = 1 },
                // Добавьте другие данные о клиентах
            },
            Staff = new[]
            {
                new { PersonCode = "Staff1", PersonRole = "Staff", LastSecurityPointNumber = 2 },
                // Добавьте другие данные о сотрудниках
            }
        };

        return Ok(dummyData);
    }
}
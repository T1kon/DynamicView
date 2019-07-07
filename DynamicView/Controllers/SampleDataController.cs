using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NETCoreWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ViewController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_viewResult);
        }
        
        private ViewResult _viewResult = new ViewResult
        {
            Columns = new List<ColumnMetadata>
            {
                new ColumnMetadata
                {
                    Name = "id",
                    Caption = "Идентификатор",
                    Type = typeof(Guid)
                },
                new ColumnMetadata
                {
                    Name = "name",
                    Caption = "Название",
                    Type = typeof(string)
                },
                new ColumnMetadata
                {
                    Name = "ip",
                    Caption = "IP-адрес",
                    Type = typeof(string)
                },
                new ColumnMetadata
                {
                    Name = "is offline",
                    Caption = "Оффлайн",
                    Type = typeof(bool)
                }
            },
            Rows = new List<Dictionary<string, object>>
            {
                new Dictionary<string, object>
                {
                    {"id", Guid.NewGuid() },
                    {"name", "Device 1" },
                    {"ip", "192.168.0.1" },
                    {"is offline", true }
                },
                new Dictionary<string, object>
                {
                    {"id", Guid.NewGuid() },
                    {"name", "Device 2" },
                    {"ip", "192.168.0.2" },
                    {"is offline", true }
                },
                new Dictionary<string, object>
                {
                    {"id", Guid.NewGuid() },
                    {"name", "Device 3" },
                    {"ip", "192.168.0.3" },
                    {"is offline", true }
                },
                new Dictionary<string, object>
                {
                    {"id", Guid.NewGuid() },
                    {"name", "Device 4" },
                    {"ip", "192.168.0.4" },
                    {"is offline", false }
                }
            }
        }; 
    }

    public class ViewResult
    {
        public List<ColumnMetadata> Columns { get; set; }
        
        public List<Dictionary<string, object>> Rows { get; set; }
    }

    public class ColumnMetadata
    {
        public Type Type { get; set; }
        
        public string Name { get; set; }
        
        public string Caption { get; set; }
    }
}

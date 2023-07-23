using DataBase_Test.Common;
using DataBase_Test.MySQL;
using DataBase_Test.SQL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;

namespace DataBase_Test.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ISqlService _sqlService;
        private readonly IMySqlService _mySqlService;
        public List<Table> Tables { get; set; }


        public IndexModel(ILogger<IndexModel> logger,ISqlService service,IMySqlService mySqlService)
        {
            _logger = logger;
            _sqlService = service;
            _mySqlService = mySqlService;
        }

        public void OnGet()
        {
            Tables = new List<Table>();
            // ---------------  SQL --------------
            Tables.Add(new Table
            {
                DBName = "SQL",
                Insert = _sqlService.Insert(),
                Update = _sqlService.Update(),
                Select = _sqlService.GetAll(),
                Delete = _sqlService.Delete()
            });
            //_sqlService.Delete();
            //ViewData["SQL_Insert"] = _sqlService.Insert();
            //ViewData["SQL_Update"] = _sqlService.Update();
            //ViewData["SQL_Select"] = _sqlService.GetAll();

            // --------------- MySQL --------------
            Tables.Add(new Table
            {
                DBName = "MySQL",
                Insert = _mySqlService.Insert(),
                Update = _mySqlService.Update(),
                Select = _mySqlService.GetAll(),
                Delete = _mySqlService.Delete()
            });
            //_mySqlService.Delete();
            //ViewData["MySQL_Insert"] = _mySqlService.Insert();
            //ViewData["MySQL_Update"] = _mySqlService.Update();
            //ViewData["MySQL_Select"] = _mySqlService.GetAll();
            
        }
    }
}
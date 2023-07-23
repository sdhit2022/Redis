using DataBase_Test.Common;
using DataBase_Test.MySQL;
using DataBase_Test.PostgreSQL;
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
        private readonly IPostgreService _postgreService;
        public List<Table> Tables { get; set; }


        public IndexModel(ILogger<IndexModel> logger,ISqlService service,IMySqlService mySqlService,
            IPostgreService postgreService)
        {
            _logger = logger;
            _sqlService = service;
            _mySqlService = mySqlService;
            _postgreService= postgreService;
        }

        public void OnGet()
        {
            Tables = new List<Table>();
            // ---------------  SQL --------------
            Tables.Add(new Table
            {
                DBName = "SQL",
                Delete = _sqlService.Delete(),
                Insert = _sqlService.Insert(),
                Update = _sqlService.Update(),
                Select = _sqlService.GetAll()
               
            });

            // --------------- MySQL --------------
            Tables.Add(new Table
            {
                DBName = "MySQL",
                Delete = _mySqlService.Delete(),
                Insert = _mySqlService.Insert(),
                Update = _mySqlService.Update(),
                Select = _mySqlService.GetAll()
            });
            // _______________ PostgreSQL -------------
            Tables.Add(new Table
            {
                DBName = "PostgreSQL",
                Delete = _postgreService.Delete(),
                Insert = _postgreService.Insert(),
                Update = _postgreService.Update(),
                Select = _postgreService.GetAll()         
            });


        }
    }
}
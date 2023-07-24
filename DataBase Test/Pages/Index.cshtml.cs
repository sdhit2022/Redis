using DataBase_Test.Common;
using DataBase_Test.MySQL;
using DataBase_Test.PostgreSQL;
using DataBase_Test.SQL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;
using System.Diagnostics;
using System.Net;

namespace DataBase_Test.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ISqlService _sqlService;
        private readonly IMySqlService _mySqlService;
        private readonly IPostgreService _postgreService;
        public List<Table> Tables { get; set; }
        public Result ins, del, upd, sel;

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
            var i = _sqlService.Delete();
            //// ---------------  SQL --------------

            ins = _sqlService.Insert();
            del = _sqlService.Insert();
            upd = _sqlService.Insert();
            sel = _sqlService.Insert();



            Tables.Add(new Table
            {
                DBName = "SQL",
                Insert = ins.Time,
                Update = upd.Time,
                Select = sel.Time,
                Delete = del.Time,


            });

           
            //// --------------- MySQL --------------
            //i = _mySqlService.Delete();
            //Tables.Add(new Table
            //{
            //    DBName = "MySQL",
            //    Insert = _mySqlService.Insert(),
            //    Update = _mySqlService.Update(),
            //    Select = _mySqlService.GetAll(),
            //    Delete = _mySqlService.Delete(),
            //});
            // _______________ PostgreSQL -------------
            // i = _postgreService.Delete();

            //Tables.Add(new Table
            //{
            //    DBName = "PostgreSQL",
            //    Insert = _postgreService.Insert(),
            //    Update = _postgreService.Update(),
            //    Select = _postgreService.GetAll(),
            //    Delete = _postgreService.Delete(),

            //});


        }
        public static  void sql()
        {
        }
        public static void sqlRam()
        {

        }
    }
}
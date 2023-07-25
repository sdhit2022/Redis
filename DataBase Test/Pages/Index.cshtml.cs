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
        public List<DBusage> Usage;

        

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
            Result ins, del, upd, sel;

            //// ---------------  SQL --------------
            Usage = new List<DBusage>();
            ins = _sqlService.Insert();
            upd = _sqlService.Update();
            sel = _sqlService.GetAll();
            del = _sqlService.Delete();

            Usage.Add(setUsage(ins,"Insert"));
            Usage.Add(setUsage(upd,"Update"));
            Usage.Add(setUsage(sel,"Select"));
            Usage.Add(setUsage(del,"Delete"));

            Tables.Add(new Table
            {
                DBName = "SQL",
                Insert = ins.Time,
                Update = upd.Time,
                Select = sel.Time,
                Delete = del.Time,
                Usage=Usage
            });


            //// --------------- MySQL --------------
            Usage = new List<DBusage>();
             i = _mySqlService.Delete();

            ins = _mySqlService.Insert();
            upd = _mySqlService.Update();
            sel = _mySqlService.GetAll();
            del = _mySqlService.Delete();

            Usage.Add(setUsage(ins, "Insert"));
            Usage.Add(setUsage(upd, "Update"));
            Usage.Add(setUsage(sel, "Select"));
            Usage.Add(setUsage(del, "Delete"));

            Tables.Add(new Table
            {
                DBName = "MySQL",
                Insert = ins.Time,
                Update = upd.Time,
                Select = sel.Time,
                Delete = del.Time,
                Usage = Usage
            });

            // _______________ PostgreSQL -------------
            Usage = new List<DBusage>();
            i = _postgreService.Delete();

            ins = _postgreService.Insert();
            upd = _postgreService.Update();
            sel = _postgreService.GetAll();
            del = _postgreService.Delete();

            Usage.Add(setUsage(ins, "Insert"));
            Usage.Add(setUsage(upd, "Update"));
            Usage.Add(setUsage(sel, "Select"));
            Usage.Add(setUsage(del, "Delete"));

            Tables.Add(new Table
            {
                DBName = "PostgreSQL",
                Insert = ins.Time,
                Update = upd.Time,
                Select = sel.Time,
                Delete = del.Time,
                Usage = Usage
            });



        }
        public DBusage setUsage(Result result,string name)
        {
            var usage=new DBusage
            {
                DBoperation = name,
                //Cpu = result.Cpu,
                Memory = result.Memory/ 1024 ^ 2,
                Time = result.Time
            };
             return usage;
        }
     
        
    }
}
using DataBase_Test.SQL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DataBase_Test.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ISqlService _service;


        public IndexModel(ILogger<IndexModel> logger,ISqlService service)
        {
            _logger = logger;
            _service = service;
        }

        public void OnGet()
        {
            _service.Delete();
           ViewData["SQL_Insert"]= _service.Insert();
            ViewData["SQL_Update"] = _service.Update();
            ViewData["SQL_Select"] = _service.GetAll();
        }
    }
}
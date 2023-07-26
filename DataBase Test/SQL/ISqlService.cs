using DataBase_Test.Common;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Diagnostics;
using System.Threading;

namespace DataBase_Test.SQL
{
    public interface ISqlService
    {
        Result Delete();
        Result Insert(int num);
        Result Update();
        Result GetAll();

    }

    public class SqlService : ISqlService
    {
        private readonly ISQLContext _context;
        public SqlService(ISQLContext context)
        {
            _context= context;
            _context.Database.SetCommandTimeout(86000);

        }

        public Result GetAll()
        {
            var time = select();
            Process currentProcess = Process.GetProcessById(10924);
            var RamUsage = currentProcess.WorkingSet64;
            var Cpu = currentProcess.TotalProcessorTime;
             
            //PerformanceCounter system_cpu_usage = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            var result = new Result
            {
                Time = time.Result,
                Memory = RamUsage,
               //  // Cpu = Cpu
            };
            return result;

        }

        public Result Insert(int num)
        {

            var list = new List<Object>();
            for (int i = 0; i < num; i++)
            {
                var obj = new Object
                {
                    Id = Guid.NewGuid(),
                    String = "Late edit, there's something else to know : You can't run Scaffold-DbContext against",
                    Date = DateTime.Now,
                    Decimal = new decimal(),
                    Image = "Late edit, there's something else to know : You can't run Scaffold-DbContext against"
                };
                list.Add(obj);
                _context.Objects.Add(obj);
            }

            var time = save();

            Process currentProcess = Process.GetProcessById(10924);
            var RamUsage = currentProcess.WorkingSet64;
            var cpu = currentProcess.TotalProcessorTime;
            var result = new Result
            {
                Time = time.Result,
                Memory = RamUsage,
                 // Cpu = Cpu
            };
            return result;

        }

        public Result Update()
        {
            var time = update();
            Process currentProcess = Process.GetProcessById(10924);
            var RamUsage = currentProcess.WorkingSet64;
            var Cpu = currentProcess.TotalProcessorTime;
            var result = new Result
            {
                Time = time.Result,
                Memory = RamUsage,
                 // Cpu = Cpu
            };
            return result;
        }

        public Result Delete()
        {
            var time = delete();
            Process currentProcess = Process.GetProcessById(10924);
            var RamUsage = currentProcess.WorkingSet64;
            var Cpu = currentProcess.TotalProcessorTime;
            var result = new Result
            {
                Time = time.Result,
                Memory = RamUsage,
                 // Cpu = Cpu
            };
            return result;
        }

        //  Tasks
        public async Task<double> save()
        {
            long result = 0;
            await Task.Run(() =>
            {


                var watch = new Stopwatch();
                watch.Start();
                _context.SaveChanges();
                watch.Stop();


                result = watch.ElapsedMilliseconds;


            });

            return result;
        }
        public async Task<double> select()
        {
            long result = 0;
            await Task.Run(() =>
            {


                var watch = new Stopwatch();
                watch.Start();
                var reult = _context.Objects.ToList();
                watch.Stop();
                result = watch.ElapsedMilliseconds;


            });

            return result;
        }
        public async Task<double> update()
        {
            long result = 0;
            await Task.Run(() =>
            {
                var watch = new Stopwatch();
                watch.Start();
                List<Object> list = new List<Object>();
                list = _context.Objects.Where(x => x.String.Equals("Late edit, there's something else to know : You can't run Scaffold-DbContext against")).ToList();

                list.ForEach(x => x.Date = DateTime.Now);
                //_context.Database.SetCommandTimeout(1);
                _context.Objects.UpdateRange(list);
                _context.SaveChanges();
                watch.Stop();
                result = watch.ElapsedMilliseconds;


            });

            return result;
        }
        public async Task<double> delete()
        {
            long result = 0;
            await Task.Run(() =>
            {
                var watch = new Stopwatch();
                watch.Start();
                _context.Objects.FromSql($"delete from Object where Image = \"Late edit, there's something else to know : You can't run Scaffold-DbContext against\"");
                _context.SaveChanges();
                watch.Stop();
                result = watch.ElapsedMilliseconds;


            });

            return result;
        }
    }
}

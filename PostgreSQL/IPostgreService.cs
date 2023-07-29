using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Redis.Common;

namespace Redis.PostgreSQL
{
    public interface IPostgreService
    {
        Result Delete();
        Result Insert(int num);
        Result Update();
        Result GetAll();

    }

    public class PostgreService : IPostgreService
    {
        private readonly IPostgresContext _context;
        public PostgreService(IPostgresContext context)
        {
            _context = context;
            _context.Database.SetCommandTimeout(86000);
        }

        public Result GetAll()
        {
            var time = select();
            Process currentProcess = Process.GetProcessById(19844);
            var RamUsage = currentProcess.WorkingSet64;
            var Cpu = currentProcess.TotalProcessorTime;
            var result = new Result
            {
                Time = time.Result,
                Memory = RamUsage,
                //Cpu= Cpu
            };
            return result;

        }

        public Result Insert(int num)
        {

            var list = new List<Pobject>();
            for (int i = 0; i < num; i++)
            {
                var obj = new Pobject
                {
                    Id = Guid.NewGuid(),
                    String = "Late edit, there's something else to know : You can't run Scaffold-DbContext against",
                    Date = DateTime.Now,
                    Decimal = new decimal(),
                    Image = "Late edit, there's something else to know : You can't run Scaffold-DbContext against"
                };
                list.Add(obj);
                _context.Pobjects.Add(obj);
            }

            var time = save();

            Process currentProcess = Process.GetProcessById(19844);
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
            var time = update().Result;
            Process currentProcess = Process.GetProcessById(19844);
            var RamUsage = currentProcess.WorkingSet64;
            var Cpu = currentProcess.TotalProcessorTime;
            var result = new Result
            {
                Time = time,
                Memory = RamUsage,
                // Cpu = Cpu
            };
            return result;
        }

        public Result Delete()
        {
            var time = delete();
            Process currentProcess = Process.GetProcessById(19844);
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
                var reult = _context.Pobjects.ToList();
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
                List<Pobject> list = new List<Pobject>();
                list = _context.Pobjects.Where(x => x.String.Equals("Late edit, there's something else to know : You can't run Scaffold-DbContext against")).ToList();

                list.ForEach(x => x.Date = DateTime.Now);
                _context.Pobjects.UpdateRange(list);
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
                _context.Pobjects.FromSql($"delete from Pobject where Image = \"Late edit, there's something else to know : You can't run Scaffold-DbContext against\"");
                _context.SaveChanges();
                watch.Stop();
                result = watch.ElapsedMilliseconds;


            });

            return result;
        }



    }
}

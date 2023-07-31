﻿using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Diagnostics;
using System.Threading;
using Redis.Common;
using Redis.SQL.Cache;
using Microsoft.Extensions.Caching.Distributed;
using Redis_Demo.Extensions;

namespace Redis.SQL
{
    public interface ISqlService
    {
        Result Delete();
        Result Insert(int num);
        Result Update();
        Result GetAll();
        IEnumerable<Object> GetAllCached();
        void DeleteCached();
        void InsertCached();
        void UpdateCached();

    }

    public class SqlService : ISqlService
    {
        private readonly ISQLContext _context;
        private readonly ICacheService _cacheService;
        private IDistributedCache cache;

        public SqlService(ISQLContext context,ICacheService cacheService,IDistributedCache cache)
        {
            _context = context;
            _cacheService = cacheService;
            _context.Database.SetCommandTimeout(86000);
            this.cache= cache;

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

        public IEnumerable<Object> GetAllCached()
        {
            string recordKey = "Object_" + DateTime.Now.ToString("yyyyMMdd_hhmm");
            var cacheData = cache.GetRecordAsync<IEnumerable<Object>>(recordKey).Result;
            if (cacheData != null)
            {
                return cacheData;
            }
            var expirationTime = DateTimeOffset.Now.AddMinutes(5.0);
            var result = _context.Objects.ToList();
            cache.SetRecordAsync(recordKey, result);
            return result;
        }

        public void DeleteCached() 
        { 
        }
        public void InsertCached()
        { }
        public void UpdateCached()
        { }

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
                var reult = GetAllCached();
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

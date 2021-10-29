using Mansion.DataGenerator;
using Mansion.Models;
using Mansion.Services;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Mansion.Controllers
{
    public class HomeController : Controller
    {
        private readonly PatternService _patternService;
        private readonly BankService _bankService;

        public HomeController(PatternService patternService, BankService bankService)
        {
            _patternService = patternService;
            _bankService = bankService;
        }

        public IActionResult Index()
        {
            //var gen = new Generator("A00");
            //var list = gen.Build(randomized: true);
            //Bank testBank = new(list);
            //GitTest :)
            //var guid = _bankService.Upload(testBank);
            // var guid = new Guid("5714ce5c-405a-471d-b18f-216214340c94");
            var guid = new Guid("b28be209-0222-4884-a394-48470a4aca4e");
            var dl = _bankService.DownloadList(guid);

            //gen.WriteToCSVFile(list);
            return View(dl);
        }

        public FileResult Download()
        {
            var guid = new Guid("b28be209-0222-4884-a394-48470a4aca4e");
            var list = _bankService.DownloadList(guid);

            var dl = new MemoryStream();
            var sw = new StreamWriter(dl);
            foreach (var line in list)
            {
                sw.WriteLine(line);
            }
            //byte[] bytes;
            //using (MemoryStream ms = new())
            //{
            //    StreamWriter sw = new(ms);
            //    foreach (var line in dl)
            //    {
            //        sw.WriteLine(line);
            //    }
            //    bytes = ms.ToArray();
            //}
            return File(dl.ToArray(), "txt/csv");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

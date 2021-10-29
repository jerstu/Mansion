using Mansion.Models;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Text;

namespace Mansion.Services
{
    public class BankService
    {
        private readonly GridFSBucket _banks;

        public BankService(IMongoDbSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _banks = new GridFSBucket(database);
        }

        public Guid Upload(Bank bank)
        {
            Guid guid = Guid.NewGuid();
            using (StreamWriter sw = new(_banks.OpenUploadStream(guid.ToString())))
            {
                foreach (string serial in bank.Serials)
                {
                    sw.WriteLine(serial);
                }

            }
            return guid;
        }

        // Download by guid
        public List<string> DownloadList(Guid guid)
        {
            List<string> list = new();
            using (StreamReader sr = new(_banks.OpenDownloadStreamByName(guid.ToString())))
            {
                while (!sr.EndOfStream)
                {
                    list.Add(sr.ReadLine());
                }
            }
            return list;
        }

        public Stream DownloadStream(Guid guid)
        {
            //using (StreamReader sr = new(_banks.OpenDownloadStreamByName(guid.ToString())))
            //{
            //    StringBuilder sb = new();
            //    while (!sr.EndOfStream)
            //    {
            //        sb.Append(sr.ReadLine());                    
            //    }
            //    return sb.ToString();
            //}

            return _banks.OpenDownloadStreamByName(guid.ToString());
        }
    }
}

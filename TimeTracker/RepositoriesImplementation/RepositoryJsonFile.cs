﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TimeTracker.RepositoriesInterfaces;

namespace TimeTracker.RepositoriesImplementation
{
    class RepositoryJsonFile<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected string FilePath;

        private StreamReader OpenReader()
        {
            var file = new FileStream(FilePath, FileMode.OpenOrCreate, FileAccess.Read, FileShare.None);
            StreamReader fileReader = new StreamReader(file);
            return fileReader;
        }
        private StreamWriter OpenWriter()
        {
            var file = new FileStream(FilePath, FileMode.Append, FileAccess.Write, FileShare.None);
            StreamWriter fileWriter = new StreamWriter(file);
            return fileWriter;
        }

        public RepositoryJsonFile(string filePath)
        {

            FilePath = filePath;
            //File = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None);

            //TODO - add handling of not valid path, etc.
        }
        public TEntity Get(int id)
        {
            IEnumerable<TEntity> records = GetAll();
            return records.ElementAt(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            string line;
            var records = new List<TEntity>();

            JsonSerializer serializer = new JsonSerializer();
            var fileReader = OpenReader();

            using (fileReader)
            {
                while ((line = fileReader.ReadLine()) != null)
                {
                    records.Add(JsonConvert.DeserializeObject<TEntity>(line));
                }
            }
            
            return records;
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Add(TEntity entity)
        {
            //IEnumerable<TEntity> records = GetAll();

            //records.Append(entity);
            
            string json = JsonConvert.SerializeObject(entity);

            var fileWriter = OpenWriter();

            using (fileWriter)
            {
                fileWriter.WriteLine(json);
                fileWriter.Flush();
            }
        }

        public void Remove(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
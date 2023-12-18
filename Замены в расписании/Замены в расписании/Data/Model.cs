using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
namespace Замены_в_расписании.Data
{
    public class Model : DbContext
    {
        public DbSet<Группы> Группы { get; set; }
        public DbSet<Дисциплины> Дисциплины { get; set; }
        public DbSet<Специалиности_и_профессии> Специалиности_и_профессии { get; set; }
        public string DbPath { get; }
        public Model()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = @"C:\Изменения в расписании\DataBase.db";
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite($"Data Source={DbPath}");
    }
    public class Группы
    {
        public int ID { get; set; }
        public string Название_группы { get; set; }
        public int Специальность_профессия { get; set; }
        public string Название_специальность_профессии
        {
            get
            {
                return App.model.Специалиности_и_профессии.ToList().Single(x => x.ID == Специальность_профессия).Специальность_профессия;
            }
        }
    }
    public class Дисциплины
    {
        public int ID { get; set; }
        public string Название_дисциплины { get; set; }
        public int Специальность_профессия { get; set; }
    }
    public class Специалиности_и_профессии
    {
        public int ID { get; set; }
        public string Специальность_профессия { get; set; }
    }
}

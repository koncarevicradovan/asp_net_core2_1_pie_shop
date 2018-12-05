using System;
using System.Linq;
using Debts.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Core;
using Microsoft.EntityFrameworkCore.InMemory;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Debts.Test
{
    [TestClass]
    public class UnitTest1
    {
        //private readonly AppDbContext _appDbContext;
        //public UnitTest1(AppDbContext appDbContext)
        //{
        //    _appDbContext = appDbContext;
        //}

        [TestMethod]
        public void TestMethod1()
        {
            // Arrange
            DbContextOptions<AppDbContext> options;
            DbContextOptionsBuilder<AppDbContext> builder = new DbContextOptionsBuilder<AppDbContext>();
            builder.UseInMemoryDatabase(Guid.NewGuid().ToString());
            options = builder.Options;

            Pie testPie = new Pie()
            {
                Name = "TestPie"
            };

            // Act
            using (var context = new AppDbContext(options))
            {
                context.Pies.Add(testPie);
                context.SaveChanges();
            }

            Pie foundEntity;
            using (var context = new AppDbContext(options))
            {
                foundEntity = context.Pies.FirstOrDefault(x => x.Id == testPie.Id);
            }

            // Assert  
            Assert.IsNotNull(foundEntity);
            Assert.AreEqual(testPie.Name, foundEntity.Name);
        }
    }
}

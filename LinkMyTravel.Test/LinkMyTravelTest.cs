using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LinkMyTravel.WebAPI.Controllers;
using LinkMyTravel.WebAPI.Repositories;
using LinkMyTravel.Data;

namespace LinkMyTravel.Test
{
    [TestClass]
    public class LinkMyTravelTest
    {
        string _connectionString = 
            "Server=DESKTOP-7SHT74O\\SQLEXPRESS;Database=LinkMyTravelDb;integrated security=yes;";

        //TodoController _todoController = null;
        //ITodoRepository _todoRepository = null;
        //LinkMyTravelContext _linkMyTravelContext = null;
        public LinkMyTravelTest()
        {

            //DbContextOptions<LinkMyTravelContext> 
            //_linkMyTravelContext = new LinkMyTravelContext();
            //_todoRepository = new TodoRepository(_linkMyTravelContext); 
            //_todoController = new TodoController(_todoRepository);
        }

      

        [TestMethod]
        public void TestMethod1()
        {

        }
    }
}

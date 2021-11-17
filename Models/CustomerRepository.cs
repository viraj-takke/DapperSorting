using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC_CRUD.Models;
using System.Data;
using System.Data.SqlClient;

namespace MVC_CRUD.Models
{
    public class CustomerRepository
    {
        private string connectionstring;
        public CustomerRepository()
        {
            connectionstring = System.Configuration.ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;
        }
        public List<Customer> GetAll(RequestModel request)
        {
            using (IDbConnection db = new SqlConnection(connectionstring))
            {
                return db
                    .Query<Customer>("Customer_GetAll",
                    request,
                    commandType: CommandType.StoredProcedure)
                    .ToList();

            }
        }
        public Customer Get(int Id)
        {
            using (IDbConnection db = new SqlConnection(connectionstring))
            {
                return db
                        .Query<Customer>("Customer_Get",
                            new { Id },
                            commandType: CommandType.StoredProcedure)
                        .FirstOrDefault();
            }
        }
        public int Create(Customer customer)
        {
            using (IDbConnection db = new SqlConnection(connectionstring))
            {
                int lastInsertedId =
                    db.Query<int>("Customer_Create",
                    customer,
                    commandType: CommandType.StoredProcedure)
                    .FirstOrDefault();
                return lastInsertedId;
            }
        }
        public int Update(Customer customer)
        {
            using (IDbConnection db = new SqlConnection(connectionstring))
            {
                return db
                    .Execute("Customer_Update",
                       customer,
                       commandType: CommandType.StoredProcedure);
            }
        }
        public int Delete(int Id)
        {
            using (IDbConnection db = new SqlConnection(connectionstring))
            {
                return db.Execute(
                        "Customer_Delete",
                        new { Id },
                        commandType: CommandType.StoredProcedure);
            }
        }
    }
}
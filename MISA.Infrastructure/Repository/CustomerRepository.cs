using Microsoft.Extensions.Configuration;
using MISA.Infrastructure.Interface;
using MISA.Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using MySqlConnector;
using System.Data;

namespace MISA.Infrastructure.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        IConfiguration _configutation;

        private IDbConnection _dbConnection;


        public CustomerRepository(IConfiguration configuration)
        {
            _configutation = configuration;
            _dbConnection = new MySqlConnection(_configutation.GetConnectionString("connectionDB"));
        }

        public int Delete(Guid customerId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@CustomerId", customerId);

            var sqlCommand = "Proc_DeleteCustomer";
            var rowsAffects = _dbConnection.Execute(sqlCommand, param: parameters, commandType: CommandType.StoredProcedure);
            return rowsAffects;
        }

        public IEnumerable<Customer> GetAll()
        {
            var sqlCommand = "Proc_GetCustomers";
            var customers = _dbConnection.Query<Customer>(sqlCommand, commandType: CommandType.StoredProcedure);
            return customers;

        }

        public Customer GetById(Guid customerId)
        {
            var sqlCommand = "Proc_GetCustomerById";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@CustomerId", customerId);
            var customer = _dbConnection.Query<Customer>(sqlCommand, param: parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            return customer;
        }

        public int Insert(Customer customer)
        {
            var sqlCommand = "Proc_InsertCustomer";
            var rowsAffect = _dbConnection.Execute(sqlCommand, param: customer, commandType: CommandType.StoredProcedure);
            return rowsAffect;
        }

        public int Update(Customer customer)
        {
            var sqlCommand = "Proc_UpdateCustomer";
            var rowsAffect = _dbConnection.Execute(sqlCommand, param: customer, commandType: CommandType.StoredProcedure);
            return rowsAffect;
        }
    }
}

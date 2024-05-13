using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerModel;

namespace DAL
{
   public class CustomerDAL
    {
        #region Basic Functionality

        #region Variable Declaration

        /// <summary>
        /// Variable to store Database object to interact with database.
        /// </summary>
        private Database db;
        List<Customer> list = new List<Customer>();
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the Tags class.
        /// </summary>
        public CustomerDAL()
        {
            this.db = DatabaseFactory.CreateDatabase();

        }
        #endregion


        public List<Customer> GetList(Customer customer)
        {
            DataSet ds = null;
            try
            {
                DbCommand com = db.GetStoredProcCommand("CustomersGetList");             
                if (customer.CustomerId > 0)           
                    db.AddInParameter(com, "@CustomerId", DbType.Int32, customer.CustomerId);            
                else
                    db.AddInParameter(com, "@CustomerId", DbType.Int32, null);     
                ds = db.ExecuteDataSet(com);
            
                foreach (DataRow Row in ds.Tables[0].Rows)
                {
                    list.Add(new Customer
                    {
                        CustomerId = Convert.ToInt32(Row["CustomerId"]),
                        Name= Convert.ToString(Row["Name"]),
                        Address= Convert.ToString(Row["Address"]),
                        PhoneNumber = Convert.ToString(Row["PhoneNumber"])
                    });
                }
                return list;
            }
            catch (Exception ex)
            {
                //To Do: Handle Exception
                Debug.WriteLine(ex.StackTrace);
                return null;
            }


        }
      

    }
}
#endregion
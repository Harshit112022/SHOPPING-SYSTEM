using System;
using System.Data;

using System.Data.Common;
using System.Data.SqlClient;
using Microsoft.Practices.EnterpriseLibrary.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using CustomerModel;
using System.Collections.Generic;

namespace DataAccessLayer
{
    public class DataLayer
    {
        private Database db;
        Customer customer = new Customer();

        public DataLayer()
        {
            db = DatabaseFactory.CreateDatabase();
        }
        public DataLayer(int CustomerId)
        {
            db = DatabaseFactory.CreateDatabase();
            customer.CustomerId = CustomerId;
        }


        public Customer Load(int CustomerId)
        {
            Customer customer = new Customer();
            try
            {
                if (CustomerId != 0)
                {
                    DbCommand com = this.db.GetStoredProcCommand("CustomersGetList");
                    this.db.AddInParameter(com, "CustomerId", DbType.Int32, CustomerId);
                    DataSet ds = this.db.ExecuteDataSet(com);
                    if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        DataTable dt = ds.Tables[0];
                        customer.CustomerId = Convert.ToInt32(dt.Rows[0]["CustomerId"]);
                        customer.Name = Convert.ToString(dt.Rows[0]["Name"]);
                        customer.Address = Convert.ToString(dt.Rows[0]["Address"]);
                        customer.PhoneNumber = Convert.ToString(dt.Rows[0]["PhoneNumber"]);           
                        //customer.LastLastModifiedBy = Convert.ToString(dt.Rows[0]["LastLastModifiedBy"]);          
                        return customer;
                    }
                }

                return null;
            }
            catch (Exception ex)
            {
                // To Do: Handle Exception
                return null;
            }
        }
        public bool Save(Customer customer)
        {
            if (customer.CustomerId == 0)
            {
                  return this.Insert(customer);
            }
            else
            {
                if (customer.CustomerId > 0)
                {
                    return this.Update(customer);
                }
                else
                {
                    customer.CustomerId = 0;
                    return false;

                }
            }
        }
        private bool Update(Customer customer)
        {
            try
            {
                DbCommand com = this.db.GetStoredProcCommand("[CustomersUpdate]");
                this.db.AddInParameter(com, "CustomerId", DbType.Int32, customer.CustomerId);
                if (!String.IsNullOrEmpty(customer.Name))
                {
                    this.db.AddInParameter(com, "Name", DbType.String, customer.Name);
                }
                else
                {
                    this.db.AddInParameter(com, "Name", DbType.String, DBNull.Value);
                }
                //this.db.AddOutParameter(com, "Address", DbType.Int32, 1024);
                if (!String.IsNullOrEmpty(customer.Address))
                {
                    this.db.AddInParameter(com, "Address", DbType.String, customer.Address);
                }
                else
                {
                    this.db.AddInParameter(com, "Address", DbType.String, DBNull.Value);
                }
                //this.db.AddOutParameter(com, "PhoneNumber", DbType.Int32, 1024);
                if (!String.IsNullOrEmpty(customer.PhoneNumber))
                {
                    this.db.AddInParameter(com, "PhoneNumber", DbType.String, customer.PhoneNumber);
                }
                else
                {
                    this.db.AddInParameter(com, "PhoneNumber", DbType.String, DBNull.Value);
                }
                if (!String.IsNullOrEmpty(customer.LastLastModifiedBy))
                {
                    this.db.AddInParameter(com, "ModifyBy", DbType.String, customer.LastLastModifiedBy);
                }
                else
                {
                    this.db.AddInParameter(com, "ModifyBy", DbType.String, DBNull.Value);
                }

                this.db.ExecuteNonQuery(com);
            }
            catch (Exception ex)
            {
                // To Do: Handle Exception
                return false;
            }

            return true;
        }
        private bool Insert(Customer customer)
        {
            try
            {
                DbCommand com = this.db.GetStoredProcCommand("CustomersInsert");

                this.db.AddOutParameter(com, "@CustomersId", DbType.Int32, 1024);
                if (!String.IsNullOrEmpty(customer.Name))
                {
                    this.db.AddInParameter(com, "Name", DbType.String, customer.Name);
                }
                else
                {
                    this.db.AddInParameter(com, "Name", DbType.String, DBNull.Value);
                }
                //this.db.AddOutParameter(com, "Address", DbType.Int32, 1024);
                if (!String.IsNullOrEmpty(customer.Address))
                {
                    this.db.AddInParameter(com, "Address", DbType.String, customer.Address);
                }
                else
                {
                    this.db.AddInParameter(com, "Address", DbType.String, DBNull.Value);
                }
                //this.db.AddOutParameter(com, "PhoneNumber", DbType.Int32, 1024);
                if (!String.IsNullOrEmpty(customer.PhoneNumber))
                {
                    this.db.AddInParameter(com, "PhoneNumber", DbType.String, customer.PhoneNumber);
                }
                else
                {
                    this.db.AddInParameter(com, "PhoneNumber", DbType.String, DBNull.Value);
                }
                this.db.ExecuteNonQuery(com);
                customer.CustomerId = Convert.ToInt32(this.db.GetParameterValue(com, "CustomersId"));      // Read in the output parameter value
            }
            catch (Exception ex)
            {
                // To Do: Handle Exception
                return false;
            }

            return customer.CustomerId > 0; // Return whether ID was returned
        }
        public List<Customer> GetList()
        {
            DataSet ds = null;
            try
            {
                DbCommand com = db.GetStoredProcCommand("CustomersGetList");
                ds = db.ExecuteDataSet(com);


            }
            catch (Exception ex)
            {
                //To Do: Handle Exception
            }

            return ds;
        }
        public bool Delete(int CustomerId)
        {
            try
            {
                DbCommand com = this.db.GetStoredProcCommand("CustomersDelete");
                this.db.AddInParameter(com, "CustomerId", DbType.Int32, CustomerId);
                this.db.ExecuteNonQuery(com);
            }
            catch (Exception ex)
            {
                // To Do: Handle Exception
                return false;
            }

            return true;
        }

    }


}
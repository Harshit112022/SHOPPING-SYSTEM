using Microsoft.Practices.EnterpriseLibrary.Data;
//using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DAL
{
    /// <summary>
    /// Business class representing Tags
    /// </summary>
    public class ShopMaster
    {
        public int? PageSize
        {
            get; set;
        } = 10;
        public int? PageNumber
        {
            get; set;
        } = 1;
        public string CustomerName
        {
            get; set;
        }
        public string DateSaleOrders
        {
            get; set;
        }
        public string ProductName
        {
            get; set;
        }
        public string ProductCategory
        {
            get; set;
        }
        public int ProductCategoriesId
        {
            get; set;
        }
        public int Quantity
        {
            get; set;
        }
        public int ProductPrice
        {
            get; set;
        }
        public int ProductId
        {
            get; set;
        }
        public int TotalAmmount
        {
            get; set;
        }
        public string ToDate
        {
            get; set;
        }
        public string FromDate
        {
            get; set;
        }
        public int CustomerId { get; set; }
        public int TotalCount
        {
            get; set;
        }
        public int SaleOrdersDetailsId
        {
            get; set;
        }
        #region Basic Functionality
        #region Variable Declaration
        private Database db;
        #endregion
        #region Constructors
        public ShopMaster()
        {
            this.db = DatabaseFactory.CreateDatabase();
        }
        #endregion
        public List<ShopMaster> GetList()
        {
            DataSet ds = null;
            try
            {
                DbCommand com = db.GetStoredProcCommand("ShopMasterList");
                if (this.SaleOrdersDetailsId > 0)
                    db.AddInParameter(com, "@id", DbType.Int32, this.SaleOrdersDetailsId);
                else
                    db.AddInParameter(com, "@id", DbType.Int32, DBNull.Value);
                db.AddInParameter(com, "@Varname", DbType.String, this.CustomerName);
                if (this.ProductId > 0)
                    db.AddInParameter(com, "@VarProductId", DbType.Int32, this.ProductId);
                else
                    db.AddInParameter(com, "@VarProductId", DbType.Int32, DBNull.Value);
                if (this.ProductCategoriesId > 0)
                {
                    db.AddInParameter(com, "@varProductCategory", DbType.Int32, this.ProductCategoriesId);
                }
                else
                    db.AddInParameter(com, "@varProductCategory", DbType.Int32, DBNull.Value);
                db.AddInParameter(com, "@varDateFrom", DbType.String, this.FromDate);
                db.AddInParameter(com, "@varDateTo", DbType.String, this.ToDate);
                if (this.PageNumber > 0)
                    db.AddInParameter(com, "@PageNumber", DbType.Int32, this.PageNumber);
                else
                    db.AddInParameter(com, "@PageNumber", DbType.Int32, DBNull.Value);
                if (this.PageSize > 0)
                    db.AddInParameter(com, "@PageSize", DbType.Int32, this.PageSize);
                else
                    db.AddInParameter(com, "@PageSize", DbType.Int32, DBNull.Value);
                db.AddOutParameter(com, "@TotalCount", DbType.Int32, 1024);
                ds = db.ExecuteDataSet(com);
                this.TotalCount = (int)db.GetParameterValue(com, "@TotalCount");
                List<ShopMaster> list = new List<ShopMaster>();
                foreach (DataRow Row in ds.Tables[0].Rows)
                {
                    list.Add(new ShopMaster
                    {
                        SaleOrdersDetailsId = Convert.ToInt32(Row["SaleOrdersDetailsId"]),
                        CustomerName = Convert.ToString(Row["CustomerName"]),
                        CustomerId = Convert.ToInt32(Row["CustomerId"]),
                        DateSaleOrders=((DateTime)Row["DateSaleOrders"]).ToString("dd-MM-yyyy"),
                        // DateSaleOrders = Convert.ToString(Row["DateSaleOrders"]),
                        ProductName = Convert.ToString(Row["ProductName"]),
                        ProductId = Convert.ToInt32(Row["ProductId"]),
                        ProductCategory = Convert.ToString(Row["ProductCategory"]),
                        Quantity = Convert.ToInt32(Row["Quantity"]),
                        ProductPrice = Convert.ToInt32(Row["ProductPrice"]),
                        TotalAmmount = Convert.ToInt32(Row["TotalAmmount"])
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
        #endregion
        public bool Delete(int SaleOrdersDetailsId)
        {
            try
            {
                DbCommand com = this.db.GetStoredProcCommand("SaleOrdersDetailDelete");
                db.AddInParameter(com, "@SaleOrdersDetailsId", DbType.Int32, SaleOrdersDetailsId);
                db.ExecuteNonQuery(com);
            }
            catch (Exception ex)
            {
                // To Do: Handle Exception
                return false;
            }
            return true;
        }
        public bool Load()
        {
            DataSet ds = null;
            try
            {
                if (this.SaleOrdersDetailsId != 0)
                {
                    //  DbCommand com = this.db.GetStoredProcCommand("ShopMasterList");
                    DbCommand com = db.GetStoredProcCommand("ShopMasterList");
                    if (this.SaleOrdersDetailsId > 0)
                        db.AddInParameter(com, "@id", DbType.Int32, this.SaleOrdersDetailsId);
                    else
                        db.AddInParameter(com, "@id", DbType.Int32, DBNull.Value);
                    db.AddInParameter(com, "@Varname", DbType.String, this.CustomerName);
                    if (this.ProductId > 0)
                        db.AddInParameter(com, "@VarProductId", DbType.Int32, this.ProductId);
                    else
                        db.AddInParameter(com, "@VarProductId", DbType.Int32, DBNull.Value);
                    if (this.ProductCategoriesId > 0)
                    {
                        db.AddInParameter(com, "@varProductCategory", DbType.Int32, this.ProductCategoriesId);
                    }
                    else
                        db.AddInParameter(com, "@varProductCategory", DbType.Int32, DBNull.Value);
                    db.AddInParameter(com, "@varDateFrom", DbType.String, this.FromDate);
                    db.AddInParameter(com, "@varDateTo", DbType.String, this.ToDate);
                    if (this.PageNumber > 0)
                        db.AddInParameter(com, "@PageNumber", DbType.Int32, this.PageNumber);
                    else
                        db.AddInParameter(com, "@PageNumber", DbType.Int32, DBNull.Value);
                    if (this.PageSize > 0)
                        db.AddInParameter(com, "@PageSize", DbType.Int32, this.PageSize);
                    else
                        db.AddInParameter(com, "@PageSize", DbType.Int32, DBNull.Value);
                    db.AddOutParameter(com, "@TotalCount", DbType.Int32, 1024);
                    ds = db.ExecuteDataSet(com);
                    this.TotalCount = (int)db.GetParameterValue(com, "@TotalCount");
                    //  DataSet ds = this.db.ExecuteDataSet(com);
                    if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        DataTable dt = ds.Tables[0];
                        //this.SaleOrdersDetailsId = Convert.ToInt32(dt.Rows[0]["id"]);
                        this.CustomerName = Convert.ToString(dt.Rows[0]["CustomerName"]);
                        this.CustomerId = Convert.ToInt32(dt.Rows[0]["CustomerId"]);
                        this.DateSaleOrders = Convert.ToDateTime(dt.Rows[0]["DateSaleOrders"]).ToString("yyyy-MM-dd");
                        this.ProductName = Convert.ToString(dt.Rows[0]["ProductName"]);
                        this.ProductId = Convert.ToInt32(dt.Rows[0]["ProductId"]);
                        this.Quantity = Convert.ToInt32(dt.Rows[0]["Quantity"]);
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                // To Do: Handle Exception
                return false;
            }
        }
        public bool Save()
        {
            if (this.SaleOrdersDetailsId == 0)
            {
                return Insert();
            }
            else
            {
                if (this.SaleOrdersDetailsId > 0)
                {
                    return this.Update();
                }
                else
                {
                    this.SaleOrdersDetailsId = 0;
                    return false;
                }
            }
        }
        private bool Update()
        {
            try
            {
                DbCommand com = this.db.GetStoredProcCommand("ShopMasterUpdate");
                db.AddInParameter(com, "@SaleOrdersDetailsId", DbType.Int32, this.SaleOrdersDetailsId);
                db.AddInParameter(com, "@CustomerId", DbType.String, this.CustomerId);
                db.AddInParameter(com, "@DateOfOrder", DbType.String, this.DateSaleOrders);
                db.AddInParameter(com, "@ProductId", DbType.Int32, this.ProductId);
                db.AddInParameter(com, "@Quantity", DbType.Int32, this.Quantity);
                db.ExecuteNonQuery(com);
            }
            catch (Exception ex)
            {
                // To Do: Handle Exception
                return false;
            }
            return true;
        }
        private bool Insert()
        {
            //this this = new this();
            try
            {
                DbCommand com = this.db.GetStoredProcCommand("SaleOrdersDetailInsert");
                //    this.db.AddOutParameter(com, "TagId", DbType.Int32, 1024); 
                if (this.CustomerId > 0)
                    db.AddInParameter(com, "@CustomerId", DbType.Int32, this.CustomerId);
                else
                    db.AddInParameter(com, "@CustomerId", DbType.Int32, null);
                if (this.ProductId > 0)
                    db.AddInParameter(com, "@ProductId", DbType.Int32, this.ProductId);
                else
                    db.AddInParameter(com, "@ProductId", DbType.Int32, null);
                if (this.Quantity > 0)
                    db.AddInParameter(com, "@Quantity", DbType.Int32, this.Quantity);
                else
                    db.AddInParameter(com, "@Quantity", DbType.Int32, null);
                if (String.IsNullOrEmpty(this.DateSaleOrders))
                    db.AddInParameter(com, "@DateSaleOrder", DbType.String, null);
                else
                    db.AddInParameter(com, "@DateSaleOrder", DbType.String, this.DateSaleOrders);
                this.db.ExecuteNonQuery(com);
                //     this.TagId = Convert.ToInt32(this.db.GetParameterValue(com, "TagId"));      // Read in the output parameter value
            }
            catch (Exception ex)
            {
                // To Do: Handle Exception
                return false;
            }
            return true; // Return whether ID was returned
        }
    }
}

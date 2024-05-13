using Microsoft.Practices.EnterpriseLibrary.Data;
using ProductModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayeProduct
{
    public class DataLaye
    {
        private Database db;
        Product product = new Product();
        List<Product> list = new List<Product>();

        public DataLaye()
        {
            this.db = DatabaseFactory.CreateDatabase();
        }
        /// <summary>
        /// Inserts details for Products if ProductId = 0.
        /// Else updates details for Products.
        /// </summary>
        /// <returns>True if Save operation is successful; Else False.</returns>
        public bool Save(Product product)
        {
            if (product.ProductId == 0)
            {
                return Insert(product);
            }
            else
            {
                //if (product.ProductId > 0)
                //{
                //    return this.Update();
                //}
                //else
                //{
                //    product.ProductId = 0;
                //    return false;
                //}
                return false;
            }
        }

        /// <summary>
        /// Inserts details for Products.
        /// Saves newly created Id in ProductId.
        /// </summary>
        /// <returns>True if Insert operation is successful; Else False.</returns>
        private bool Insert(Product product)
        {
            try
            {
                DbCommand com = this.db.GetStoredProcCommand("ProductsInsert");
                db.AddOutParameter(com, "ProductId", DbType.Int32, 1024);
                if (!String.IsNullOrEmpty(product.Name))
                {
                    db.AddInParameter(com, "ProductName", DbType.String, product.Name);
                }
                else
                {
                    db.AddInParameter(com, "ProductName", DbType.String, DBNull.Value);
                }
                 //   db.AddInParameter(com, "IsActive", DbType.Boolean, product.Name);
                if (product.ProductCategoriesId != 0)
                {
                    db.AddInParameter(com, "ProductCategoriesId", DbType.Int32, product.ProductCategoriesId);
                }
                else
                {
                    db.AddInParameter(com, "ProductCategoriesId", DbType.Int32, DBNull.Value);
                }
                if (!String.IsNullOrEmpty(product.CreatedBy))
                {
                    db.AddInParameter(com, "CreatedBy", DbType.String, product.CreatedBy);
                }
                else
                {
                    db.AddInParameter(com, "CreatedBy", DbType.String, DBNull.Value);
                }
                if (product.ProductPrice !=0 )
                {
                    db.AddInParameter(com, "price", DbType.Int32, product.ProductPrice);
                }
                else
                {
                    db.AddInParameter(com, "price", DbType.Int32, DBNull.Value);
                }
                db.ExecuteNonQuery(com);
                product.ProductId = Convert.ToInt32(this.db.GetParameterValue(com, "ProductId"));      // Read in the output parameter value
            }
            catch (Exception ex)
            {
                // To Do: Handle Exception
                return false;
            }

            return product.ProductId > 0; // Return whether ID was returned
        }





        public List<Product> Search(string varName, string productCategory )
        {
         
            try
            {
                if (varName != null || productCategory != null)
                {
                    DbCommand cmd = this.db.GetStoredProcCommand("[ProductsGetList]");
                    this.db.AddInParameter(cmd, "@varName", DbType.String, varName);
                    this.db.AddInParameter(cmd, "@varproductCategory", DbType.String, productCategory);
                    DataSet ds = this.db.ExecuteDataSet(cmd);
                    foreach (DataRow Row in ds.Tables[0].Rows)
                    {
                        list.Add(new Product
                        {
                            Name = (Row["Name"]).ToString(),
                            ProductCategory = (Row["ProductCategory"]).ToString(),
                            ProductPrice = Convert.ToInt32(Row["ProductPrice"])                    
                        }
                     );
                    }
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

        public List<Product> GetList()
        {
            DataSet ds = null;
            try
            {
                DbCommand com = db.GetStoredProcCommand("ProductsGetList");
                ds = db.ExecuteDataSet(com);
                foreach (DataRow Row in ds.Tables[0].Rows)
                {
                    list.Add(new Product
                    {
                        ProductId = Convert.ToInt32(Row["ProductId"]),
                        Name = (Row["Name"]).ToString(),
                        ProductCategory = (Row["ProductCategory"]).ToString(),                    
                        ProductPrice = Convert.ToInt32(Row["ProductPrice"])

                    });
                }
                    return list;
                }
            catch (Exception ex)
            {
                //To Do: Handle Exception
                Debug.WriteLine(ex.StackTrace);
            }

            return list;
        }

    }
}

using Microsoft.Practices.EnterpriseLibrary.Data;
using ProductCategoriesModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayeProductCategories
{
    public class DataLayeCategories
    { 
        private Database db;
        ProductCategories productCategories = new ProductCategories();
        List<ProductCategories> list = new List<ProductCategories>();

        public DataLayeCategories()
        {
            this.db = DatabaseFactory.CreateDatabase();
        }

        public List<ProductCategories> GetList()
        {
            DataSet ds = null;
            try
            {
                DbCommand com = db.GetStoredProcCommand("[ProductCategoriesGetList]");
                ds = db.ExecuteDataSet(com);
                foreach (DataRow Row in ds.Tables[0].Rows)
                {
                    list.Add(new ProductCategories
                    {
                        ProductCategoriesId = Convert.ToInt32(Row["ProductCategoriesId"]),
                        Name = (Row["Name"]).ToString()                

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

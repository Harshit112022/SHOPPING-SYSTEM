using ProductCategoriesModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductModel
{
    public class Product
    {

        public int ProductId
        {
            get; set;
        }
        public string Name
        {
            get; set;
        }
        public string ProductCategory
        {
            get; set;
        }

        public int ProductPrice
        {
            get; set;
        }
        public string CreatedBy
        {
            get; set;
        }
        public int ProductCategoriesId
        {
            get; set;
        }
  
        public List<ProductCategories> ProductCategoriesList { get; set;}
     
    }
}

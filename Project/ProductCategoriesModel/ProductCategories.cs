using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCategoriesModel
{

    public class ProductCategories
    {

        public int ProductCategoriesId
        {
            get; set;
        }
        public string Name
        {
            get; set;
        }
        public int IsActive
        {
            get; set;
        }

        public string CreatedBy
        {
            get; set;
        }
        public string LastModifiedBy
        {
            get; set;
        }
        public string LastModifiedOn
        {
            get; set;
        }
    }

}

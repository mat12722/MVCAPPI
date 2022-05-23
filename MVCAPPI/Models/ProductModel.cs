using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCAPPI.Models
{
    public class ProductModel
    {
        [Display(Name = "Code")]
        [Required(ErrorMessage = "You need to give a Product Code")]
        [StringLength(50)]
        public string Code { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "You need to give a Name")]
        [StringLength(255)]
        public string Name { get; set; }

        [Display(Name = "Description")]
        [StringLength(4000)]
        public string Description { get; set; }

        //[Range(0.01,999999,ErrorMessage ="You entered valid Price")]
        //[DataType(DataType.Currency)]
        [Display(Name="Price")]
        [Range(typeof(decimal),"0,01", "999999,0", ErrorMessage = "You entered valid Price")]
        [Required(ErrorMessage ="You need to give a price")]
        public decimal Price { get; set; }

        [Display(Name = "Category Id")]
        [Range(1, 4, ErrorMessage = "You entered valid Category_Id")]
        [Required(ErrorMessage = "You need to give a Category_Id")]
        public int Category_Id { get; set; }
    }
}
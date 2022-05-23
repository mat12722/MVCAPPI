using DataLibrary.DataAccess;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.BusinessLogic
{
    public class ProductProcessor
    {
        public static int CreateProduct(string code,string name, string description,decimal price,int category_Id)
        {
            ProductModel data = new ProductModel
            {
                Code = code,
                Name = name,
                Description = description,
                Price = price,
                Category_Id=category_Id
            };
            string sql = @"insert into dbo.Product (Code,Name,Description,Price,Category_Id) values (@Code,@Name,@Description,@Price,@Category_Id);";
            return SqlDataAccess.SaveData(sql, data);
        }
        public static List<ProductModel> LoadProducts()
        {
            string sql = @"select Id, Code, Name,Description,Price,Category_Id from dbo.Product;";
            return SqlDataAccess.LoadDtata<ProductModel>(sql);
        }
        public static int DeleteProduct(string code)
        {
            ProductModel data = new ProductModel
            {
                Code=code
            };
            string sql = @"DELETE FROM dbo.Product WHERE Code=@Code;";
            return SqlDataAccess.DeleteData(sql,data);
        }
        public static int UpdateProduct(string code, string name, string description, decimal price, int category_Id)
        {
            ProductModel data = new ProductModel
            {
                Code = code,
                Name = name,
                Description = description,
                Price = price,
                Category_Id = category_Id
            };
            string sql = @"update dbo.Product set Code=@Code,Name=@Name,Description=@Description,Price=@Price,Category_Id=@Category_Id where Code=@Code;";
            return SqlDataAccess.UpdateData(sql, data);
        }
    }
}

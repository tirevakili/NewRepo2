using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayaTejaratDto.Options.API
{
    public class APIs
    {
        public const string BaseUrl = "https://api.tekegah.com/";
        //https://localhost:44365/
        //https://api.tekegah.com/
        #region Product
        public const string GetArticleID = "GetArticleID/";
        public const string UpdateArticle = "UpdateArticle/";
        public const string GetAllCategoryArticleID = "GetAllCategoryArticle";    
        public const string GetAllArticleID = "GetAllCateGoryArticleID";
        public const string GetArticleCategory = "GetAllCateGoryArticleID";        
        public const string GetCategoryArticleID = "GetCategoryArticleID/";
        public const string UpdateArticleCategoryID = "UpdateArticleCategory/";        
        public const string GetProductID = "api/Product/GetProductID/";     
        public const string AddProduct = "api/Product";
        public const string DeleteProduct = "DeleteProduct/";
        public const string AddArticle = "AddArticle";
        public const string PutProduct = "UpdateProduct/";      
        public const string GetAllProduct = "api/Product/GetIsNonProductAsync";
        public const string GetNonProduct = "api/Product/GetAllDeletedProductAsync";
        public const string GetCountProductAsync = "api/Product/GetCountProductAsync";
        public const string GetNonCountProductAsync = "api/Product/GetNonCountProductAsync";
        public const string AuthenticationUser = "AuthenticationUser";
        public const string RegisterUser = "RegisterUser";
        public const string UploadProductImageOne = "api/Attachment/UploadImageProductOne";
        #endregion

        #region Version
        public const string GetVersion = "api/Base/GetVersion";
        public const string UpdateVersion = "api/Base/UpdateVersion";
        #endregion

        #region Debug
        public const string GetDebug = "GetDebugAsync";
        #endregion

        #region ProductDeitles
        public const string GetProductDeitels = "GetAllProductDetiles";
        public const string AddProductDeitels = "AddProductDeitles";
        public const string GetProductDetilesID = "GetProductDetilesID";
        public const string UpdateProductDeitlesID = "UpdateProductDeitles";
        public const string DeleteProductDeitlesID = "DeleteProductDeitles";

        #endregion

        #region Users
        public const string Authentication = "Login";
        #endregion

        #region Complaint
        public const string AddComplaint = "api/Base/AddComplaint";
        public const string GetComplaintID = "api/Base/GetComplaintID";
        public const string GetAllComplaint = "api/Base/GetAllComplaint";
        #endregion

    }
}

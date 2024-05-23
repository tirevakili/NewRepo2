using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using ImageMagick;
using SystemFile = System.IO.File;
using MimeTypes;
using Microsoft.AspNetCore.Authorization;
using TakGhahCore.Repostiory;
using TakGhahCore.Service;
using TakGhahCore.UOF;

namespace GhorfeDar.Server.Api.Controllers;
//[Authorize]
[Route("api/[controller]/[action]")]
[ApiController]

public partial class AttachmentController : ControllerBase
{
    private IUserService _userServices;
    private UnitOfWork _unit;
    private IWebHostEnvironment _webHostEnvironment;

    public AttachmentController(IUserService userServices, IWebHostEnvironment webHostEnvironment, UnitOfWork unit)
    {
        _unit = unit;
        _userServices = userServices;
        _webHostEnvironment = webHostEnvironment;
    }





    #region UploadImageArticle
    [HttpPost("{productID}")]
    [RequestSizeLimit(11 * 2024 * 2024 /*11MB*/)]
    public async Task UploadImageArticle([FromRoute] int productID, IFormFile? file, CancellationToken cancellationToken)
    {
        if (file is null)
            throw new();

        var product = _unit.GetArticleName(productID);

        if (product is null)
            throw new();

        var destFileName = $"{product}_{file.FileName}";

        var userProfileImagesDir = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/ArticleImage");

        var destFilePath = Path.Combine(userProfileImagesDir, destFileName);

        await using (var requestStream = file.OpenReadStream())
        {
            Directory.CreateDirectory(userProfileImagesDir);

            await using var fileStream = SystemFile.Create(destFilePath);

            await requestStream.CopyToAsync(fileStream, cancellationToken);

        }

        if (product is not null)
        {
            try
            {
                var oldFilePath = Path.Combine(userProfileImagesDir, product.Images!);

                if (SystemFile.Exists(oldFilePath))
                {
                    SystemFile.Delete(oldFilePath);
                }
            }
            catch
            {
                // not important
            }
        }

        destFileName = destFileName.Replace(Path.GetExtension(destFileName), "_256.webp");
        var resizedFilePath = Path.Combine(userProfileImagesDir, destFileName);

        try
        {
            //if (!SystemFile.Exists(product.Images))
            // SystemFile.Delete(product!.Images!);

            using MagickImage sourceImage = new(destFilePath);

            MagickGeometry resizedImageSize = new(500, 500);

            sourceImage.Resize(resizedImageSize);

            using (MagickImage image2 = new(destFilePath))
            {
                new Drawables()

                .FontPointSize(18)
                .Font("tahoma", FontStyleType.Italic, FontWeight.Bold, FontStretch.ExtraExpanded)
                .StrokeColor(MagickColors.Black)
                .FillColor(MagickColors.White)
                .TextAlignment(TextAlignment.Center)

                .Text(150, 50, "TekeGah\nتک گاه")
                .Draw(image2);
                image2.Write(resizedFilePath, MagickFormat.WebP);
            }

            //sourceImage.Write(resizedFilePath, MagickFormat.WebP);

            //var proimage = new ProductImage
            //{
            //    Images = destFileName,
            //    Product_ID = productID,               
            //};

            SystemFile.Delete(destFilePath);
            await _unit.UpdateArticleImage(productID, destFileName);
        }
        catch
        {
            //if (SystemFile.Exists(resizedFilePath))
            // SystemFile.Delete(resizedFilePath);

            throw;
        }
        finally
        {
            //SystemFile.Delete(destFilePath);
        }
    }

    [HttpPost("UploadImageArticleOne/{productID}")]
    [RequestSizeLimit(11 * 2024 * 2024 /*11MB*/)]
    public async Task UploadImageArticleOne([FromRoute] int productID, IFormFile? file, CancellationToken cancellationToken)
    {
        if (file is null)
            throw new();

        var product = _unit.GetArticleName(productID);

        //if (product is null)
        //    throw new();

        var destFileName = $"{product}_{file.FileName}";

        var userProfileImagesDir = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/ProductImage");

        var destFilePath = Path.Combine(userProfileImagesDir, destFileName);

        await using (var requestStream = file.OpenReadStream())
        {
            Directory.CreateDirectory(userProfileImagesDir);

            await using var fileStream = SystemFile.Create(destFilePath);

            await requestStream.CopyToAsync(fileStream, cancellationToken);

        }



        destFileName = destFileName.Replace(Path.GetExtension(destFileName), "_256.webp");
        var resizedFilePath = Path.Combine(userProfileImagesDir, destFileName);

        try
        {
            //if (!SystemFile.Exists(product.Images))
            // SystemFile.Delete(product!.Images!);

            using MagickImage sourceImage = new(destFilePath);

            MagickGeometry resizedImageSize = new(500, 500);

            sourceImage.Resize(resizedImageSize);
            using (MagickImage image2 = new(destFilePath))
            {
                new Drawables()

                .FontPointSize(18)
                .Font("tahoma", FontStyleType.Italic, FontWeight.Bold, FontStretch.ExtraExpanded)
                .StrokeColor(MagickColors.Black)
                .FillColor(MagickColors.White)
                .TextAlignment(TextAlignment.Center)

                     .Text(150, 50, "TekeGah\nتک گاه")
                .Draw(image2);
                image2.Write(resizedFilePath, MagickFormat.WebP);
            }

            var proimage = new DataLayer.Entities.Articles.ArticleImage
            {
                 Images= destFileName,
                Article_ID = productID,
            };

            SystemFile.Delete(destFilePath);

            _userServices.AddArticleImage(proimage);
        }
        catch
        {
            //if (SystemFile.Exists(resizedFilePath))
            // SystemFile.Delete(resizedFilePath);

            throw;
        }
        finally
        {
            //SystemFile.Delete(destFilePath);
        }
    }
    #endregion


    #region UploadImageCategoryArticle
    [HttpPost("{categoryID}")]
    [RequestSizeLimit(11 * 2024 * 2024 /*11MB*/)]
    public async Task UploadImageCategoryArticle([FromRoute] int categoryID, IFormFile? file, CancellationToken cancellationToken)
    {
        if (file is null)
            throw new();

        var category = _unit.FindCategoryArticleID(categoryID);

        if (category is null)
            throw new();

        var destFileName = $"{category}_{file.FileName}";

        var userProfileImagesDir = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/ArticleImage");

        var destFilePath = Path.Combine(userProfileImagesDir, destFileName);

        await using (var requestStream = file.OpenReadStream())
        {
            Directory.CreateDirectory(userProfileImagesDir);

            await using var fileStream = SystemFile.Create(destFilePath);

            await requestStream.CopyToAsync(fileStream, cancellationToken);
        }

        if (category.ImageArticlesCategory is not null)
        {
            try
            {
                var oldFilePath = Path.Combine(userProfileImagesDir, category.ImageArticlesCategory);

                if (SystemFile.Exists(oldFilePath))
                {
                    SystemFile.Delete(oldFilePath);
                }
            }
            catch
            {
                // not important
            }
        }

        destFileName = destFileName.Replace(Path.GetExtension(destFileName), "_256.webp");
        var resizedFilePath = Path.Combine(userProfileImagesDir, destFileName);

        try
        {
            using MagickImage sourceImage = new(destFilePath);

            MagickGeometry resizedImageSize = new(1000, 1000);

            sourceImage.Resize(resizedImageSize);

            sourceImage.Write(resizedFilePath, MagickFormat.WebP);

            category.ImageArticlesCategory = destFileName;

            await _userServices.UpdateArticlesCategory(categoryID, category);
        }
        catch
        {
            if (SystemFile.Exists(resizedFilePath))
                SystemFile.Delete(resizedFilePath);

            throw;
        }
        finally
        {
            SystemFile.Delete(destFilePath);
        }
    }
    #endregion

    #region GetImageCategoryArticle

    [HttpGet("{categoryID}")]
    public async Task<IActionResult> GetImageCategoryArticle([FromRoute] int categoryID)
    {
        var category = _unit.FindCategoryArticleID(categoryID);



        if (category?.ImageArticlesCategory is null)
            throw new();

        var userProfileImageDirPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/ArticleImage");

        var filePath = Path.Combine(userProfileImageDirPath, category.ImageArticlesCategory);

        if (SystemFile.Exists(filePath) is false)
            return new EmptyResult();

        return PhysicalFile(Path.Combine(_webHostEnvironment.ContentRootPath, filePath),
            MimeTypeMap.GetMimeType(Path.GetExtension(filePath)), enableRangeProcessing: true);
    }
    #endregion

    #region RemoveImageCategoryArticle

    [HttpDelete("{categoryID}")]
    public async Task RemoveImageCategoryArticle([FromRoute] int categoryID)
    {
        var category = _unit.FindCategoryArticleID(categoryID);



        if (category?.ImageArticlesCategory is null)
            throw new();

        var userProfileImageDirPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/ArticleImage");

        var filePath = Path.Combine(userProfileImageDirPath, category.ImageArticlesCategory);

        if (SystemFile.Exists(filePath) is false)
            throw new();

        category.ImageArticlesCategory = null;

        await _userServices.UpdateArticlesCategory(categoryID, category);

        SystemFile.Delete(filePath);
    }
    #endregion

}

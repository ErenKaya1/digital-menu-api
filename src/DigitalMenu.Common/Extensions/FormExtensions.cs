using System.IO;
using Microsoft.AspNetCore.Http;

namespace DigitalMenu.Common.Extensions
{
    public static class FormExtensions
    {
        public static bool IsImage(this IFormFile file)
        {
            switch (Path.GetExtension(file.FileName).ToLower())
            {
                case ".png":
                case ".jpg":
                case ".jpeg":
                case ".jfif":
                case ".gif":
                case ".tiff":
                case ".pjp":
                case ".svg":
                case ".bmp":
                case ".webp":
                case ".ico":
                case ".tif":
                case ".avif":
                    return true;
                default:
                    return false;
            }
        }
    }
}
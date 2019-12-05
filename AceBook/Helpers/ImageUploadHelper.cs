using System;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace AceBook.Helpers
{
    public class ImageUploadHelper
    {

        public static string ImageToBase64(IFormFile image)
        {
            using (var ms = new MemoryStream())
            {
                image.CopyTo(ms);
                string base64 = Convert.ToBase64String(ms.ToArray());

                Console.WriteLine("Base64: " + "data:image/gif;base64," + base64);

                return "data:image/gif;base64," + base64;
            }
        }
    }
}

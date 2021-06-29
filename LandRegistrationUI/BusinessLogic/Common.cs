using Microsoft.AspNetCore.Http;
using System.IO;

namespace LandRegistrationUI.BusinessLogic
{
    public class Common
    {
        public static byte[] GetBytes(IFormFile formFile)
        {
            using (var memoryStream = new MemoryStream())
            {
                formFile.CopyToAsync(memoryStream);
                return memoryStream.ToArray();
            }
        }
    }
}
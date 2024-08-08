namespace PhoneBook.Api.Extensions
{
    public static class FormFileExtensions
    {
        public static async Task<byte[]> GetFileBytesAsync(this IFormFile formFile)
        {
            byte[] photoBytes = null;
            using (var memoryStream = new MemoryStream())
            {
                await formFile.CopyToAsync(memoryStream);
                photoBytes = memoryStream.ToArray();
            }

            return photoBytes;
        }
    }
}

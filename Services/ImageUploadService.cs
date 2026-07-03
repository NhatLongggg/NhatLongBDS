namespace DKRSLandingPage_WebApp.Services;

public class ImageUploadService
{
    public async Task<string?> UploadAsync(
        IFormFile? file,
        string folderName)
    {
        if (file == null || file.Length == 0)
            return null;

        var folder = Path.Combine(
            Directory.GetCurrentDirectory(),
            "wwwroot",
            "images",
            folderName);

        if (!Directory.Exists(folder))
            Directory.CreateDirectory(folder);

        var fileName = Guid.NewGuid() +
                       Path.GetExtension(file.FileName);

        var filePath = Path.Combine(folder, fileName);

        using var stream = new FileStream(filePath, FileMode.Create);

        await file.CopyToAsync(stream);

        return "/images/" + folderName + "/" + fileName;
    }
}
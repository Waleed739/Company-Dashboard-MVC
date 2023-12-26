namespace PL.Helper
{
    static class DocumentSettings
    {
        //4Steps
        public static string UploadFile(IFormFile file,string FolderName)
        {
            //1- Get the laocation of the Folder
            var FolderPath=Path.Combine(Directory.GetCurrentDirectory(), "~/Files",FolderName);

            //2- Get File Name and make it unique
            var _FileName = $"{Guid.NewGuid()}{Path.GetFileName(file.FileName)}";

            //3- Get File Path
            var _FilePath= Path.Combine(FolderName, _FileName);

            //4- 
            using var fileStream = new FileStream(_FilePath,FileMode.Create);

            file.CopyTo(fileStream);

            return _FileName;

        }
    }
}

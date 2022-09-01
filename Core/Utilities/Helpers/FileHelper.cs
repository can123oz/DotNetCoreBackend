using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers
{
    public class FileHelper
    {
        private static string _currentFileDirectory = Environment.CurrentDirectory + "\\wwwroot";
        private static string _folderName = "\\uploads\\";


        public static IResult Add(IFormFile file)
        {
            var fileExist = CheckFileExist(file);
            if (fileExist.Message != null)
            {
                return new ErrorResult(fileExist.Message);
            }
            var type = Path.GetExtension(file.FileName);
            var typeValid = CheckFileTypeValid(type);

            if (!typeValid.Success)
            {
                return new ErrorResult(typeValid.Message);
            }

            var randomName = Guid.NewGuid().ToString();
            CheckFileDirectoryExist(_currentFileDirectory + _folderName);
            CreateImageFile((_currentFileDirectory + _folderName + randomName + type), file);
            return new SuccessResult((_folderName + randomName + type).Replace("\\", "/"));
        }

        public static IResult Update(string imagePath, IFormFile file)
        {
            var fileExist = CheckFileExist(file);
            if (fileExist.Message != null)
            {
                return new ErrorResult(fileExist.Message);
            }
            var type = Path.GetExtension(file.FileName);
            var typeValid = CheckFileTypeValid(type);

            if (!typeValid.Success)
            {
                return new ErrorResult(typeValid.Message);
            }

            var randomName = Guid.NewGuid().ToString();

            DeleteOldImageFile((_currentFileDirectory + imagePath).Replace("/", "\\"));
            CheckFileDirectoryExist(_currentFileDirectory + _folderName);
            CreateImageFile((_currentFileDirectory + _folderName + randomName + type), file);

            return new SuccessResult((_folderName + randomName + type).Replace("\\", "/"));
        }

        public static IResult Delete(string path)
        {
            DeleteOldImageFile((_currentFileDirectory + path).Replace("\\", "/"));
            return new SuccessResult();
        }

        //Verification Methods

        private static IResult CheckFileTypeValid(string type)
        {
            if (type != ".jpg" && type != ".png" && type != ".jpeg")
            {
                return new ErrorResult("Wront File Type");
            }
            return new SuccessResult();
        }

        private static IResult CheckFileExist(IFormFile file)
        {
            if (file.Length > 0 && file != null)
            {
                return new SuccessResult();
            }
            return new ErrorResult("File is not exist");
        }

        private static void DeleteOldImageFile(string directory)
        {
            if (File.Exists(directory.Replace("/", "\\")))
            {
                File.Delete(directory.Replace("/", "\\"));
            }
        }

        private static void CreateImageFile(string directory, IFormFile file)
        {
            using (FileStream fs = File.Create(directory))
            {
                file.CopyTo(fs);
                fs.Flush();
            }
        }

        private static void CheckFileDirectoryExist(string directory)
        {
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }

    }
}

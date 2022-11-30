using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_ICS_ClassLibrary.Interfaces
{
    public interface IFileAccessServices
    {
        bool SaveFile(string destinationPath, bool overwriteExisting);
        bool DeleteFile(string pathOfFileToDelete);
        bool CreateFolder(string pathToFolder);

    }
}

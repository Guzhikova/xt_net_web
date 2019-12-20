using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5Files
{
    class BackupsControl 
    {


        //public Dictionary<DateTime, List<FileData>> GetDictionaryFromJson()
        //{
        //    BackupsLog backupsLog = new BackupsLog();

        //    JsonAdapter jsonAdapter = new JsonAdapter();
        //    BackupFolder mainFloder = new BackupFolder();
        //    try
        //    {
        //        backupsLog = jsonAdapter.ReadFromJsonFile<BackupsLog>($"{mainFloder.Info.FullName}\\Log.json");
        //    }
        //    catch(Exception ex)
        //    {
        //        Console.WriteLine("The process failed: {0}{1}{2}", ex.Message, Environment.NewLine, ex.StackTrace);
        //    }
        //    return backupsLog.BackupsLogDictionary;
        //}

        //public void AddChangeToDictionary(DateTime date, List<FileData> files)
        //{
        //    BackupsLog backupsLog = new BackupsLog();
        //    if (backupsLog.BackupsLogDictionary == null)
        //    {
        //        //может в конструктор??

        //        backupsLog.BackupsLogDictionary = new Dictionary<DateTime, List<FileData>>();
        //    }

        //    backupsLog.BackupsLogDictionary.Add(date, files);

        //}


    }
}

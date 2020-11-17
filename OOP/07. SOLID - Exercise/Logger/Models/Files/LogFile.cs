using System;
using System.IO;
using System.Linq;
using System.Globalization;

using Logger.Models.Contracts;
using Logger.Models.Enumerations;
using Logger.Models.IIOManagement;
using Logger.Common;

namespace Logger.Models.Files
{
    public class LogFile : IFile
    {
        private IOManager IOManaer;
        public LogFile(string folderName, string fileName)
        {
            this.IOManaer = new IOManager(folderName, fileName);

            this.IOManaer.EnsureDirectoryAndFileExists();
        }
        public string Path => this.IOManaer.CurrentFilePath;

        public long Size => this.GetFileSize();

        public string Write(ILayout layout, IError error)
        {
            string format = layout.Format;

            DateTime datetime = error.DateTime;
            string message = error.Message;
            Level level = error.Level;

            string formattedMessage = string.Format(format,
                datetime.ToString(GlobalConstants.DATE_FORMAT, CultureInfo.InvariantCulture), message, level.ToString()) + Environment.NewLine;

            return formattedMessage;
        }

        private long GetFileSize()
        {
            string text = File.ReadAllText(this.Path);

            long size = text
                .Where(ch => Char.IsLetter(ch))
                .Sum(ch => ch);

            return size;
        }
    }
}

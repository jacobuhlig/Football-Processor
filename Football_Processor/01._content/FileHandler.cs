namespace Football_Processor
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class FileHandler
    {
        private readonly FileInfo _file;
        private StreamReader _reader;
        private readonly List<string> _headers = new List<string>();
        private string _splitVar = ",";

        public FileHandler(string filePath)
        {
            _file = new FileInfo(filePath);

            try
            {
                _reader = new StreamReader(_file.FullName);
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private string GetFilename()
        {
            return _file.Name.Contains(".") ? _file.Name.Split('.')[0] : _file.Name;
        }
    }
}

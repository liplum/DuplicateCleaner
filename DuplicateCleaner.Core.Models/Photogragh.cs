using Prism.Mvvm;


namespace DuplicateCleaner.Core.Models
{
    public class Photogragh : BindableBase
    {
        public Photogragh(string path)
        {
            Path = path;
            FileName = Path.Split("\\")[^1];
        }

        private string _fileName;
        public string FileName
        {
            get
            {
                return _fileName;
            }
            init
            {
                SetProperty(ref _fileName, value);
            }
        }

        private string _path;
        public string Path
        {
            get
            {
                return _path;
            }
            init
            {
                SetProperty(ref _path, value);
            }
        }

        public override int GetHashCode()
        {
            return _path.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj is Photogragh p2)
            {
                return string.Equals(_path, p2.Path);
            }
            return false;
        }

    }
}

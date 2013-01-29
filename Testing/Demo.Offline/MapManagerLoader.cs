using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using GMap.NET;

namespace Demo.Offline
{
    public class MapManagerLoader
    {
        private static readonly MapManagerLoader _instance = new MapManagerLoader();

        public static MapManagerLoader Instance
        {
            get { return _instance; }
        }

        private MapManagerLoader()
        {
        }

        private bool _isLoaded;

        public bool Load(string fileName)
        {
            if (!_isLoaded)
            {
                new Thread(() => GMaps.Instance.ImportFromGMDB(fileName)).Start();
                _isLoaded = true;
            }
            return _isLoaded;
        }
    }
}

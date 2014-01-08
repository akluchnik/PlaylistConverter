using System;
using System.Collections.Generic;
using System.Text;

namespace PlaylistConverter
{
    /// <summary>
    /// Class for writing data to mpcpl format
    /// </summary>
    class MpcWriter : Writer
    {
        public MpcWriter(string path) : base(path) { }

        public override void WriteHeader()
        {
            f.WriteLine("MPCPLAYLIST");
        }

        public override void WriteItem(int index, string caption, string URL)
        {
            f.WriteLine(string.Format("{0},type,0", index));
            f.WriteLine(string.Format("{0},label,{1}", index, caption));
            f.WriteLine(string.Format("{0},filename,{1}", index, URL));
            Console.WriteLine(string.Format("Item {0}: {1}, {2}", index, caption, URL));
        }
    }
}

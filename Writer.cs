using System;
using System.Collections.Generic;
using System.Text;

namespace PlaylistConverter
{
    abstract class Writer:IDisposable
    {
        protected System.IO.TextWriter f;

        public Writer(string path)
        {
            f = new System.IO.StreamWriter(path);
        }

        public virtual void WriteHeader()  { }

        public abstract void WriteItem(int index, string caption, string URL);

        public virtual void WriteFooter() { }

        public void Dispose()
        {
            f.Close();
        }        
    }
}

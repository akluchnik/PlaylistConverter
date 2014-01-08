using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Xml;

namespace PlaylistConverter
{
    class Program
    {
        const string DEFAULT_OUTPUT_PATH = @"playlist.mpcpl";
        const string DEFAULT_XML_PATH = @"http://itv.fregat.net/playlist/default.xml";
        
        static void Main(string[] args)
        {
            string OutputPath = DEFAULT_OUTPUT_PATH;
            string XMLPath = DEFAULT_XML_PATH;
            
            if (args.Length >= 2)
                OutputPath = args[1];
            if (args.Length >= 3)
                XMLPath = args[2];

            Console.WriteLine(string.Format("Getting XML from {0}", XMLPath));
            XmlReader reader = XmlReader.Create(XMLPath);

            Console.WriteLine(string.Format("Creating output file {0}", OutputPath));
            Writer w = new MpcWriter(OutputPath);

            Console.WriteLine("Writing file header");
            w.WriteHeader();

            Console.WriteLine("Writing file content");
            int index=1;
            while (reader.ReadToFollowing("channel"))
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    reader.ReadToFollowing("title");
                    string name = reader.ReadString();
                    reader.ReadToFollowing("stream_url");
                    string url = reader.ReadString();
                    w.WriteItem(index++, name, url);
                }
            }
            Console.WriteLine("Writing footer");
            w.WriteFooter();
            Console.WriteLine("Finished");
            w.Dispose();
        }
    }



    
}

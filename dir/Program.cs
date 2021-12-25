using System;
using System.IO;
using System.Linq;
using System.Text;

namespace dir
{
    class Program
    {
        static readonly (FileAttributes, string)[] flags = new (FileAttributes, string)[] {
            (FileAttributes.Directory, "d"), (FileAttributes.ReadOnly, "r"),
            (FileAttributes.Archive, "a"), (FileAttributes.Hidden, "h")
        };

        static void Main()
        {
            while (true)
            {
                try
                {
                    Console.Write("path: ");
                    var path = Console.ReadLine();

                    var items =
                        Directory.EnumerateFileSystemEntries(path).Select<string, FileSystemInfo>(
                            p => Directory.Exists(p) ? new DirectoryInfo(p) : new FileInfo(p));
                    foreach (var fsi in items)
                    {
                        foreach (var (flag, alias) in flags)
                        {
                            Console.Write(fsi.Attributes.HasFlag(flag) ? alias : "-");
                        }
                        Console.WriteLine("  {0}  {1}", fsi.CreationTime, fsi.FullName);
                    }
                }
                catch
                {
                }
            }
        }
    }
}

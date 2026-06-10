using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Demo
{
    internal class DirectoryBase
    {

        public string Name { get; private set; }

        public string FullPath => System.IO.Path.Combine(Parent?.FullPath ?? "", Name);

        public DirectoryBase Parent { get; internal set; }

        public DirectoryBase(string name)
        {
            Name = name;
        }

        public void Create()
        {
            if (!Directory.Exists(FullPath))
            {
                Directory.CreateDirectory(FullPath);
            }
        }
    }


    internal class ConfigDirectory : DirectoryBase
    {


        public ConfigDirectory(DirectoryBase parent) : base("Config")
        {
            Parent = parent;
        }
    }

    internal class WorkspaceDirectory : DirectoryBase
    {

        public DateDirectory Date { get; private set; }

        public WorkspaceDirectory(DirectoryBase parent) : base("Workspace")
        {
            Parent = parent;
            Date = new DateDirectory(this);
        }
    }

    internal class DateDirectory : DirectoryBase
    {
        public DateDirectory(DirectoryBase parent) : base(DateTime.Now.ToString("yyyyMMddHHmmss"))
        {
            Parent = parent;
        }
    }

    internal class RootDirectory : DirectoryBase
    {
        public ConfigDirectory Config { get; private set; }
        public WorkspaceDirectory Workspace { get; private set; }

        public RootDirectory(string name) : base(name)
        {
            Config = new ConfigDirectory(this);
            Workspace = new WorkspaceDirectory(this);
        }


    }
}

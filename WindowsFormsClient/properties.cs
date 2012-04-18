using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace WindowsFormsClient
{
    public static class properties
    {
        public static string errorMessage;
        public static string tags;
        public static string filename;
        public static string nameSpace;
        public static string guid;
        public static string moreOption;
        public static string info;
        public static string stacktrace;
        public static string version;
        public static string os;
        public static string userId;
        public static string group;
        public static string output;
        public static string projectTitle;

        //public properties()
        //{
        //    errorMessage = "";
        //    tags = "";
        //    filename = "";
        //    nameSpace = "";
        //    guid = "";
        //    moreOption = "";
        //    info = "";
        //    stacktrace = "";
        //    version = "";
        //    os = "";
        //    userId = "";
        //    group = "";
        //    output = "";
        //}

        public static void init(string error, string tgs)
        {
            errorMessage = error;
            tags = tgs;
            filename = Assembly.GetEntryAssembly().GetTypes()[0].Name; 
            nameSpace = Assembly.GetEntryAssembly().GetTypes()[0].Namespace;
            guid = Assembly.GetEntryAssembly().GetTypes()[0].GUID.ToString();
            moreOption = "0";

            object[] attributes = Assembly.GetEntryAssembly().GetCustomAttributes(true);
            foreach (object o in attributes)
            {
                if (o is AssemblyDescriptionAttribute)
                {
                    info = ((AssemblyDescriptionAttribute)o).Description;
                }
                else if (o is AssemblyTitleAttribute)
                {
                    projectTitle = ((AssemblyTitleAttribute)o).Title;
                }
                else if (o is AssemblyFileVersionAttribute)
                {
                    version = ((AssemblyFileVersionAttribute)o).Version;
                }
            }
            //info = appinfo;
            //version = Environment.Version.ToString();
            stacktrace = Environment.StackTrace;
            os = Environment.OSVersion.VersionString;
            userId = Environment.UserName;
            group = Environment.UserDomainName;
            output = Environment.CommandLine;
        }

        //public string ErrorMessage
        //{
        //    get { return errorMessage; }
        //    set { errorMessage = value; }
        //}

        //public string Tags
        //{
        //    get { return tags; }
        //    set { tags = value; }
        //}
        //public string Filename
        //{
        //    get { return filename; }
        //    set { filename = value; }
        //}
        //public string Namespace
        //{
        //    get { return nameSpace; }
        //    set { nameSpace = value; }
        //}
        //public string Guid
        //{
        //    get { return guid; }
        //    set { guid = value; }
        //}

        //public string Moreoption
        //{
        //    get { return moreOption; }
        //    set { moreOption = value; }
        //}
        //public string Info
        //{
        //    get { return info; }
        //    set { info = value; }
        //}
        //public string Stacktrace
        //{
        //    get { return stacktrace; }
        //    set { stacktrace = value; }
        //}
        //public string Version
        //{
        //    get { return version; }
        //    set { version = value; }
        //}
        //public string OS
        //{
        //    get { return os; }
        //    set { os = value; }
        //}
        //public string UserId
        //{
        //    get { return userId; }
        //    set { userId = value; }
        //}
        //public string Group
        //{
        //    get { return group; }
        //    set { group = value; }
        //}
        //public string Output
        //{
        //    get { return output; }
        //    set { output = value; }
        //}
    }
}

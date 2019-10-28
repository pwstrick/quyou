using System;
using System.Web;
using System.Xml;
using QuyouCore.Core.Domain;
using QuyouCore.Properties;

namespace QuyouCore.Core.DataAccess.Impl
{
    public class Connection
    {
        public Connection()
        {
            ConnString = GetCurrentConnectionString();
        }
        public ClubDataContext GetClubContext()
        {
            var vcd = new ClubDataContext(ConnString);
            //vcd.Log = new DebuggerWriter();
            return vcd;
        }
        public string GetCurrentConnectionString()
        {
            var connString = string.Empty;
            try
            {
                var doc = new XmlDocument();
                doc.Load(HttpContext.Current.Request.PhysicalApplicationPath + "bin/ConnectionStringToUse.xml");
                var xnl = doc.GetElementsByTagName("environment");
                var xe = (XmlElement)xnl[0];
                switch (xe.InnerText.ToLower())
                {
                    case "local":
                        connString = Settings.Default.ClubConnectionString;
                        break;
                    case "production":
                        connString = Settings.Default.ClubServerConnectionString;
                        break;
                    case "test":
                        connString = Settings.Default.ClubTestConnectionString;
                        break;
                }
            }
            catch (Exception e)
            {
                connString = Settings.Default.ClubTestConnectionString;
            }
            return connString;
        }

        public string ConnString
        {
            get;
            set;
        }
    }
}

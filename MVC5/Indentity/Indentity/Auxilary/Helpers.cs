using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Indentity.Auxilary
{
    public enum EnvironmentModes { Test, Production }


    public class Helpers
    {
        public static string EnvironmentConnection => (ConfigurationManager.AppSettings["EnvironmentMode"] == EnvironmentModes.Production.ToString() ? "ProductionConnection" : "DefaultConnection");
    }


}
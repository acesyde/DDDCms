using System.Reflection;

namespace DDDCms.Domain
{
    public static class DomainAssemblyHelper
    {
        public static Assembly Assembly => typeof(DomainAssemblyHelper).Assembly;
    }
}
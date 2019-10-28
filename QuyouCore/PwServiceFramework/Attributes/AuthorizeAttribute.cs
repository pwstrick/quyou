using System;
using System.Linq;
using System.Web;

namespace PwServiceFramework
{
    /// <summary>
    /// 用于验证用户身份的修饰属性
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public class AuthorizeAttribute : Attribute
    {
        private string _user;
        private string[] _users;
        private string _role;
        private string[] _roles;

        private string[] SplitString(string value)
        {
            if (string.IsNullOrEmpty(value))
                return null;
            return (from s in value.Split(',')
                        let u = s.Trim()
                        where u.Length > 0
                        select u).ToArray();
        }

        /// <summary>
        /// 允许访问的用户列表，用逗号分隔。
        /// </summary>
        public string Users
        {
            get { return _user; }
            set { _user = value; _users = SplitString(value); }
        }

        /// <summary>
        /// 允许访问的角色列表，用逗号分隔。
        /// </summary>
        public string Roles
        {
            get { return _role; }
            set { _role = value; _roles = SplitString(value); }
        }


        internal bool AuthenticateRequest(HttpContext context)
        {
            if (context.Request.IsAuthenticated == false)
                return false;

            if (_users != null && _users.Contains(context.User.Identity.Name, StringComparer.OrdinalIgnoreCase) == false)
                return false;

            if (_roles != null && _roles.Any(context.User.IsInRole) == false)
                return false;

            return true;
        }
    }
}

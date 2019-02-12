using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITNews
{
    public class AuthOptions
    {
        public const string DefaultIdClaimType = "id";
        public const string DefaultEmailClaimType = "email";
        public const string DefaultRoleClaimType = "role";

        public const string ISSUER = "ITNews";
        public const string AUDIENCE = "http://localhost:44355/";
        const string KEY = "78!9aksdugndhys_!264dgss4asdf8dsfs3asd7gaxcfy!q";
        public const int LIFETIME = 100;
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}

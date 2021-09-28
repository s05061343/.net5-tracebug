using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Filters
{
    public class TokenSettingAttribute : Attribute 
    {
        public TokenFrom TokenFrom { get; set; }
        public TokenSettingAttribute()
        {
            this.TokenFrom = TokenFrom.All;
        }
        public TokenSettingAttribute(TokenFrom tokenFrom)
        {
            this.TokenFrom = tokenFrom;
        }
    }
}
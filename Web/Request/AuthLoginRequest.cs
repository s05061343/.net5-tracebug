using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace Web.Request
{
    public class AuthLoginRequest
    {
        [Required]
        public string userId { get; set; }
        [Required]
        public string password { get; set; }
        public List<IFormFile> imageset { get; set; }
    }
}

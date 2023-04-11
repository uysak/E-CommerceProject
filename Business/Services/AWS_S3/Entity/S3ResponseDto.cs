using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.AWS_S3.Entity
{
    public class S3ResponseDto
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public string ObjectUrl { get; set; }
    }
}

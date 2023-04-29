using Business.Services.AWS_S3.Entity;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.AWS_S3.Abstract
{
    public interface IStorageService
    {
        public S3ResponseDto UploadFile(S3Object obj);
        public Task<IResult> DeleteFile(string objectKey);
    }
}

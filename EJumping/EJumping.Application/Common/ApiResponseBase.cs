using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace EJumping.Application.Common
{
    [DataContract(IsReference = true)]
    public class ApiResponseBase
    {
        public ApiResponseBase()
        {
            Errors = new List<object>();
        }
        [IgnoreDataMember]
        public bool HasError
        {
            get
            {
                if(Errors != null && Errors.Any())
                {
                    return true;
                }
                return false;
            }
        }
        [DataMember]
        public List<object> Errors { get; set; }
    }
    [DataContract]
    public class ApiResponse<T> : ApiResponseBase
    {
        public ApiResponse()
        {

        }
        public ApiResponse(T data)
        {
            Data = data;
        }
        [DataMember]
        public T Data { get; set; }
    }
}

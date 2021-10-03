using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EJumping.Domain.Infrastructure.MessageBrokers
{
    public class Message<T>
    {
        public MetaData MetaData { get; set; }
        public T Data { get; set; }
        public string SerializeObject()
        {
            return JsonConvert.SerializeObject(this);
        }
        public byte[] GetBytes()
        {
            return Encoding.UTF8.GetBytes(SerializeObject());
        }
    }
}

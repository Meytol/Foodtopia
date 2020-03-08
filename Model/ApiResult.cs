using System;
using Common.Model.Enum;
using Newtonsoft.Json;

namespace Common.Model
{
    public class ApiResult
    {
        public bool Success { get; set; }
        public MessageType MessageType { get; set; }
        public string Message { get; set; }
        public DateTime ResultDate { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Exception Exception { get; set; }
        public string Info { get; set; }

        public ApiResult()
        {
            ResultDate = DateTime.Now;
        }
    }
    public class ApiResult<T> : ApiResult
    {
        public T Data { get; set; }
        public ApiResult()
        {
            var type = typeof(T);
            var ctor = type.GetConstructor(Type.EmptyTypes);
            if (ctor != null)
            {
                Data = Activator.CreateInstance<T>();
            }
        }
        public ApiResult(ApiResult apr)
        {
            var type = typeof(T);
            var ctor = type.GetConstructor(Type.EmptyTypes);

            if (ctor != null)
            {
                Data = Activator.CreateInstance<T>();
            }

            this.Success = apr.Success;
            this.Info = apr.Info;
            this.Message = apr.Message;
            this.MessageType = apr.MessageType;
            this.ResultDate = apr.ResultDate;
        }


    }
}
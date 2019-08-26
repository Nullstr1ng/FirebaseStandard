using System;

namespace HelloFirebaseLibrary.Model
{
    public class ResponseResult
    {
        public string Message { get; set; } = null;
        public Exception Exception { get; set; } = null;
        public object Result { get; set; } = null;
    }
}

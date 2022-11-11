namespace MegghyDanmakuShared
{
    public class ResponeValue<T>
    {
        public ResponeValue(T? data, int code = 200, string msg = "")
        {
            Data = data;
            Code = code;
            Message = msg;
        }
        public static ResponeValue<T> CustomSuccess(T data)
        {
            return new(data, 200, "成功");
        }
        public static ResponeValue<object> CustomError(string reason, int code = 400)
        {
            return new(null, code, reason);
        }
        public static readonly ResponeValue<object> Success = new(null, 200, "成功");
        public int Code { get; set; } = 200;
        public string Message { get; set; } = "";
        public T? Data { get; set; }
    }
}

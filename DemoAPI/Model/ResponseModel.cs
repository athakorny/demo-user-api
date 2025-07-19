namespace DemoAPI.Model
{
    public class ResponseModel<T>
    {
        public bool IsSuccess { get; set; }
        public int Status { get; set; }
        public T Data { get; set; }
        public string ErrorMessage { get; set; }

        public int TotalRecords { get; set; }

        public static ResponseModel<T> Success<T>(T data, int total)
        {
            return new ResponseModel<T>() { Data = data, IsSuccess = true, Status = 200, TotalRecords = total };
        }

        public static ResponseModel<T> Fail(string msg)
        {
            return new ResponseModel<T>() { IsSuccess = false, Status = 400, ErrorMessage = msg };
        }
    }
}

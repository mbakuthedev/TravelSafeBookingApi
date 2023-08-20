namespace TravelSafeBookingApi.ApiModels.OperationResults
{
    public class OperationResult
    {
        public bool Sucessful => ErrorMessage == null;
        public int Status { get; set; }
        public string ErrorTitle { get; set; }
        public string ErrorMessage { get; set; }
        public object ErrorResult { get; set; }
        public object Result { get; set; }
    }
    public class OperationResult<TResult> : OperationResult
    {
        public new TResult Result { get; set; }
    }
}

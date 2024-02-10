namespace vpsAPI.DTOs
{
    public class ErrorResponseModel
    {
         IEnumerable<string> Messages { get; set; }
        public ErrorResponseModel()
        {
            Messages = new List<string>();
        }
        public ErrorResponseModel(string errorMessage)
        {
            var msgs = new List<string>();
            msgs.Add(errorMessage);
            Messages = msgs;
        }
    }
}

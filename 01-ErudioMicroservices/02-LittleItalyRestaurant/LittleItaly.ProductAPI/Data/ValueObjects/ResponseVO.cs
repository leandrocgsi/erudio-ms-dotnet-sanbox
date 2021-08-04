using System.Collections.Generic;

namespace LittleItaly.ProductAPI.Data.ValueObjects
{
    public class ResponseVO
    {
        public bool IsSuccess {  get; set; } =  true;
        public object Result { get; set; }
        public string DisplayMessage { get; set; } = "";
        public List<string> ErrorMessages { get; set; }
    }
}

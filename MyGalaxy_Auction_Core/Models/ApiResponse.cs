using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MyGalaxy_Auction_Core.Models
{
    public class ApiResponse
    {
        public ApiResponse()
        {
            // her tetiklendiğinde ErrorMessages listesini new'lesin boş bir liste halinde
            ErrorMessages = new List<string>();
        }

        public HttpStatusCode StatusCode { get; set; }
        public bool IsSuccess { get; set; }
        public List<string> ErrorMessages { get; set; }
        public object Result { get; set; }
    }
}

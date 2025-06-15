using System;
using EQUIPO_LINCES_BACKEND.Models;

namespace EQUIPO_LINCES_BACKEND.Helpers
{
    public class Helper
    {
        public Helper()
        {
        }
        // Returns structure for Json Response
        public static DataResponse GetStructResponse()
        {
            return new DataResponse
            {
                StatusCode=0,
                success = false,
                message = "",
              
                response = new { data = "" }

            };
        }
    }
}

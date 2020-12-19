using Roofcare_APIs.UserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roofcare_APIs.Helper
{
    public class Responses
    {
        public static object AuthenticationResponse(bool Success, int UserId, string Message, string Username, string FullName, string UserType, string UserImage)
        {
            return new AuthenticationModel()
            {
                Success = Success,
                Message = Message,
                UserId = UserId,
                Username = Username,
                FullName = FullName,
                UserType = UserType,
                UserImage = UserImage
            };
        }
    }
}

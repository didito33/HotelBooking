using HotelBooking.Data;

namespace HotelBooking.Services.Users
{
    public class UserService : IUserService
    {
        private readonly HotelBookingDbContext data;
        public UserService(HotelBookingDbContext data)
        {
            this.data = data;
        }

        public string UserFullName(string userId)
        {
            var user = this.data.Users.Find(userId);

            if (string.IsNullOrEmpty(user.FirstName) || string.IsNullOrEmpty(user.LastName))
            {
                return null;
            }

            return user.FirstName + " " + user.LastName;
        }
    }
}

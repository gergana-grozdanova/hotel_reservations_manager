using FluentValidation;
using HotelReservationsManager.Data.Entities;

namespace HotelReservationsManager.Validation
{
    public class UserValidator:AbstractValidator<ApplicationUser>
    {
        public UserValidator()
        {
            RuleFor(x => x.DismissalDate)
                .Cascade(CascadeMode.Stop)
                .GreaterThan(x => x.HiredDate);
        }
    }
}

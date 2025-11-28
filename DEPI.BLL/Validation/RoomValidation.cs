
namespace DEPI.BLL.Validation
{
    public class RoomValidation:AbstractValidator<RoomDTO>
    {
        public RoomValidation()
        {
            RuleFor(r => r.RoomNumber)
                .GreaterThan(0).WithMessage("Room Number must be greater than 0.");
            RuleFor(r => r.TypeId)
                .GreaterThan(0).WithMessage("TypeId must be greater than 0.");
        }

    }
}

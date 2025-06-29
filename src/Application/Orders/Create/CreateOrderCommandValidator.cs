    using Application.Common.Constants;

    namespace Application.Orders.Create;

    public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator()
        {
            RuleFor(x => x.CreateOrderDto.SenderCity)
                .NotNull()
                .NotEmpty()
                .MaximumLength(InputLimits.CityMaxLength);
            RuleFor(x => x.CreateOrderDto.SenderAddress)
                .NotNull()
                .NotEmpty()
                .MaximumLength(InputLimits.AddressMaxLength);
            RuleFor(x => x.CreateOrderDto.ReceiverCity)
                .NotNull()
                .NotEmpty()
                .MaximumLength(InputLimits.CityMaxLength);
            RuleFor(x => x.CreateOrderDto.ReceiverAddress)
                .NotNull()
                .NotEmpty()
                .MaximumLength(InputLimits.AddressMaxLength);
            RuleFor(x => x.CreateOrderDto.PackageWeightKg)
                .GreaterThan(0);
        }
    }
using Application.Settings;
using Microsoft.Extensions.Options;

namespace Application.Orders.Commands.Create;

public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
{
    public CreateOrderCommandValidator(IOptions<InputLimitSettings> options)
    {
        var inputLimits = options.Value;
        RuleFor(x => x.CreateOrderDto.SenderCity)
            .NotNull()
            .NotEmpty()
            .MaximumLength(inputLimits.MaxCharacterCityLength);
        RuleFor(x => x.CreateOrderDto.SenderAddress)
            .NotNull()
            .NotEmpty()
            .MaximumLength(inputLimits.MaxCharacterAddressLength);
        RuleFor(x => x.CreateOrderDto.ReceiverCity)
            .NotNull()
            .NotEmpty()
            .MaximumLength(inputLimits.MaxCharacterCityLength);
        RuleFor(x => x.CreateOrderDto.ReceiverAddress)
            .NotNull()
            .NotEmpty()
            .MaximumLength(inputLimits.MaxCharacterAddressLength);
        RuleFor(x => x.CreateOrderDto.PackageWeightKg)
            .GreaterThan(0)
            .LessThanOrEqualTo(inputLimits.MaxPackageWeightKg);
    }
}
using Application.DTOs;
using Application.Features.ShippingCarrier.Commands.CreateShippingCarrier;
using Application.Features.ShippingCarrier.Commands.UpdateShippingCarrier;
using Application.Features.ShippingCarrier.Queries.GetShippingCarrierById;
using MediatR;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace WebUI.Components.Layout.ShippingCarrier
{
    public partial class ShippingCarrierEdit
    {
        [CascadingParameter] IMudDialogInstance MudDialog { get; set; } = default!;
        [Parameter] public Guid Id { get; set; }

        [Inject] private ISnackbar Snackbar { get; set; } = default!;

        private MudForm form = default!;
        private bool isValid;
        private ShippingCarrierDTO carrier = new() { IsActive = true };

        protected override async Task OnInitializedAsync()
        {
            if (Id != Guid.Empty)
            {
                var result = await Mediator.Send(new GetShippingCarrierByIdQuery { Id = Id });
                if (result != null)
                {
                    carrier = result;
                }
            }
        }

        private void Cancel() => MudDialog.Cancel();

        private async Task Save()
        {
            await form.Validate();
            if (!isValid) return;

            try
            {
                if (Id == Guid.Empty)
                {
                    var command = new CreateShippingCarrierCommand
                    {
                        Name = carrier.Name,
                        Code = carrier.Code,
                        LogoUrl = carrier.LogoUrl,
                        IsActive = carrier.IsActive
                    };
                    await Mediator.Send(command);
                    Snackbar.Add("Thêm đơn vị vận chuyển thành công", Severity.Success);
                }
                else
                {
                    var command = new UpdateShippingCarrierCommand
                    {
                        Id = Id,
                        Name = carrier.Name,
                        Code = carrier.Code,
                        LogoUrl = carrier.LogoUrl,
                        IsActive = carrier.IsActive
                    };
                    await Mediator.Send(command);
                    Snackbar.Add("Cập nhật đơn vị vận chuyển thành công", Severity.Success);
                }
                MudDialog.Close(DialogResult.Ok(true));
            }
            catch (Exception ex)
            {
                Snackbar.Add(ex.Message, Severity.Error);
            }
        }
    }
}

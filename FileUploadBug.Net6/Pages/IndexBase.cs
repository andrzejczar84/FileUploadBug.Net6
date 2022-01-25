using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace FileUploadBug.Net6.Pages
{
    public class IndexBase: ComponentBase
    {
        public byte[] ImgUploaded { get; set; }

        public string imageDataUrl = string.Empty;

        public int readbytes;
        protected async Task OnInputFileChange(InputFileChangeEventArgs e)
        {

            var format = "image/png";

            var imageFile = e.File;
            var resizedImageFile = await imageFile.RequestImageFileAsync(format,
                    400, 200);
            var buffer = new byte[resizedImageFile.Size];
            readbytes = await resizedImageFile.OpenReadStream().ReadAsync(buffer);
            imageDataUrl =
                $"data:{format};base64,{Convert.ToBase64String(buffer)}";

            ImgUploaded = buffer;

        }

    }
}

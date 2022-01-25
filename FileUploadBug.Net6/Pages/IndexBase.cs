using FileUploadBug.Net6.DBModel;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace FileUploadBug.Net6.Pages
{
    public class IndexBase: ComponentBase
    {
        public byte[] ImgUploaded { get; set; }

        public string imageDataUrl = string.Empty;

        public int readbytes;

        /// <summary>
        /// to repro img only
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        //protected async Task OnInputFileChange(InputFileChangeEventArgs e)
        //{

        //    var format = "image/png";

        //    var imageFile = e.File;
        //    var resizedImageFile = await imageFile.RequestImageFileAsync(format,
        //            400, 200);
        //    var buffer = new byte[resizedImageFile.Size];
        //    readbytes = await resizedImageFile.OpenReadStream().ReadAsync(buffer);
        //    imageDataUrl =
        //        $"data:{format};base64,{Convert.ToBase64String(buffer)}";

        //    ImgUploaded = buffer;

        //}

        protected async Task OnInputFileChange(InputFileChangeEventArgs e)
        {

            var format = e.File.ContentType.ToString();
            

            if (format == "image/jpeg")
            {
                var imageFile = e.File;
                var resizedImageFile = await imageFile.RequestImageFileAsync(format,
                        600, 800);
                var buffer = new byte[resizedImageFile.Size];
                readbytes = await resizedImageFile.OpenReadStream().ReadAsync(buffer);

                Task_Attachment AddAttachment = new Task_Attachment()
                {
                    Attachment = buffer.ToArray(),
                    Description = e.File.Name,
                    Uploaded = DateTime.Now,
                    FileType = e.File.ContentType
                };
                

                //Db.Task_Attachments.Add(AddAttachment);
                //Db.SaveChanges();
            }
            if (format == "application/pdf")
            {
                if (e.File.Size > 0 && e.File.Size < 2097152) //2 MB
                {
                    var buffer = new byte[e.File.Size];
                    readbytes = await e.File.OpenReadStream(2097152).ReadAsync(buffer);
                    
                    Task_Attachment AddAttachment = new Task_Attachment()
                    {
                        Attachment = buffer.ToArray(),
                        Description = e.File.Name,
                        Uploaded = DateTime.Now,
                        FileType = e.File.ContentType
                    };
                    //Db.Task_Attachments.Add(AddAttachment);
                    //Db.SaveChanges();
                }

            }




        }

    }
}

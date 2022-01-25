namespace FileUploadBug.Net6.DBModel
{
    public class Task_Attachment
    {
        public int Id { get; set; }
        public byte[] Attachment { get; set; }
        public string Description { get; set; }
        public DateTime Uploaded { get; set; }
        public string UploadedBy { get; set; }
        public string FileType { get; set; }
    }
}

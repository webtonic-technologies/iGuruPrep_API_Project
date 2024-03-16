namespace ControlPanel_API.DTOs
{
    public class MagazineDTO
    {
        public int? MagazineId { get; set; }
        public string MagazineName { get; set; }
        public string ClassName { get; set; }
        public string CourseName { get; set; }
        public IFormFile? File { get; set; } = null;
    }

    public class UpdateMagazineDTO
    {
        public int? MagazineId { get; set; }
        public string MagazineName { get; set; }
        public string ClassName { get; set; }
        public string CourseName { get; set; }
    }
}

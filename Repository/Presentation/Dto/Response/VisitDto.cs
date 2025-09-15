namespace Repository.Presentation.Dto.Response
{
    public class VisitDto
    {
        public VisitDto(string ipAddress, string url, DateTime created)
        {
            IpAddress = ipAddress;
            Url = url;
            Created = TimeZoneInfo.ConvertTimeFromUtc(created, TimeZoneInfo.FindSystemTimeZoneById("Russian Standard Time"));
        }

        public string IpAddress { get; }
        public string Url { get; }
        public DateTime Created { get; }
    }
}

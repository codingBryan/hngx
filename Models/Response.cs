namespace backend_stage_one.Models
{
    public class Response
    {
        public string slack_name { get; set; } = String.Empty;
        public string? current_day { get; set; } = String.Empty;
        public string utc_time { get; set; } = DateTime.UtcNow.ToString("o");
        public string? track { get; set; } = String.Empty;
        public string? github_file_url { get; set; } = String.Empty;
        public string? github_repo_url { get; set; } = String.Empty;

        public int status_code { get; set; } = 200;
    }
}

using backend_stage_one.Models;

namespace backend_stage_one.Services
{
    public class JsonResponseService : IJsonResponseService
    {
        public Response GetResponseAsync(string slack_name, string track)
        {
            Response res = new Response
            {
                slack_name = slack_name,
                current_day = DateTime.Now.ToString("dddd"),
                utc_time = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ"),
                track = track,
                github_file_url = "https://github.com/codingBryan/hngx/blob/master/Program.cs",
                github_repo_url = "https://github.com/codingBryan/hngx",
            };

            return res;
        }
    }
}

using backend_stage_one.Models;

namespace backend_stage_one.Services
{
    public class JsonResponseService : IJsonResponseService
    {
        public async Task<Response> GetResponseAsync(string slack_name, string track)
        {
            Response res = new Response
            {
                slack_name = slack_name,
                current_day = DateTime.Now.ToString("dddd"),
                utc_time = DateTime.UtcNow.ToString("o"),
                track = track,
                github_file_url = "",
                github_repo_url = "",
            };

            return res;
        }
    }
}

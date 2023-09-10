using backend_stage_one.Models;

namespace backend_stage_one.Services
{
    public interface IJsonResponseService
    {
        Task<Response> GetResponseAsync(string slack_name,string track);
    }
}

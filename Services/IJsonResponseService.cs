using backend_stage_one.Models;

namespace backend_stage_one.Services
{
    public interface IJsonResponseService
    {
        Response GetResponseAsync(string slack_name,string track);
        Task<Res> CreateUser(NewPersonDTO personDTO);
        Task<Person> GetUserById(int id);
        Task<Res> DeleteUser(int id);
        Task<Res> UpdateUser(int id, NewPersonDTO personDTO);
    }
}

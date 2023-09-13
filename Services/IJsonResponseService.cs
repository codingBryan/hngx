using backend_stage_one.Models;

namespace backend_stage_one.Services
{
    public interface IJsonResponseService
    {
        Task<Person> CreateUser(NewPersonDTO personDTO);
        Task<Person> GetUserById(int id);
        Task<Res<Person>> DeleteUser(int id);
        Task<Res<Person>> UpdateUser(int id, NewPersonDTO personDTO);
    }
}

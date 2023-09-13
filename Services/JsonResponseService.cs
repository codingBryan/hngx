using backend_stage_one.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace backend_stage_one.Services
{
    public class JsonResponseService : IJsonResponseService
    {
        private readonly IMapper mapper;
        private readonly DataContext context;

        public JsonResponseService(IMapper mapper,DataContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }
        public async Task<Person> CreateUser(NewPersonDTO personDTO)
        {

            Person person = mapper.Map<Person>(personDTO);
            await context.users.AddAsync(person);
            await context.SaveChangesAsync();
            return person;
        }

        public async Task<Res<Person>> DeleteUser(int id)
        {
            Res<Person> res = new Res<Person>();
            try
            {

                Person? user = await context.users.Where(t => t.Id == id).SingleOrDefaultAsync();
                if (user != null)
                {
                    res.data = user;
                    await context.users.Where(t => t.Id == id).ExecuteDeleteAsync();
                    await context.SaveChangesAsync();
                    res.message = "user was deleted successfully";
                }
                else
                {
                    throw new Exception($"Failed to find user with id {id}");
                }

            }
            catch (Exception ex)
            {
                res.success = false;
                res.message = ex.Message;
            }
            return res;
        }

        Person p = new Person();
        public async Task<Person> GetUserById(int id)
        {
            
            Person? person = await context.users.Where(u => u.Id == id).FirstOrDefaultAsync();
            if (person is not null)
            {
                p=person;
            }
            return p;
             
        }

        public async Task<Res<Person>> UpdateUser(int id,NewPersonDTO personDTO)
        {
            Res<Person> res = new Res<Person>();
            try
            {
                var user = await context.users.FindAsync(id);

                if (user is null)
                {
                    throw new Exception("Invalid user ID");
                }

                user.name = personDTO.name;
                await context.SaveChangesAsync();
                res.data = user;
                res.message = "Update was succesful";
            }catch(Exception ex)
            {
                res.success = false;
                res.message = ex.Message;
            }

            return res;
            
        }
    }
}

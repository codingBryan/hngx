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
        public async Task<Res> CreateUser(NewPersonDTO personDTO)
        {
            Res res = new Res();
            Person person = mapper.Map<Person>(personDTO);
            try
            {
                await context.users.AddAsync(person);
                await context.SaveChangesAsync();
                res.message = "Created user successfully";
            }catch(DbUpdateException ex)
            {
                res.success = false;
                res.message = "Failed to create user";
            }

            return res;
        }

        public async Task<Res> DeleteUser(int id)
        {
            Res res = new Res();
            try
            {

                Person? user = await context.users.Where(t => t.Id == id).SingleOrDefaultAsync();
                if (user != null)
                {
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

        public async Task<Res> UpdateUser(int id,NewPersonDTO personDTO)
        {
            Res res = new Res();
            try
            {
                var user = await context.users.FindAsync(id);

                if (user is null)
                {
                    throw new Exception("Invalid user ID");
                }
                user.name = personDTO.name;

                await context.SaveChangesAsync();
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

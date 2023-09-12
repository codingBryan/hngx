using backend_stage_one.Models;

namespace backend_stage_one
{
    public class AutomapperProfile:Profile
    {
        public AutomapperProfile()
        {
            CreateMap<NewPersonDTO, Person>();
        }
    }
}

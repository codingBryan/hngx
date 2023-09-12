using System.ComponentModel.DataAnnotations;

namespace backend_stage_one.Models
{
    public class NewPersonDTO
    {
        [Required] public string name { get; set; }
    }
}

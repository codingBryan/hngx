namespace backend_stage_one.Models
{
    public class Res<t>
    {
        public t? data { get; set; }
        public bool success { get; set; } = true;
        public string? message { get; set; }
    }
}

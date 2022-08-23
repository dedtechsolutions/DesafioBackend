using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Shedule.Domain
{
    public class Assignment
    {

        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; } = String.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime CreateOn { get; set; }
        public DateTime UpdateOn { get; set; }
    }
}

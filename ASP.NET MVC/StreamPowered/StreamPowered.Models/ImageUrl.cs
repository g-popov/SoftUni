using System.ComponentModel.DataAnnotations;

namespace StreamPowered.Models
{
    public class ImageUrl
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Url)]
        public string Url { get; set; }

        public int GameId { get; set; }

        public virtual Game Game { get; set; }
    }
}
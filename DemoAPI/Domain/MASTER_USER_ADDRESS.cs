using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoAPI.Domain
{
    [Table("MASTER_USER_ADDRESS")]
    public class MASTER_USER_ADDRESS
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 1)]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [StringLength(150)]
        public string Street { get; set; }

        [StringLength(150)]
        public string Suite { get; set; }

        [StringLength(150)]
        public string City { get; set; }

        [StringLength(150)]
        public string Zipcode { get; set; }

        public decimal? Lat { get; set; }

        public decimal? Lng { get; set; }


        [ForeignKey("UserId")]
        public virtual MASTER_USERS MASTER_USERS { get; set; }



    }
}

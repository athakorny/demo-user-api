using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoAPI.Domain
{
    [Table("MASTER_COMPANY")]
    public class MASTER_COMPANY
    {
        [Key]
        [Column(Order = 1)]
        [StringLength(4)]
        public string Code { get; set; }

        [Required]
        [StringLength(50)]
        [Column(Order = 2)]
        public string Name { get; set; }

        [StringLength(150)]
        [Column(Order = 3)]
        public string CatchPhrase { get; set; }

        [StringLength(150)]
        [Column(Order = 4)]
        public string Bs { get; set; }

        public virtual MASTER_USERS MASTER_USERS { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoAPI.Domain
{
    [Table("MASTER_USERS")]
    public class MASTER_USERS
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 1)]
        public int Id { get; set; }

        [Required]
        [Column(Order = 2)]
        public string Name { get; set; }

        [Required]
        [Column(Order = 3)]
        [StringLength(50)]
        public string UserName { get; set; }

        [Required]
        [Column(Order = 4)]
        [StringLength(250)]
        public string PasswordHash { get; set; }

        [Column(Order = 5)]
        [StringLength(50)]
        public string Email { get; set; }

        [Column(Order = 6)]
        [StringLength(20)]
        public string Phone { get; set; }

        [Column(Order = 7)]
        [StringLength(250)]
        public string Website { get; set; }

        [Column(Order = 8)]
        public bool ActiveFlag { get; set; }

        [Column(Order = 9)]
        [StringLength(4)]
        public string CompanyCode { get; set; }

        public string CreateBy { get; set; }
        public DateTime CreateDate { get; set; }

        public string UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }

        [ForeignKey("CompanyCode")]
        public virtual MASTER_COMPANY MASTER_COMPANY { get; set; }

        public virtual MASTER_USER_ADDRESS MASTER_USER_ADDRESS { get; set; }
    }
}

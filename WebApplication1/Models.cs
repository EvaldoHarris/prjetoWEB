using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1
{
    public class Usuario
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Required]
        [DisplayName("Id")]
        public int Id { get; set; }

        [MaxLength(50)]
        [DisplayName("Nome")]
        public string Nome { get; set; }

        [Required]
        [MaxLength(15)]
        [DisplayName("Login")]
        public string Login { get; set; }

        [Required]
        [MaxLength(15)]
        [DisplayName("Senha")]
        public string Senha { get; set; }

        [DisplayName("NDE")]
        public bool? NDE { get; set; }

        [DisplayName("Admin")]
        public bool? Admin { get; set; }

        //public virtual ICollection<Disciplina> Disciplinas { get; set; }
        //public ICollection<Curso> Cursos { get; set; }
    }

    public class Disciplina
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Required]
        [DisplayName("Id")]
        public int Id { get; set; }

        [MaxLength(50)]
        [DisplayName("Nome")]
        public string Nome { get; set; }

        [Required]
        [MaxLength(15)]
        [DisplayName("Codigo")]
        public string Codigo { get; set; }

        public int ResponsavelId { get; set; }

        [DisplayName("Responsavel")]
        [ForeignKey("ResponsavelId")]
        public Usuario Responsavel { get; set; }

    }

    public class Curso
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Required]
        [DisplayName("Id")]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        [DisplayName("Nome")]
        public string Nome { get; set; }

        //[Required]
        //
        public int CoordenadorId { get; set; }
        //[ForeignKey("CoordenadorId")]
        [DisplayName("Coordenador")]
        [ForeignKey("CoordenadorId")]
        public Usuario Coordenador { get; set; }

        //public Usuario Coordenador { get; set; }

        //public virtual ICollection<Disciplina> Disciplinas { get; set; }
        //public virtual ICollection<Curso> Cursos { get; set; }
    }


}

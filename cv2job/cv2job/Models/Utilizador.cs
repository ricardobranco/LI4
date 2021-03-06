﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;


namespace cv2job.Models
{

    [Table("Utilizadores")]
    public class Utilizador
    {
        

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public virtual ICollection<Corporacao> CorpSeguidas { get; set; }
        public virtual ICollection<Corporacao> CorpColab { get; set; }
        public virtual ICollection<Anuncio> AnunciosSeguidos { get; set; }
        public virtual ICollection<Anuncio> AnunciosCriados { get; set; }
        public virtual IDictionary<Utilizador,ICollection<Mensagem>> Mensagens { get; set; }
        public virtual ICollection<Skill> Skills { get; set; }
        public virtual ICollection<Educacao> Educacoes { get; set; }
        public virtual ICollection<Trabalho> Trabalhos { get; set; }
        public DateTime Criado { get; set; }
        public string Avatar { get; set; }
        public string Nome { get; set; }
        public string Apelido { get; set; }
        public string Morada { get; set; }
        public string CodPostal {get;set;}
        public string Cidade { get; set; }
        public string Nacionalidade { get; set; }
        public string Pais { get; set; }
        public string Sexo { get; set; }
        
        public string Email { get; set; }
        public string Fax { get; set; }
        public string Contacto { get; set; }
        public string WebSite { get; set; }
        public string Sobre { get; set; }
        
        public string DataNascimento { get; set; }
    }

    public class RegisterExternalLoginModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        public string ExternalLoginData { get; set; }
    }

    public class LocalPasswordModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password atual")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "O {0} deve ter pelo menos {2} carateres.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Nova password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar a nova password")]
        [Compare("NewPassword", ErrorMessage = "A nova password e a password de confirmação não são iguais.")]
        public string ConfirmPassword { get; set; }
    }

    public class LoginModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterModel
    {
        [Required]
        [Display(Name = "Username")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Nome")]
        public string Nome { get; set; }


        [Required]
        [Display(Name = "Apelido")]
        public string Apelido { get; set; }



        [Required]
        [StringLength(100, ErrorMessage = "O {0} deve ter pelo menos {2} carateres.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar password")]
        [Compare("Password", ErrorMessage = "A password e a password de confirmação não são iguais.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public string Sexo { get; set; }

    }

    public class ExternalLogin
    {
        public string Provider { get; set; }
        public string ProviderDisplayName { get; set; }
        public string ProviderUserId { get; set; }
    }



}

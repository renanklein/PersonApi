using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PersonAPI.Models
{ 
    public enum DocumentType
    {
        [Display(Name = "None")]
        None,

        [Display(Name = "CPF")]
        CPF,

        [Display(Name = "CNPJ")]
        CNPJ
    }
}

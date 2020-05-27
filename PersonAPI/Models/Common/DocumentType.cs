using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PersonAPI.Models
{
    [JsonConverter(typeof(DocumentType))]
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

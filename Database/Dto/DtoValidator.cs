using System.ComponentModel.DataAnnotations;

namespace MapaEstoqueCD.Database.Dto
{
    public class DtoValidator
    {
        public static List<ValidationResult> Validate(object dto, out List<ValidationResult> erros )
        {
            var results = new List<ValidationResult>();
            var context = new ValidationContext(dto, null, null);

            Validator.TryValidateObject(dto, context, results, validateAllProperties: true);

            erros = results;
            return results;
        }
    }
}

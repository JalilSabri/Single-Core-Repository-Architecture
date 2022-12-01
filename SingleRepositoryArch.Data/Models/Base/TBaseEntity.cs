using System.ComponentModel.DataAnnotations;

namespace SingleRepositoryArch.Data.Models.Base
{
    public class TBaseEntity<TIdType>
    {
        [Key]
        public TIdType Id { get; set; }
    }
}

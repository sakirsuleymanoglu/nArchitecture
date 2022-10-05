namespace Kodlama.io.Devs.Application.Features.UserOperationClaims.Models
{
    public class GetListByUserUserOperationClaimElementModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string UserEmail { get; set; }
        public int OperationClaimId { get; set; }
        public string OperationClaimName { get; set; }
    }
}

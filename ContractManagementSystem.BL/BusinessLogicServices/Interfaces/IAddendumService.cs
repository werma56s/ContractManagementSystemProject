using ContractManagementSystem.Core.Domain;

namespace ContractManagementSystem.BL.BusinessLogicServices.Interfaces
{
    public interface IAnnexService
    {
        IEnumerable<Annex> GetAllAnnex();
        Annex GetAnnexById(Guid id);
        void AddAAnnex(Annex addendum);
        void UpdateAnnex(Annex addendum);
        void DeleteAnnex(Guid id);
    }
}

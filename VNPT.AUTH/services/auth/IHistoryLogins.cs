using ClassLibrary.model;
using ClassLibrary.responsitory;

namespace VNPT.AUTH.services.auth
{
    public interface IHistoryLogins : IProductResponsetory<HistoryLogins>
    {
        dynamic getHistoryLoginInEmployer(HistoryLoginsRequest historyLoginsRequest);
    }
}

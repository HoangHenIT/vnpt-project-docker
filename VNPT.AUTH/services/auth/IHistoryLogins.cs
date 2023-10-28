using ClassLibrary.model;
using ClassLibrary.responsitory;

namespace VNPT.AUTH.services.auth
{
    public interface IHistoryLogins : IOCOPResponsetory<HistoryLogins>
    {
        dynamic getHistoryLoginInEmployer(HistoryLoginsRequest historyLoginsRequest);
    }
}

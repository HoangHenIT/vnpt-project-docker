using ClassLibrary.connectdb;
using ClassLibrary.model;
using ClassLibrary.respond;
using ClassLibrary.responsitory;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System.Globalization;

namespace VNPT.AUTH.services.auth.impl
{
    public class HistoryLoginsImpl : Responsetory<HistoryLogins>, IHistoryLogins
    {
        public HistoryLoginsImpl(DataContext context) : base(context)
        {

        }

        public dynamic getHistoryLoginInEmployer(HistoryLoginsRequest historyLoginsRequest)
        {
            DateTime sDate = DateTime.ParseExact(historyLoginsRequest.startDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime eDate = DateTime.ParseExact(historyLoginsRequest.endDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
           
                var res = (from employer in m_context.Employers.Where(m => m.employer_id == historyLoginsRequest.employer_id)
                           join hislogin in m_context.HistoryLogins //.Where(m => m.datetime_login >= sDate && m.datetime_login < eDate)
                on employer.employer_id equals hislogin.employer_id
                           select new
                           {
                               employer_id = employer.employer_id,
                               full_name = employer.full_name,
                               username = employer.username,
                               system_login = hislogin.system_login,
                               datetime_login = hislogin.datetime_login.ToString("dd/MM/yyyy HH:mm:ss"),
                           }).ToList();
                return res;
        }

        
    }
}

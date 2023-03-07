using ClassLibrary.auth.hashpass;
using ClassLibrary.model;
using ClassLibrary.respond;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using VNPT.AUTH.services.auth;

namespace VNPT.AUTH.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AuthController : ControllerBase
    {
        private readonly IAuth m_auth;
        private readonly IHistoryLogins m_history;
        public AuthController(IAuth _auth, IHistoryLogins _history)
        {
            m_auth = _auth;
            m_history = _history;
        }
        [AllowAnonymous]
        [HttpPost("login")]
        public DataRespond login(Employers employers)
        {
            DataRespond data = new DataRespond();
            try
            {

                data.success = true;
                data.data = m_auth.login(employers);
                insertHistoryLogin(employers.username);


            }
            catch (Exception ex)
            {
                data.success = false;
                data.error = ex;
                data.message = ex.Message;
            }
            return data;
        }
        //[AllowAnonymous]
        [HttpPost("insertHistoryLogin")]
        public DataRespond insertHistoryLogin(string username)
        {
            DataRespond data = new DataRespond();
            try
            {
                data.success = true;
                var employer = m_auth.findByLogin(username);
                HistoryLogins history = new HistoryLogins();
                history.employer_id = employer.employer_id;
                history.username = employer.username;
                history.datetime_login = DateTime.Now;
                history.system_login = System.Net.Dns.GetHostName();
                m_history.insert(history);


            }
            catch (Exception e)
            {
                data.success = false;
                data.error = e;
                data.message = e.Message;
            }
            return data;
            //}
        }

        [HttpPost("getHistoryLoginInEmployer")]
        public DataRespond insertHistoryLoginInEmployer(HistoryLoginsRequest historyLoginsRequest)
        {
            DataRespond data = new DataRespond();
            try
            {
                data.success = true;
                data.data = m_history.getHistoryLoginInEmployer(historyLoginsRequest);
                data.message = "";

            }
            catch (Exception e)
            {
                data.success = false;
                data.error = e;
                data.message = e.Message;
            }
            return data;
            //}
        }
    }
}

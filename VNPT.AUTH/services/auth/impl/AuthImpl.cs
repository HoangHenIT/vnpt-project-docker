using ClassLibrary.auth;
using ClassLibrary.connectdb;
using ClassLibrary.model;
using ClassLibrary.respond;
using ClassLibrary.responsitory;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic.FileIO;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace VNPT.AUTH.services.auth.impl
{
    public class AuthImpl : Responsetory<Employers>, IAuth
    {
        private IOptions<Audience> m_audience;
        public AuthImpl(DataContext context, IOptions<Audience> _audience) : base(context)
        {
            m_audience = _audience;
        }

        public DataRespond login(Employers employers)
        {
            DataRespond data= new DataRespond();
            try
            {
                if (checkEmployers(employers))
                {
                    data.success = true;
                    var ckEmployer = findByLogin(employers.username);
                    data.data = new { token = genToken(employers), employer = ckEmployer };
                } else
                {
                    data.success = false;
                    data.message = "Username or password not fount!";
                }
            }catch(Exception e)
            {
                data.success = false;
                data.error = e;
                data.message = e.Message;
            }
            return data;
        }
        public Boolean checkEmployers(Employers employers)
        {
            var employer = findByLogin(employers.username);
            if(employer == null)
            {
                return false;
            }
            else if(employers.password == employer.password)
            {
                return true;
            }
            return false;
        }
        public Employers findByLogin(string username)
        {
            return getAll().FirstOrDefault(m => m.username == username);
        }
        public DataRespond insertHistoryLogin(Employers employers)
        {
            DataRespond data = new DataRespond();
            try
            {
                var employer = findByLogin(employers.username);
                data.success = true;

            }
            catch(Exception e)
            {
                data.success = false;
                data.error = e;
                data.message = e.Message;
            }
            return data;
        }

        public dynamic genToken(Employers employers)
        {
            var now = DateTime.UtcNow;
            var claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, employers.employer_id.ToString()),
                new Claim(JwtRegisteredClaimNames.Iss, employers.username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, now.ToUniversalTime().ToString(), ClaimValueTypes.Integer64),
                new Claim(ClaimTypes.Role, employers.role_id.ToString())//check quyen
            };

            var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(m_audience.Value.Secret));
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = signingKey,
                ValidateIssuer = true,
                ValidIssuer = m_audience.Value.Issuer,
                ValidateAudience = true,
                ValidAudience = m_audience.Value.Aud,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero,
                RequireExpirationTime = true,

            };

            var jwt = new JwtSecurityToken(
                issuer: m_audience.Value.Issuer,
                audience: m_audience.Value.Aud,
                claims: claims,
                notBefore: now,
                expires: now.Add(TimeSpan.FromDays(1)),
                signingCredentials: new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256)
            );
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
            var responseJson = new
            {
                access_token = encodedJwt,
                expires_in = (int)TimeSpan.FromDays(1).TotalSeconds
                //expires_in = (int)TimeSpan.FromMinutes(1).TotalSeconds
            };

            return responseJson;
        }
    }
}

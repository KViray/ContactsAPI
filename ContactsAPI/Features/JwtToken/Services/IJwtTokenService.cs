namespace ContactsAPI.Features.JwtToken.Services
{
    public interface IJwtTokenService
    {
        public Task<string> CreateToken();
    }
}

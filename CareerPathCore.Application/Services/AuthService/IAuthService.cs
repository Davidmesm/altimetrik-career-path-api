using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerPathCore.Application.Services.AuthService
{
    public interface IAuthService
    {
        Task<string> Login(string? email, string? password);
        Task Register(string? email, string? password, string? passwordConfirmation);
    }
}

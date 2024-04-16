using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using TodoApi.Model.Request;
using TodoApi.Model.Response;


namespace TodoApi.Service
{
    public interface IAuthManager
    {
        Task<AuthResponseDto> login(UserLoginDto loginRequestDto);
    }
}
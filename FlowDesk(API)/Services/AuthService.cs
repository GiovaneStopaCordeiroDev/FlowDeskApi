using FlowDesk_API_.Context;
using FlowDesk_API_.Dtos;
using FlowDesk_API_.Modelos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FlowDesk_API_.Services
{
    public class AuthService
    {
        private FlowDeskContext _context;
        private UserManager<Usuario> _userManager;
        private SignInManager<Usuario> _signInManager;
        private TokenService _tokenService;
        public AuthService(FlowDeskContext context, UserManager<Usuario> userManager,
            SignInManager<Usuario> signInManager, TokenService tokenService)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        public async Task<IdentityResult> CadastrarUsuario(CriarUsuarioDto dto)
        {

                Usuario usuario = new Usuario
                {
                    Nome = dto.Nome,
                    UserName = dto.Nome,
                };

                return await _userManager.CreateAsync(usuario, dto.Senha);
            
        }

        public async Task<string> LogarUsuario(LoginUsuarioDto dto)
        {
            var usuario = await _userManager.FindByNameAsync(dto.Nome);
            if (usuario == null)
            {
                return null;
            }
            var resultado = await _signInManager.PasswordSignInAsync(usuario, dto.Senha, isPersistent:false, lockoutOnFailure: false);

            var encontrarUsuario = _signInManager.
                UserManager.Users.FirstOrDefault(user => user.NormalizedUserName == dto.Nome.ToUpper());
            if (encontrarUsuario == null)
            {
                return null;
            }
            var token = _tokenService.GenerateToken(encontrarUsuario);
            if (!resultado.Succeeded)
            {
                return null;
            }

            return _tokenService.GenerateToken(usuario);
        }

       

    }
}

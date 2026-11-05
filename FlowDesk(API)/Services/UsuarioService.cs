using FlowDesk_API_.Modelos;
using Microsoft.AspNetCore.Identity;

namespace FlowDesk_API_.Services
{
    public class UsuarioService
    {

        private UserManager<Usuario> _userManager;
        private RoleManager<IdentityRole> _roleManager;

        public UsuarioService(UserManager<Usuario> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IdentityResult> AtribuirPerfil(string id, string perfil)
        {
            var usuario = await _userManager.FindByIdAsync(id);
            if (usuario == null)
            {
                throw new Exception("Resultado nulo");
            }

            string[] perfisPermitidos =
            {
                "Administrador",
                "Gestor",
                "Tecnico",
                "Cliente"
            };

            var perfilValido = perfisPermitidos.FirstOrDefault(p => p.Equals(perfil, StringComparison.OrdinalIgnoreCase));
            if (perfilValido == null || !await _roleManager.RoleExistsAsync(perfilValido))
            {
                return IdentityResult.Failed(new IdentityError { Description = "Perfil inválido" });
            }

            if (await _userManager.IsInRoleAsync(usuario, perfilValido))
            {
                return IdentityResult.Success;
            }
            return  await _userManager.AddToRoleAsync(usuario, perfilValido);
        }

    }
}

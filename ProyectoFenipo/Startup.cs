using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using ProyectoFenipo.Models;

[assembly: OwinStartupAttribute(typeof(ProyectoFenipo.Startup))]
namespace ProyectoFenipo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRolesAndUsers();
        }

        private void CreateRolesAndUsers()
        {
            //accedemos al modelo de la seguridad integrada
            ApplicationDbContext context = new ApplicationDbContext();

            //definimos las variables manejadoras de roles y usuarios
            var ManejadorRol = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var ManejadorUsuario = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            //Verificamos la excistencia de los roles por defecto
            if (!ManejadorRol.RoleExists("Admin"))
            {
                //sino existe, se crea el rol y se asigna un nuevo usuario con ese rol

                var rol = new IdentityRole();
                rol.Name = "Admin";
                ManejadorRol.Create(rol);

                //creamos un primer usuario para ese rol
                var user = new ApplicationUser();
                user.UserName = "Admin@gmail.com";
                user.Email = "Admin@gmail.com";
                string PWD = "123456";

                var chkUser = ManejadorUsuario.Create(user, PWD);
            }

            //Verificamos la excistencia de los roles por defecto
            if (!ManejadorRol.RoleExists("Tecnico"))
            {
                //sino existe, se crea el rol y se asigna un nuevo usuario con ese rol

                var rol = new IdentityRole();
                rol.Name = "Tecnico";
                ManejadorRol.Create(rol);

                //creamos un primer usuario para ese rol
                var user = new ApplicationUser();
                user.UserName = "Tecnico@gmail.com";
                user.Email = "Tecnico@gmail.com";
                string PWD = "123456";

                var chkUser = ManejadorUsuario.Create(user, PWD);
            }
        }

        // administrador
        // tecnico
        // publico

    }
}

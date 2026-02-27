using Xunit;
using ejercicio6;
using System;
using System.Collections.Generic;

namespace ejercicio6.tests
{
    public class UnitTest1
    {
        [Fact]
        public void Usuario_DeberiaSerIgual_CuandoPropiedadesSonLasMismas()
        {
            var u1 = new Usuario("user1", "User One", DateOnly.FromDateTime(DateTime.Now));
            var u2 = new Usuario("user1", "User One", u1.FechaRegistro);

            Assert.Equal(u1, u2);
        }

        [Fact]
        public void RegistraUsuario_DeberiaAnadirUsuario_CuandoUsuarioNoExiste()
        {
            var redSocial = new RedSocial();
            var u1 = new Usuario("user1", "User One", DateOnly.FromDateTime(DateTime.Now));

            redSocial.RegistraUsuario(u1);

            // Since we cannot access private dictionary, we can try to add again and expect exception
            Assert.Throws<RedSocial.RedSocialException>(() => redSocial.RegistraUsuario(u1));
        }

        [Fact]
        public void RegistraUsuario_DeberiaLanzarExcepcion_CuandoUsuarioYaExiste()
        {
            var redSocial = new RedSocial();
            var u1 = new Usuario("user1", "User One", DateOnly.FromDateTime(DateTime.Now));
            redSocial.RegistraUsuario(u1);

            Assert.Throws<RedSocial.RedSocialException>(() => redSocial.RegistraUsuario(u1));
        }

        [Fact]
        public void AnadePublicacion_DeberiaAnadirPublicacion_CuandoEsValida()
        {
            var redSocial = new RedSocial();
            var u1 = new Usuario("user1", "User One", DateOnly.FromDateTime(DateTime.Now));
            redSocial.RegistraUsuario(u1);

            var p1 = new Publicacion(DateTime.Now, u1, "Content", 0);

            redSocial.AñadePublicacion(p1);

            Assert.Throws<RedSocial.RedSocialException>(() => redSocial.AñadePublicacion(p1));
        }

        [Fact]
        public void AnadePublicacion_DeberiaLanzarExcepcion_CuandoUsuarioNoExiste()
        {
            var redSocial = new RedSocial();
            var u1 = new Usuario("user1", "User One", DateOnly.FromDateTime(DateTime.Now));

            var p1 = new Publicacion(DateTime.Now, u1, "Content", 0);

            Assert.Throws<RedSocial.RedSocialException>(() => redSocial.AñadePublicacion(p1));
        }
    }
}

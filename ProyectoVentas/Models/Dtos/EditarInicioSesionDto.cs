﻿namespace ProyectoVentas.Models.Dtos
{
    public class EditarInicioSesionDto
    {
        public int loginId { get; set; }
        public string? correo { get; set; }
        public string? contrasenaActual { get; set; }

        public string? contrasenaNueva { get; set; }

        public string? contrasenaNuevaConfirmacion { get; set; }
    }
}

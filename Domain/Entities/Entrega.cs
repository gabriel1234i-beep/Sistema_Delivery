using Domain.Common;
using Domain.Enums;
using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Entrega : BaseEntity
    {
        public string Descripcion { get; private set; }
        public Direccion PuntoRecojo { get; private set; }
        public Direccion PuntoEntrega { get; private set; }
        public string PersonaContacto { get; private set; }
        public string TelefonoContacto { get; private set; }
        public EstadoEntrega Estado { get; private set; }
        public Guid? IdRepartidor { get; private set; }

        //private Entrega() { }

        public Entrega(string descripcion, Direccion recojo, Direccion Entrega, string contacto, string telefonoContacto)
        {
            Descripcion = descripcion;
            PuntoRecojo = recojo;
            PuntoEntrega = Entrega;
            PersonaContacto = contacto;
            TelefonoContacto = telefonoContacto;
            Estado = EstadoEntrega.Creado;
        }

        public void AsignarRepartidor(Guid Idrepartidor)
        {
            IdRepartidor = Idrepartidor;
            Estado = EstadoEntrega.Asignado;
        }
        public void ActualizarEstado(EstadoEntrega nuevoEstado)
        {
            Estado = nuevoEstado;
        }
    }
}

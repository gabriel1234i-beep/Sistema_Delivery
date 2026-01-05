using Aplication.DTOs;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Mapeo de objetos de valor y detalles
            CreateMap<UbicacionDTOs, Ubicacion>();

            CreateMap<DetalleProductoDTOs, DetallePedido>();

            //Mapeo para crear pedido de compra
            CreateMap<PedidoCompraDTOs, Pedido>()
                .ForMember(dest => dest.TipoServicio, opt => opt.MapFrom(src => TipoServicio.Compra))
                .ForMember(dest => dest.Estado, opt => opt.MapFrom(src => EstadoPedido.Pendiente))
                .ForMember(dest => dest.Detalles, opt => opt.MapFrom(src => src.Productos))
                .ForMember(dest => dest.UbicacionDestino, opt => opt.MapFrom(src => src.UbicacionEntrega))
                .ForMember(dest => dest.UbicacionOrigen, opt => opt.Ignore());

            //Mapeo para crear pedido de envio
            CreateMap<PedidoEnvioDTOs, Pedido>()
                .ForMember(dest => dest.TipoServicio, opt => opt.MapFrom(src => TipoServicio.Compra))
                .ForMember(dest => dest.Estado, opt => opt.MapFrom(src => EstadoPedido.Pendiente))
                .ForMember(dest => dest.UbicacionOrigen, opt => opt.MapFrom(src => src.UbicacionRecojo))
                .ForMember(dest => dest.UbicacionDestino, opt => opt.MapFrom(src => src.UbicacionEntrega))
                .ForMember(dest => dest.Detalles, opt => opt.Ignore())
                .ForMember(dest => dest.IdComercio, opt => opt.Ignore());

            //Mapeo de salida
            CreateMap<Pedido, ResumenPedidoDTOs>()
                .ForMember(dest => dest.TipoServicio, opt => opt.MapFrom(src => src.TipoServicio.ToString()))
                .ForMember(dest => dest.Estado, opt => opt.MapFrom(src => src.Estado.ToString()))
                .ForMember(dest => dest.Total, opt => opt.MapFrom(src => src.Total));
        }
    }
}

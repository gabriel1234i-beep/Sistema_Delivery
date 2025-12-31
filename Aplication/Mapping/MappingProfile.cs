using Aplication.DTOs;
using Aplication.DTOs.Compra;
using Aplication.DTOs.Envio;
using AutoMapper;
using Domain.Entities;
using Domain.ValueObjects;
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
            CreateMap<DireccionDTOs, Direccion>().ReverseMap();

            CreateMap<PedidoDTOs, Pedido>();

            CreateMap<ItemPedidoDTO, ItemPedido>();

            CreateMap<EntregaDTOs, Entrega>();
        }
    }
}

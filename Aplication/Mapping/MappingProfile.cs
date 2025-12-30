using Aplication.DTOs;
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
            CreateMap<DireccionDTO, Direccion>();

            CreateMap<Pedido, PedidoDTOs>().ReverseMap();

            CreateMap<ItemPedido, ItemDTO>().ReverseMap();

            CreateMap<Entrega, EntregaDTOs>().ReverseMap();
        }
        
    }
}

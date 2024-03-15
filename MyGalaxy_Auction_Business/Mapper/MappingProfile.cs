﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MyGalaxy_Auction_Business.Dtos;
using MyGalaxy_Auction_DataAccess.Models;

namespace MyGalaxy_Auction_Business.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RegisterRequestDTO, ApplicationUser>().ReverseMap();
        }
    }
}

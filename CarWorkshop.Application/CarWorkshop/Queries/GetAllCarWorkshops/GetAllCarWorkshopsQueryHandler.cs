﻿using AutoMapper;
using CarWorkshop.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Application.CarWorkshop.Queries.GetAllCarWorkshops
{
    public class GetAllCarWorkshopsQueryHandler : IRequestHandler<GetAllCarWorkshopsQuery, IEnumerable<CarWorkshopDto>>
    {
        private IMapper _mapper;
        private ICarWorkshopRepository _carWorkshopRepository;

        public GetAllCarWorkshopsQueryHandler(ICarWorkshopRepository carWorkshopRepository, IMapper mapper)
        {
            _mapper = mapper;
            _carWorkshopRepository = carWorkshopRepository;
        }
        public async Task<IEnumerable<CarWorkshopDto>> Handle(GetAllCarWorkshopsQuery request, CancellationToken cancellationToken)
        {
            var carWorkshops = await _carWorkshopRepository.GetAll();
            var dtos = _mapper.Map<IEnumerable<CarWorkshopDto>>(carWorkshops);
            return dtos;
        }
    }
}

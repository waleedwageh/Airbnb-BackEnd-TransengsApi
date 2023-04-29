using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.DTOS;
using Api.Helpers;
using AutoMapper;
using Domain.Entities;
using Domain.EntitiesSpecification.Statespec;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class StateController : ApiBaseController
    {
        private readonly ApplicationContext context;
        private readonly IMapper _mapper;
        public StateController(ApplicationContext context, IMapper mapper)
        {
            this.context = context;
            _mapper = mapper;
           
        }
        [HttpGet]
        public async Task<ActionResult<List<StateDTO>>> GetStates([FromQuery]StateSpecParams specParams)
        {
            var states = context.States.Where(x => string.IsNullOrEmpty(specParams.Country)
            || x.country.name == specParams.Country)
            .Take(6).ToList();
            
            var mapped = _mapper.Map<List<state>, List<StateDTO>>(states);
            return Ok(mapped);
        }

       
    }
}
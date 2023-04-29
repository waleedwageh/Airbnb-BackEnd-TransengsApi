using Api.DTOS;
using AutoMapper;
using Domain.Entities;
using Microsoft.Extensions.Configuration;



namespace Api.Helpers
{
    public class StateImageResolver : IValueResolver<state, StateDTO, string>
    {
        private readonly IConfiguration configuration;



        public StateImageResolver(IConfiguration configuration)
        {
            this.configuration = configuration;
        }



        public string Resolve(state source, StateDTO destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.PictureUrl))
            {
                return "https://localhost:44351/Images/StateImage/" + source.PictureUrl;
            }
            return null;
        }
    }
}

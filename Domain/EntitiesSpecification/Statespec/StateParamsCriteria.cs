using System;
using System.Linq.Expressions;
using Domain.Entities;

namespace Domain.EntitiesSpecification.Statespec
{
    public class StateParamsCriteria
    {
        private readonly StateSpecParams _params;
        public StateParamsCriteria(StateSpecParams Params)
        {
            _params = Params;
        }

        public  Expression<Func<state,bool>> GetCriteria(){
            Func<state,bool> criteria = x=>{
                return (string.IsNullOrEmpty(_params.Country)||x.country.name==_params.Country);
            };
            return x=> criteria(x); 



        }
    }
}
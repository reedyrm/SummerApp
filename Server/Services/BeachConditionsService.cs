using Grpc.Core;
using Microsoft.Extensions.Logging;
using Protos;
using System;
using System.Threading.Tasks;

namespace Server.Services
{
    public class BeachConditionsService : BeachConditions.BeachConditionsBase
    {
        private readonly ILogger<BeachConditionsService> _logger;
        public BeachConditionsService(ILogger<BeachConditionsService> logger)
        {
            _logger = logger;
        }

        public override Task<GetAllBeachConditionResponse> getAllBeachConditions(GetAllBeachConditionRequest request, ServerCallContext context)
        {
            GetAllBeachConditionResponse result = new GetAllBeachConditionResponse();
            result.BeachConditions.Add(new BeachCondition { BeachId = 1, Name = "North Point", Condition = "Sandy" });
            result.BeachConditions.Add(new BeachCondition { BeachId = 2, Name = "South Point", Condition = "Murky" });

            return Task.FromResult(result);
        }

        public override Task<CreateBeachConditionResponse> createBeachCondition(CreateBeachConditionRequest request, ServerCallContext context)
        {
            BeachCondition beachCondition = new BeachCondition
            {
                BeachId = new Random().Next(),
                Name = request.Name,
                Condition = request.Condition
            };

            CreateBeachConditionResponse response = new CreateBeachConditionResponse
            {
                CreatedBeachCondition = beachCondition
            };

            return Task.FromResult(response);
        }
    }
}

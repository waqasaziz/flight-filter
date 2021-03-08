using Domain;
using Domain.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Runner
{
    public class Startup : BackgroundService
    {
        private const int ExitOption = 0;
        private const string DefaultAppVersion = "v1.0";

        private readonly IHostApplicationLifetime _lifeTime;
        private readonly ILogger<Startup> _log;
        private readonly IFilterService _filterService;
        private readonly IFlightBuilder _flightBuilder;

        public Startup(
            IHostApplicationLifetime lifeTime,
            ILogger<Startup> log,
            IFilterService filterService,
            IFlightBuilder flightBuilder)
        {
            _lifeTime = lifeTime;
            _log = log;
            _filterService = filterService;
            _flightBuilder = flightBuilder;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var filters = new Filter[] {
                    new DepartsBeforeCurrentTimeFilter(),
                    new ArrivalDateBeforeDepartureDateFilter(),
                    new OverTwoHoursOnTheGroundFilter(),
                };

            var flights = _filterService.Filter(_flightBuilder.GetFlights(), filters);

            foreach (var item in flights)
                _log.LogInformation(item.Description);

            return Task.CompletedTask;

        }
    }
}

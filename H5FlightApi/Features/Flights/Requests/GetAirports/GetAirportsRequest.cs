using System.Globalization;
using CsvHelper;

namespace H5FlightApi.Features.Flights.Requests.GetAirports;

public record GetAirportsRequest(string DepartureCountry, string ArrivalCountry);

public class GetAirportsRequestHandler()
{
    public async Task<IResult> Handle(GetAirportsRequest request)
    {
        using var csv = CsvReader.FromFile("Data/airports_with_iata.csv");

        var airports = csv.GetRecords<AirportCsvRow>()
            .Where(r =>
                r.iso_country == request.DepartureCountry ||
                r.iso_country == request.ArrivalCountry
            )
            .Select(r => new Airport
            {
                Id = r.id,
                Name = r.name,
                IsoCountry = r.iso_country,
                Municipality = r.municipality,
                IataCode = r.iata_code,
                Type = r.type,
                HasScheduledService = r.scheduled_service == "yes"
            })
            .ToList();

        return (Results.Ok(airports));
    }
}

public sealed class Airport
{
    public long Id { get; set; }
    public string Ident { get; set; } = "";
    public string Type { get; set; } = "";
    public string Name { get; set; } = "";
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public int? ElevationFeet { get; set; }
    public string Continent { get; set; } = "";
    public string IsoCountry { get; set; } = "";
    public string IsoRegion { get; set; } = "";
    public string Municipality { get; set; } = "";
    public bool HasScheduledService { get; set; }
    public string IcaoCode { get; set; } = "";
    public string IataCode { get; set; } = "";
    public string GpsCode { get; set; } = "";
    public string LocalCode { get; set; } = "";
}

[CsvRecord]
public sealed partial class AirportCsvRow
{
    public long id { get; set; }
    public string ident { get; set; } = "";
    public string type { get; set; } = "";
    public string name { get; set; } = "";
    public double latitude_deg { get; set; }
    public double longitude_deg { get; set; }
    public int? elevation_ft { get; set; }
    public string continent { get; set; } = "";
    public string iso_country { get; set; } = "";
    public string iso_region { get; set; } = "";
    public string municipality { get; set; } = "";
    public string scheduled_service { get; set; } = "";
    public string icao_code { get; set; } = "";
    public string iata_code { get; set; } = "";
    public string gps_code { get; set; } = "";
    public string local_code { get; set; } = "";
}
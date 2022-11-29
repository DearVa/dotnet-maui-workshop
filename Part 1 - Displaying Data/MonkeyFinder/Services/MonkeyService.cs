using Microsoft.Maui.Devices.Sensors;
using System.Net.Http.Json;

namespace MonkeyFinder.Services;

public class MonkeyService {
	private readonly IConnectivity connectivity;
	private readonly IGeolocation geolocation;

	public MonkeyService(IConnectivity connectivity, IGeolocation geolocation) {
		this.connectivity = connectivity;
		this.geolocation = geolocation;
	}

	public async Task<List<Monkey>> GetMonkeys() {

	}

	public async Task<Monkey> FindClosest(IEnumerable<Monkey> monkeys) {
		if (connectivity.NetworkAccess != NetworkAccess.Internet) {
			return null;
		}

		var location = await geolocation.GetLastKnownLocationAsync() 
			?? await geolocation.GetLocationAsync(new GeolocationRequest {
			DesiredAccuracy = GeolocationAccuracy.Medium,
			Timeout = TimeSpan.FromSeconds(30)
		});

		if (location == null) {
			return null;
		}

		return monkeys.MinBy(m => location.CalculateDistance(new Location(m.Latitude, m.Longitude), DistanceUnits.Kilometers));
	}
}

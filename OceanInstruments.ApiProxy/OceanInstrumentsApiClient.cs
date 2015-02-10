using Auth0.Windows;
using OceanInstruments.ApiProxy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace OceanInstruments.ApiProxy
{
	public class OceanInstrumentsApiClient
	{
		#region Properties

		private Auth0User User { get; set; }

		public HttpClient HttpClient { get; private set; }
		public Auth0Configuration Auth0Config { get; private set; }

		public const string ModelUrl = "api/Models";
		public const string DeviceUrl = "api/Devices";
		public const string CalibrationUrl = "api/Calibrations";

		public string LoggedInUser {
			get
			{
				if (User != null && User.Profile["name"] != null)
					return User.Profile["name"].ToString();
				else
					return null;
			}
		}

		#endregion

		#region Constructor

		public OceanInstrumentsApiClient()
		{
			HttpClient = new HttpClient() { BaseAddress = new Uri("http://oceaninstruments.azurewebsites.net/") };
			Auth0Config = new Auth0Configuration
			{
				Domain = "oceaninstruments.auth0.com",
				ClientID = "3oxfyEqFp3WIEzpLXShhPqoGidyI5Kd5",
				Connection = "Username-Password-Authentication",
				Scope = "openid name given_name email role"
			};
		}

		#endregion

		#region Authentication

		public async Task Login()
		{
			//Ideally best to move this into a handler and check for 403 (unauth) responses so that if the JWT token has expired we can request it again.
			//However very unlikely to hit this situation at the mo as JWT timeout is huge (i.e. days or weeks)
			try
			{
				var auth0 = new Auth0Client(
					Auth0Config.Domain,
					Auth0Config.ClientID);

				User = await auth0.LoginAsync(
					Auth0Config.Connection,
					"john@oceanInstruments.co.nz",
					"Biggles12",
					Auth0Config.Scope).ConfigureAwait(false);

				HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", User.IdToken);
			}
			catch (Exception ex)
			{
				throw new Exception("Error logging in", ex);
			}
		}

		#endregion

		#region Devices

		public virtual async Task<List<Device>> GetDevicesSearchAsync(string serialNo)
		{
            var response = await HttpClient.GetAsync(DeviceUrl + "/search/" + serialNo).ConfigureAwait(false);
			response.EnsureSuccessStatusCode();
			return await response.Content.ReadAsAsync<List<Device>>().ConfigureAwait(false);
		}

		#endregion

		#region Calibrations

		public virtual async Task<List<Calibration>> GetCalibrationsForDeviceAsync(int deviceId)
		{
			var response = await HttpClient.GetAsync(CalibrationUrl + "/device/" + deviceId);
			response.EnsureSuccessStatusCode();
			return await response.Content.ReadAsAsync<List<Calibration>>();

		}

		#endregion

		#region Generic REST methods

		public async Task<List<T>> GetAsync<T>(string urlParameters = null)
		{
			var url = GetUrl(typeof(T)) + "?" + (urlParameters ?? "");
			var response = await HttpClient.GetAsync(url);
			response.EnsureSuccessStatusCode();
			return await response.Content.ReadAsAsync<List<T>>();
		}

		public async Task<T> GetSingleAsync<T>(object id, string urlParameters = null)
		{
			var url = GetUrl(typeof(T)) + "/" + id + "?" + (urlParameters ?? "");
			var response = await HttpClient.GetAsync(url);
			response.EnsureSuccessStatusCode();
			return await response.Content.ReadAsAsync<T>();
		}

		public virtual async Task<T> PutAsync<T>(object id, T model, string urlParameters = null)
		{
			var url = GetUrl(typeof(T)) + "/" + id + "?" + (urlParameters ?? "");
			var response = await HttpClient.PutAsJsonAsync<T>(url, model);
			response.EnsureSuccessStatusCode();
			return await response.Content.ReadAsAsync<T>();
		}

		public virtual async Task<T> PostAsync<T>(T model, string urlParameters = null)
		{
			var url = GetUrl(typeof(T)) + "?" + (urlParameters ?? "");
			var response = await HttpClient.PostAsJsonAsync<T>(url, model);
			response.EnsureSuccessStatusCode();
			return await response.Content.ReadAsAsync<T>();
		}


		public virtual async Task<T> DeleteAsync<T>(object id)
		{
			var url = GetUrl(typeof(T)) + "/" + id;
			var response = await HttpClient.DeleteAsync(url);
			response.EnsureSuccessStatusCode();
			return await response.Content.ReadAsAsync<T>();
		}

		#endregion

		#region Private Helpers

		private string GetUrl(System.Type type)
		{
			if (type == typeof(Model))
				return ModelUrl;
			else if (type == typeof(Device))
				return DeviceUrl;
			else if (type == typeof(Calibration))
				return CalibrationUrl;
			else
				throw new Exception("Type url not defined");
		}

		#endregion
	}
}

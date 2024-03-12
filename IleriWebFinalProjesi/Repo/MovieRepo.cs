using IleriWebFinalProjesi.Models;
using Newtonsoft.Json;

namespace IleriWebFinalProjesi.Repo
{
	public class MovieRepo
	{
		private readonly HttpClient _client;

		public MovieRepo()
		{
			_client = new HttpClient();
		}
		//Ana ayfa için random getirdik
		public async Task<List<Movie>> GetRandomMovies()
		{
				var moviesRequest = new HttpRequestMessage
				{
					Method = HttpMethod.Get,
					RequestUri = new Uri("https://imdb-top-100-movies.p.rapidapi.com/"),
					Headers =
						{
							{ "X-RapidAPI-Key", "874b392386msh5ad862ee7af15aap133e90jsn8988d778f8ba" },
							{ "X-RapidAPI-Host", "imdb-top-100-movies.p.rapidapi.com" },
						},
				};

				var seriesRequest = new HttpRequestMessage
				{
					Method = HttpMethod.Get,
					RequestUri = new Uri("https://imdb-top-100-movies.p.rapidapi.com/series"),
					Headers =
						{
							{ "X-RapidAPI-Key", "874b392386msh5ad862ee7af15aap133e90jsn8988d778f8ba" },
							{ "X-RapidAPI-Host", "imdb-top-100-movies.p.rapidapi.com" },
						},
				};

				using (var moviesResponse = await _client.SendAsync(moviesRequest))
				using (var seriesResponse = await _client.SendAsync(seriesRequest))
				{

					moviesResponse.EnsureSuccessStatusCode();
					seriesResponse.EnsureSuccessStatusCode();

					var moviesBody = await moviesResponse.Content.ReadAsStringAsync();
					var seriesBody = await seriesResponse.Content.ReadAsStringAsync();

					var movies = JsonConvert.DeserializeObject<List<Movie>>(moviesBody);
					var series = JsonConvert.DeserializeObject<List<Movie>>(seriesBody);
							foreach (var serie in series)
							{
								serie.MovieType =MovieType.series;
							}

							// Filmlerin MovieType'ını ayarla
							foreach (var movie in movies)
							{
								movie.MovieType = MovieType.movie;
							}
				var mediaItems = movies.Concat(series).ToList();

					var random = new Random();
				//	var randomMediaItems = mediaItems.OrderBy(x => random.Next()).Take(20).ToList();
					var randomMediaItems = mediaItems.OrderBy(x => random.Next()).ToList();

					return randomMediaItems; 
				}
		}
		public async Task<List<Movie>> SliderMovies()
		{
			var moviesRequest = new HttpRequestMessage
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri("https://imdb-top-100-movies.p.rapidapi.com/"),
				Headers =
						{
							{ "X-RapidAPI-Key", "874b392386msh5ad862ee7af15aap133e90jsn8988d778f8ba" },
							{ "X-RapidAPI-Host", "imdb-top-100-movies.p.rapidapi.com" },
						},
			};

			var seriesRequest = new HttpRequestMessage
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri("https://imdb-top-100-movies.p.rapidapi.com/series"),
				Headers =
						{
							{ "X-RapidAPI-Key", "874b392386msh5ad862ee7af15aap133e90jsn8988d778f8ba" },
							{ "X-RapidAPI-Host", "imdb-top-100-movies.p.rapidapi.com" },
						},
			};

			using (var moviesResponse = await _client.SendAsync(moviesRequest))
			using (var seriesResponse = await _client.SendAsync(seriesRequest))
			{

				moviesResponse.EnsureSuccessStatusCode();
				seriesResponse.EnsureSuccessStatusCode();

				var moviesBody = await moviesResponse.Content.ReadAsStringAsync();
				var seriesBody = await seriesResponse.Content.ReadAsStringAsync();

				var movies = JsonConvert.DeserializeObject<List<Movie>>(moviesBody);
				var series = JsonConvert.DeserializeObject<List<Movie>>(seriesBody);
				foreach (var serie in series)
				{
					serie.MovieType = MovieType.series;
				}

				// Filmlerin MovieType'ını ayarla
				foreach (var movie in movies)
				{
					movie.MovieType = MovieType.movie;
				}
				var mediaItems = movies.Concat(series).ToList();

				var random = new Random();
				var randomMediaItems = mediaItems.OrderBy(x => random.Next()).Take(5).ToList();
				//var randomMediaItems = mediaItems.OrderBy(x => random.Next()).ToList();

				return randomMediaItems;
			}
		}
		public  async Task<List<Movie>> RecommendedMovies()
		{
			var moviesRequest = new HttpRequestMessage
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri("https://imdb-top-100-movies.p.rapidapi.com/"),
				Headers =
						{
							{ "X-RapidAPI-Key", "874b392386msh5ad862ee7af15aap133e90jsn8988d778f8ba" },
							{ "X-RapidAPI-Host", "imdb-top-100-movies.p.rapidapi.com" },
						},
			};


			using (var moviesResponse = await _client.SendAsync(moviesRequest))
			{
				moviesResponse.EnsureSuccessStatusCode();
				var moviesBody = await moviesResponse.Content.ReadAsStringAsync();
				var movies = JsonConvert.DeserializeObject<List<Movie>>(moviesBody);
				// Filmlerin MovieType'ını ayarla
				foreach (var movie in movies)
				{
					movie.MovieType = MovieType.movie;
				}

				var random = new Random();
				//	var randomMediaItems = mediaItems.OrderBy(x => random.Next()).Take(20).ToList();
				var randomMediaItems = movies.OrderBy(x => random.Next()).Take(10).ToList();

				return randomMediaItems;
			}
		}
		public async Task<List<Movie>> RecommendedSeries()
		{
			var moviesRequest = new HttpRequestMessage
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri("https://imdb-top-100-movies.p.rapidapi.com/series"),
				Headers =
						{
							{ "X-RapidAPI-Key", "874b392386msh5ad862ee7af15aap133e90jsn8988d778f8ba" },
							{ "X-RapidAPI-Host", "imdb-top-100-movies.p.rapidapi.com" },
						},
			};


			using (var moviesResponse = await _client.SendAsync(moviesRequest))
			{
				moviesResponse.EnsureSuccessStatusCode();
				var moviesBody = await moviesResponse.Content.ReadAsStringAsync();
				var movies = JsonConvert.DeserializeObject<List<Movie>>(moviesBody);
				// Filmlerin MovieType'ını ayarla
				foreach (var movie in movies)
				{
					movie.MovieType = MovieType.series;
				}

				var random = new Random();
				//	var randomMediaItems = mediaItems.OrderBy(x => random.Next()).Take(20).ToList();
				var randomMediaItems = movies.OrderBy(x => random.Next()).Take(10).ToList();

				return randomMediaItems;
			}
		}
		#region FİLM API GET İŞLEMLERİ
		public async Task<List<Movie>> GetMovies(bool? ifRandom)
		{
			var request = new HttpRequestMessage
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri("https://imdb-top-100-movies.p.rapidapi.com/"),
				Headers =
				{
					{ "X-RapidAPI-Key", "874b392386msh5ad862ee7af15aap133e90jsn8988d778f8ba" },
					{ "X-RapidAPI-Host", "imdb-top-100-movies.p.rapidapi.com" },
				},
			};

			using (var response = await _client.SendAsync(request))
			{
				response.EnsureSuccessStatusCode();
				var body = await response.Content.ReadAsStringAsync();
				var result = JsonConvert.DeserializeObject<List<Movie>>(body);
				if (ifRandom==true)
				{
					var random = new Random();
					//	var randomMediaItems = mediaItems.OrderBy(x => random.Next()).Take(20).ToList();
					var randomMediaItems = result.OrderBy(x => random.Next()).ToList();
					return randomMediaItems;
				}

				
				
				return result;
			}
		}
		public async Task<Movie> GetMovieById(string id)
		{
			var request = new HttpRequestMessage
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri("https://imdb-top-100-movies.p.rapidapi.com/" + id),
				Headers =
					{
						{ "X-RapidAPI-Key", "874b392386msh5ad862ee7af15aap133e90jsn8988d778f8ba" },
					{ "X-RapidAPI-Host", "imdb-top-100-movies.p.rapidapi.com" },
					},
			};

			using (var response = await _client.SendAsync(request))
			{
				response.EnsureSuccessStatusCode();
				var body = await response.Content.ReadAsStringAsync();
				Console.WriteLine(body); // Gelen verileri konsola yazdır

				// JSON veriyi modelde işle
				var model = JsonConvert.DeserializeObject<Movie>(body);

				return model; // İşlenmiş verileri döndür
			}
		}

		#endregion

		#region Dizi API GET İŞLEMLERİ
		public async Task<List<Movie>> GetSeries(bool? ifRandom)
		{
			var request = new HttpRequestMessage
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri("https://imdb-top-100-movies.p.rapidapi.com/series"),
				Headers =
				{
					{ "X-RapidAPI-Key", "874b392386msh5ad862ee7af15aap133e90jsn8988d778f8ba" },
					{ "X-RapidAPI-Host", "imdb-top-100-movies.p.rapidapi.com" },
				},
			};

			using (var response = await _client.SendAsync(request))
			{
				response.EnsureSuccessStatusCode();
				var body = await response.Content.ReadAsStringAsync();

				var result = JsonConvert.DeserializeObject<List<Movie>>(body);
				if (ifRandom == true)
				{
					var random = new Random();
					//	var randomMediaItems = mediaItems.OrderBy(x => random.Next()).Take(20).ToList();
					var randomMediaItems = result.OrderBy(x => random.Next()).ToList();
					return randomMediaItems;
				}
				return result;
			}
		}
		public async Task<Movie> GetSeriesById(string id)
		{
			var request = new HttpRequestMessage
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri("https://imdb-top-100-movies.p.rapidapi.com/series/" + id),
				Headers =
		{
			{ "X-RapidAPI-Key", "874b392386msh5ad862ee7af15aap133e90jsn8988d778f8ba" },
			{ "X-RapidAPI-Host", "imdb-top-100-movies.p.rapidapi.com" },
		},
			};

			using (var response = await _client.SendAsync(request))
			{
				response.EnsureSuccessStatusCode();
				var body = await response.Content.ReadAsStringAsync();
				Console.WriteLine(body); // Gelen verileri konsola yazdır

				// JSON veriyi modelde işle
				var model = JsonConvert.DeserializeObject<Movie>(body);

				return model; // İşlenmiş verileri döndür
			}
		}


		#endregion
	}
}

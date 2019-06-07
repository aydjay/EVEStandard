using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using EVEStandard.API;
using EVEStandard.Enumerations;
using EVEStandard.Interfaces;
using EVEStandard.Models.API;
using Microsoft.Extensions.Logging;

namespace EVEStandard
{
    public class EVEStandardAPI
    {
        
        private static HttpClient http;
        private string userAgent;
        private readonly string dataSource;

        /// <summary>
        /// Initialize the EVEStandard Library
        /// </summary>
        /// <param name="userAgent"></param>
        /// <param name="dataSource"></param>
        /// <param name="timeOut"></param>
        public EVEStandardAPI(string userAgent, DataSource dataSource, TimeSpan timeOut)
        {
            http = new HttpClient();
            http.DefaultRequestHeaders.Add("User-Agent", HttpUtility.UrlEncode(userAgent));
            http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            http.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("gzip"));
            http.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("deflate"));
            http.Timeout = timeOut;

            this.userAgent = userAgent ?? "EVEStandard-default";
            this.dataSource = dataSource == DataSource.Tranquility ? "tranquility" : "singularity";

            initializeAPI();
        }

        public void AddLogging(ILoggerFactory factory)
        {
            LibraryLogging.LoggerFactory = factory;
            initializeAPI();
        }

        /// <inheritdoc />
        /// <summary>
        /// Initialize the EVE Standard Library with Single Sign On support.
        /// </summary>
        /// <param name="userAgent"></param>
        /// <param name="dataSource"></param>
        /// <param name="timeOut"></param>
        /// <param name="callbackUri"></param>
        /// <param name="clientId"></param>
        /// <param name="secretKey"></param>
        public EVEStandardAPI(string userAgent, DataSource dataSource, TimeSpan timeOut, string callbackUri, string clientId, string secretKey) : this(userAgent, dataSource, timeOut)
        {
            SSO.HTTP = http;
            SSO = new SSO(callbackUri, clientId, secretKey, dataSource);
        }

        /// <summary>
        /// Test a route that is still in development.
        /// </summary>
        /// <param name="httpMethod"></param>
        /// <param name="dataSource"></param>
        /// <param name="route">The entire VERSIONED route you want to test, including query parameters like datasource and user agent. (Example: /v3/alliances/{alliance_id}/?datasource=tranquility&user_agent=EVEStandard)</param>
        /// <param name="queryParameters"></param>
        /// <returns></returns>
        public async Task<string> TestDevRoute(string httpMethod, string dataSource, string route, Dictionary<string, string> queryParameters, object body, string ifNoneMatch = null)
        {
            if (string.IsNullOrWhiteSpace(dataSource))
            {
                throw new ArgumentException("Argument was invalid", nameof(dataSource));
            }

            return await TestDevRoute(httpMethod, dataSource, route, queryParameters, null, body, ifNoneMatch);
        }

        /// <summary>
        /// Test a route that is still in development and requires authentication via SSO
        /// </summary>
        /// <param name="dataSource"></param>
        /// <param name="route">The entire VERSIONED route you want to test, including query parameters like datasource and useragent. (Example: /v3/alliances/{alliance_id}/?datasource=tranquility&user_agent=EVEStandard)</param>
        /// <param name="httpMethod"></param>
        /// <param name="queryParameters"></param>
        /// <param name="auth"></param>
        /// <returns></returns>
        public async Task<string> TestDevRoute(string httpMethod, string dataSource, string route, Dictionary<string, string> queryParameters, AuthDTO auth, object body, string ifNoneMatch = null)
        {
            if (string.IsNullOrEmpty(dataSource))
            {
                throw new ArgumentException("Argument was invalid", nameof(dataSource));
            }

            var api = new APIBase(dataSource);

            APIResponse responseModel;

            switch (httpMethod.ToUpper())
            {
                case "GET":
                    responseModel = await api.GetAsync(route, auth, ifNoneMatch, queryParameters);
                    break;
                case "POST":
                    responseModel = await api.PostAsync(route, auth, body, ifNoneMatch, queryParameters);
                    break;
                case "PUT":
                    responseModel = await api.PutAsync(route, auth, body, queryParameters);
                    break;
                case "DELETE":
                    responseModel = await api.DeleteAsync(route, auth, queryParameters);
                    break;
                default:
                    throw new ArgumentException("Argument was invalid", nameof(httpMethod));
            }

            if (responseModel.Error)
            {
                throw new EVEStandardException("TestDevRoute failed");
            }

            return responseModel.JSONString;
        }

        /// <summary>
        /// Perform SSO Authentication operations
        /// </summary>
        public SSO SSO { get; }

        public IAlliance Alliance { get; private set; }
        public IAssets Assets { get; private set; }
        public IBookmarks Bookmarks { get; private set; }
        public ICalendar Calendar { get; private set; }
        public ICharacter Character { get; private set; }
        public IClones Clones { get; private set; }
        public IContacts Contacts { get; private set; }
        public IContracts Contracts { get; private set; }
        public ICorporation Corporation { get; private set; }
        public IDogma Dogma { get; private set; }
        public IFactionWarfare FactionWarfare { get; private set; }
        public IFittings Fittings { get; private set; }
        public IFleets Fleets { get; private set; }
        public IIncursions Incursion { get; private set; }
        public IIndustry Industry { get; private set; }
        public IInsurance Insurance { get; private set; }
        public IKillmails Killmails { get; private set; }
        public ILocation Location { get; private set; }
        public ILoyalty Loyalty { get; private set; }
        public IMail Mail { get; private set; }
        public IMarket Market { get; private set; }
        public IOpportunities Opportunities { get; private set; }
        public IPlanetaryInteraction PlanetaryInteraction { get; private set; }
        public IRoutes Routes { get; private set; }
        public ISearch Search { get; private set; }
        public ISkills Skills { get; private set; }
        public ISovereignty Sovereignty { get; private set; }
        public IStatus Status { get; private set; }
        public IUniverse Universe { get; private set; }
        public IUserInterface UserInterface { get; private set; }
        public IWallet Wallet { get; private set; }
        public IWars Wars { get; private set; }

        // ReSharper disable once InconsistentNaming
        private void initializeAPI()
        {
            Alliance = new Alliance(dataSource)
            {
                HTTP = http
            };
            Assets = new Assets(dataSource)
            {
                HTTP = http
            };
            Bookmarks = new Bookmarks(dataSource)
            {
                HTTP = http
            };
            Calendar = new Calendar(dataSource)
            {
                HTTP = http
            };
            Character = new Character(dataSource)
            {
                HTTP = http
            };
            Clones = new Clones(dataSource)
            {
                HTTP = http
            };
            Contacts = new Contacts(dataSource)
            {
                HTTP = http
            };
            Contracts = new Contracts(dataSource)
            {
                HTTP = http
            };
            Corporation = new Corporation(dataSource)
            {
                HTTP = http
            };
            Dogma = new Dogma(dataSource)
            {
                HTTP = http
            };
            FactionWarfare = new FactionWarfare(dataSource)
            {
                HTTP = http
            };
            Fittings = new Fittings(dataSource)
            {
                HTTP = http
            };
            Fleets = new Fleets(dataSource)
            {
                HTTP = http
            };
            Incursion = new Incursions(dataSource)
            {
                HTTP = http
            };
            Industry = new Industry(dataSource)
            {
                HTTP = http
            };
            Insurance = new Insurance(dataSource)
            {
                HTTP = http
            };
            Killmails = new Killmails(dataSource)
            {
                HTTP = http
            };
            Location = new Location(dataSource)
            {
                HTTP = http
            };
            Loyalty = new Loyalty(dataSource)
            {
                HTTP = http
            };
            Mail = new Mail(dataSource)
            {
                HTTP = http
            };
            Market = new Market(dataSource)
            {
                HTTP = http
            };
            Opportunities = new Opportunities(dataSource)
            {
                HTTP = http
            };
            PlanetaryInteraction = new PlanetaryInteraction(dataSource)
            {
                HTTP = http
            };
            Routes = new Routes(dataSource)
            {
                HTTP = http
            };
            Search = new Search(dataSource)
            {
                HTTP = http
            };
            Skills = new Skills(dataSource)
            {
                HTTP = http
            };
            Sovereignty = new Sovereignty(dataSource)
            {
                HTTP = http
            };
            Status = new Status(dataSource)
            {
                HTTP = http
            };
            Universe = new Universe(dataSource)
            {
                HTTP = http
            };
            UserInterface = new UserInterface(dataSource)
            {
                HTTP = http
            };
            Wallet = new Wallet(dataSource)
            {
                HTTP = http
            };
            Wars = new Wars(dataSource)
            {
                HTTP = http
            };
        }
    }
}

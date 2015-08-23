using System;
using System.Web;

namespace PDTS.Data_Access_Layer
{
    public class SqlAccess
    {
        private static readonly publicTransportDataEntities Ptde =new publicTransportDataEntities();
        public static Repository<agency, publicTransportDataEntities> AgencyRepository = new Repository<agency, publicTransportDataEntities>(Ptde);
        public static Repository<calendar, publicTransportDataEntities> CalendaRepository = new Repository<calendar, publicTransportDataEntities>(Ptde);
        public static Repository<routesInfo, publicTransportDataEntities> RoutesRepository = new Repository<routesInfo, publicTransportDataEntities>(Ptde);
        public static Repository<shape, publicTransportDataEntities> ShapesRepository = new Repository<shape, publicTransportDataEntities>(Ptde);
        public static Repository<stop, publicTransportDataEntities> StopsRepository = new Repository<stop, publicTransportDataEntities>(Ptde);
        public static Repository<stop_times, publicTransportDataEntities> StoptimesRepository = new Repository<stop_times, publicTransportDataEntities>(Ptde);
        public static Repository<translation, publicTransportDataEntities> TranslationsRepository = new Repository<translation, publicTransportDataEntities>(Ptde);
        public static Repository<trip, publicTransportDataEntities> TripsRepository = new Repository<trip, publicTransportDataEntities>(Ptde);


        public static int CreateAgency(int agencyId, string agencyUrl, string agencyTimezone, string agencyLang)
        {
            if (agencyTimezone == null) throw new ArgumentNullException("agencyTimezone");
            if (agencyLang == null) throw new ArgumentNullException("agencyLang");
            try
            {
                var agencyVar = new agency { agency_id = agencyId, agency_url = agencyUrl, agency_timezone = agencyLang };
                var newAgency = AgencyRepository.Create(agencyVar);
                AgencyRepository.SaveChanges();
                return newAgency.agency_id;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public static int RemoveAgency(int agencyId)
        {
            try
            {
                AgencyRepository.Delete(agencyId);
                return agencyId;
            }
            catch
            {
                return -1;
            }
        }

        public static string CreateTrip(int routeId, int serviceId, string tripId, int directionId, int shapeId)
        {
            try
            {
                var tripsVar = new trip
                {
                    route_id = routeId,
                    service_id = serviceId,
                    trip_id = tripId,
                    direction_id = directionId,
                    shape_id = shapeId
                };
                var newTrip = TripsRepository.Create(tripsVar);
                TripsRepository.SaveChanges();
                return newTrip.trip_id;
            }
            catch (Exception)
            {
                return "-1";
            }
        }
        public static int CreateTranlsation(int transId, bool lang, string translation1)
        {
            try
            {
                var translationVar = new translation
                {
                    trans_id = transId, lang = lang, translation1 = translation1};
                var newTranslation = TranslationsRepository.Create(translationVar);
                TripsRepository.SaveChanges();
                return newTranslation.trans_id;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public static string CreateStopTime(string tripId, TimeSpan arrivalTime, TimeSpan departuretime, int stopId,
            int stopSequnce, int pickupType, int dropOffType)
        {
            try
            {
                var stopTimeVar = new stop_times
                {
                    trip_id = tripId,
                    arrival_time = arrivalTime,
                    departure_time = departuretime,
                    stop_id = stopId,
                    stop_sequence = stopSequnce,
                    pickup_type = pickupType,
                    drop_off_type = dropOffType
                };
                var newstopTime = StoptimesRepository.Create(stopTimeVar);
                StoptimesRepository.SaveChanges();
                return newstopTime.trip_id + newstopTime.arrival_time;
            }
            catch (Exception)
            {
                return "-1";

            }
        }

        public static int CreateStop(int stopId, int stopCode, string stopName, string stopDesc)
        {
            try
            {
                var stopVar = new stop
                {
                    stop_id = stopId, stop_code = stopCode, stop_name = stopName, stop_desc = stopDesc
                    };
                var newStop = StopsRepository.Create(stopVar);
                StopsRepository.SaveChanges();
                return newStop.stop_id;
            }
            catch (Exception)
            {
                return -1;

            }
        }

        public static int CreateShape(int shapeId, double shapePtLat, double shapePtLon, int shapePtSequence)
        {
            try
            {
                var shapeVar = new shape
                {
                    shape_id = shapeId, shape_pt_lat = shapePtLat, shape_pt_lon = shapePtLon, shape_pt_sequence = shapePtSequence
                };
                var newShape = ShapesRepository.Create(shapeVar);
                ShapesRepository.SaveChanges();
                return newShape.shape_id;
            }
            catch (Exception)
            {
                return -1;

            }
        }

        public static int CreateRoute(int routeId, int agencyId, string routeShortName, string routeLongeName, 
            string routeDesc, int routeType, int routeColor)
        {
            try
            {
                var routeVar = new routesInfo
                {
                    route_id = routeId,
                    agency_id = agencyId,
                    route_color = routeColor,
                    route_desc = routeDesc,
                    route_long_name = routeLongeName,
                    route_short_name = routeShortName,
                    route_type = routeType
                };
                var newRoute = RoutesRepository.Create(routeVar);
                RoutesRepository.SaveChanges();
                return newRoute.route_id;
            }
            catch (Exception)
            {
                return -1;

            }
        }

        public static int CrateCalendar(int serviceId, bool sunday, bool monday, bool tuesday, bool wednesday,
            bool thursday, bool friday, bool saturday, DateTime startingDate, DateTime endDate)
        {
            try
            {
                var calendarVar = new calendar
                {
                    service_id = serviceId,
                    sunday = sunday,
                    monday = monday,
                    tuesday = tuesday,
                    wednesday = wednesday,
                    thrusday =  thursday,
                    friday = friday,
                    saturday = saturday,
                    starting_date = startingDate,
                    end_date = endDate
                };
                var newcalendar = CalendaRepository.Create(calendarVar);
                CalendaRepository.SaveChanges();
                return newcalendar.service_id;
            }
            catch (Exception)
            {
                return -1;

            }
        }

    }
}
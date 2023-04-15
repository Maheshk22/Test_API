using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_API.Data.Model
{
    public class Leads_API
    {
        public class CustomData
        {
            public string type { get; set; }
            public int unitCount { get; set; }
            public int Mahesh { get; set; }
         

        }

        public class Datum
        {
            public string uuid { get; set; }
            public string type { get; set; }
            public string status { get; set; }
            public string expiresAt { get; set; }
            public bool instantRental { get; set; }
            public string createdAt { get; set; }
            public string updatedAt { get; set; }
            public Needs needs { get; set; }
            public List<Record> records { get; set; }
            public Store store { get; set; }
            public List<State> states { get; set; }
            public object conversation { get; set; }
        }

        public class Link
        {
            public string url { get; set; }
            public string label { get; set; }
            public bool active { get; set; }
            public string first { get; set; }
            public string last { get; set; }
            public object prev { get; set; }
            public string next { get; set; }
        }

        public class Meta
        {
            public int current_page { get; set; }
            public int from { get; set; }
            public int last_page { get; set; }
            public List<Link> links { get; set; }
            public string path { get; set; } = null;
            public int per_page { get; set; }
            public int to { get; set; }
            public int total { get; set; }
        }

        public class Needs
        {
            public string duration { get; set; }
            public string moveInDate { get; set; }
            public string typesOfItems { get; set; }
            public string reasonForStorage { get; set; }
        }

        public class Record
        {
            public string type { get; set; }
            public int quoteId { get; set; }
            public Reservation reservation { get; set; }
        }

        public class Reservation
        {
            public string TAX { get; set; }
            public int? DOOR { get; set; }
            public string ICON { get; set; }
            public string DEPTH { get; set; }
            public string PRICE { get; set; }
            public string WIDTH { get; set; }
            public int STATUS { get; set; }
            public int ACCT_ID { get; set; }
            public int CHANNEL { get; set; }
            public int CLIMATE { get; set; }
            public DateTime CREATED { get; set; }
            public string DEPOSIT { get; set; }
            public int SITE_ID { get; set; }
            public int SQ_FEET { get; set; }
            public string TOT_AMT { get; set; }
            public int UNIT_ID { get; set; }
            public object DISC_AMT { get; set; }
            public string DOOR_VAL { get; set; }
            public int FEATURES { get; set; }
            public object MKT_CODE { get; set; }
            public int QUOTE_ID { get; set; }
            public bool RENT_NOW { get; set; }
            public string ACCT_NAME { get; set; }
            public string ADMIN_FEE { get; set; }
            public string PUSH_RATE { get; set; }
            public int? RENTAL_ID { get; set; }
            public string CLASS_TYPE { get; set; }
            public int CREATED_BY { get; set; }
            public DateTime EXPIRATION { get; set; }
            public object MKT_SOURCE { get; set; }
            public int OBJ_PERIOD { get; set; }
            public int QUOTE_TYPE { get; set; }
            public int UPDATED_BY { get; set; }
            public int? ACCESS_TYPE { get; set; }
            public int ATTRIBUTE01 { get; set; }
            public int ATTRIBUTE02 { get; set; }
            public string CLIMATE_VAL { get; set; }
            public int? GATE_KEYPAD { get; set; }
            public string PRORATE_AMT { get; set; }
            public string RES_DEPOSIT { get; set; }
            public string STREET_RATE { get; set; }
            public string UNIT_NUMBER { get; set; }
            public string FEATURES_VAL { get; set; }
            public object RES_GROUP_ID { get; set; }
            public int SITE_CLASS_ID { get; set; }
            public int INQUIRY_SOURCE { get; set; }
            public int OBJ_PERIOD_UOM { get; set; }
            public TRANQUOTEPCD TRAN_QUOTE_PCD { get; set; }
            public string ACCESS_TYPE_VAL { get; set; }
            public string ATTRIBUTE01_VAL { get; set; }
            public string ATTRIBUTE02_VAL { get; set; }
            public string CREATED_BY_NAME { get; set; }
            public string START_RENT_RATE { get; set; }
            public DateTime QUOTE_START_DATE { get; set; }
            public int LOST_DEMAND_REASON { get; set; }
            public string OBJ_PERIOD_UOM_VAL { get; set; }
            public TRANQUOTEPCDDETAIL TRAN_QUOTE_PCD_DETAIL { get; set; }
            public TRANQUOTENOTESDETAIL TRAN_QUOTE_NOTES_DETAIL { get; set; }
        }

        public class Root
        {
            public List<Datum> data { get; set; }
            public Link links { get; set; }
            public Meta meta { get; set; }
        }

        public class State
        {
            public string state { get; set; }
            public CustomData customData { get; set; }
            public DateTime createdAt { get; set; }
            public User user { get; set; }
        }

        public class Store
        {
            public string name { get; set; }
            public string identifier { get; set; }
        }

        public class TRANQUOTENOTESDETAIL
        {
        }

        public class TRANQUOTEPCD
        {
        }

        public class TRANQUOTEPCDDETAIL
        {
        }

        public class User
        {
            public int id { get; set; }
            public string firstName { get; set; }
            public string lastName { get; set; }
            public string name { get; set; }
            public string jobTitle { get; set; }
            public string employmentDate { get; set; }
            public string email { get; set; }
            public bool demoAccount { get; set; }
            public string profilePictureUrl { get; set; }
            public object deletedAt { get; set; }
        }
    }
}

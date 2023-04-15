using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;

using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;
using static Test_API.Program;
using static System.Net.Mime.MediaTypeNames;
using System.Json;
using Test_API.Data;
using Microsoft.TeamFoundation;
using System.Runtime.Remoting.Lifetime;
using static Test_API.Data.Model.Leads_API;

namespace Test_API
{
    public class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Root obj = new Root();

                //Your Code Here for view
                Console.WriteLine("Schedular run at:"+DateTime.Now);

                // call api from server
                string satrtdate = "2022-09-01 00:00:00";
                string enddate = "2022-09-10 00:00:00";

                Root getapidata = GetDataFromAPI(satrtdate, enddate);
                bool issavestatus = saveAPIData(getapidata);
                if (issavestatus)
                    Console.WriteLine("data save successfully");
                else
                    Console.WriteLine("Something went wrong");

                int milliseconds = 300000;  //300000 milliseconds = 5 minutes
                Thread.Sleep(milliseconds);
            }
        }

        private static Root GetDataFromAPI(string startdate, string enddate)
        {
            var parameters = new Dictionary<string, string>() {
                            { "start", startdate },
                            { "end", enddate }
                            };

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //client.DefaultRequestHeaders.Add("APIKEYPARAM", "9|i7n9vPfpWjpiH5KUP95gBVNhXuzWdyc2IuPphYKK");
                client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", "9|i7n9vPfpWjpiH5KUP95gBVNhXuzWdyc2IuPphYKK");
                var baseUrl = "https://api.csrscape.com/api/yardi/leads";
                var url = baseUrl + "?" + string.Join("&", parameters.Select(x => string.Format("{0}={1}", x.Key, x.Value)));
                var task = client.GetAsync(url);
                task.Wait();

                if (!task.Result.IsSuccessStatusCode)
                {
                    throw new Exception(task.Result.StatusCode.ToString());
                }

                var readTask = task.Result.Content.ReadAsStringAsync();
                var settings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    MissingMemberHandling = MissingMemberHandling.Ignore
                };
                Root jsonModel = JsonConvert.DeserializeObject<Root>(readTask.Result, settings);
                readTask.Wait();
                return jsonModel;
            }
        }

        private static bool saveAPIData(Root getapidata)
        {
            try
            {
                Console_ApiEntities db = new Console_ApiEntities();
                foreach (var item in getapidata.data)
                {
                    // insert record in leads table
                    Lead lead = new Lead();
                    lead.Uuid = Guid.Parse(item.uuid);
                    lead.Type = item.type;
                    lead.Status = item.status;
                    lead.ExpiresAt = item.expiresAt;
                    lead.InstantRental = Convert.ToBoolean(item.instantRental);
                    lead.CreatedAt = item.createdAt;
                    lead.UpdatedAt = item.updatedAt;
                    db.Leads.Add(lead);
                    db.SaveChanges();
                    // insert record in needs table
                    Need needs = new Need();
                    needs.NeedId = Guid.NewGuid();
                    needs.Duration = item.needs.duration;
                    needs.MoveInDate = item.needs.moveInDate;
                    needs.TypesOfItems = item.needs.typesOfItems;
                    needs.ReasonForStorage = item.needs.reasonForStorage;
                    db.Needs.Add(needs);
                    db.SaveChanges();
                }
                //
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
      



    }
}

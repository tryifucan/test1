using ExtentReportsTest;
using Framework;
using NUnit.Framework;
using RestSharp;
using System.Collections.Generic;
using System.Net;

namespace Tests
{
    public class APITests : Reporter
    {
        string APIClient = "http://10.129.41.181:8087/api/";
     
        [Test]
        public void GetCustodianAPI()
        {
            var client = new RestClient(APIClient);
            var request = new RestRequest("Custodian", Method.GET);
            IRestResponse<List<Custodian>> response = client.Execute<List<Custodian>>(request);
            List<Custodian> custodians = response.Data;
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        }

        [Test]
        public void PostCustodianAPI()
        {
            var client = new RestClient(APIClient);
            var request = new RestRequest("Custodian", Method.POST);
            IRestResponse<List<Custodian>> response = client.Execute<List<Custodian>>(request);
            List<Custodian> custodians = response.Data;
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        }

        [Test]
        public void GetCustodianStatusesAPI()
        {
            var client = new RestClient(APIClient + "Custodian");
            var request = new RestRequest("Statuses", Method.GET);
            IRestResponse<List<Statuses>> response = client.Execute<List<Statuses>>(request);
            var status = response.StatusDescription;
            List<Statuses> custodians = response.Data;
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        }

        [Test]
        public void GetCustodianEmploymentTypesAPI()
        {
            var client = new RestClient(APIClient + "Custodian");
            var request = new RestRequest("EmploymentTypes", Method.GET);
            IRestResponse<List<EmploymentTypes>> response = client.Execute<List<EmploymentTypes>>(request);
            List<EmploymentTypes> custodians = response.Data;
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        }

        [Test]
        public void GetCustodianTypesAPI()
        {
            var client = new RestClient(APIClient + "Custodian");
            var request = new RestRequest("Types", Method.GET);
            IRestResponse<List<CustodianTypes>> response = client.Execute<List<CustodianTypes>>(request);
            List<CustodianTypes> custodians = response.Data;
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        }

        [Test]
        public void GetLocationStatesAPI()
        {
            var client = new RestClient(APIClient + "Location/");
            var request = new RestRequest("States", Method.GET);
            IRestResponse<List<LocationStates>> response = client.Execute<List<LocationStates>>(request);
            List<LocationStates> custodians = response.Data;
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        }
    }

    internal class LocationStates
    {
    }

    internal class CustodianTypes
    {
    }

    internal class EmploymentTypes
    {
    }

    internal class Statuses
    {
    }

    internal class Custodian
    {
    }
}
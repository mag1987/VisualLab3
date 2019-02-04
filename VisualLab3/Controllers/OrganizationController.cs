using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VisualLab3.Models;

namespace VisualLab3.Controllers
{
    public class OrganizationController : ApiController
    {
        static List<Organization> organizations = new List<Organization>
        {
            new Organization { Name = "Иванов и сыновья", Inn = 123456798, Phone = 1112223 },
            new Organization { Name = "Молодые ветра", Inn = 45454545, Phone = 2221113 },
            new Organization { Name = "Красные тюльпаны", Inn = 555555555, Phone = 4444447 },

        };
        [HttpGet]
        public IEnumerable<Organization> GetAllOrganizations()
        {
            return organizations;
        }
        [HttpGet]
        public IEnumerable<Organization> GetOrganizations(string Name)
        {
            var organization = from org in organizations
                               where org.Name == Name
                               select org;                  
            return organization;
        }
        [HttpGet]
        public void AddOrganization(string name, ulong inn, ulong phone)
        {
            organizations.Add(new Organization
            { Name = name, Inn= inn, Phone= phone } );
        }
        [HttpGet]
        public void ChangeOrganization(string name, ulong inn, ulong phone)
        {
            var organization = from org in organizations
                               where org.Name == name
                               select org;
            if (organization.Count() == 1)
            {
                organization.First().Inn = inn;
                organization.First().Phone = phone;
            }
        }
        [HttpGet]
        public void DeleteOrganization(string name, ulong inn, ulong phone)
        {
            var organization = from org in organizations
                               where org.Name == name
                               select org;
            if (organization.Count() == 1)
            {
                organizations.Remove(organization.First());
            }
        }
    }
}
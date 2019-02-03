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
        Organization[] organizations = new Organization[]
        {
            new Organization { Name = "Иванов и сыновья", Inn = 123456798, Phone = 1112223 },
            new Organization { Name = "Молодые ветра", Inn = 45454545, Phone = 2221113 },
            new Organization { Name = "Красные тюльпаны", Inn = 555555555, Phone = 4444447 },
        };

        public IEnumerable<Organization> GetAllOrganizations()
        {
            return organizations;
        }

        public IEnumerable<Organization> GetOrganizations1(ulong Name)
        {
            var organization = from org in organizations
                               where org.Phone == Name
                               select org;
                           
            return organization;
        }

        public IHttpActionResult GetOrganizations(string Name)
        {
            var organization = organizations[0];
                /*
                from org in organizations
                               where org.Name == Name
                               select org;
                               */
            if (organization == null)
            {
                return NotFound();
            }
            return Ok(organization);
        }
        //public IHttpActionResult AddOrganization()
        //{ }
    }
}
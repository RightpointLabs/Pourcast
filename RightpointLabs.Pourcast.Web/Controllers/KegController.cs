﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using RighpointLabs.Pourcast.Orchestrator.Abstract;
using RighpointLabs.Pourcast.Orchestrator.Models;
using RightpointLabs.Pourcast.Repository.Abstract;

namespace RightpointLabs.Pourcast.Web.Controllers
{
    [System.Web.Http.RoutePrefix("api/keg")]
    public class KegController : ApiController
    {


        private readonly IKegOrchestrator _kegOrchestrator;
        
        public KegController(IKegOrchestrator kegOrchestrator)
        {
            _kegOrchestrator = kegOrchestrator;
        }

        // GET api/<controller>

        public IEnumerable<Keg> Get()
        {
            return _kegOrchestrator.GetAll();
        }

        // GET api/<controller>/5
        public IEnumerable<Keg> Get(bool ontap)
        {
            return ontap ? _kegOrchestrator.GetOnTap() : _kegOrchestrator.GetAll();
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}
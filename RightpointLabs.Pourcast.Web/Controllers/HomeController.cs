﻿using System.Web.Mvc;

namespace RightpointLabs.Pourcast.Web.Controllers
{
    using RightpointLabs.Pourcast.Application.Orchestrators.Abstract;

    public class HomeController : Controller
    {
        private readonly ITapOrchestrator _tapOrchestrator;

        private readonly IIdentityOrchestrator _identityOrchestrator;

        public HomeController(ITapOrchestrator tapOrchestrator, IIdentityOrchestrator identityOrchestrator)
        {
            _tapOrchestrator = tapOrchestrator;
            _identityOrchestrator = identityOrchestrator;
        }

        //
        // GET: /Home/
        public ActionResult Index()
        {
            // Replace this with a Mock so it doesn't blow up the app
            //_tapOrchestrator.PourBeerFromTap("534a14b1aed2bf2a00045509", .01);

#if DEBUG
            // TODO : remove this so users aren't added to admin automatically!
            var roleName = "Administrators";
            var username = Request.LogonUserIdentity.Name;

            if (!_identityOrchestrator.UserExists(username))
            {
                _identityOrchestrator.CreateUser(username);
            }

            if (!_identityOrchestrator.RoleExists(roleName))
            {
                _identityOrchestrator.CreateRole(roleName);
            }

            if (!_identityOrchestrator.IsUserInRole(username, roleName))
            {
                _identityOrchestrator.AddUserToRole(username, roleName);
            }
#endif

            return View();
        }
    }
}
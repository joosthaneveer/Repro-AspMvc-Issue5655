using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication3.ViewModels;

namespace BDO.CMS.Portal.Controllers
{
    public class AssignmentsController : Controller
    {
        public AssignmentsController()
        {
        }

        public async Task<IActionResult> Create()
        {
            var viewModel = EmptyAssignmentViewModel();

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AssignmentViewModel viewModel)
        {
            if (ModelState.IsValid)
                return await SaveToRepositoryAync(viewModel);

            viewModel.Title = viewModel.Title = "Plan Assignments > Plan New";
            return View(viewModel);
        }

        public IActionResult Error()
        {
            return BadRequest();
        }

        private AssignmentViewModel Transform(Assignment assignment)
        {
            var model = new AssignmentViewModel
            {
                Address = assignment.LocationAddress,
                BasicInstruction = assignment.BasicInstructions,
                ClientName = assignment.ClientName,
                CountDate = assignment.CountDate,
                ExpectedNumberOfItems = assignment.ExpectedNumberOfItems,
                FinalDeliverableListing = assignment.FinalDeliverable
            };

            foreach (var person in assignment.ClientContacts)
                model.ContactPersons.Add(Transform(person));

            return model;
        }

        private ContactPersonViewModel Transform(ClientContact clientContact)
        {
            return new ContactPersonViewModel
            {
                Name = clientContact.Name,
                PhoneNumber = clientContact.PhoneNumber,
            };
        }

        private async Task<IActionResult> SaveToRepositoryAync(AssignmentViewModel viewModel)
        {
            return RedirectToAction("Planned", "Assignments");
        }

        private AssignmentViewModel EmptyAssignmentViewModel()
        {
            var viewModel = new AssignmentViewModel
            {
                CountDate = DateTime.UtcNow.AddDays(1)
            };

            viewModel.Title = "Plan Assignments > Plan New";

            viewModel.ContactPersons.Add(EmptyContactPerson());
            return viewModel;
        }

        private ContactPersonViewModel EmptyContactPerson()
        {
            return new ContactPersonViewModel { Name = string.Empty, PhoneNumber = string.Empty };
        }
    }
}
